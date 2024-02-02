using System.Linq.Expressions;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;

namespace JeBalance.Domain.Queries.Persons
{
    public class FindPersonsByBannedSpecification : Specification<Person>
    {
        private readonly bool _isBanned;

        public FindPersonsByBannedSpecification(bool isBanned)
        {
            _isBanned = isBanned;
        }

        public override Expression<Func<Person, bool>> ToExpression()
        {
            return person => person.IsBanned == _isBanned;
        }
    }
}