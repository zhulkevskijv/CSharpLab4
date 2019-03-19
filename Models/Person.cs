using Lab4.Tools;
using System;
using System.Text.RegularExpressions;
using Lab4.Tools.Exceptions;

namespace Lab4.Models
{
    [Serializable]
    internal class Person : BaseViewModel
    {

        #region Fields

        private bool _initialized = false;
        private string _name;
        private string _surname;
        private DateTime _birthday;
        private string _email;
        private string _westHoroSign;
        private string _chineseHoroSign;
        private bool _isAdult;
        private bool _isBirthday;


        #endregion

        #region Properties

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                _initialized = false;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Constructors

        public Person(string name, string surname, string email, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = birthday;
        }

        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        public Person(string name, string surname, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _birthday = birthday;
        }

        #endregion

        #region ReadOnly Properties

        public bool IsAdult
        {
            get
            {
                if (!_initialized)
                    InitializePerson();
                return _isAdult;
            }
        }

        public string WestHoroSign
        {
            get
            {
                if (!_initialized)
                    InitializePerson();
                return _westHoroSign;
            }
        }

        public string ChineseHoroSign
        {
            get
            {
                if (!_initialized)
                    InitializePerson();
                return _chineseHoroSign;
            }
        }

        public bool IsBirthday
        {
            get
            {
                if (!_initialized)
                    InitializePerson();
                return _isBirthday;
            }
        }


        #endregion

        #region AdditionalMethodsForCalculating

        private int CalculateAge()
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - Birthday.Year;
            if (Birthday.Month > currentDate.Month)
                --age;
            else if (Birthday.Month == currentDate.Month)
            {
                if (Birthday.Day > currentDate.Day)
                    --age;
            }

            return age;
        }

        private string CalculateWestHoroscope()
        {
            if (Birthday.Day >= 21 && Birthday.Month == 3 || Birthday.Day <= 20 && Birthday.Month == 4)
                return "Aries";
            if (Birthday.Day >= 21 && Birthday.Month == 4 || Birthday.Day <= 22 && Birthday.Month == 5)
                return "Taurus";
            if (Birthday.Day >= 22 && Birthday.Month == 5 || Birthday.Day <= 21 && Birthday.Month == 6)
                return "Gemini";
            if (Birthday.Day >= 22 && Birthday.Month == 6 || Birthday.Day <= 22 && Birthday.Month == 7)
                return "Cancer";
            if (Birthday.Day >= 23 && Birthday.Month == 7 || (Birthday.Day <= 22 && Birthday.Month == 8))
                return "Leo";
            if (Birthday.Day >= 23 && Birthday.Month == 8 || Birthday.Day <= 23 && Birthday.Month == 9)
                return "Virgo";
            if (Birthday.Day >= 24 && Birthday.Month == 9 || Birthday.Day <= 23 && Birthday.Month == 10)
                return "Libra";
            if (Birthday.Day >= 24 && Birthday.Month == 10 || Birthday.Day <= 22 && Birthday.Month == 11)
                return "Scorpio";
            if (Birthday.Day >= 23 && Birthday.Month == 11 || Birthday.Day <= 21 && Birthday.Month == 12)
                return "Sagittarius";
            if (Birthday.Day >= 22 && Birthday.Month == 12 || Birthday.Day <= 20 && Birthday.Month == 1)
                return "Capricorn";
            if (Birthday.Day >= 21 && Birthday.Month == 1 || Birthday.Day <= 19 && Birthday.Month == 2)
                return "Aquarius";
            return "Pisces";
        }

        private string CalculateChineseHoroscope()
        {
            switch (Birthday.Year % 12)
            {
                case 0:
                    return "Monkey";
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
                default:
                    return "Lol";
            }
        }

        public void CheckInput()
        {
            var age = CalculateAge();
            if (age >= 135)
                throw new PersonTooOldException(age);
            if (age < 0)
                throw new PersonNotBornException(age);
            if (!Regex.IsMatch(Email, @"[A-Za-z][A-Za-z0-9]*@[A-Za-z]+\.[A-Za-z]+"))
            {
                throw new EmailNotValidException(Email);
            }
        }

        private void InitializePerson()
        {
            _isBirthday = Birthday.Day == DateTime.Today.Day && Birthday.Month == DateTime.Today.Month;
            _chineseHoroSign = CalculateChineseHoroscope();
            _westHoroSign = CalculateWestHoroscope();
            _isAdult = CalculateAge() >= 18;
            _initialized = true;

            OnPropertyChanged($"IsAdult");
            OnPropertyChanged($"IsBirthday");
            OnPropertyChanged($"BirthdayResult");
            OnPropertyChanged($"WestHoroSign");
            OnPropertyChanged($"ChineseHoroSign");
        }
        #endregion
    }
}
