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

        const int size_chanel = 64;
        const int size_column = 12;
        public test5_mem[] test5_Mem_array = new test5_mem[size_chanel];

        public UDP_Communication mysql_Thread = new UDP_Communication(new byte[4] { 10, 137, 8, 15 }, 2333);

        public MainWindow()
        {
            InitializeComponent();
            Init_Tab1_ComboBox();
            Init_Tab2_ComboBox();
            Init_Tab3_CurrentStatus_ListView(ref test5_Mem_array, Tab3_CurrentStatus_ListView);
            Init_test5_Mem_array(ref test5_Mem_array, size_chanel);

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

        public void Init_Tab3_CurrentStatus_ListView(ref test5_mem[] test5_Mem_array_tt, ListView listView_tt)
        {
            listView_tt.ItemsSource = test5_Mem_array_tt;
        }

        public void Init_test5_Mem_array(ref test5_mem[] test5_Mem_array_tt, int size_chanel_tt)
        {
            if(test5_Mem_array_tt[0] == null)
            {
                for(int i = 0; i < size_chanel_tt; i++)
                {
                    test5_Mem_array_tt[i] = new test5_mem();
                }
            }

            for (int i = 0; i < size_chanel_tt; i++)
            {
                //DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from test5 where to_days(now())-to_days(Date)<2 and id=\"" + (i + 1).ToString() + "\" order by `Date` desc", null);
                DataSet dataSet_temp = new DataSet();
                //从最近的日期开始查找，如果今天没有数据，就查找近两天的数据，如果近两天也没有，就查找近三天的，以此类推
                for (int j = 1; dataSet_temp.Tables.Count <= 0 || dataSet_temp.Tables[0].Rows.Count <= 0; j++)
                {
                    dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from test5 where to_days(now())-to_days(Date)<" + j.ToString() + " and id=\"" + (i + 1).ToString() + "\" order by `Date` desc", null);
                }

                DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//获取列
                test5_Mem_array_tt[i].ID = temp_DataRow[0][0].ToString();
                test5_Mem_array_tt[i].Name = temp_DataRow[0][1].ToString();
                test5_Mem_array_tt[i].Type = temp_DataRow[0][2].ToString();
                test5_Mem_array_tt[i].Gas_Type = temp_DataRow[0][3].ToString();
                test5_Mem_array_tt[i].DanWei = temp_DataRow[0][4].ToString();

                test5_Mem_array_tt[i].Status = temp_DataRow[0][5].ToString();
                test5_Mem_array_tt[i].NongDu = temp_DataRow[0][6].ToString();
                test5_Mem_array_tt[i].DiXian = temp_DataRow[0][7].ToString();
                test5_Mem_array_tt[i].GaoXian = temp_DataRow[0][8].ToString();
                test5_Mem_array_tt[i].DianLiang = temp_DataRow[0][9].ToString();

                test5_Mem_array_tt[i].WenDu = temp_DataRow[0][10].ToString();
                test5_Mem_array_tt[i].Date = temp_DataRow[0][11].ToString();
            }
        }




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

        //Tab3 用户界面
        private void Tab3_Back_Button_Click(object sender, RoutedEventArgs e)
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

        //地图维护
        private void Tab6_Back_Button_Click(object sender, RoutedEventArgs e)
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

        #region//地图功能的实现
        private void img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown = true;
            previousMousePoint = e.GetPosition(img);
        }

        private void img_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown = false;
        }

        private void img_MouseLeave(object sender, MouseEventArgs e)
        {
            isMouseLeftButtonDown = false;
        }

        private void img_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseLeftButtonDown == true)
            {
                Point position = e.GetPosition(img);
                tlt.X += (position.X - this.previousMousePoint.X) * sfr.ScaleX;
                tlt.Y += (position.Y - this.previousMousePoint.Y) * sfr.ScaleY;

                tlt2.X += (position.X - this.previousMousePoint.X) * sfr.ScaleX;
                tlt2.Y += (position.Y - this.previousMousePoint.Y) * sfr.ScaleY;

            }
        }

        private void img_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sfr.ScaleX < 0.2 && sfr.ScaleY < 0.2 && e.Delta < 0)
            {
                return;
            }
            Point centerPoint = e.GetPosition(img);
            Point pt = img.RenderTransform.Inverse.Transform(centerPoint);
            this.tlt.X = (centerPoint.X - pt.X) * this.sfr.ScaleX;
            this.tlt.Y = (centerPoint.Y - pt.Y) * this.sfr.ScaleY;
            this.sfr.CenterX = centerPoint.X;
            this.sfr.CenterY = centerPoint.Y;
            this.sfr.ScaleX += e.Delta / 1000.0;
            this.sfr.ScaleY += e.Delta / 1000.0;

            Point centerPoint2 = e.GetPosition(rectangle1);
            Point pt2 = rectangle1.RenderTransform.Inverse.Transform(centerPoint2);
            this.tlt2.X = (centerPoint2.X - pt2.X) * this.sfr2.ScaleX;
            this.tlt2.Y = (centerPoint2.Y - pt2.Y) * this.sfr2.ScaleY;
            this.sfr2.CenterX = centerPoint2.X;
            this.sfr2.CenterY = centerPoint2.Y;
            this.sfr2.ScaleX += e.Delta / 1000.0;
            this.sfr2.ScaleY += e.Delta / 1000.0;
        }
        #endregion

        #region//地图功能的实现
        private void img_MouseDown_Tab6(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown_Tab6 = true;
            previousMousePoint_Tab6 = e.GetPosition(img_Tab6);
        }

        private void img_MouseUp_Tab6(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown_Tab6 = false;
        }

        private void img_MouseLeave_Tab6(object sender, MouseEventArgs e)
        {
            isMouseLeftButtonDown_Tab6 = false;
        }

        private void img_MouseMove_Tab6(object sender, MouseEventArgs e)
        {
            if (isMouseLeftButtonDown_Tab6 == true)
            {
                Point position_Tab6 = e.GetPosition(img_Tab6);
                tlt_Tab6.X += (position_Tab6.X - this.previousMousePoint_Tab6.X) * sfr_Tab6.ScaleX;
                tlt_Tab6.Y += (position_Tab6.Y - this.previousMousePoint_Tab6.Y) * sfr_Tab6.ScaleY;

                tlt2_Tab6.X += (position_Tab6.X - this.previousMousePoint_Tab6.X) * sfr_Tab6.ScaleX;
                tlt2_Tab6.Y += (position_Tab6.Y - this.previousMousePoint_Tab6.Y) * sfr_Tab6.ScaleY;

            }
        }

        private void img_MouseWheel_Tab6(object sender, MouseWheelEventArgs e)
        {
            if (sfr_Tab6.ScaleX < 0.2 && sfr_Tab6.ScaleY < 0.2 && e.Delta < 0)
            {
                return;
            }
            Point centerPoint_Tab6 = e.GetPosition(img_Tab6);
            Point pt_Tab6 = img_Tab6.RenderTransform.Inverse.Transform(centerPoint_Tab6);
            this.tlt_Tab6.X = (centerPoint_Tab6.X - pt_Tab6.X) * this.sfr_Tab6.ScaleX;
            this.tlt_Tab6.Y = (centerPoint_Tab6.Y - pt_Tab6.Y) * this.sfr_Tab6.ScaleY;
            this.sfr_Tab6.CenterX = centerPoint_Tab6.X;
            this.sfr_Tab6.CenterY = centerPoint_Tab6.Y;
            this.sfr_Tab6.ScaleX += e.Delta / 1000.0;
            this.sfr_Tab6.ScaleY += e.Delta / 1000.0;

            Point centerPoint2_Tab6 = e.GetPosition(rectangle1_Tab6);
            Point pt2_Tab6 = rectangle1_Tab6.RenderTransform.Inverse.Transform(centerPoint2_Tab6);
            this.tlt2_Tab6.X = (centerPoint2_Tab6.X - pt2_Tab6.X) * this.sfr2_Tab6.ScaleX;
            this.tlt2_Tab6.Y = (centerPoint2_Tab6.Y - pt2_Tab6.Y) * this.sfr2_Tab6.ScaleY;
            this.sfr2_Tab6.CenterX = centerPoint2_Tab6.X;
            this.sfr2_Tab6.CenterY = centerPoint2_Tab6.Y;
            this.sfr2_Tab6.ScaleX += e.Delta / 1000.0;
            this.sfr2_Tab6.ScaleY += e.Delta / 1000.0;
        }
        #endregion
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
