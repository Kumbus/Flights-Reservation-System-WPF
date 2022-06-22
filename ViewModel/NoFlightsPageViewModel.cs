using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za zachowanie strony informującej o braku dostępnych lotów
    /// </summary>
    public class NoFlightsPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public NoFlightsPageViewModel()
        {
            GoToSearchPageCommand = new RelayCommand(GoToSearchPage, CanGoToSearchPage);
        }

        #region Wróć so strony głównej
        /// <summary>
        /// Komenda zmieniająca stronę na stronę początkową
        /// </summary>
        public ICommand GoToSearchPageCommand { get; set; }
        /// <summary>
        /// Metoda wykonywana przez komendę do zmiany strony na stronę początkową
        /// </summary>
        /// <param name="value">Parametr komendy - null</param>
        private void GoToSearchPage(object value)
        {
            WindowViewModel mainWindow = WindowViewModel.GetInstanceWindowViewModel();
            mainWindow.CurrentPage = ApplicationPage.Main;
        }
        /// <summary>
        /// Metoda sprawdzająca czy komenda zmiany strony na stronę początkową może zostać wykonana
        /// </summary>
        /// <param name="value">>Parametr komendy - null</param>
        /// <returns>True</returns>
        private bool CanGoToSearchPage(object value)
        {
            return true;
        }

        #endregion
    }
}
