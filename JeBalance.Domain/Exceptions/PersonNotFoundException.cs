using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Exceptions
{
    [Serializable]
    public class PersonNotFoundException : Exception
    {

        public PersonNotFoundException(string id) :
            base($"Person not found for Id: {id}")
        {

        }
    }
}
