using System.Linq.Expressions;

namespace CSharpPlus.Tests;

public class ExpressionExtensionsTests
{
    record ClassWithMembers(int Foo, string Bar);

    [Test]
    public void ShouldGetClassMemberName()
    {
        Expression<Func<ClassWithMembers, object>> bar = x => x.Bar;
        Expression<Func<ClassWithMembers, object>> foo = x => x.Foo;
        Expression<Func<ClassWithMembers, object>> length = x => x.Bar.Length;

        bar.GetMemberName().Should().Be(nameof(ClassWithMembers.Bar));
        foo.GetMemberName().Should().Be(nameof(ClassWithMembers.Foo));
        length.GetMemberName().Should().Be(nameof(string.Length));
    }
}
