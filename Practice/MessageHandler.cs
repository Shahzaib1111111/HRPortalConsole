namespace Portal
{
    public static class MessageHandler
    {
        public static Action<string> PrintResponse = message => Console.WriteLine(message);
    }
}
