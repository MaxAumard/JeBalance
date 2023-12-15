using JeBalanceDenonciation.Models;

namespace JeBalanceDenonciation.Repository
{
    public interface IDenonciationRepository
    {
        Denonciation? GetById(string id);

        IReadOnlyCollection<Denonciation> GetAll();

        string Add(Denonciation denonciation);

        bool Update(string id, Reponse reponse);

        bool DeleteById(string id);
    }
}
