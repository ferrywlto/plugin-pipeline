using System;
using System.Collections.Generic;
using Xunit;

public class SubsitutePluginTest : SubsitutePlugin {
    const string input = "Hello World";

    [Fact]
    public void OutputShouldRemainIntactWithoutConfig() {
        var output = Process(input);
        Assert.Equal(input, output);
    }

    [Fact]
    public void OutputShouldHaveCharOReplaced() {
        Setup(new List<KeyValuePair<string,string>> {
            new KeyValuePair<string, string>("o", "@")
        });

        var output = Process(input);

        Assert.Equal("Hell@ W@rld", output);
    }

    [Fact]
    public void OutputShouldRemainIntactIfNoMatch() {
        Setup(new List<KeyValuePair<string,string>> {
            new KeyValuePair<string, string>("!", "@")
        });

        var output = Process(input);

        Assert.Equal(input, output);
    }
}