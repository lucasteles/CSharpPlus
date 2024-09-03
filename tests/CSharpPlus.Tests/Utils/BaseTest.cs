namespace CSharpPlus.Tests.Utils;

public class BaseTest
{
    protected BaseTest()
    {
    }

    protected static readonly Faker faker = new("pt_BR");

    protected static int Int() => faker.Random.Int();
}
