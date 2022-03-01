using System.Text;

public class SubsitutePlugin : IPipelinePlugin
{
    private readonly List<KeyValuePair<string, string>> config = new();
    public void Setup(List<KeyValuePair<string, string>> newConfig) {
        config.Clear();
        config.AddRange(newConfig);
    }
    public string Process(string input)
    {
        var output = new StringBuilder(input);
        for(var i=0; i<config.Count; i+=1) {
            var pair = config[i];
            output = output.Replace(pair.Key, pair.Value);
        }
        return output.ToString();
    }
}