
namespace landm.Transfer.Sample.Exceptions
{
    using System;

    public class ConfigurationValueInvalidException: Exception
    {
        public ConfigurationValueInvalidException()
        {
        }

        public ConfigurationValueInvalidException(string message)
            : base(message)
        {
        }

        public ConfigurationValueInvalidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
