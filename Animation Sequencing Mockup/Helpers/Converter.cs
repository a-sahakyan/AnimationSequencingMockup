using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Animation_Sequencing_Mockup.Helpers
{
    public class ListConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";
            var list = value as IEnumerable;
            string result = "";
            foreach(var l in list)
            {
                result = result + l.ToString() + "\r\n";
            }
            int index = result.Length - 3;
            if (index > 0)
            {
                result = result.Remove(result.Length - 3);
            }
            return result;
        }

        public object ConvertBack(

            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    
    public class ColorSchemeConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";
            var scheme = value as ColorScheme;
            string result = "";
            if(scheme.Number != null)
            {
                result = result + scheme.Number + "\r\n";
            }
            if (scheme.Color != null)
            {
                result = result + scheme.Color + "\r\n";
            }
            if (scheme.YesNo != null)
            {
                result = result + scheme.YesNo;
            }
            return result;
        }

        public object ConvertBack(

            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
