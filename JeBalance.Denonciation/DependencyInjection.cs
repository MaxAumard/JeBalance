using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;
using JeBalance.Domain.Repositories;
using System.Xml.Linq;

namespace JeBalance.Denonciations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddSingleton<IDenonciationRepository, DenonciationRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository >();

            return services;
        }


    }
    public class DenonciationRepository : IDenonciationRepository
    {
        private readonly List<Denonciation> _donnees = new();

        public DenonciationRepository()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            string guid3 = Guid.NewGuid().ToString();
            _donnees.Add(new Denonciation("01", guid1, guid2, DateTimeOffset.UtcNow, Crime.EvasionFiscale, "France", new Response()));
            _donnees.Add(new Denonciation(Guid.NewGuid().ToString(), guid1, guid3, DateTimeOffset.UtcNow, Crime.DissimulationDeRevenus, "Suisse", new Response()));
            _donnees.Add(new Denonciation(Guid.NewGuid().ToString(), guid3, guid2, DateTimeOffset.UtcNow, Crime.EvasionFiscale, "France", new Response()));
        }

        public IReadOnlyCollection<Denonciation> GetAll()
        {
            return _donnees;
        }


        public Task<(IEnumerable<Denonciation> Results, int Total)> Find(int limit, int offset, Specification<Denonciation> specification)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(Specification<Denonciation> specification)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasAny(Specification<Denonciation> specification)
        {
            throw new NotImplementedException();
        }

        public Task<Denonciation> GetOne(string id)
        {
            return Task.FromResult(_donnees.FirstOrDefault(e => e.Id == id) ?? new Denonciation());
        }

        public  Task<string> Create(Denonciation denonciation)
        {
            _donnees.Add(denonciation);
            return Task.FromResult(denonciation.Id);               
        }

        public Task<string> Update(string id, Denonciation T)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }



    }
    public class PersonRepository : IPersonRepository
    {
        public Task<int> Count(Specification<Person> specification)
        {
            throw new NotImplementedException();
        }

        public Task<string> Create(Person T)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Person> Results, int Total)> Find(int limit, int offset, Specification<Person> specification)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasAny(Specification<Person> specification)
        {
            throw new NotImplementedException();
        }

        public Task<string> SetIsBanned(string id, bool isBanned)
        {
            throw new NotImplementedException();
        }

        public Task<string> SetIsVIP(string id, bool isVIP)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(string id, Person T)
        {
            throw new NotImplementedException();
        }
    }
}
