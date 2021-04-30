using System;
using System.Collections.Generic;
using System.Text;

namespace Gl.ExceptionHandler
{
    public class NoRecordFoundException : DomainException
    {
        public NoRecordFoundException() : base()
        {
        }

        public NoRecordFoundException(string message) : base(message)
        {
        }
    }
}