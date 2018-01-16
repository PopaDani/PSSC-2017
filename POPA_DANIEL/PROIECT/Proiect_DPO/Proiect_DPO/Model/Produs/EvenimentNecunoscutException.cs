using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Proiect_DPO.Model.Produs
{
    [Serializable]
    internal class EvenimentNecunoscutException : Exception
    {
        public EvenimentNecunoscutException()
        {
        }

        public EvenimentNecunoscutException(string message) : base(message)
        {
        }

        public EvenimentNecunoscutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EvenimentNecunoscutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
