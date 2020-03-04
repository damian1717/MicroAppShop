using System;

namespace MicroApp.Common.Types
{
    public class MicroAppException : Exception
    {
        public string Code { get; }

        public MicroAppException()
        {
        }

        public MicroAppException(string code)
        {
            Code = code;
        }

        public MicroAppException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public MicroAppException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public MicroAppException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public MicroAppException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
