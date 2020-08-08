using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;

namespace EMR
{
    /// <summary>
    /// Receipt_management.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Receipt_management : Window
    {
        public Receipt_management()
        {
            InitializeComponent();
      
        }
     
    }
    public class YourConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Tuple<object, object> Tuple = new Tuple<object, object>(values[0], values[1]);
            return Tuple;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
