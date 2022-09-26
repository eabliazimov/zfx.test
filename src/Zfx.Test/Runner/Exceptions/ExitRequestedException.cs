using System;
using System.Runtime.Serialization;

namespace Zfx.Test.Runner.Exceptions
{
    [Serializable]
    internal class ExitRequestedException : Exception
    {
        public ExitRequestedException()
        {
        }

        protected ExitRequestedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}