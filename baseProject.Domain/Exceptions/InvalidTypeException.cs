using System;

namespace BaseProject.Domain.Exceptions
{
    public class InvalidTypeException : SystemException
    {
        public InvalidTypeException(string message) : base(message) { }
    }
}
