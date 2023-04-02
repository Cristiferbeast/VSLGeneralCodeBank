class Program
{
    static void Main(string[] args)
    {
        var chatbot = new Chatbot();
        Console.WriteLine("Type 'quit' to exit.");
        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            var response = chatbot.Respond(input);
            Console.WriteLine(response);
        }
    }
}
