using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;

namespace JeBalance.Domain.Queries.Denonciations
{
    public class CountNumberOfDeclinedResponseSpecification : Specification<Denonciation>
    {
        private readonly string _informantId;

        public CountNumberOfDeclinedResponseSpecification(string informantId)
        {
            _informantId = informantId;
        }

        public override Expression<Func<Denonciation, bool>> ToExpression()
        {
            return denonciation => denonciation.InformantId.Equals(_informantId) && (denonciation.Response != null && denonciation.Response.ResponseType.Equals(ResponseType.Rejet));
        }
    }
}
