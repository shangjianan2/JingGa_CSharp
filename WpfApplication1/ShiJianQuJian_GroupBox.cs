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
            //输入开机时间
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
                sfd.Filter = "文件(*.xls)|*.xls";
                OutputExcel_Button.Content = "保存中...";
                if (sfd.ShowDialog() == true)
                {                    
                    output_excel(sfd.FileName);
                    OutputExcel_Button.Content = "";
                }
                #endregion
            }
            catch
            {
                MessageBox.Show("日期格式错误", "error");
                return;
            }


}

        public void output_excel(string strFileName)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {

                MessageBox.Show("无法创建excel对象，可能您的系统没有安装excel");

                return;

            }

            xlApp.DefaultFilePath = "";

            xlApp.DisplayAlerts = true;

            xlApp.SheetsInNewWorkbook = 1;

            Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);

            //添加列表头
            DataSet temp_dataset = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "show columns from test5;", null);
            DataRowCollection temp_dataRow = temp_dataset.Tables[0].Rows;
            for (int i = 0; i < temp_dataRow.Count; i++)
            {
                //listView_tt.Columns.Add(temp_dataRow[i][0].ToString(), 50);
                xlApp.Cells[1, (i + 1)] = temp_dataRow[i][0].ToString();
            }



            //添加列
            string dataSet_temp_str = "select * from test5 where `Date`>=\"" + date_begin.ToString() + "\" and `Date`<=\"" + date_end.ToString() + "\" order by `Date` desc";
            //string dataSet_temp_str = "select * from test5 order by `Date` desc";
            DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, dataSet_temp_str, null);
            DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//获取列

            //将ListView中的数据导入Excel中
            for (int i = 0; i < temp_DataRow.Count; i++)
            {
                for (int j = 0; j < temp_dataRow.Count; j++)
                {
                    //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。

                    xlApp.Cells[(i + 2), (j + 1)] = temp_DataRow[i][j].ToString() + "\t";

                }

            }

            //例外需要说明的是用strFileName,Excel.XlFileFormat.xlExcel9795保存方式时 当你的Excel版本不是95、97 而是2003、2007 时导出的时候会报一个错误：异常来自 HRESULT:0x800A03EC。 解决办法就是换成strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal。

            xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, false, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlBook.Close();
            xlApp = null;

            xlBook = null;

            MessageBox.Show("生成报表完成");
        }

        //public void Update_Excel_ListView(ListView listView_tt, ListViewItem[] listViewItem_tt)
        //{
        //    listView_tt.Items.Clear();//清除上次数据
        //    listView_tt.Columns.Clear();//每次都清除表头

        //    //添加列表头
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


        //    //添加列
        //    string dataSet_temp_str = "select * from test5 where `Date`>=\"" + date_begin.ToString() + "\" and `Date`<=\"" + date_end.ToString() + "\" order by `Date` desc";
        //    DataSet dataSet_temp = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, dataSet_temp_str, null);
        //    DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//获取列
        //    listViewItem_tt = new ListViewItem[temp_DataRow.Count];
        //    for (int i = 0; i < temp_DataRow.Count; i++)//
        //    {
        //        listViewItem_tt[i] = new ListViewItem();
        //        listViewItem_tt[i].ImageIndex = 0;
        //        listViewItem_tt[i].Text = temp_DataRow[i][0].ToString();//将第一列录入
        //        for (int j = 1; j <= temp_dataRow.Count - 1; j++)
        //        {
        //            listViewItem_tt[i].SubItems.Add(temp_DataRow[i][j].ToString());//将第一列录入
        //        }
        //    }
                     

        //    listView_tt.BeginUpdate();
        //    for (int i = 0; i < temp_DataRow.Count; i++)
        //    {
        //        listView_tt.Items.Add(listViewItem_tt[i]);
        //    }
        //    listView_tt.EndUpdate();

        //    #region
        //    System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();//注意 这里是SaveFileDialog,不是OpenFileDialog
        //    sfd.DefaultExt = "xls";
        //    sfd.Filter = "文件(*.xls)|*.xls";
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        DoExport(listView_tt, sfd.FileName);//网上的例程
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

        //            MessageBox.Show("无法创建excel对象，可能您的系统没有安装excel");

        //            return;

        //        }

        //        xlApp.DefaultFilePath = "";

        //        xlApp.DisplayAlerts = true;

        //        xlApp.SheetsInNewWorkbook = 1;

        //        Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);

        //        //将ListView的列名导入Excel表第一行

        //        foreach (ColumnHeader dc in listView.Columns)
        //        {

        //            columnIndex++;

        //            xlApp.Cells[rowIndex, columnIndex] = dc.Text;

        //        }

        //        //将ListView中的数据导入Excel中

        //        for (int i = 0; i < rowNum; i++)
        //        {

        //            rowIndex++;

        //            columnIndex = 0;

        //            for (int j = 0; j < columnNum; j++)
        //            {

        //                columnIndex++;

        //                //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。

        //                xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";

        //            }

        //        }

        //        //例外需要说明的是用strFileName,Excel.XlFileFormat.xlExcel9795保存方式时 当你的Excel版本不是95、97 而是2003、2007 时导出的时候会报一个错误：异常来自 HRESULT:0x800A03EC。 解决办法就是换成strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal。

        //        xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, false, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //        xlBook.Close();
        //        xlApp = null;

        //        xlBook = null;

        //        MessageBox.Show("生成报表完成");

        //    }

        //}
    }
}