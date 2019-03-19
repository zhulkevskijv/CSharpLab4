using System.Collections.Generic;
using Lab4.Models;

namespace Lab4.Tools.DataStorage
{
    internal interface IDataStorage
    {
        bool PersonExists(string email);

        Person GetPersonByEmail(string email);

        void AddPerson(Person person);
        List<Person> PersonsList { get; }
    }
}
