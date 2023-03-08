using Parser;

namespace TestParser;

public class CombinationParsingTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CombinationParsingWithOddNumbers()
    {
        uint value = 123;
        Combinations c = new Combinations();
        Assert.That(c.InitializeCombination(value, 0).Item2, Is.EqualTo(false));
    }

    [Test]
    public void CombinationParsingWithCorrectInputParameter()
    {
        uint value = 123456;
        Combinations c = new Combinations();

        Assert.Multiple(() =>
        {
            Assert.That(c.InitializeCombination(value, 0).Item2, Is.EqualTo(true));
            Assert.That(c.Value[0].Value, Is.EqualTo(12));
            Assert.That(c.Value[1].Value, Is.EqualTo(34));
            Assert.That(c.Value[2].Value, Is.EqualTo(56));
        });
    }
}
