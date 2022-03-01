using Xunit;

public class AppendCountPluginTest: AppendCountPlugin {
    const string input = "Hello World";
    [Fact]
    public void OutputShouldEndsWith11Chars() {
        var result = Process(input);
        Assert.EndsWith(" - Has 11 characters.", result);
    }
}