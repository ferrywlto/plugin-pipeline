using System.Linq;
using Xunit;

public class RemoveExclaimationPluginTest : RemoveExclamationPlugin {
    const string input = "Hello World!";

    [Fact]
    public void OutputShouldWithoutExclaimationMark() {
        var output = Process(input);

        Assert.DoesNotContain(output, c => c.Equals('!'));
    }
}