namespace CSharpPlus.Tests.Utils;

public sealed class PropertyTestAttribute : FsCheck.NUnit.PropertyAttribute
{
    public PropertyTestAttribute() => this.QuietOnSuccess = true;
}
