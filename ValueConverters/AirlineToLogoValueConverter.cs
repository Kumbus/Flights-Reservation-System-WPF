using System;
using System.Diagnostics;
using System.Globalization;

namespace Projekt
{
    internal class AirlineToLogoValueConverter : BaseValueConverter<AirlineToLogoValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((String)value)
            {
                case "LOT":
                    return "C:\\Users\\jakub\\Desktop\\Wszechswiat\\WPF\\Projekt\\Images\\LOTNB.png";

                case "RyanAir":
                    return "C:\\Users\\jakub\\Desktop\\Wszechswiat\\WPF\\Projekt\\Images\\RyanAirNB.png";

                case "Emirates":
                    return "C:\\Users\\jakub\\Desktop\\Wszechswiat\\WPF\\Projekt\\Images\\EmiratesNB.png";

                case "Lufthansa":
                    return "C:\\Users\\jakub\\Desktop\\Wszechswiat\\WPF\\Projekt\\Images\\LufthansaNB.png";

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
