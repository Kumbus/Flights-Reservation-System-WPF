using System.ComponentModel;

namespace Projekt
{
    /// <summary>
    /// Klasa bazowa dla klas odpowiadających za zachowanie poszczególnych stron
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    
    }
}
