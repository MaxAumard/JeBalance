using JeBalanceDenonciation.Models;

namespace JeBalanceDenonciation.Repository
{
    public class DenonciationRepository : IDenonciationRepository
    {
        private readonly List<Denonciation> _donnees = new();

        public DenonciationRepository()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            string guid3 = Guid.NewGuid().ToString();
            _donnees.Add(new Denonciation(Guid.NewGuid().ToString() , guid1, guid2, DateTimeOffset.UtcNow, Delit.EvasionFiscale, "France", null));
            _donnees.Add(new Denonciation(Guid.NewGuid().ToString(), guid1, guid3, DateTimeOffset.UtcNow, Delit.DissimulationDeRevenus, "Suisse", null));
            _donnees.Add(new Denonciation(Guid.NewGuid().ToString(), guid3, guid2, DateTimeOffset.UtcNow, Delit.EvasionFiscale, "France", null));
        }

        public IReadOnlyCollection<Denonciation> GetAll()
        {
            return _donnees;
        }

        public Denonciation? GetById(string id)
        {
            return _donnees.FirstOrDefault(e => e.Id == id);
        }

        public string Add(Denonciation denonciation)
        {
            _donnees.Add(denonciation);
            return denonciation.Id;
        }

        public bool DeleteById(string id)
        {
            Denonciation? denonciation = GetById(id);
            if (denonciation == null) 
            {
                return false;
            }
            return _donnees.Remove(denonciation);
        }

        bool IDenonciationRepository.Update(string id, Reponse reponse)
        {
            Denonciation? denonciation = GetById(id);
            if (denonciation == null )
            {
                return false;
            }        
            denonciation.Reponse = reponse;
            return true;
        }
    }
}
