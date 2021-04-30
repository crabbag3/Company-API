using System;
using System.Collections.Generic;
using System.Text;

namespace Gl.ExceptionHandler
{
    public abstract class DomainException : Exception
    {
        private string message;

        protected DomainException()
        {
        }

        protected DomainException(string message)
        {
            this.message = message;
        }
    }
}