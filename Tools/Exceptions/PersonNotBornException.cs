using System;

namespace Lab4.Tools.Exceptions
{
    internal class PersonNotBornException:Exception
    {
        internal PersonNotBornException(int age) :base($"You are not born yet.\nPlease enter the date in the past.")
        {

        }
    }
}
