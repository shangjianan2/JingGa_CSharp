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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using MySQL_Funtion;

using UDP_Thread;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isMouseLeftButtonDown = false;
        Point previousMousePoint = new Point(0, 0);

        private bool isMouseLeftButtonDown_Tab6 = false;
        Point previousMousePoint_Tab6 = new Point(0, 0);

        public UDP_Communication mysql_Thread = new UDP_Communication(new byte[4] { 10, 137, 8, 15 }, 2333);

        public MainWindow()
        {
            InitializeComponent();
            Init_Tab1_ComboBox();
            Init_Tab2_ComboBox();
            Init_Tab3_CurrentStatus_ListView(ref test5_Mem_array, Tab3_CurrentStatus_ListView);
            Init_test5_Mem_array(ref test5_Mem_array, size_chanel);
            Init_ShiJianQuJian_GroupBox();
            Init_translateTransform_Array();
            Init_scaleTransform_Array();
            Init_rectangle_Array();

            //注册事件
            mysql_Thread.rev_New2 += new recNewMessage2(rec2_NewMessage_Form1);
            mysql_Thread.recThread_Start();
        }

        #region//rec2_NewMessage_Form1函数是rec_NewMessage_Form1函数的新的实现，可以返回源地址和源端口
        public void rec2_NewMessage_Form1(byte[] message, ref EndPoint endPoint_tt)
        {
            //if (message.Length != 14)//数据的有效性还需要检验，但是暂时没有想到靠谱的方法
            //    return;
            //显示源地址和源端口
            System.Diagnostics.Debug.WriteLine(endPoint_tt.ToString());


            string[] temp_array_str = ShuJuJieXi(message);
            string str = "INSERT INTO test5 ( `id`, `name`, `type`, `gas type`, `DanWei`,`status`, `NongDu`, `DiXian`, `GaoXian`, `DianLiang`, `WenDu`, `Date` ) " +
        "VALUES ( \"1\",\"2\",\"3\",\"" + temp_array_str[0] + "\",\"" + temp_array_str[1] + "\",\"" + temp_array_str[2] + "\",\"" + temp_array_str[3] + "\",\"" + temp_array_str[4] + "\",\"" + temp_array_str[5] + "\",\"" + temp_array_str[6] + "\",\"" + temp_array_str[7] + "\",now());";
            MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, str, null);

            Init_test5_Mem_array(ref test5_Mem_array, size_chanel);
        }
        #endregion

        




        //tab2
        public void Init_Tab2_ComboBox()
        {
            Tab2_ComboBox.Items.Clear();
            Tab2_ComboBox.Items.Add("用户维护");
            Tab2_ComboBox.Items.Add("节点维护");
            Tab2_ComboBox.Items.Add("地图维护");
            Tab2_ComboBox.Items.Add("其他");
            //Tab2_ComboBox.Items.Add(" ");
        }

        private void Tab2_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab2_ComboBox.SelectedItem == null)
                return;
            switch (Tab2_ComboBox.SelectedItem.ToString())
            {
                case "用户维护":
                    tabcontrol.SelectedIndex = 3;
                    break;
                case "节点维护":
                    tabcontrol.SelectedIndex = 4;
                    break;
                case "地图维护":
                    tabcontrol.SelectedIndex = 5;
                    break;
                case "其他":
                    tabcontrol.SelectedIndex = 6;
                    break;
            }
        }

        private void Tab2_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 0;
            Init_Tab1_ComboBox();
        }

        

        //Tab用户维护
        private void Tab4_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }

        //节点维护
        private void Tab5_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }

        

        //其他
        private void Tab7_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }

                
    }

    public class test5_mem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string id;
        private string name;
        private string type;
        private string gas_type;
        private string danwei;

        private string status;
        private string nongdu;
        private string dixian;
        private string gaoxian;
        private string dianliang;

        private string wendu;
        private string date;

        public string ID
        {
            get { return id; }
            set
            {
                if(value == null)
                {
                    id = " ";
                }
                else
                {
                    id = value;
                }
                OnPropertyChanged("ID");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if(value == null)
                {
                    name = " ";
                }
                else
                {
                    name = value;
                }
                OnPropertyChanged("Name");
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                if(value == null)
                {
                    type = " ";
                }
                else
                {
                    type = value;
                }
                OnPropertyChanged("Type");
            }
        }

        public string Gas_Type
        {
            get { return gas_type; }
            set
            {
                if(value == null)
                {
                    gas_type = " ";
                }
                else
                {
                    gas_type = value;
                }
                OnPropertyChanged("Gas_Type");
            }
        }

        public string DanWei
        {
            get { return danwei; }
            set
            {
                if(value == null)
                {
                    danwei = " ";
                }
                else
                {
                    danwei = value;
                }
                OnPropertyChanged("DanWei");
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                if(value == null)
                {
                    status = " ";
                }
                else
                {
                    status = value;
                }
                OnPropertyChanged("Status");
            }
            
        }

        public string NongDu
        {
            get { return nongdu; }
            set
            {
                if(value == null)
                {
                    nongdu = " ";
                }
                else
                {
                    nongdu = value;
                }
                OnPropertyChanged("NongDu");
            }
        }

        public string DiXian
        {
            get { return dixian; }
            set
            {
                if(value == null)
                {
                    dixian = " ";
                }
                else
                {
                    dixian = value;
                }
                OnPropertyChanged("DiXian");
            }
        }

        public string GaoXian
        {
            get { return gaoxian; }
            set
            {
                if(value == null)
                {
                    gaoxian = " ";
                }
                else
                {
                    gaoxian = value;
                }
                OnPropertyChanged("GaoXian");
            }
        }

        public string DianLiang
        {
            get { return dianliang; }
            set
            {
                if(value == null)
                {
                    dianliang = " ";
                }
                else
                {
                    dianliang = value;
                }
                OnPropertyChanged("DianLiang");
            }
        }

        public string WenDu
        {
            get { return wendu; }
            set
            {
                if(value == null)
                {
                    wendu = " ";
                }
                else
                {
                    wendu = value;
                }
                OnPropertyChanged("WenDu");
            }
        }

        public string Date
        {
            get { return date; }
            set
            {
                if(value == null)
                {
                    date = " ";
                }
                else
                {
                    date = value;
                }
                OnPropertyChanged("Date");
            }
        }

        private void OnPropertyChanged(string strPropertyInfo)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(strPropertyInfo));
            }
        }
    }
}
