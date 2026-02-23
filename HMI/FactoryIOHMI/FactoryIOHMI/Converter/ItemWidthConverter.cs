using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FactoryIOHMI.Converter
{
    public class ItemWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double fallbackReturnValue = 100.0;
            if (values[0] is double totalWidth &&
                values[1] is int itemsPerRow)
            {
                double margin = 8; // links + rechts
                return (totalWidth / itemsPerRow) - margin;
            }

            return fallbackReturnValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
