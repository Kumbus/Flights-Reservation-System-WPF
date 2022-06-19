using System.Threading;

namespace Projekt
{
    public class ThanksPageViewModel : BaseViewModel
    {
        public ThanksPageViewModel()
        {
            Thread WaitingThread = new Thread(GoToMain);
            WaitingThread.Start();

        }

        private void GoToMain()
        {
            Thread.Sleep(3000);
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;
        }
    }
}
