using System.Collections.Generic;
using System.ComponentModel;
using Lab4.Models;

namespace Lab4.Tools.DataStorage
{
    internal interface IDataStorage
    {

        void AddPerson(Person person);

        void DeletePerson(Person person);
        List<Person> PersonsList { get; }

        event CollectionChangeEventHandler _collectionChanged;
        //void OnCollectionChanged();
    }
}
