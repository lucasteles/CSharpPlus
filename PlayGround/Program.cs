using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");

var persons = new Person[]
{
    new(1, "Lucas", FooType.Foo1), new(2, "Teles", FooType.Foo2)
};

var json = JsonSerializer.Serialize(persons);
Console.WriteLine(json);

var back = JsonSerializer.Deserialize<Person[]>(json);
foreach (var p in back ?? Array.Empty<Person>())
    Console.WriteLine(p.ToString());


public record Person(int Id, string Name, FooType Foo);

[JsonEnumDescription]
public enum FooType : long
{
    [Description("The Foo number 1")]
    Foo1 = 1,

    [EnumMember(Value = "The Foo number 2")]
    Foo2,
}
