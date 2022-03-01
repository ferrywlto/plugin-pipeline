public class AppendCountPlugin : IPipelinePlugin
{
    public string Process(string input)
    {
        return $"{input} - Has {input.Length} characters.";
    }
}