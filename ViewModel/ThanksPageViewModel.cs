using System.Threading;

namespace Projekt
{
    /// <summary>
    /// Strona odpowiadająca za zachowanie strony, która dziękuje za skorzystanie z aplikacji
    /// </summary>
    public class ThanksPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Konstruktor wywołujący metodę GoToMain
        /// </summary>
        public ThanksPageViewModel()
        {
            Thread WaitingThread = new Thread(GoToMain);
            WaitingThread.Start();

        }
        /// <summary>
        /// Metoda przechodząca do strony początkowej po upłynięciu 3 sekund
        /// </summary>
        private void GoToMain()
        {
            Thread.Sleep(3000);
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;
        }
    }
}
