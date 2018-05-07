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

namespace WpfApplication1
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mainWindow;

        public Window1()
        {
            InitializeComponent();            
        }

        public Window1(MainWindow mainWindow_tt)
        {
            InitializeComponent();
            this.Title = mainWindow_tt.Tab1_ComboBox.SelectedItem.ToString() + " 请输入密码";
            mainWindow = mainWindow_tt;
        }

        private void Passwd_Button_Click(object sender, EventArgs e)
        {
            if (Passwd_TextBox.Password == "")
                return;
            if (mainWindow.passwd_str == Passwd_TextBox.Password)
            {
                this.DialogResult = true;
            }
            else
            {
                this.DialogResult = false;
            }
        }

        private void Passwd_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Passwd_Button_Click(sender, e);
            }
        }
    }
}
