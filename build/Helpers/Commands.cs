namespace Helpers;

public static class Commands
{
    public static Tool BrowserTool => GetTool(
        Platform switch
        {
            PlatformFamily.Windows => "explorer",
            PlatformFamily.OSX => "open",
            _ => new[] { "google-chrome", "firefox" }
                .FirstOrDefault(CommandExists),
        });

    public static void OpenBrowser(AbsolutePath path)
    {
        Assert.FileExists(path);
        try
        {
            BrowserTool($"{path.ToString().DoubleQuoteIfNeeded()}");
        }
        catch (Exception e)
        {
            if (!IsWin) // Windows explorer always return 1
                Log.Error(e, "Unable to open report");
        }
    }

    public static IProcess RunWiremock(AbsolutePath dir) =>
        ProcessTasks.StartProcess("dotnet",
            "dotnet-wiremock --Port 9090 --ReadStaticMappings true", dir);

    public static IReadOnlyCollection<Output> Playwright(params string[] args) =>
        DotNet($"dotnet playwright {string.Join(" ", args)}", NukeBuild.RootDirectory);

    public static Tool GetTool(string name) =>
        ToolResolver.TryGetEnvironmentTool(name) ??
        ToolResolver.GetPathTool(name);

    public static IProcess RunCommand(string command, params string[] args) =>
        ProcessTasks.StartProcess(command,
            string.Join(" ", args.Select(a => a.DoubleQuoteIfNeeded())),
            NukeBuild.RootDirectory);

    public static async Task RunCommandUntil(
        string command,
        IEnumerable<string> args,
        Func<OutputType, string, bool> pred,
        TimeSpan? timeout = null)
    {
        TaskCompletionSource tcs = new();
        var process = ProcessTasks.StartProcess(
            command,
            string.Join(" ", args.Select(a => a.DoubleQuoteIfNeeded())),
            NukeBuild.RootDirectory,
            logger: (t, msg) =>
            {
                if (t == OutputType.Err)
                    Log.Error("{Msg}", msg);
                else
                    Log.Information("{Msg}", msg);

                if (tcs.Task.IsCompleted || !pred(t, msg)) return;
                tcs.SetResult();
            });

        await tcs.Task.WaitAsync(timeout ?? TimeSpan.FromMinutes(1));
        if (process.HasExited) process.AssertZeroExitCode();
    }

    public static bool CommandExists(string command)
    {
        using var process = RunCommand("which", command);
        process.WaitForExit();
        return process.ExitCode == 0;
    }
}