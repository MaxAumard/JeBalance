namespace JeBalance.Domain.Exceptions
{
    [Serializable]
    public class DenonciationNotFoundException : Exception
    {

        public DenonciationNotFoundException(string id): 
            base($"Denonciation not found for Id: {id}")
        {

        }
    }
}
