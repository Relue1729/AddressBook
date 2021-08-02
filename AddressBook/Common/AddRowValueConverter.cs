using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace AddressBook.Common
{
    public class AddRowValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Dictionary<string, object>()
            {
                { "Name",        values[0] },
                { "PhoneNumber", values[1] }
            };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}