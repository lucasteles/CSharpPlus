public class DictionaryExtensionsTests
{
    [Test]
    public void ShouldMergeTwoDicts()
    {
        Dictionary<string, int> first = new()
        {
            ["a"] = 1,
            ["b"] = 2,
        };

        Dictionary<string, int> second = new()
        {
            ["c"] = 3,
            ["d"] = 4,
        };

        Dictionary<string, int> expected = new()
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3,
            ["d"] = 4,
        };

        first.Merge(second).Should().BeEquivalentTo(expected);

    }


    [Test]
    public void ShouldMergeTwoDictsReplacingKey()
    {
        Dictionary<string, int> first = new()
        {
            ["a"] = 1,
            ["b"] = 2,
        };

        Dictionary<string, int> second = new()
        {
            ["a"] = 99,
            ["c"] = 3,
            ["d"] = 4,
        };

        Dictionary<string, int> expected = new()
        {
            ["a"] = 99,
            ["b"] = 2,
            ["c"] = 3,
            ["d"] = 4,
        };

        first.Merge(second).Should().BeEquivalentTo(expected);

    }

}
