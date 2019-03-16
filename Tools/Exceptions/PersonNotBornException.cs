using System;

namespace Lab03.Tools.Exceptions
{
    internal class PersonNotBornException:Exception
    {
        internal PersonNotBornException(int age) :base($"You are not born yet.\nPlease enter the date in the past.")
        {

        }
    }
}
