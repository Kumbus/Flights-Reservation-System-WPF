using System;
using System.Diagnostics;
using System.Globalization;

namespace Projekt
{
    /// <summary>
    /// Konwerter nazwy strony na stronę ułatwiający nawigację w aplikacji
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
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

                case ApplicationPage.SeatChoice:
                    return new SeatChoicePage();

                case ApplicationPage.Summary:
                    return new SummaryPage();

                case ApplicationPage.Payment:
                    return new PaymentPage();

                case ApplicationPage.Thanks:
                    return new ThanksPage();

                case ApplicationPage.NoFlights:
                    return new NoFlightsPage();

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
