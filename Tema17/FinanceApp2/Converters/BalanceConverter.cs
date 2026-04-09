using System;
using System.Globalization;
using System.Windows.Data;

namespace FinanceApp2.Converters;

public class BalanceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is decimal balance)
        {
            return balance > 0 ? "Positive" : balance < 0 ? "Negative" : "Zero";
        }
        return "Zero";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}