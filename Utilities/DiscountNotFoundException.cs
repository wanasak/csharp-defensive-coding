using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    [Serializable()]
    public class DiscountNotFoundException : Exception
    {
        public DiscountNotFoundException()
        {
        }

        public DiscountNotFoundException(string? message) : base(message)
        {
        }

        public DiscountNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DiscountNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
