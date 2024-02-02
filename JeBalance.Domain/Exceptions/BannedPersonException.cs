namespace JeBalance.Domain.Exceptions
{
    [Serializable]
    public class BannedPersonException : Exception
    {
        public BannedPersonException(string id) : base($"Cannot create denonciation, Person id {id} is banned")
        {
        }
    }
}