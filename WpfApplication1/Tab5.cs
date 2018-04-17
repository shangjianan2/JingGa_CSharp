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
        public test5_mem_Tab5[] test5_Mem_Tab5_array = new test5_mem_Tab5[size_chanel];//������size_chanel�������ʾ������û���
        public int CurrentLength_test5_Mem_Tab5_array = 0;

        public void Init_Tab5_CurrentStatus_ListView(ref test5_mem_Tab5[] test5_Mem_Tab5_array_tt, ListView listView_tt)
        {
            listView_tt.ItemsSource = test5_Mem_Tab5_array_tt;
        }

        public void Init_test5_Mem_Tab5_array(ref test5_mem_Tab5[] test5_Mem_array_tt)
        {
            //�����
            string dataSet_temp_str = "select * from jiedian";
            DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, dataSet_temp_str, null);
            DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//��ȡ��

            CurrentLength_test5_Mem_Tab5_array = temp_DataRow.Count;//�ѵ�ǰ���ݿ������ݵ�������ֵ��CurrentLength_test5_Mem_Tab5_array

            for (int i = 0; i < temp_DataRow.Count; i++)//
            {
                test5_Mem_array_tt[i] = new test5_mem_Tab5();
                test5_Mem_array_tt[i].ID = temp_DataRow[i][0].ToString();//
                test5_Mem_array_tt[i].Name = temp_DataRow[i][1].ToString();//
                test5_Mem_array_tt[i].BianMa = temp_DataRow[i][2].ToString();//
                test5_Mem_array_tt[i].ShuoMing = temp_DataRow[i][3].ToString();//
            }
        }

        private void Tab5_AddUser_Button_Click(object sender, EventArgs e)
        {
            if (Tab5_AddID_TextBox.Text == "" || Tab5_AddName_TextBox.Text == "" || Tab5_AddBianMa_TextBox.Text == "")
                return;

            //insert into users (`name`, `password`) VALUES ( );
            string temp_str = "insert into jiedian (`id`, `name`, `bianma`, `shuoming`) VALUES ( \"" + Tab5_AddID_TextBox.Text + "\", \"" + Tab5_AddName_TextBox.Text + "\", \"" + Tab5_AddBianMa_TextBox.Text + "\", \"" + Tab5_AddShuoMing_TextBox.Text + "\" );";
            try
            {
                MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, temp_str, null);
                CurrentLength_test5_Mem_Tab5_array++;//������е�����˵���Ѿ��ɹ���ӣ����Խ���ǰ�û���������������ֵ����
            }
            catch
            {
                MessageBox.Show("���û������", "error");
            }
            Tab5_JieDian_ListView.Items.Refresh();//�������ͺ�ʹ
            //ΪTab5���û�ά�����棩�е�listview��ʼ��
            //Init_Tab5_CurrentStatus_ListView(ref test5_Mem_Tab5_array, Tab5_JieDian_ListView);
            Init_test5_Mem_Tab5_array(ref test5_Mem_Tab5_array);
            Init_Tab1_ComboBox();
        }

        private void Tab5_DeleteUser_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string DeletedID = test5_Mem_Tab5_array[Tab5_JieDian_ListView.SelectedIndex].ID;
                
                if (System.Windows.MessageBox.Show("��ȷ��Ҫɾ����", "��ʾ��", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    string command_str = "delete from jiedian where id=\"" + DeletedID + "\"";
                    MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, command_str, null);
                    CurrentLength_test5_Mem_Tab5_array--;//������е����˵���ɹ������ݿ���ɾ�����ݡ����Խ���������һ
                }
                else
                {
                    return;
                }
                
                test5_Mem_Tab5_array[CurrentLength_test5_Mem_Tab5_array] = null;//������һ��
                Tab5_JieDian_ListView.Items.Refresh();//�������ͺ�ʹ
                
                Init_test5_Mem_Tab5_array(ref test5_Mem_Tab5_array);
                Init_Tab1_ComboBox();

            }
            catch
            {
                MessageBox.Show("��ѡ��һ���û�", "error");
            }
        }
        
        //�ڵ�ά��
        private void Tab5_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }
    }
}