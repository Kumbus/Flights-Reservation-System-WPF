using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            Thread.Sleep(4000);
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;
        }
    }
}
