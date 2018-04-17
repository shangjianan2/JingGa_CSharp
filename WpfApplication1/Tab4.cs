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
        public test5_mem_Tab4[] test5_Mem_Tab4_array = new test5_mem_Tab4[size_chanel];

        public void Init_Tab4_CurrentStatus_ListView(ref test5_mem_Tab4[] test5_Mem_Tab4_array_tt, ListView listView_tt)
        {
            listView_tt.ItemsSource = test5_Mem_Tab4_array_tt;
        }

        public void Init_test5_Mem_Tab4_array(ref test5_mem_Tab4[] test5_Mem_array_tt)
        {
            //if (test5_Mem_array_tt[0] == null)
            //{
            //    for (int i = 0; i < size_chanel_tt; i++)
            //    {
            //        test5_Mem_array_tt[i] = new test5_mem();
            //    }
            //}

            //for (int i = 0; i < size_chanel_tt; i++)
            //{
            //    //DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from test5 where to_days(now())-to_days(Date)<2 and id=\"" + (i + 1).ToString() + "\" order by `Date` desc", null);
            //    DataSet dataSet_temp = new DataSet();
            //    //从最近的日期开始查找，如果今天没有数据，就查找近两天的数据，如果近两天也没有，就查找近三天的，以此类推
            //    for (int j = 1; dataSet_temp.Tables.Count <= 0 || dataSet_temp.Tables[0].Rows.Count <= 0; j++)
            //    {
            //        dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from test5 where to_days(now())-to_days(Date)<" + j.ToString() + " and id=\"" + (i + 1).ToString() + "\" order by `Date` desc", null);
            //    }

            //    DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//获取列
            //    test5_Mem_array_tt[i].ID = temp_DataRow[0][0].ToString();
            //    test5_Mem_array_tt[i].Name = temp_DataRow[0][1].ToString();
            //    test5_Mem_array_tt[i].Type = temp_DataRow[0][2].ToString();
            //    test5_Mem_array_tt[i].Gas_Type = temp_DataRow[0][3].ToString();
            //    test5_Mem_array_tt[i].DanWei = temp_DataRow[0][4].ToString();

            //    test5_Mem_array_tt[i].Status = temp_DataRow[0][5].ToString();
            //    test5_Mem_array_tt[i].NongDu = temp_DataRow[0][6].ToString();
            //    test5_Mem_array_tt[i].DiXian = temp_DataRow[0][7].ToString();
            //    test5_Mem_array_tt[i].GaoXian = temp_DataRow[0][8].ToString();
            //    test5_Mem_array_tt[i].DianLiang = temp_DataRow[0][9].ToString();

            //    test5_Mem_array_tt[i].WenDu = temp_DataRow[0][10].ToString();
            //    test5_Mem_array_tt[i].Date = temp_DataRow[0][11].ToString();
            //}



            //添加列
            string dataSet_temp_str = "select * from users";
            DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, dataSet_temp_str, null);
            DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//获取列

            for (int i = 0; i < temp_DataRow.Count; i++)//
            {
                test5_Mem_array_tt[i] = new test5_mem_Tab4();
                test5_Mem_array_tt[i].UserName = temp_DataRow[i][0].ToString();
                test5_Mem_array_tt[i].PassWord = temp_DataRow[i][1].ToString();
            }
        }

        //Tab用户维护
        private void Tab4_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }
    }
}