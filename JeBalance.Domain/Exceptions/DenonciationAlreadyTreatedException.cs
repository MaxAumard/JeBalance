using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Exceptions
{
    [Serializable]
    public class DenonciationAlreadyTreatedException : Exception
    {
        public DenonciationAlreadyTreatedException(string id) :
            base($"Denonciation {id} already has a response")
        {
        }
    }
}