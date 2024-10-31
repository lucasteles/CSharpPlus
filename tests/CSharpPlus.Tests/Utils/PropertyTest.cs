using Microsoft.FSharp.Core;

namespace CSharpPlus.Tests.Utils;

[Serializable]
[AttributeUsage(AttributeTargets.Method)]
[CompilationMapping(SourceConstructFlags.ObjectType)]
public sealed class PropertyTestAttribute : FsCheck.NUnit.PropertyAttribute
{
    public PropertyTestAttribute() => QuietOnSuccess = true;
}
