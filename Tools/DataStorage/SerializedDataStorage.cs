using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab4.Models;
using Lab4.Tools.Managers;

namespace Lab4.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _persons;

        internal SerializedDataStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _persons = new List<Person>();
                AddPersonsToInitialize();
            }
        }

        public bool PersonExists(string email)
        {
            return _persons.Exists(u => u.Email == email);
        }

        public Person GetPersonByEmail(string email)
        {
            return _persons.FirstOrDefault(u => u.Email == email);
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
            SaveChanges();
        }

        public List<Person> PersonsList
        {
            get { return _persons.ToList(); }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }

        private void AddPersonsToInitialize()
        {
            AddPerson(new Person("Eukakyi", "Pontisey", "eukakyi@gmail.com", new DateTime(1980,8,7)));
            AddPerson(new Person("Eurasyi", "Kapustyan", "eurasyi@gmail.com", new DateTime(1949, 12, 31)));
            AddPerson(new Person("Monokek", "Kox", "koxkox@kekeke.kek", new DateTime(1954, 1, 30)));
            AddPerson(new Person("Galileo", "Galiley", "sun_is_center@zemlya.com", new DateTime(2003, 10, 17)));
            AddPerson(new Person("Mykolay", "Kopernyk", "burn_to_the_ground@astronomia.com", new DateTime(1976, 5, 12)));

        }
    }
}
