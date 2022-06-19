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

        #region Hasło i sprawdzanie hasła
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = "";
                if(previousLenght<value.Length)
                    realPassword += value[value.Length - 1];
                else
                    realPassword = realPassword.Substring(0, realPassword.Length - 1);

                previousLenght = value.Length;
                for (int i=0; i < value.Length; i++)
                {   
                    password += "•";
                }
            }
        }

        private int previousLenght = 0;
        private string password = "";
        private string realPassword = "";

        public string PasswordCheck
        {
            get
            {
                return passwordCheck;
            }

            set
            {
                passwordCheck = "";
                if (previousLenghtCheck < value.Length)
                    realPasswordCheck += value[value.Length - 1];
                else
                    realPasswordCheck = realPasswordCheck.Substring(0, realPasswordCheck.Length - 1);

                previousLenghtCheck = value.Length;
                for (int i = 0; i < value.Length; i++)
                {
                    passwordCheck += "•";
                }
            }
        }

        private int previousLenghtCheck = 0;
        private string passwordCheck = "";
        private string realPasswordCheck = "";

        #endregion
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
                User user = new User(Name, Surname, Email, realPassword, CalendarDateString, PhoneNumber);

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
                WrongData = "Nazwisko zawiera nieprawidłowe znaki";
                return false;
            }
            else if(!checkEmail.IsMatch(Email))
            {
                WrongData = "Email jest nieprawidłowy";
                return false;
            }
            else if(realPassword != realPasswordCheck)
            {
                WrongData = "Hasła nie są identyczne";
                return false;
            }
            else if(!(checkPhoneNumber1.IsMatch(PhoneNumber) || checkPhoneNumber2.IsMatch(PhoneNumber)))
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
