using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Denolk.XchangeWrapper.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
