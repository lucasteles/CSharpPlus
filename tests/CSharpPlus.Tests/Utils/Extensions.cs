namespace CSharpPlus.Tests.Utils;

public static class Util
{
    public static int Int(this Index index) => index.Value * (index.IsFromEnd ? -1 : 1);
}
