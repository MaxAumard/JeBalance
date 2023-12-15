namespace JeBalanceDenonciation.Models
{
    public class Reponse
    {
        public DateTimeOffset Date { get; }

        public float Retribution { get; }

        public TypeReponse TypeReponse { get; }

        public Reponse() { }

        public Reponse(float retribution, TypeReponse typeReponse)
        {
            Date = DateTimeOffset.UtcNow;
            Retribution = retribution;
            TypeReponse = typeReponse;
        }
    }
}
