using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank.Exceptions
{
    class FinancialOperationException : Exception
    {
        public FinancialOperationException()
        {

        }

        public FinancialOperationException(string message) 
            : base(message)
        {

        }

        public FinancialOperationException(string message, Exception internException) 
            : base(message, internException)
        {

        }
    }
}
