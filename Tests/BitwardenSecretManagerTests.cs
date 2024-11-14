namespace Tests;

public sealed class BitwardenSecurityManagerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        //todo: You could write a test which ensures that all settings in your test csv file match what is available on the secret manager, and the models contained in the ApplicationUtilities.Configuration namespace.
        // any models which do not correspond to a setting in the csv file could be indication there is a mismatch between settings loaded into the secret manager and the models in the ApplicationUtilities.Configuration namespace.
        // I will leave this as an exercise for the reader.
        Assert.Pass();
    }
}