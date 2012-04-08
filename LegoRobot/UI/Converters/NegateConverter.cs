using System;
using System.Globalization;
using System.Windows.Data;

namespace LegoRobot.UI.Converters
{
    public class NegateConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is bool ? !(bool) value : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is bool ? !(bool) value : value;
        }

        #endregion
    }
}