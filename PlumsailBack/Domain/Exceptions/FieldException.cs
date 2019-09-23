using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class FieldException : Exception
    {
        public FieldException() : base() { }

        public FieldException(string textError) : base(textError) { }
    }
}
