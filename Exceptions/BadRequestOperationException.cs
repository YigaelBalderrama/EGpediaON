using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGpediaON.Exceptions
{
    public class BadRequestOperationException : Exception
    {
        public BadRequestOperationException(string Msg)
            :base(Msg)
        {
        }
    }
}
