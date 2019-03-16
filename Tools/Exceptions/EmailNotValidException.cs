using System;

namespace Lab03.Tools.Exceptions
{
    internal class EmailNotValidException:Exception
    {
        internal EmailNotValidException(string email) : base($"{email} is not correct format for email.")
        {

        }
    }
}
