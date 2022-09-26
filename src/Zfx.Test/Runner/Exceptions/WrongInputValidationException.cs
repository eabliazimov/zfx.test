using FluentValidation;
using System;
using System.Runtime.Serialization;

namespace Zfx.Test.Runner.Exceptions
{
    [Serializable]
    internal class WrongInputValidationException : ValidationException
    {
        protected WrongInputValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public WrongInputValidationException() : base("Wrong Input.")
        {
        }
    }
}
