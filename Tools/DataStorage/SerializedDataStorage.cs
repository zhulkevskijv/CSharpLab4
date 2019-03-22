using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Lab4.Models;
using Lab4.Tools.Managers;

namespace Lab4.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        #region Fields And Construcrtor
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
        #endregion

        #region Public Methods

        public void AddPerson(Person person)
        {
            _persons.Add(person);
            OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, person));
            SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            _persons.Remove(person);
            OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, person));
            SaveChanges();
        }

        public List<Person> PersonsList
        {
            get { return _persons.ToList(); }
        }
        public void SaveChanges()
        {
            SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }

        #endregion

        #region Event
        public event CollectionChangeEventHandler _collectionChanged;

        protected void OnCollectionChanged(CollectionChangeEventArgs e)
        {
            _collectionChanged?.Invoke(this, e);
        }
        #endregion

        #region Persons to Initialize

        private void AddPersonsToInitialize()
        {
            AddPerson(new Person("Galileo", "Galiley", "sun_is_center@zemlya.com", new DateTime(2003, 10, 17)));
            AddPerson(new Person("Nicolaus", "Copernicus", "burn_to_the_ground@astronomia.com",
                new DateTime(1976, 5, 12)));
            AddPerson(new Person("Isaac", "Newton", "appleIsaac@vovan.com", new DateTime(2005, 1, 13)));
            AddPerson(new Person("Albert", "Einstein", "e_mc@squared.com", new DateTime(1940, 7, 9)));
            AddPerson(new Person("Charles", "Darwin", "monkey@human.evo", new DateTime(1992, 12, 1)));
            AddPerson(new Person("Niels", "Bor", "quantum@physics.com", new DateTime(1931, 7, 4)));
            AddPerson(new Person("Marie", "Skadovska-Curie", "toxic@uran.rad", new DateTime(1945, 8, 7)));
            AddPerson(new Person("Amadeo", "Avogadro", "6_02@10_23.mol", new DateTime(1997, 10, 29)));
            AddPerson(new Person("Alexander Graham", "Bell", "dzin_dzin@text.me", new DateTime(1984, 2, 28)));
            AddPerson(new Person("Rene", "Descarts", "abscissa@oridanta.xy", new DateTime(1978, 3, 4)));
            AddPerson(new Person("Eratosphen", "Eratosphenovich", "zemlya_big@resheto.greece",
                new DateTime(2015, 8, 11)));
            AddPerson(new Person("Michael", "Faraday", "magnetic@elektric.anod", new DateTime(2018, 7, 12)));
            AddPerson(new Person("Fibonacci", "Fibonaccicus", "1_1_2_3@5_8.13", new DateTime(2004, 11, 18)));
            AddPerson(new Person("Heinrich", "Hertz", "vibrator@bzbzbz.hz", new DateTime(1959, 1, 20)));
            AddPerson(new Person("Robert", "Hooke", "stretch@squish.k", new DateTime(1943, 2, 21)));
            AddPerson(new Person("Omar", "Khayyam", "rubay@binom.com", new DateTime(1990, 7, 4)));
            AddPerson(new Person("Dmitri", "Mendeleev", "dream_is@life.table", new DateTime(1963, 6, 8)));
            AddPerson(new Person("Alfred", "Nobel", "bombit@menya.com", new DateTime(2010, 11, 9)));
            AddPerson(new Person("Pythogoras", "Pythogoras", "katet@gipotenuza.pif", new DateTime(2013, 12, 15)));
            AddPerson(new Person("Ernest", "Rutherford", "radio@active.ruth", new DateTime(1960, 1, 30)));
            AddPerson(new Person("James", "Watt", "rozetka@elctro.zzzz", new DateTime(1978, 10, 7)));
            AddPerson(new Person("Nikola", "Tesla", "edisson@sucks.kek", new DateTime(1924, 4, 23)));
            AddPerson(new Person("Thomas", "Edison", "tesla@sucks.lol", new DateTime(1967, 5, 31)));
            AddPerson(new Person("Elon", "Mask", "how_do_you@like_it.musk", new DateTime(1983, 6, 5)));
            AddPerson(new Person("Steve", "Jobs", "who_rule_the_world@pple.yabloko", new DateTime(1991, 8, 18)));
            AddPerson(new Person("Gottfried", "von Leibniz", "integral@different.omg", new DateTime(2009, 9, 11)));
            AddPerson(new Person("Blaise", "Pascal", "programme@begin.end", new DateTime(1952, 5, 14)));
            AddPerson(new Person("Archimedes", "Archim", "eurekaaaa@lamp.bath", new DateTime(1996, 3, 13)));
            AddPerson(new Person("Wilhelm", "Conrad Rentgen", "see_your@bone.hihihi", new DateTime(1945, 12, 8)));
            AddPerson(new Person("Leonardo", "Da Vinci", "genius@jaconda.me", new DateTime(1967, 2, 24)));
            AddPerson(new Person("Charles-Augustin", "de Coulomb", "this_is@merica.new", new DateTime(1994, 5, 21)));
            AddPerson(new Person("Tsar", "Leonid", "this@is.sparta", new DateTime(2008, 7, 27)));
            AddPerson(new Person("Erwin", "Schrodinger", "exist@notexists.cat", new DateTime(2016, 1, 23)));
            AddPerson(new Person("Carl", "Gauss", "math@rules.yeah", new DateTime(1951, 10, 1)));
            AddPerson(new Person("Borys", "Paton", "svarka@beton.h", new DateTime(1989, 9, 8)));
            AddPerson(new Person("Stephen", "Hawking", "black@hole.aaaa", new DateTime(1945, 4, 9)));
            AddPerson(new Person("August", "Lumiere", "twix1@lum.pla", new DateTime(1913, 2, 3)));
            AddPerson(new Person("Louis", "Lumiere", "twix2@lum.pla", new DateTime(1923, 7, 5)));
            AddPerson(new Person("Adolf", "Hitler", "mein@kamph.paint", new DateTime(1989, 9, 7)));
            AddPerson(new Person("Napoleon", "Bonapart", "hory@napol.small", new DateTime(1971, 9, 12)));
            AddPerson(new Person("Joseph", "Stalin", "mustache@molot.serp", new DateTime(2004, 10, 16)));
            AddPerson(new Person("Vovan", "Lenin", "welcome@mavsolei.com", new DateTime(1999, 4, 10)));
            AddPerson(new Person("Winston", "Churchill", "no@comments.uk", new DateTime(1977, 11, 15)));
            AddPerson(new Person("Kim", "Jong un", "lolly_pop@bomb.dushka", new DateTime(1966, 3, 20)));
            AddPerson(new Person("Victor", "Frankenstein", "elctro@monster.rise", new DateTime(1955, 8, 30)));
            AddPerson(new Person("Benito", "Musollini", "hitler@one.love", new DateTime(1944, 9, 1)));
            AddPerson(new Person("Julius", "Cesar", "and_u@brutus.gr", new DateTime(1933, 11, 5)));
            AddPerson(new Person("Volodymyr", "Boublik", "nikak_ne_poymu@schto_ty_imela.vvidu",
                new DateTime(1956, 10, 9)));
            AddPerson(new Person("John", "Kennedy", "snipers@sucks.com", new DateTime(1978, 5, 8)));
            AddPerson(new Person("Neil", "Armstrong", "dude@its.moon", new DateTime(1990, 6, 1)));
        }

        #endregion

        
    }
}
