using System.Windows.Input;

namespace Projekt
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin);
            BackToMainPageCommand = new RelayCommand(BackToMainPage, CanBackToMainPage);
        }

        #region Logowanie
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";

        public string WrongEmailOrPassword { get; set; } = "";
        public ICommand LoginCommand { get; set; }

        private void Login(object value)
        {
            User user = new User("", "", Email, Password, "", "");
            

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

        public bool CanLogin(object value)
        {
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
