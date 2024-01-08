using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Models
{
    public class Response
    {
        public DateTimeOffset Date { get; }

        public float Retribution { get; }

        public ResponseType ResponseType { get; }

        public Response()
        {
        }

        public Response(DateTimeOffset date, float retribution, ResponseType responseType)
        {
            Date = date;
            Retribution = retribution;
            ResponseType = responseType;
        }
    }
}
