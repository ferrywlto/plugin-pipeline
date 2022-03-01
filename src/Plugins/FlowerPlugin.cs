public class FlowerPlugin : IPipelinePlugin
{
    public string Process(string input)
    {
        return $"***{input}***";
    }
}
