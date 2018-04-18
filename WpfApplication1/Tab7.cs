using System;
using System.Collections.Generic;
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

using System.Data;
using MySQL_Funtion;

//using UDP_Thread;

namespace WpfApplication1
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        //其他
        private void Tab7_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }
    }
}