using System;


namespace WebCrawler.Helpers
{
    [Serializable] // ASK: Why Serializable?
    public class KnownException : Exception
    {
        public KnownException(string message)
            : base(message)
        {
        }
    }
}
