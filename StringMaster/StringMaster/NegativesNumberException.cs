using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMaster
{
    public class NegativesNumberException : Exception
    {
        public NegativesNumberException()
        {
        }

        public NegativesNumberException(string message)
            : base(message)
        {
        }
    }
}
