public class Pipeline
{
    public static bool ShowIntermediate {get; set;}
    private readonly List<IPipelinePlugin> plugins;
    private readonly List<string> intermediateResults;

    public Pipeline() {
        plugins = new List<IPipelinePlugin>();
        intermediateResults = new List<string>();
    }

    public void Use(IPipelinePlugin plugin) {
        var pluginName = plugin.GetType().Name;
        if(plugins.Any(p => p.GetType().Name == pluginName)) throw new Exception("Plugin already added.");
        Add(plugin);
    }

    public void Add(IPipelinePlugin plugin) {
        plugins.Add(plugin);
    }

    public string Start(string input) {
        intermediateResults.Clear();
        var output = input;
        foreach(var plugin in plugins) {
            output = plugin.Process(output);
            intermediateResults.Add(output);
        }
        if(ShowIntermediate) PrintIntermediateResults();
        return output;
    }

    private void PrintIntermediateResults() {
        Console.WriteLine("Intermediate results:");
        foreach(var r in intermediateResults) {
            Console.WriteLine(r);
        }
    }
}
