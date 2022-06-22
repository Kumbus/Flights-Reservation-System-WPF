using System;
using System.Windows.Input;

namespace Projekt
{
    /// <summary>
    /// KLasa implementująca ogólne działanie komend
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Pole przechowujące metodę do wykonania
        /// </summary>
        Action<object> _execute;
        /// <summary>
        /// Pole przechowujące metodę sprawdzającą czy można wykonać komendę
        /// </summary>
        Func<object, bool> _canExecute;

        /// <summary>
        /// Konstruktor przyjmujący metody, które będą wykonywane przez komendę
        /// </summary>
        /// <param name="execute">Metoda do wykonania</param>
        /// <param name="canExecute">Metoda sprawdzająca czy można wykonać komendę</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Metoda zwracająca czy można wykonać komendę
        /// </summary>
        /// <param name="parameter">Parametr komendy</param>
        /// <returns>Wykonuje metodę sprawdzającą jeśli istnieje, false jeśli nie ma metody sprawdzającej</returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute(parameter);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Sprawdza czy zmieniła się wartość zwracana przez metodę sprawdzającą 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Wykonuje metodę podaną przy tworzeniu komendy
        /// </summary>
        /// <param name="parameter">Parametr komendy</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}