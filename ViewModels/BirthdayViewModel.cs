using Semytskyi1.Models;
using Semytskyi1.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Semytskyi1.ViewModels
{
    internal class BirthdayViewModel : INotifyPropertyChanged
    {
        private UserBirthday _userBirthday = new UserBirthday();
        private RelayCommand<object> _submitCommand;
        private string _age;
        private string _zodiac;
        private string _chineseZodiac;

        public DateTime Birthday 
        {
            get
            {
                return _userBirthday.Birthday;
            } 
            set
            {
                _userBirthday.Birthday = value;
            }
        }

        public string Age 
        { 
            get
            {
                return _age;
            }
            private set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string Zodiac
        {
            get
            {
                return _zodiac.ToString();
            }
            private set
            {
                _zodiac = value;
                OnPropertyChanged(nameof(Zodiac));
            }
        }

        public string ChineseZodiac
        {
            get
            {
                return _chineseZodiac.ToString();
            }
            private set
            {
                _chineseZodiac = value;
                OnPropertyChanged(nameof(ChineseZodiac));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public RelayCommand<object> SubmitCommand
        {
            get
            {
                return _submitCommand ??= new RelayCommand<object>(_ => Submit(),_ => !_userBirthday.Birthday.Equals(DateTime.MinValue));
            }
        }

        private int CalculateAge()
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - _userBirthday.Birthday.Year;
            if (_userBirthday.Birthday.Date > currentDate.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        private ZodiacEnum CalculateZodiac()
        {
            int day = _userBirthday.Birthday.DayOfYear;
            if (day >= 21 && day <= 51)
                return ZodiacEnum.Aquarius;
            else if (day >= 52 && day <= 80)
                return ZodiacEnum.Pisces;
            else if (day >= 81 && day <= 110)
                return ZodiacEnum.Aries;
            else if (day >= 111 && day <= 141)
                return ZodiacEnum.Taurus;
            else if (day >= 142 && day <= 172)
                return ZodiacEnum.Gemini;
            else if (day >= 173 && day <= 204)
                return ZodiacEnum.Cancer;
            else if (day >= 205 && day <= 236)
                return ZodiacEnum.Leo;
            else if (day >= 237 && day <= 266)
                return ZodiacEnum.Virgo;
            else if (day >= 267 && day <= 296)
                return ZodiacEnum.Libra;
            else if (day >= 297 && day <= 326)
                return ZodiacEnum.Scorpio;
            else if (day >= 327 && day <= 355)
                return ZodiacEnum.Sagittarius;
            else
                return ZodiacEnum.Capricorn;
        }

        private ChineseZodiacEnum CalculateChineseZodiac()
        {
            return (ChineseZodiacEnum) (_userBirthday.Birthday.Year % 12);
        }

        private void Submit()
        {
            int age = CalculateAge();
            if (age < 0 || age >= 130) 
            {
                Clear();
                MessageBox.Show("Incorrect age");
                return;
            }
            Age = CalculateAge().ToString();
            Zodiac = CalculateZodiac().ToString();
            ChineseZodiac = CalculateChineseZodiac().ToString();
            if (CheckBirthday())
            {
                MessageBox.Show("Congratulations! I wish you to get the max mark for this lab! Happy Birthday!");
            }
        }

        private void Clear()
        {
            Age = "";
            Zodiac = "";
            ChineseZodiac = "";
        }

        private bool CheckBirthday()
        {
            DateTime today = DateTime.Today;
            if (_userBirthday.Birthday.Month == today.Month && _userBirthday.Birthday.Day == today.Day)
                return true;
            return false;
        }
    }

    enum ZodiacEnum
    {
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius,
        Capricorn,
        Aquarius,
        Pisces
    }

    enum ChineseZodiacEnum
    {
        Monkey = 0,
        Rooster = 1,
        Dog = 2,
        Pig = 3,
        Rat = 4,
        Ox = 5,
        Tiger = 6,
        Rabbit = 7,
        Dragon = 8,
        Snake = 9,
        Horse = 10,
        Goat = 11
    }
}
