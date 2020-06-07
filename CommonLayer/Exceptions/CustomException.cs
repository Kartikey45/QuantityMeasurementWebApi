using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Exceptions
{
    public class CustomException : Exception
    {
        public enum ExceptionType
        {
            EMPTY_FIELD,
            INVALID_FIELD,
            NULL_VALUE_UNIT
        }

        ExceptionType type;

        public CustomException(CustomException.ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
