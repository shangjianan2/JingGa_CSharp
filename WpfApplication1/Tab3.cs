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
        //这里的代码是用户界面 还有部分代码存放在ShiJianQuJian_GroupBox.cs文件中（主要是有关于excel生成的代码）
        const int size_chanel = 64;
        const int size_column = 12;
        public test5_mem[] test5_Mem_array = new test5_mem[size_chanel];

        
        public void Init_Tab3_CurrentStatus_ListView(ref test5_mem[] test5_Mem_array_tt, ListView listView_tt)
        {
            listView_tt.ItemsSource = test5_Mem_array_tt;
        }

        public void Init_test5_Mem_array(ref test5_mem[] test5_Mem_array_tt, int size_chanel_tt)
        {
            if (test5_Mem_array_tt[0] == null)
            {
                for (int i = 0; i < size_chanel_tt; i++)
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

        //Tab3 用户界面
        private void Tab3_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 0;
            Init_Tab1_ComboBox();            
        }
    }
}