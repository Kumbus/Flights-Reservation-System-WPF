using System;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za zachowanie strony rejestracji
    /// </summary>
    public class RegistrationPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public RegistrationPageViewModel()
        {
            RegisterCommand = new RelayCommand(Register, CanRegister);
            BackToMainPageCommand = new RelayCommand(BackToMainPage, CanBackToMainPage);
        }
        /// <summary>
        /// Imię podawane przy rejestracji
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// Nazwisko podawane przy rejestracji
        /// </summary>
        public string Surname { get; set; } = "";
        /// <summary>
        /// Email podawany przy rejestracji
        /// </summary>
        public string Email { get; set; } = "";

        #region Hasło i sprawdzanie hasła
        /// <summary>
        /// Hasło podawane przy rejestracji
        /// </summary>
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
        /// <summary>
        /// Poprzednia długość hasła podczas wpisywania go
        /// </summary>
        private int previousLenght = 0;
        /// <summary>
        /// Zakropkowane hasło potrzebne do zwracania przez publiczną właściwość
        /// </summary>
        private string password = "";
        /// <summary>
        /// Prawdziwe hasło zapisywane później do bazy danych
        /// </summary>
        private string realPassword = "";
        /// <summary>
        /// Hasło sprawdzające podawane przy rejestracji
        /// </summary>
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
        /// <summary>
        /// Poprzednia długość hasła sprawdzającego podczas wpisywania go
        /// </summary>
        private int previousLenghtCheck = 0;
        /// <summary>
        /// Zakropkowane hasło sprawdzające potrzebne do zwracania przez publiczną właściwość
        /// </summary>
        private string passwordCheck = "";
        /// <summary>
        /// Prawdziwe hasło potrzebne do porównywania
        /// </summary>
        private string realPasswordCheck = "";

        #endregion
        /// <summary>
        /// Numer telefonu podawany przy rejestracji
        /// </summary>
        public string PhoneNumber { get; set; } = "";
        /// <summary>
        /// Właściwość przechowująca tekst, który jest wyświetlony kiedy wprowadzone dane są nieprawidłowe
        /// </summary>
        public string WrongData { get; set; } = "";

        #region Data urodzenia
        /// <summary>
        /// Data urodzenia potrzebna do getera publicznej właściwości
        /// </summary>
        private DateTime calendarDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Data urodzenia w postaci tekstowej, która jest wyświetlana na stronie
        /// </summary>
        public string CalendarDateString { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        /// <summary>
        /// Właściwość przypsująca tekstowi datę wybraną przez użytkownika w kalendarzu
        /// </summary>
        public DateTime CalendarDate
        {
            get { return calendarDate; }
            set
            {
                CalendarDateString = value.ToString("yyyy-MM-dd");
            }
        }
        #endregion

        #region Rejestracja 
        /// <summary>
        /// Komenda odpowiedzialna za przycisk rejestracji
        /// </summary>
        public ICommand RegisterCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę rejestrująca użytkownika jeśli dane są poprawne
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void Register(object value)
        {
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
        /// <summary>
        /// Metoda sprawdzająca czy można wykonać komendę
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        /// <returns></returns>
        public bool CanRegister(object value)
        {
            return true;
        }
        #endregion

        #region Sprawdzanie poprawności danych przy rejestracji
        /// <summary>
        /// Metoda sprawdzająca czy wpisane dane są poprawne
        /// </summary>
        /// <returns>True jeśli dane są poprawne, false jeśli dan enie są poprawne</returns>
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
        /// <summary>
        /// Komenda zmieniająca stronę na stronę początkową
        /// </summary>
        public ICommand BackToMainPageCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę początkową
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void BackToMainPage(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę początkową może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanBackToMainPage(object value)
        {
            return true;
        }
        #endregion
    }
}
