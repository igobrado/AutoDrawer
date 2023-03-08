using Parser;

namespace TestParser;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LineParseTestWithInt()
    {
        const string str = "1;123;231;412;3923";
        var line = new Line();
        
        Assert.Multiple(() =>
        {
            Assert.That(line.Initialize(str), Is.EqualTo(true));
            Assert.That(line.Point.X, Is.EqualTo(123));
            Assert.That(line.Point.Y, Is.EqualTo(231));
            Assert.That(line.Point.Z, Is.EqualTo(412));
            Assert.That(line.CurrentLineNumber, Is.EqualTo(1));
        });
    }
    
    [Test]
    public void LineParseTestWithFloat()
    {
        const string str = "1;123.3214;231.3214;412.3214;3923";
        var line = new Line();

        Assert.Multiple(() =>
        {
            Assert.That(line.Initialize(str), Is.EqualTo(true));
            Assert.That(line.Point.X, Is.EqualTo(123.3214f));
            Assert.That(line.Point.Y, Is.EqualTo(231.3214f));
            Assert.That(line.Point.Z, Is.EqualTo(412.3214f));
            Assert.That(line.CurrentLineNumber, Is.EqualTo(1));
        });
    }
    
    [Test]
    public void LineParseTestWithInvalidArgumentSize()
    {
        const string str = "123.3214;231.3214;412.3214";
        var line = new Line();
        Assert.Multiple(() =>
        {
            Assert.That(line.Initialize(str), Is.EqualTo(false));
        });
    }
    
    [Test]
    public void TwoTimeInitializationIsFailing()
    {
        const string str = "1;123.3214;231.3214;412.3214;3923";
        var line = new Line();
        Assert.Multiple(() =>
        {
            Assert.That(line.Initialize(str), Is.EqualTo(true));
            Assert.That(line.Point.X, Is.EqualTo(123.3214f));
            Assert.That(line.Point.Y, Is.EqualTo(231.3214f));
            Assert.That(line.Point.Z, Is.EqualTo(412.3214f));
            Assert.That(line.CurrentLineNumber, Is.EqualTo(1));
        });
        
        Assert.Multiple(() =>
        {
            Assert.That(line.Initialize(str), Is.EqualTo(false));
        });
    }
    
    [Test]
    public void InvalidNumberOfParams()
    {
        const string str = "1;123.3214;;412.3214;;";
        var line = new Line();
        Assert.Multiple(() =>
        {
            Assert.That(line.Initialize(str), Is.EqualTo(false));
        });
    }
}
