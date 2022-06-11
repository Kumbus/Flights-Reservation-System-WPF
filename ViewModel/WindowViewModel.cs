using System;
using System.IO;
using System.Windows.Input;

namespace Projekt
{
    public class WindowViewModel : BaseViewModel
    {

        public static bool logged = false;

        public static BasicFlight Flight { get; set; }

        public string RegisterButtonText { get; set; } = "Zarejestruj się";
        public string LoginButtonText { get; set; } = "Zaloguj się";
        private WindowViewModel()
        {
            ChangePageToLoginCommand = new RelayCommand(ChangePageToLogin, CanChangePageToLogin);
            ChangePageToRegistrationCommand = new RelayCommand(ChangePageToRegistration, CanChangePageToRegistration);
            CreateEntryLog();
        }



        #region Singleton
        private static WindowViewModel? instance;

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
        public void CreateEntryLog()
        {
            string path = "C:\\Users\\jakub\\Desktop\\Wszechswiat\\WPF\\Projekt\\Logs.txt";
            StreamWriter sw = File.AppendText(path);
            sw.Write("Data wejścia: ");
            sw.Write(DateTime.Now.ToString());
            sw.Flush();
            sw.Close();
        }

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
        public ICommand ChangePageToLoginCommand { get; set; }
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Main;



        public void ChangePageToLogin(object value)
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

        public bool CanChangePageToLogin(object value)
        {
            return true;
        }

        public ICommand ChangePageToRegistrationCommand { get; set; }

        public void ChangePageToRegistration(object value)
        {
            if(logged == false)
                CurrentPage = ApplicationPage.Registration;
            else
            {
                CurrentPage = ApplicationPage.Account;
            }
        }

        public bool CanChangePageToRegistration(object value)
        {
            return true;
        }

        #endregion

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
    }

}
