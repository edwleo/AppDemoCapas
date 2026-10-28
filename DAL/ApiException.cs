using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }
    }
}
