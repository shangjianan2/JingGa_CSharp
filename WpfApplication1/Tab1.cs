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

using MySQL_Funtion;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string passwd_str = null;//存储当前用户的密码

        public void Init_Tab1_ComboBox()
        {
            DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select name from users", null);
            DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;
            Tab1_ComboBox.Items.Clear();//清除现有显示
            for (int i = 0; i < temp_DataRow.Count; i++)
            {
                Tab1_ComboBox.Items.Add(temp_DataRow[i][0]);
            }
        }

        private void Tab1_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab1_ComboBox.SelectedItem == null)
                return;

            DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select password from users where name=" + "\'" + Tab1_ComboBox.SelectedItem.ToString() + "\'", null);
            DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;
            passwd_str = temp_DataRow[0][0].ToString();

            Window1 passwd_Form2 = new Window1(this);
            passwd_Form2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            passwd_Form2.Owner = this;
            passwd_Form2.ShowDialog();
            if (passwd_Form2.DialogResult == true)
            {
                if (Tab1_ComboBox.SelectedItem.ToString() == "root")
                {
                    tabcontrol.SelectedIndex = 1;
                }
                else
                {
                    tabcontrol.SelectedIndex = 2;
                    Init_ShiJianQuJian_ComboBox_CurrentTime();//每次切换到用户界面的时候更新时间
                }
            }
            this.Init_Tab1_ComboBox();
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            ((MediaElement)sender).Position = ((MediaElement)sender).Position.Add(TimeSpan.FromMilliseconds(1));
        }

        private void Tab1_Button_Click(object sender, RoutedEventArgs e)
        {
            //Tab2.Visibility = System.Windows.Visibility.Visible;
            tabcontrol.SelectedIndex = 1;
        }
    }
}