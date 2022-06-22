using System;
using System.IO;
using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za zachowanie głównej strony, w której zawierają się inne
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        /// <summary>
        /// Statyczne pole pokazujące czy użytkownik jest zalogowany
        /// </summary>
        public static bool logged = false;
        /// <summary>
        /// Statyczna własciwość reprezentująca lot, który jes rezerwowany 
        /// </summary>
        public static BasicFlight Flight { get; set; }
        /// <summary>
        /// Tekst przycisku rejestracji/wejścia w profil
        /// </summary>
        public string RegisterButtonText { get; set; } = "Zarejestruj się";
        /// <summary>
        /// Tekst przycisku logowania/wylogowywania się
        /// </summary>
        public string LoginButtonText { get; set; } = "Zaloguj się";
        /// <summary>
        /// Prywatny konstruktor, żeby móc zastosować wzorzec singleton
        /// </summary>
        private WindowViewModel()
        {
            ChangePageToLoginCommand = new RelayCommand(ChangePageToLogin, CanChangePageToLogin);
            ChangePageToRegistrationCommand = new RelayCommand(ChangePageToRegistration, CanChangePageToRegistration);
            CreateEntryLog();
        }



        #region Singleton
        /// <summary>
        /// Instancja klasy potrzebna do wzorca singleton
        /// </summary>
        private static WindowViewModel? instance;
        /// <summary>
        /// Metoda zwracająca jedyną instancję klasy lub tworząca ją jeśli jeszcze nie istnieje
        /// </summary>
        /// <returns>Instancja klasy</returns>
        public static WindowViewModel GetInstanceWindowViewModel()
        {
            if (instance == null)
            {
                instance = new WindowViewModel();
            }
            return instance;
        }

        #endregion

        #region Tworzenie logów
        /// <summary>
        /// Metoda tworząca log o wejściu w pliku tekstowym podczas startu aplikacji
        /// </summary>
        public void CreateEntryLog()
        {
            string path = "C:\\Users\\jakub\\Desktop\\Wszechswiat\\WPF\\Projekt\\Logs.txt";
            StreamWriter sw = File.AppendText(path);
            sw.Write("Data wejścia: ");
            sw.Write(DateTime.Now.ToString());
            sw.Flush();
            sw.Close();
        }
        /// <summary>
        /// Metoda tworząca log o wyjściu podczas zamykania aplikacji
        /// </summary>
        public void CreateCloseLog()
        {
            string path = "C:\\Users\\jakub\\Desktop\\Wszechswiat\\WPF\\Projekt\\Logs.txt";
            StreamWriter sw = File.AppendText(path);
            sw.Write(" Data wyjścia: ");
            sw.WriteLine(DateTime.Now.ToString());
            sw.Flush();
            sw.Close();
        }
        #endregion

        #region Zmiana stron na logowanie i rejestrację lub profil użytkownika w zależności od zalogowania
        /// <summary>
        /// Komenda zmieniająca stronę na stronę logowania
        /// </summary>
        public ICommand ChangePageToLoginCommand { get; set; }
        /// <summary>
        /// Właściwość reprezentująca aktualną stronę
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Main;
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę logowania
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void ChangePageToLogin(object value)
        {
            if(logged == false)
                CurrentPage = ApplicationPage.Login;
            else
            {
                CurrentPage = ApplicationPage.Main;
                logged = false;
                ChangeButtonsTexts();
            }
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę logowania może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanChangePageToLogin(object value)
        {
            return true;
        }
        /// <summary>
        /// Komenda zmieniająca stronę na stronę rejestracji
        /// </summary>
        public ICommand ChangePageToRegistrationCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę rejestracji
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void ChangePageToRegistration(object value)
        {
            if(logged == false)
                CurrentPage = ApplicationPage.Registration;
            else
            {
                CurrentPage = ApplicationPage.Account;
            }
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę rejestracji może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanChangePageToRegistration(object value)
        {
            return true;
        }
        /// <summary>
        /// Metoda zmieniająca napisy na przyciskach podczas logowania/wylogowywania się
        /// </summary>
        public void ChangeButtonsTexts()
        {
            if (logged == true)
            {
                RegisterButtonText = "Mój profil";
                LoginButtonText = "Wyloguj się";
            }
            else
            {
                RegisterButtonText = "Zarejestruj się";
                LoginButtonText = "Zaloguj się";
            }
        }

        #endregion
    }

}
