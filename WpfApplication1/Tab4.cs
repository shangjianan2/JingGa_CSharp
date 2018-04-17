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
    /// Window1.xaml �Ľ����߼�
    /// </summary>
    public partial class MainWindow : Window
    {
        public test5_mem_Tab4[] test5_Mem_Tab4_array = new test5_mem_Tab4[size_chanel];//������size_chanel�������ʾ������û���
        public int CurrentLength_test5_Mem_Tab4_array = 0;

        public void Init_Tab4_CurrentStatus_ListView(ref test5_mem_Tab4[] test5_Mem_Tab4_array_tt, ListView listView_tt)
        {
            listView_tt.ItemsSource = test5_Mem_Tab4_array_tt;
        }

        public void Init_test5_Mem_Tab4_array(ref test5_mem_Tab4[] test5_Mem_array_tt)
        {
            //�����
            string dataSet_temp_str = "select * from users";
            DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, dataSet_temp_str, null);
            DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//��ȡ��

            CurrentLength_test5_Mem_Tab4_array = temp_DataRow.Count;//�ѵ�ǰ���ݿ������ݵ�������ֵ��CurrentLength_test5_Mem_Tab4_array

            for (int i = 0; i < temp_DataRow.Count; i++)//
            {
                test5_Mem_array_tt[i] = new test5_mem_Tab4();
                test5_Mem_array_tt[i].UserName = temp_DataRow[i][0].ToString();//����û���
                test5_Mem_array_tt[i].PassWord = temp_DataRow[i][1].ToString();//����û�����
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
                CurrentLength_test5_Mem_Tab4_array++;//������е�����˵���Ѿ��ɹ���ӣ����Խ���ǰ�û���������������ֵ����
            }
            catch
            {
                MessageBox.Show("���û������", "error");
            }
            Tab4_User_ListView.Items.Refresh();//�������ͺ�ʹ
            //ΪTab4���û�ά�����棩�е�listview��ʼ��
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

                //if (DeletedUser == "root")//����ɾ��root�û�
                //    return;

                //MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                //DialogResult dr = MessageBox.Show("ȷ��Ҫɾ����", "�û�ɾ��", messButton);
                //if (dr == DialogResult.OK)
                //{
                //    string command_str = "delete from users where name=\"" + DeletedUser + "\"";
                //    MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, command_str, null);
                //}
                //else
                //{
                //    return;//��Ȼû�������ı䣬�Ͳ��ý���Update_ExistYongHu_YongHuWeiHu_ListView��Init_Login_ComboBox
                //}

                string DeletedUser = test5_Mem_Tab4_array[Tab4_User_ListView.SelectedIndex].UserName;

                if (DeletedUser == "root")//����ɾ��root�û�
                    return;

                if (System.Windows.MessageBox.Show("��ȷ��Ҫɾ����", "��ʾ��", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    string command_str = "delete from users where name=\"" + DeletedUser + "\"";
                    MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, command_str, null);
                    CurrentLength_test5_Mem_Tab4_array--;//������е����˵���ɹ������ݿ���ɾ�����ݡ����Խ���������һ
                }
                else
                {
                    return;
                }

                //System.Diagnostics.Debug.WriteLine("{0}", Tab4_User_ListView.SelectedIndex);
                //test5_Mem_Tab4_array = new test5_mem_Tab4[size_chanel];
                test5_Mem_Tab4_array[CurrentLength_test5_Mem_Tab4_array] = null;//������һ��
                Tab4_User_ListView.Items.Refresh();//�������ͺ�ʹ
                
                Init_test5_Mem_Tab4_array(ref test5_Mem_Tab4_array);
                Init_Tab1_ComboBox();

            }
            catch
            {
                MessageBox.Show("��ѡ��һ���û�", "error");
            }
            //Init_test5_Mem_Tab4_array(ref test5_Mem_Tab4_array);
            //Init_Tab1_ComboBox();
        }

        //Tab�û�ά��
        private void Tab4_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }
    }
}