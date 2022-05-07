using System;
using System.Diagnostics;
using System.Globalization;

namespace Projekt
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Main:
                    return new MainPage();

                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.Registration:
                    return new RegistrationPage();

                case ApplicationPage.Account:
                    return new AccountPage();

                case ApplicationPage.Flights:
                    return new FlightsPage();
                    
                case ApplicationPage.FlightDetails:
                    return new FlightDetailsPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
