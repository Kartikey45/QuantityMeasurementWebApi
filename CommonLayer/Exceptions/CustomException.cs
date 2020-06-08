using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Exceptions
{
    // Class For Handlling Custom Exception.
    public class CustomException : Exception
    {
        // Enum For Exception Types.
        public enum ExceptionType
        {
            EMPTY_FIELD,
            INVALID_FIELD,
            NULL_VALUE_UNIT
        }

        // Exception type Reference.
        ExceptionType type;

        // Parameter Constructor For Throwing Exception.
        public CustomException(CustomException.ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
