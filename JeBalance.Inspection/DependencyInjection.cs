using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;
using JeBalance.Domain.Repositories;
using JeBalance.Domain.ValueObjects;

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
            //_donnees.Add(new Denonciation("01", "01", "02", DateTimeOffset.UtcNow, Crime.EvasionFiscale, "France", new Response(DateTimeOffset.UtcNow, 10, ResponseType.DissimulationDeRevenus)));
            //_donnees.Add(new Denonciation(Guid.NewGuid().ToString(), "02", "03", DateTimeOffset.UtcNow, Crime.DissimulationDeRevenus, "Suisse", null));
            //_donnees.Add(new Denonciation(Guid.NewGuid().ToString(), "03", "02", DateTimeOffset.UtcNow, Crime.EvasionFiscale, "France", null));
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
        private readonly List<Person> _donnees = new();

        public PersonRepository() {
            //Person person1 = new Person("01", "Max", "Aumard", new Address(8, "Rue des miracles", 9999, "Paris"));
            //Person person2 = new Person("02", "Guillaume", "Pastres", new Address(7, "Rue des Frères Lumière", 68350, "Brunstatt"));
            //Person person3 = new Person("03", "Jeremy", "Da Sylva", new Address(1, "quelque part", 77777, "Strasbourg"));
        }

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

        public Task<string> FindOrCreate(string firstName, string lastName, Address address)
        {
            Person? existingPerson = _donnees.Find(p => p.FirstName == firstName && p.LastName == lastName && p.Address.Equals(address));

            if (existingPerson != null)
            {
                return Task.FromResult(existingPerson.Id);
            }
            else
            {
                Person newPerson = new Person(Guid.NewGuid().ToString(),firstName, lastName, address);
                _donnees.Add(newPerson);
                return Task.FromResult(newPerson.Id);
            }
        }

        public Task<Person> GetOne(string id)
        {
            return Task.FromResult(_donnees.FirstOrDefault(e => e.Id == id) ?? new Person());
        }

        public Task<bool> HasAny(Specification<Person> specification)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetPersons(int limit, int offset, bool isVIP)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Person> Results, int Total)> FindVIPPersons(int limit, int offset, bool isVIP)
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
