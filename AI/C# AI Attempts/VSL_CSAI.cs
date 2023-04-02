public class Chatbot
{
    private string[] Greetings = { "hi", "hello", "hey" };
    private string[] Date = {"what is the date", "what is todays date", "what day is it today", "date"};
    private string[] Ass = { "how big is your ass", "ass size when?", "ass?", "ass size?" };
    public string Respond(string message)
    {
        if (Greetings.Contains(message.ToLower()))
        {
            return "Hi there!";
        }
        if (Date.Contains(message.ToLower()))
        {
            return $"Today's date is {DateTime.Now.ToString("MMMM dd, yyyy")}.";
        }
        if (Ass.Contains(message.ToLower()))
        {
            return "That is very crude";
        }
        return "I'm sorry, I don't understand.";
    }
}
