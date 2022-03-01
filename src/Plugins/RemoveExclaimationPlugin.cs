public class RemoveExclamationPlugin : IPipelinePlugin
{
    public string Process(string input)
    {
        return input.Replace("!", string.Empty);
    }
}