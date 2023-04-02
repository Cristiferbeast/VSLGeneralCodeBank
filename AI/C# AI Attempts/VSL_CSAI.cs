public class Chatbot
{
    public string Name { get; set; }
    public string[] Greetings { get; set; }
    public string[] Farewells { get; set; }
    public Dictionary<string, string> Responses { get; set; }
    public Chatbot(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        Name = lines[0];
        Greetings = lines[1].Split(',');
        Farewells = lines[2].Split(',');
        Responses = new Dictionary<string, string>();
        for (int i = 3; i < lines.Length; i++)
        {
            var parts = lines[i].Split('=');
            Responses.Add(parts[0], parts[1]);
        }
    }
}