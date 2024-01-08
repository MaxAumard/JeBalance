using System.Linq.Expressions;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;

namespace JeBalance.Domain.Queries.Persons
{
    public class FindPersonsByVIPSpecification : Specification<Person>
    {
        private readonly bool _isVIP;

        public FindPersonsByVIPSpecification(bool isVIP)
        {
            _isVIP = isVIP;
        }

        public override Expression<Func<Person, bool>> ToExpression()
        {
            return person => person.IsVIP == _isVIP;
        }
    }
}
