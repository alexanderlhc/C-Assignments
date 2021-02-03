using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _20210203_L02_Exceptionally_Weird_Code
{
    class RegretableActionException : Exception
    {
        public RegretableActionException()
        {
        }

        public RegretableActionException(string message) : base(message)
        {
        }

        public RegretableActionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegretableActionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
