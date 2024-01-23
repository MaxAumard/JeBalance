using System.Linq.Expressions;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;

namespace JeBalance.Domain.Queries.Denonciations
{
    public class FindUntreatedDenonciationSpecification: Specification<Denonciation>
    {
        public override Expression<Func<Denonciation, bool>> ToExpression()
        {
            return denonciation => denonciation.Response == null;
        }
    }
}
