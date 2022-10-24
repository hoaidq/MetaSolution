using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaSolution.Utilities.Exceptions
{
    public class MetaException : Exception
    {
        public MetaException()
        {
        }

        public MetaException(string message) : base(message)
        {
        }

        public MetaException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
