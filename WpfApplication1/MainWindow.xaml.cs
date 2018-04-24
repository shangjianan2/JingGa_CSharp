//#define YanShi
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
using IP_PeiZhiWenJian_JieXi;
using Map_PeiZhiWenJian_JieXi;

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

        public UDP_Communication mysql_Thread = null;

        private System.Threading.Timer SendToIoT = null;
        
        IP_PZWJ_JieXi IP_WJ_JieXi = null;

        public int[,] JieDianZuoBiao_Array_int = new int[size_chanel, 2];
        public string map_LuJing = null;


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

            Init_translateTransform_Array_Tab3();
            Init_scaleTransform_Array_Tab3();
            Init_rectangle_Array_Tab3();

            Init_UDP();//初始化udp通讯，

            Init_Map();







            //为Tab4（用户维护界面）中的listview初始化
            Init_Tab4_CurrentStatus_ListView(ref test5_Mem_Tab4_array, Tab4_User_ListView);
            Init_test5_Mem_Tab4_array(ref test5_Mem_Tab4_array);

            //Tab5界面初始化
            Init_Tab5_CurrentStatus_ListView(ref test5_Mem_Tab5_array, Tab5_JieDian_ListView);
            Init_test5_Mem_Tab5_array(ref test5_Mem_Tab5_array);

#if YanShi
            tabcontrol.SelectedIndex = 7;
#endif
        }

        public void Init_Map()
        {
            map_PZWJ_JieXi.get_JieDianZuoBiao("C:\\NBIoT\\map.txt", size_chanel, ref JieDianZuoBiao_Array_int);
            map_PZWJ_JieXi.get_DiTuLuJing("C:\\NBIoT\\map.txt", size_chanel, ref map_LuJing);

            clear_img_canvas();//将地图的图片位置归零
            clear_tlt();//将每个矩形的tlt清零
            clear_scale();//将所有的放大倍数归零（具体是不是放大倍数我也不知道，反正就是将之前所有因为操作而更改的数据全部复位，其中放大倍数应该为1）


            for(int i = 0; i < size_chanel; i++)
            {
                change_XY_rectangle(rectangle_Array[i], Convert.ToDouble(JieDianZuoBiao_Array_int[i, 0]), Convert.ToDouble(JieDianZuoBiao_Array_int[i, 1]));
            }
            img_Tab6.Source = new BitmapImage(new Uri(map_LuJing));

            update_map_Tab3();
        }

        public void Init_UDP()
        {
            byte[] IP_byte_array = new byte[4];
            int DuanKou_in = 0;
            Init_PeiZhiIPAddress(ref IP_byte_array, ref DuanKou_in);
            //初始化udp通讯类
            mysql_Thread = new UDP_Communication(IP_byte_array, DuanKou_in);
            //注册事件
            mysql_Thread.rev_New2 += new recNewMessage2(rec2_NewMessage_Form1);
            mysql_Thread.recThread_Start();

            Init_NBIoT();//将NBIoT的远程地址绑定

            //添加定时器，因为长时间上位机不向下位机发送指令上位机与云平台会断线
            SendToIoT = new System.Threading.Timer(new System.Threading.TimerCallback(SendToIoTCall), this, 3000, 3000);
        }

        public void Init_PeiZhiIPAddress(ref byte[] temp_byte_array, ref int temp_duankou_int)
        {
            try
            {
                #region
                
                IP_WJ_JieXi = new IP_PZWJ_JieXi("C:\\NBIoT\\IP.txt");
                temp_byte_array = IP_WJ_JieXi.IP;
                temp_duankou_int = IP_WJ_JieXi.DuanKou;
                #endregion
            }
            catch
            {
                MessageBox.Show("IP配置文件加载失败", "加载失败");
            }
        }

        public void SendToIoTCall(object state)
        {
            string temp_str = "ep=J4JFAJUGYS3GGF7Z&pw=123456";
            byte[] buff = System.Text.Encoding.ASCII.GetBytes(temp_str);

            //byte[] array_byte = new byte[4] { 115, 29, 240, 46 };//设定远程ip地址
            //IPAddress ip = new IPAddress(array_byte);
            //IPEndPoint lep = new IPEndPoint(ip, 6000);

            //mysql_Thread.newsock.Connect(lep);
            mysql_Thread.newsock.Send(buff);

#if YanShi
            if(flag_Tab8 >= 2)
            {
                
            }
            else if(flag_Tab8 < 1)
            {
                flag_Tab8++;
            }
            else
            {
                Action<bool> action_tt = (x) =>
                {
                    tabcontrol.SelectedIndex = 0;//开启登陆界面
                };
                this.Dispatcher.Invoke(action_tt, true);
                
                flag_Tab8++;
            }
#endif
        }

        public void Init_NBIoT()
        {
            string temp_str = "ep=J4JFAJUGYS3GGF7Z&pw=123456";
            byte[] buff = System.Text.Encoding.ASCII.GetBytes(temp_str);
            
            byte[] array_byte = new byte[4] { 115, 29, 240, 46 };//设定远程ip地址
            IPAddress ip = new IPAddress(array_byte);
            IPEndPoint lep = new IPEndPoint(ip, 6000);
            
            mysql_Thread.newsock.Connect(lep);
            mysql_Thread.newsock.Send(buff);
        }

#region//rec2_NewMessage_Form1函数是rec_NewMessage_Form1函数的新的实现，可以返回源地址和源端口
        public void rec2_NewMessage_Form1(byte[] message, ref EndPoint endPoint_tt)
        {
            //if (message.Length != 14)//数据的有效性还需要检验，但是暂时没有想到靠谱的方法
            //    return;
            string temp_str = System.Text.Encoding.ASCII.GetString(message);
            //if (temp_str == "[iotxx:ok]" || temp_str == "[iotxx:update]")//[iotxx:ok]
            if (temp_str.Contains("[iotxx:"))
            {
                System.Diagnostics.Debug.WriteLine("[iotxx:ok]");
                return;
            }

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

    public class test5_mem_Tab4 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        private string username;
        private string password;

        public string UserName
        {
            get { return username; }
            set
            {
                if (value == null)
                {
                    username = " ";
                }
                else
                {
                    username = value;
                }
                OnPropertyChanged("UserName");
            }
        }

        public string PassWord
        {
            get { return password; }
            set
            {
                if (value == null)
                {
                    password = " ";
                }
                else
                {
                    password = value;
                }
                OnPropertyChanged("PassWord");
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

    public class test5_mem_Tab5 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string id;
        private string name;
        private string bianma;
        private string shuoming;

        public string ID
        {
            get { return id; }
            set
            {
                if (value == null)
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
                if (value == null)
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

        public string BianMa
        {
            get { return bianma; }
            set
            {
                if (value == null)
                {
                    bianma = " ";
                }
                else
                {
                    bianma = value;
                }
                OnPropertyChanged("BianMa");
            }
        }

        public string ShuoMing
        {
            get { return shuoming; }
            set
            {
                if (value == null)
                {
                    shuoming = " ";
                }
                else
                {
                    shuoming = value;
                }
                OnPropertyChanged("ShuoMing");
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
