
using Xunit;

public class FlowerPluginTest : FlowerPlugin {
    const string input = "Hello World";
    [Fact]
    public void OutputShouldStartAndEndWithThreeAsterisks() {
        var result = Process(input);
        Assert.True(result.StartsWith("***") && result.EndsWith("***"));
    }
}