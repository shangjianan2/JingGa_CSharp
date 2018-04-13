using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySQL_Funtion;
using Excel = Microsoft.Office.Interop.Excel;

using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        DateTime date_begin = new DateTime();
        DateTime date_end = new DateTime();
        ListViewItem[] lvi_excel = new ListViewItem[] { };

        public string[] CurrentTime()
        {
            string[] output_str = null;
            string CurrentTime_YMDHMS = System.DateTime.Now.ToLocalTime().ToString();
            output_str = CurrentTime_YMDHMS.Split(':');
            output_str = output_str[0].Split('/', ' ');


            return output_str;
        }

        public void Init_ShiJianQuJian_ComboBox_CurrentTime()
        {
            string[] time_str_array = null;
            //���뿪��ʱ��
            time_str_array = CurrentTime();
            BeginYear_ComboBox.Text = time_str_array[0];
            EndYear_ComboBox.Text = time_str_array[0];

            BeginMonth_ComboBox.Text = time_str_array[1];
            EndMonth_ComboBox.Text = time_str_array[1];

            BeginDay_ComboBox.Text = time_str_array[2];
            EndDay_ComboBox.Text = time_str_array[2];

            BeginHour_ComboBox.Text = time_str_array[3];
            EndHour_ComboBox.Text = time_str_array[3];
        }

        public void Init_ShiJianQuJian_GroupBox()
        {       
            BeginYear_ComboBox.Items.Add("2017");
            BeginYear_ComboBox.Items.Add("2018");

            EndYear_ComboBox.Items.Add("2017");
            EndYear_ComboBox.Items.Add("2018");

            for (int i = 0; i < 12; i++)
            {
                BeginMonth_ComboBox.Items.Add((i + 1).ToString());
                EndMonth_ComboBox.Items.Add((i + 1).ToString());
            }

            for (int i = 0; i < 31; i++)
            {
                BeginDay_ComboBox.Items.Add((i + 1).ToString());
                EndDay_ComboBox.Items.Add((i + 1).ToString());
            }

            for (int i = 0; i < 24; i++)
            {
                BeginHour_ComboBox.Items.Add((i + 1).ToString());
                EndHour_ComboBox.Items.Add((i + 1).ToString());
            }

            for(int i = 0; i < size_chanel; i++)
            {
                ChanelNum_ComboBox.Items.Add((i + 1).ToString());
            }
            ChanelNum_ComboBox.Items.Add("None");

            Init_ShiJianQuJian_ComboBox_CurrentTime();
        }

        private void OutputExcel_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string temp_str_begin = BeginYear_ComboBox.Text + " " + BeginMonth_ComboBox.Text + " " + BeginDay_ComboBox.Text + " " + BeginHour_ComboBox.Text;
                string temp_str_end = EndYear_ComboBox.Text + " " + EndMonth_ComboBox.Text + " " + EndDay_ComboBox.Text + " " + EndHour_ComboBox.Text;
                date_begin = DateTime.ParseExact(temp_str_begin, "yyyy M d H", null);
                date_end = DateTime.ParseExact(temp_str_end, "yyyy M d H", null);

                #region
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.DefaultExt = "xls";
                sfd.Filter = "�ļ�(*.xls)|*.xls";
                OutputExcel_Button.Content = "������...";
                if (sfd.ShowDialog() == true)
                {                    
                    output_excel(sfd.FileName);
                    OutputExcel_Button.Content = "";
                }
                #endregion
            }
            catch
            {
                MessageBox.Show("���ڸ�ʽ����", "error");
                return;
            }


}

        public void output_excel(string strFileName)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {

                MessageBox.Show("�޷�����excel���󣬿�������ϵͳû�а�װexcel");

                return;

            }

            xlApp.DefaultFilePath = "";

            xlApp.DisplayAlerts = true;

            xlApp.SheetsInNewWorkbook = 1;

            Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);

            //����б�ͷ
            DataSet temp_dataset = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "show columns from test5;", null);
            DataRowCollection temp_dataRow = temp_dataset.Tables[0].Rows;
            for (int i = 0; i < temp_dataRow.Count; i++)
            {
                //listView_tt.Columns.Add(temp_dataRow[i][0].ToString(), 50);
                xlApp.Cells[1, (i + 1)] = temp_dataRow[i][0].ToString();
            }



            //�����
            string dataSet_temp_str = "select * from test5 where `Date`>=\"" + date_begin.ToString() + "\" and `Date`<=\"" + date_end.ToString() + "\" order by `Date` desc";
            //string dataSet_temp_str = "select * from test5 order by `Date` desc";
            DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, dataSet_temp_str, null);
            DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//��ȡ��

            //��ListView�е����ݵ���Excel��
            for (int i = 0; i < temp_DataRow.Count; i++)
            {
                for (int j = 0; j < temp_dataRow.Count; j++)
                {
                    //ע������ڵ�����ʱ����ˡ�\t�� ��Ŀ�ľ��Ǳ��⵼����������ʾΪ��ѧ�����������Է���ÿ�е���β��

                    xlApp.Cells[(i + 2), (j + 1)] = temp_DataRow[i][j].ToString() + "\t";

                }

            }

            //������Ҫ˵��������strFileName,Excel.XlFileFormat.xlExcel9795���淽ʽʱ �����Excel�汾����95��97 ����2003��2007 ʱ������ʱ��ᱨһ�������쳣���� HRESULT:0x800A03EC�� ����취���ǻ���strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal��

            xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, false, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlBook.Close();
            xlApp = null;

            xlBook = null;

            MessageBox.Show("���ɱ������");
        }

        //public void Update_Excel_ListView(ListView listView_tt, ListViewItem[] listViewItem_tt)
        //{
        //    listView_tt.Items.Clear();//����ϴ�����
        //    listView_tt.Columns.Clear();//ÿ�ζ������ͷ

        //    //����б�ͷ
        //    DataSet temp_dataset = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "show columns from test5;", null);
        //    DataRowCollection temp_dataRow = temp_dataset.Tables[0].Rows;
        //    for(int i = 0; i < temp_dataRow.Count; i++)
        //    {
        //        listView_tt.Columns.Add(temp_dataRow[i][0].ToString(), 50);
        //    }
        //    //DataColumnCollection temp_DataColumn = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from test5 where to_days(now())-to_days(Date)<2 and id=\"1\" order by `Date` desc", null).Tables[0].Columns;
        //    //for (int i = 0; i < temp_DataColumn.Count - 1; i++)
        //    //{
        //    //    listView_tt.Columns.Add(temp_DataColumn[i].Caption, 50);
        //    //}
        //    //listView_tt.Columns.Add(temp_DataColumn[(temp_DataColumn.Count - 1)].Caption, 150);


        //    //�����
        //    string dataSet_temp_str = "select * from test5 where `Date`>=\"" + date_begin.ToString() + "\" and `Date`<=\"" + date_end.ToString() + "\" order by `Date` desc";
        //    DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, dataSet_temp_str, null);
        //    DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//��ȡ��
        //    listViewItem_tt = new ListViewItem[temp_DataRow.Count];
        //    for (int i = 0; i < temp_DataRow.Count; i++)//
        //    {
        //        listViewItem_tt[i] = new ListViewItem();
        //        listViewItem_tt[i].ImageIndex = 0;
        //        listViewItem_tt[i].Text = temp_DataRow[i][0].ToString();//����һ��¼��
        //        for (int j = 1; j <= temp_dataRow.Count - 1; j++)
        //        {
        //            listViewItem_tt[i].SubItems.Add(temp_DataRow[i][j].ToString());//����һ��¼��
        //        }
        //    }
                     

        //    listView_tt.BeginUpdate();
        //    for (int i = 0; i < temp_DataRow.Count; i++)
        //    {
        //        listView_tt.Items.Add(listViewItem_tt[i]);
        //    }
        //    listView_tt.EndUpdate();

        //    #region
        //    System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();//ע�� ������SaveFileDialog,����OpenFileDialog
        //    sfd.DefaultExt = "xls";
        //    sfd.Filter = "�ļ�(*.xls)|*.xls";
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        DoExport(listView_tt, sfd.FileName);//���ϵ�����
        //    }
        //    #endregion
        //}

        ///*****************************excel**********************************************/
        //public void DoExport(ListView listView, string strFileName)
        //{

        //    int rowNum = listView.Items.Count;

        //    int columnNum = listView.Items[0].SubItems.Count;

        //    int rowIndex = 1;

        //    int columnIndex = 0;

        //    if (rowNum == 0 || string.IsNullOrEmpty(strFileName))
        //    {

        //        return;

        //    }

        //    if (rowNum > 0)
        //    {



        //        Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();

        //        if (xlApp == null)
        //        {

        //            MessageBox.Show("�޷�����excel���󣬿�������ϵͳû�а�װexcel");

        //            return;

        //        }

        //        xlApp.DefaultFilePath = "";

        //        xlApp.DisplayAlerts = true;

        //        xlApp.SheetsInNewWorkbook = 1;

        //        Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);

        //        //��ListView����������Excel���һ��

        //        foreach (ColumnHeader dc in listView.Columns)
        //        {

        //            columnIndex++;

        //            xlApp.Cells[rowIndex, columnIndex] = dc.Text;

        //        }

        //        //��ListView�е����ݵ���Excel��

        //        for (int i = 0; i < rowNum; i++)
        //        {

        //            rowIndex++;

        //            columnIndex = 0;

        //            for (int j = 0; j < columnNum; j++)
        //            {

        //                columnIndex++;

        //                //ע������ڵ�����ʱ����ˡ�\t�� ��Ŀ�ľ��Ǳ��⵼����������ʾΪ��ѧ�����������Է���ÿ�е���β��

        //                xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";

        //            }

        //        }

        //        //������Ҫ˵��������strFileName,Excel.XlFileFormat.xlExcel9795���淽ʽʱ �����Excel�汾����95��97 ����2003��2007 ʱ������ʱ��ᱨһ�������쳣���� HRESULT:0x800A03EC�� ����취���ǻ���strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal��

        //        xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, false, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //        xlBook.Close();
        //        xlApp = null;

        //        xlBook = null;

        //        MessageBox.Show("���ɱ������");

        //    }

        //}
    }
}