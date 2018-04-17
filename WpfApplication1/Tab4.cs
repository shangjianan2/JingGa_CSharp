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
        public test5_mem_Tab4[] test5_Mem_Tab4_array = new test5_mem_Tab4[size_chanel];//这里用size_chanel代表可显示的最大用户量
        public int CurrentLength_test5_Mem_Tab4_array = 0;

        public void Init_Tab4_CurrentStatus_ListView(ref test5_mem_Tab4[] test5_Mem_Tab4_array_tt, ListView listView_tt)
        {
            listView_tt.ItemsSource = test5_Mem_Tab4_array_tt;
        }

        public void Init_test5_Mem_Tab4_array(ref test5_mem_Tab4[] test5_Mem_array_tt)
        {
            //添加列
            string dataSet_temp_str = "select * from users";
            DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, dataSet_temp_str, null);
            DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//获取列

            CurrentLength_test5_Mem_Tab4_array = temp_DataRow.Count;//把当前数据库中数据的数量赋值给CurrentLength_test5_Mem_Tab4_array

            for (int i = 0; i < temp_DataRow.Count; i++)//
            {
                test5_Mem_array_tt[i] = new test5_mem_Tab4();
                test5_Mem_array_tt[i].UserName = temp_DataRow[i][0].ToString();//添加用户名
                test5_Mem_array_tt[i].PassWord = temp_DataRow[i][1].ToString();//添加用户密码
            }
        }

        private void Tab4_AddUser_Button_Click(object sender, EventArgs e)
        {
            if (Tab4_AddUserName_TextBox.Text == "" || Tab4_AddPassWord_TextBox.Text == "")
                return;

            //insert into users (`name`, `password`) VALUES ( );
            string temp_str = "insert into users (`name`, `password`) VALUES ( \"" + Tab4_AddUserName_TextBox.Text + "\", \"" + Tab4_AddPassWord_TextBox.Text + "\" );";
            try
            {
                MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, temp_str, null);
                CurrentLength_test5_Mem_Tab4_array++;//如果运行到这里说明已经成功添加，所以将当前用户数量计数器的数值增加
            }
            catch
            {
                MessageBox.Show("此用户已添加", "error");
            }
            Tab4_User_ListView.Items.Refresh();//添加这个就好使
            //为Tab4（用户维护界面）中的listview初始化
            //Init_Tab4_CurrentStatus_ListView(ref test5_Mem_Tab4_array, Tab4_User_ListView);
            Init_test5_Mem_Tab4_array(ref test5_Mem_Tab4_array);
            Init_Tab1_ComboBox();
        }

        private void Tab4_DeleteUser_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //int temp_index = Tab4_User_ListView.SelectedItems[0].Index;
                //string DeletedUser = ExistYongHu_YongHuWeiHu_ListView.Items[temp_index].SubItems[0].Text;

                //if (DeletedUser == "root")//不能删除root用户
                //    return;

                //MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                //DialogResult dr = MessageBox.Show("确定要删除？", "用户删除", messButton);
                //if (dr == DialogResult.OK)
                //{
                //    string command_str = "delete from users where name=\"" + DeletedUser + "\"";
                //    MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, command_str, null);
                //}
                //else
                //{
                //    return;//既然没有做出改变，就不用进行Update_ExistYongHu_YongHuWeiHu_ListView和Init_Login_ComboBox
                //}

                string DeletedUser = test5_Mem_Tab4_array[Tab4_User_ListView.SelectedIndex].UserName;

                if (DeletedUser == "root")//不能删除root用户
                    return;

                if (System.Windows.MessageBox.Show("您确定要删除吗？", "提示：", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    string command_str = "delete from users where name=\"" + DeletedUser + "\"";
                    MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, command_str, null);
                    CurrentLength_test5_Mem_Tab4_array--;//如果运行到这里，说明成功从数据库中删除数据。所以将计数器减一
                }
                else
                {
                    return;
                }

                //System.Diagnostics.Debug.WriteLine("{0}", Tab4_User_ListView.SelectedIndex);
                //test5_Mem_Tab4_array = new test5_mem_Tab4[size_chanel];
                test5_Mem_Tab4_array[CurrentLength_test5_Mem_Tab4_array] = null;//清除最后一项
                Tab4_User_ListView.Items.Refresh();//添加这个就好使
                
                Init_test5_Mem_Tab4_array(ref test5_Mem_Tab4_array);
                Init_Tab1_ComboBox();

            }
            catch
            {
                MessageBox.Show("请选择一个用户", "error");
            }
            //Init_test5_Mem_Tab4_array(ref test5_Mem_Tab4_array);
            //Init_Tab1_ComboBox();
        }

        //Tab用户维护
        private void Tab4_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }
    }
}