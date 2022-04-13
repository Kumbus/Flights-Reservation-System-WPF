using System;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Projekt
{
    public class RegistrationPageViewModel : BaseViewModel
    {
        public RegistrationPageViewModel()
        {
            RegisterCommand = new RelayCommand(Register, CanRegister);
            BackToMainPageCommand = new RelayCommand(BackToMainPage, CanBackToMainPage);
        }

        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string PasswordCheck { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string WrongData { get; set; } = "";

        #region Data urodzenia
        private DateTime calendarDate { get; set; } = DateTime.Now;

        public string CalendarDateString { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

        public DateTime CalendarDate
        {
            get { return calendarDate; }
            set
            {
                CalendarDateString = value.ToString("yyyy-MM-dd");
                //CalendarDateString = CalendarDateString.Substring(0, 10);
            }
        }
        #endregion

        #region Rejestracja 
        public ICommand RegisterCommand { get; set; }

        private void Register(object value)
        {
            //sprawdzanie wartości regexem i odpowiednie komunikaty
            if (CheckData())
            {
                User user = new User(Name, Surname, Email, Password, CalendarDateString, PhoneNumber);

                if(user.Check())
                {
                    user.SaveToDataBase();
                    WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
                    mainWindow.CurrentPage = ApplicationPage.Login;
                }
                else
                {
                    WrongData = "Istnieje już konto na ten adres email";
                }
            }
        }
        
        public bool CanRegister(object value)
        {
            return true;
        }
        #endregion



        #region Sprawdzanie poprawności danych przy rejestracji
        private bool CheckData()
        {
            Regex checkNameAndSurname = new Regex(@"^[\p{L}\p{M}][\p{L}\p{M}\-.' ]*[\p{L}\p{M}]$");
            Regex checkEmail = new Regex(@"^[a-zA-Z0-9][a-zA-Z\.\-_0-9]{2,}@[a-zA-Z\.\-_0-9]{2,}(\.[a-zA-Z]{2,3})$");
            Regex checkPhoneNumber1 = new Regex(@"[0-9]{9}");
            Regex checkPhoneNumber2 = new Regex(@"^+[0-9]{2} [0-9]{9}");
            if (!checkNameAndSurname.IsMatch(Name))
            {
                WrongData = "Imię zawiera nieprawidłowe znaki";
                return false;
            }
            else if(!checkNameAndSurname.IsMatch(Surname))
            {
                WrongData = Name + " Nazwisko zawiera nieprawidłowe znaki";
                return false;
            }
            else if(!checkEmail.IsMatch(Email))
            {
                WrongData = "Email jest nieprawidłowy";
                return false;
            }
            else if(Password != PasswordCheck)
            {
                WrongData = "Hasła nie są identyczne";
                return false;
            }
            else if(!(checkPhoneNumber1.IsMatch(PhoneNumber) || checkPhoneNumber1.IsMatch(PhoneNumber)))
            {
                WrongData = "Numer telefonu jest nieprawidłowy";
                return false;
            }

            return true;
        }
        #endregion

        #region Powrót na stronę główną
        public ICommand BackToMainPageCommand { get; set; }

        private void BackToMainPage(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;
        }

        private bool CanBackToMainPage(object value)
        {
            return true;
        }
        #endregion
    }
}
