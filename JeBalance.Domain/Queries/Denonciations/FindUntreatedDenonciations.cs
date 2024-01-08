using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;
using System.Linq.Expressions;


namespace JeBalance.Domain.Queries.Denonciations
{
    public class FindUntreatedDenonciations : Specification<Denonciation>
    {
        public override Expression<Func<Denonciation, bool>> ToExpression()
        {
            return denonciation => denonciation.Response == null;
        }
    }
}
