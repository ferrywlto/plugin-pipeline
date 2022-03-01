var subsituteConfig = new List<KeyValuePair<string, string>> {
    new KeyValuePair<string, string>("x", "secret"),
    new KeyValuePair<string, string>("hello", "?"),
    new KeyValuePair<string, string>("world", "_"),
    new KeyValuePair<string, string>("A", "aa"),
    new KeyValuePair<string, string>("a", "aaa"),
    new KeyValuePair<string, string>("b", "123"),
    new KeyValuePair<string, string>("c", ">_<"),
    new KeyValuePair<string, string>("d", "@@"),
    new KeyValuePair<string, string>("e", "!"),
};
var substitutePlugin = new SubsitutePlugin();
substitutePlugin.Setup(subsituteConfig);
Pipeline.ShowIntermediate = true;

var pipeline = new Pipeline();
pipeline.Use(new FlowerPlugin());
pipeline.Use(new RemoveExclamationPlugin());
pipeline.Add(new FlowerPlugin());
pipeline.Use(substitutePlugin);
pipeline.Use(new AppendCountPlugin());

var input = string.Empty;
var result = string.Empty;
var isContinue = false;

do {
    Console.Write("Input the text to process: ");
    input = Console.ReadLine();
    if(string.IsNullOrEmpty(input)) throw new Exception("Invalid input.");
    result = pipeline.Start(input);
    Console.WriteLine("Result:");
    Console.WriteLine(result);

    Console.Write("Continue? [Y/n]:");
    input = Console.ReadLine();

    isContinue = (string.IsNullOrEmpty(input) || input.Trim().ToLower()[0].Equals("y"));
} while (isContinue);
