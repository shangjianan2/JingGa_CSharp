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
        public test5_mem_Tab4[] test5_Mem_Tab4_array = new test5_mem_Tab4[size_chanel];

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

            for (int i = 0; i < temp_DataRow.Count; i++)//
            {
                test5_Mem_array_tt[i] = new test5_mem_Tab4();
                test5_Mem_array_tt[i].UserName = temp_DataRow[i][0].ToString();//����û���
                test5_Mem_array_tt[i].PassWord = temp_DataRow[i][1].ToString();//����û�����
            }
        }

        //Tab�û�ά��
        private void Tab4_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }
    }
}