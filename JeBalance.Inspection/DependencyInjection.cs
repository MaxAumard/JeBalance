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
            //services.AddSingleton<IDenonciationRepository, DenonciationRepository>();
            //services.AddSingleton<IPersonRepository, PersonRepository >();

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
            _donnees.Add(new Denonciation("01", guid1, guid2, DateTimeOffset.UtcNow, Crime.EvasionFiscale, "France", null));
            _donnees.Add(new Denonciation(Guid.NewGuid().ToString(), guid1, guid3, DateTimeOffset.UtcNow, Crime.DissimulationDeRevenus, "Suisse", null));
            _donnees.Add(new Denonciation(Guid.NewGuid().ToString(), guid3, guid2, DateTimeOffset.UtcNow, Crime.EvasionFiscale, "France", null));
        }

        public IReadOnlyCollection<Denonciation> GetAll()
        {
            return _donnees;
        }


        public Task<(IEnumerable<Denonciation> Results, int Total)> Find(int limit, int offset, Specification<Denonciation> specification)
        {
            IEnumerable<Denonciation> result = _donnees.Where(specification.IsSatisfiedBy);
            int total = result.Count();
            result = result.Skip(offset).Take(limit);
            return Task.FromResult((result, total));
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

        public Task<string> SetResponse(string id, Response response)
        {
            Denonciation denonciationToUpdate = _donnees.FirstOrDefault(d => d.Id == id);

            if (denonciationToUpdate != null)
            {
                denonciationToUpdate.Response = response;

                return Task.FromResult(id);
            }
            else
            {
                return Task.FromResult("Not Found"); ;
            }
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
