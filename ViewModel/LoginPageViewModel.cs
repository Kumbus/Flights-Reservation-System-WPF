using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za zachowanie strony logowania
    /// </summary>
    public class LoginPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public LoginPageViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin);
            BackToMainPageCommand = new RelayCommand(BackToMainPage, CanBackToMainPage);
        }
        /// <summary>
        /// Email pdawany przy logowaniu
        /// </summary>
        public string Email { get; set; } = "";
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
                if (previousLenght < value.Length)
                    realPassword += value[value.Length - 1];
                else
                    realPassword = realPassword.Substring(0, realPassword.Length - 1);

                previousLenght = value.Length;
                for (int i = 0; i < value.Length; i++)
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
        /// Właściwość przechowująca tekst, który jest wyświetlony kiedy wprowadzone dane są nieprawidłowe
        /// </summary>
        public string WrongEmailOrPassword { get; set; } = "";

        #region Logowanie się
        /// <summary>
        /// Komenda obsługująca przycisk logowania
        /// </summary>
        public ICommand LoginCommand { get; set; }
        /// <summary>
        /// Metoda logująca użytkownika, jeśli wpisał poprawne dane
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void Login(object value)
        {
            User user = new User("", "", Email, realPassword, "", "");
            

            if (user.Login() == false)
                WrongEmailOrPassword = "Email lub/i hasło niepoprawne";
            else
            {
                WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
                WindowViewModel.logged = true;
                mainWindow.ChangeButtonsTexts();
                AccountPageViewModel.User = user;
                mainWindow.CurrentPage = ApplicationPage.Main;
            }
        }
        /// <summary>
        /// Metoda sprawdzająca czy użytkownik może się zalogować
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        /// <returns>True</returns>
        public bool CanLogin(object value)
        {
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
