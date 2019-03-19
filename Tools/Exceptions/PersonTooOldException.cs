using System;


namespace Lab4.Tools.Exceptions
{
    internal class PersonTooOldException: Exception
    {
        internal PersonTooOldException(int age) : base($"You're too old to be alive - {age} years.\nPlease enter date not so far from today.")
        {

        }
    }
}
