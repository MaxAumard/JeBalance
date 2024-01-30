using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Queries.Persons
{
    public class FindPersonByPersonalDataSpecification: Specification<Person>
    {
        private readonly Name _firstName;
        private readonly Name _lastName;
        private readonly Address _address;

        public FindPersonByPersonalDataSpecification(string firsName, string lastName, Address address)
        {
            _firstName = firsName.Trim().ToLower();
            _lastName = lastName.Trim().ToLower();
            _address = address;
        }

        public override Expression<Func<Person, bool>> ToExpression()
        {
            return person => ((string)person.FirstName).ToLower().Equals(_firstName) 
                && ((string)person.LastName).ToLower().Equals(_lastName) 
                //&& person.Address.Equals(_address)
                ;
        }
    }
}
