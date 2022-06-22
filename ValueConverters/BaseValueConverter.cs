using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Projekt
{    
    /// <summary>
    /// Klasa bazowa dla innych konwerterów wartości
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members

        private static T mConverter = null;

        #endregion



        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }



        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

    }
}

