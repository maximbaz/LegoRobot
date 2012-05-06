using System;
using System.Globalization;
using System.Windows.Data;

namespace UI.Converters
{
    public class BoolToValueConverter<T> : IValueConverter
    {
        #region Properties and Indexers

        public T FalseValue { get; set; }
        public T TrueValue { get; set; }

        #endregion

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value == null ? FalseValue : ((bool) value ? TrueValue : FalseValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value != null && value.Equals(TrueValue);
        }

        #endregion
    }
}