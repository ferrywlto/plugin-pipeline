using System;
using Xunit;

public class PipelineTest: Pipeline {
    const string input = "Hello World";

    [Fact]
    public void OutptutShouldRemainIntactWithoutPlugin() {
       var output = Start(input);
       Assert.Equal(input, output);
    }

    [Fact]
    public void ShouldThrowExceptionIfAddTheSamePluginWithUse() {
        Assert.Throws<Exception>(() => {
            var plugin = new FlowerPlugin();
            Use(plugin);
            Use(plugin);
        });
    }

    [Fact]
    public void ShouldNotThrowExceptionIfAddTheSamePluginWithAdd() {
        var exception = Record.Exception(() => {
            var plugin = new FlowerPlugin();
            Use(plugin);
            Add(plugin);
        });
        Assert.Null(exception);
    }
}