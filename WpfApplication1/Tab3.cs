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

        TranslateTransform[] translateTransform_Array_Tab3 = new TranslateTransform[size_chanel];
        ScaleTransform[] scaleTransform_Array_Tab3 = new ScaleTransform[size_chanel];
        Rectangle[] rectangle_Array_Tab3 = new Rectangle[size_chanel];


        #region//地图的配置信息
        public void Init_rectangle_Array_Tab3()
        {
            rectangle_Array_Tab3[0] = rectangle1;
            rectangle_Array_Tab3[1] = rectangle2;
            rectangle_Array_Tab3[2] = rectangle3;
            rectangle_Array_Tab3[3] = rectangle4;
            rectangle_Array_Tab3[4] = rectangle5;
            rectangle_Array_Tab3[5] = rectangle6;
            rectangle_Array_Tab3[6] = rectangle7;
            rectangle_Array_Tab3[7] = rectangle8;
            rectangle_Array_Tab3[8] = rectangle9;
            rectangle_Array_Tab3[9] = rectangle10;

            rectangle_Array_Tab3[10] = rectangle11;
            rectangle_Array_Tab3[11] = rectangle12;
            rectangle_Array_Tab3[12] = rectangle13;
            rectangle_Array_Tab3[13] = rectangle14;
            rectangle_Array_Tab3[14] = rectangle15;
            rectangle_Array_Tab3[15] = rectangle16;
            rectangle_Array_Tab3[16] = rectangle17;
            rectangle_Array_Tab3[17] = rectangle18;
            rectangle_Array_Tab3[18] = rectangle19;
            rectangle_Array_Tab3[19] = rectangle20;

            rectangle_Array_Tab3[20] = rectangle21;
            rectangle_Array_Tab3[21] = rectangle22;
            rectangle_Array_Tab3[22] = rectangle23;
            rectangle_Array_Tab3[23] = rectangle24;
            rectangle_Array_Tab3[24] = rectangle25;
            rectangle_Array_Tab3[25] = rectangle26;
            rectangle_Array_Tab3[26] = rectangle27;
            rectangle_Array_Tab3[27] = rectangle28;
            rectangle_Array_Tab3[28] = rectangle29;
            rectangle_Array_Tab3[29] = rectangle30;

            rectangle_Array_Tab3[30] = rectangle31;
            rectangle_Array_Tab3[31] = rectangle32;
            rectangle_Array_Tab3[32] = rectangle33;
            rectangle_Array_Tab3[33] = rectangle34;
            rectangle_Array_Tab3[34] = rectangle35;
            rectangle_Array_Tab3[35] = rectangle36;
            rectangle_Array_Tab3[36] = rectangle37;
            rectangle_Array_Tab3[37] = rectangle38;
            rectangle_Array_Tab3[38] = rectangle39;
            rectangle_Array_Tab3[39] = rectangle40;

            rectangle_Array_Tab3[40] = rectangle41;
            rectangle_Array_Tab3[41] = rectangle42;
            rectangle_Array_Tab3[42] = rectangle43;
            rectangle_Array_Tab3[43] = rectangle44;
            rectangle_Array_Tab3[44] = rectangle45;
            rectangle_Array_Tab3[45] = rectangle46;
            rectangle_Array_Tab3[46] = rectangle47;
            rectangle_Array_Tab3[47] = rectangle48;
            rectangle_Array_Tab3[48] = rectangle49;
            rectangle_Array_Tab3[49] = rectangle50;

            rectangle_Array_Tab3[50] = rectangle51;
            rectangle_Array_Tab3[51] = rectangle52;
            rectangle_Array_Tab3[52] = rectangle53;
            rectangle_Array_Tab3[53] = rectangle54;
            rectangle_Array_Tab3[54] = rectangle55;
            rectangle_Array_Tab3[55] = rectangle56;
            rectangle_Array_Tab3[56] = rectangle57;
            rectangle_Array_Tab3[57] = rectangle58;
            rectangle_Array_Tab3[58] = rectangle59;
            rectangle_Array_Tab3[59] = rectangle60;

            rectangle_Array_Tab3[60] = rectangle61;
            rectangle_Array_Tab3[61] = rectangle62;
            rectangle_Array_Tab3[62] = rectangle63;
            rectangle_Array_Tab3[63] = rectangle64;
        }

        public void Init_translateTransform_Array_Tab3()
        {
            translateTransform_Array_Tab3[0] = tlt1;
            translateTransform_Array_Tab3[1] = tlt2;
            translateTransform_Array_Tab3[2] = tlt3;
            translateTransform_Array_Tab3[3] = tlt4;
            translateTransform_Array_Tab3[4] = tlt5;
            translateTransform_Array_Tab3[5] = tlt6;
            translateTransform_Array_Tab3[6] = tlt7;
            translateTransform_Array_Tab3[7] = tlt8;
            translateTransform_Array_Tab3[8] = tlt9;
            translateTransform_Array_Tab3[9] = tlt10;

            translateTransform_Array_Tab3[10] = tlt11;
            translateTransform_Array_Tab3[11] = tlt12;
            translateTransform_Array_Tab3[12] = tlt13;
            translateTransform_Array_Tab3[13] = tlt14;
            translateTransform_Array_Tab3[14] = tlt15;
            translateTransform_Array_Tab3[15] = tlt16;
            translateTransform_Array_Tab3[16] = tlt17;
            translateTransform_Array_Tab3[17] = tlt18;
            translateTransform_Array_Tab3[18] = tlt19;
            translateTransform_Array_Tab3[19] = tlt20;

            translateTransform_Array_Tab3[20] = tlt21;
            translateTransform_Array_Tab3[21] = tlt22;
            translateTransform_Array_Tab3[22] = tlt23;
            translateTransform_Array_Tab3[23] = tlt24;
            translateTransform_Array_Tab3[24] = tlt25;
            translateTransform_Array_Tab3[25] = tlt26;
            translateTransform_Array_Tab3[26] = tlt27;
            translateTransform_Array_Tab3[27] = tlt28;
            translateTransform_Array_Tab3[28] = tlt29;
            translateTransform_Array_Tab3[29] = tlt30;

            translateTransform_Array_Tab3[30] = tlt31;
            translateTransform_Array_Tab3[31] = tlt32;
            translateTransform_Array_Tab3[32] = tlt33;
            translateTransform_Array_Tab3[33] = tlt34;
            translateTransform_Array_Tab3[34] = tlt35;
            translateTransform_Array_Tab3[35] = tlt36;
            translateTransform_Array_Tab3[36] = tlt37;
            translateTransform_Array_Tab3[37] = tlt38;
            translateTransform_Array_Tab3[38] = tlt39;
            translateTransform_Array_Tab3[39] = tlt40;

            translateTransform_Array_Tab3[40] = tlt41;
            translateTransform_Array_Tab3[41] = tlt42;
            translateTransform_Array_Tab3[42] = tlt43;
            translateTransform_Array_Tab3[43] = tlt44;
            translateTransform_Array_Tab3[44] = tlt45;
            translateTransform_Array_Tab3[45] = tlt46;
            translateTransform_Array_Tab3[46] = tlt47;
            translateTransform_Array_Tab3[47] = tlt48;
            translateTransform_Array_Tab3[48] = tlt49;
            translateTransform_Array_Tab3[49] = tlt50;

            translateTransform_Array_Tab3[50] = tlt51;
            translateTransform_Array_Tab3[51] = tlt52;
            translateTransform_Array_Tab3[52] = tlt53;
            translateTransform_Array_Tab3[53] = tlt54;
            translateTransform_Array_Tab3[54] = tlt55;
            translateTransform_Array_Tab3[55] = tlt56;
            translateTransform_Array_Tab3[56] = tlt57;
            translateTransform_Array_Tab3[57] = tlt58;
            translateTransform_Array_Tab3[58] = tlt59;
            translateTransform_Array_Tab3[59] = tlt60;

            translateTransform_Array_Tab3[60] = tlt61;
            translateTransform_Array_Tab3[61] = tlt62;
            translateTransform_Array_Tab3[62] = tlt63;
            translateTransform_Array_Tab3[63] = tlt64;
        }

        public void Init_scaleTransform_Array_Tab3()
        {
            scaleTransform_Array_Tab3[0] = sfr1;
            scaleTransform_Array_Tab3[1] = sfr2;
            scaleTransform_Array_Tab3[2] = sfr3;
            scaleTransform_Array_Tab3[3] = sfr4;
            scaleTransform_Array_Tab3[4] = sfr5;
            scaleTransform_Array_Tab3[5] = sfr6;
            scaleTransform_Array_Tab3[6] = sfr7;
            scaleTransform_Array_Tab3[7] = sfr8;
            scaleTransform_Array_Tab3[8] = sfr9;
            scaleTransform_Array_Tab3[9] = sfr10;

            scaleTransform_Array_Tab3[10] = sfr11;
            scaleTransform_Array_Tab3[11] = sfr12;
            scaleTransform_Array_Tab3[12] = sfr13;
            scaleTransform_Array_Tab3[13] = sfr14;
            scaleTransform_Array_Tab3[14] = sfr15;
            scaleTransform_Array_Tab3[15] = sfr16;
            scaleTransform_Array_Tab3[16] = sfr17;
            scaleTransform_Array_Tab3[17] = sfr18;
            scaleTransform_Array_Tab3[18] = sfr19;
            scaleTransform_Array_Tab3[19] = sfr20;

            scaleTransform_Array_Tab3[20] = sfr21;
            scaleTransform_Array_Tab3[21] = sfr22;
            scaleTransform_Array_Tab3[22] = sfr23;
            scaleTransform_Array_Tab3[23] = sfr24;
            scaleTransform_Array_Tab3[24] = sfr25;
            scaleTransform_Array_Tab3[25] = sfr26;
            scaleTransform_Array_Tab3[26] = sfr27;
            scaleTransform_Array_Tab3[27] = sfr28;
            scaleTransform_Array_Tab3[28] = sfr29;
            scaleTransform_Array_Tab3[29] = sfr30;

            scaleTransform_Array_Tab3[30] = sfr31;
            scaleTransform_Array_Tab3[31] = sfr32;
            scaleTransform_Array_Tab3[32] = sfr33;
            scaleTransform_Array_Tab3[33] = sfr34;
            scaleTransform_Array_Tab3[34] = sfr35;
            scaleTransform_Array_Tab3[35] = sfr36;
            scaleTransform_Array_Tab3[36] = sfr37;
            scaleTransform_Array_Tab3[37] = sfr38;
            scaleTransform_Array_Tab3[38] = sfr39;
            scaleTransform_Array_Tab3[39] = sfr40;

            scaleTransform_Array_Tab3[40] = sfr41;
            scaleTransform_Array_Tab3[41] = sfr42;
            scaleTransform_Array_Tab3[42] = sfr43;
            scaleTransform_Array_Tab3[43] = sfr44;
            scaleTransform_Array_Tab3[44] = sfr45;
            scaleTransform_Array_Tab3[45] = sfr46;
            scaleTransform_Array_Tab3[46] = sfr47;
            scaleTransform_Array_Tab3[47] = sfr48;
            scaleTransform_Array_Tab3[48] = sfr49;
            scaleTransform_Array_Tab3[49] = sfr50;

            scaleTransform_Array_Tab3[50] = sfr51;
            scaleTransform_Array_Tab3[51] = sfr52;
            scaleTransform_Array_Tab3[52] = sfr53;
            scaleTransform_Array_Tab3[53] = sfr54;
            scaleTransform_Array_Tab3[54] = sfr55;
            scaleTransform_Array_Tab3[55] = sfr56;
            scaleTransform_Array_Tab3[56] = sfr57;
            scaleTransform_Array_Tab3[57] = sfr58;
            scaleTransform_Array_Tab3[58] = sfr59;
            scaleTransform_Array_Tab3[59] = sfr60;

            scaleTransform_Array_Tab3[60] = sfr61;
            scaleTransform_Array_Tab3[61] = sfr62;
            scaleTransform_Array_Tab3[62] = sfr63;
            scaleTransform_Array_Tab3[63] = sfr64;
        }
        #endregion

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
                //显示每个节点的最新数据
                dataSet_temp = MySqlHelper.GetDataSet(Init_Output_Conn(ShuJuKu.ShuJuKu_Name), CommandType.Text, "select * from " + ShuJuKu.Table1_ShiJIna_JieDian + " where id=\"" + (i + 1).ToString() + "\" order by `Date` desc limit 1", null);


                DataRowCollection temp_DataRow = dataSet_temp.Tables[0].Rows;//获取列

                //如果没有数据就退出
                if (temp_DataRow.Count <= 0)
                    continue;

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
                //Point position = e.GetPosition(img);
                //tlt.X += (position.X - this.previousMousePoint.X) * sfr.ScaleX;
                //tlt.Y += (position.Y - this.previousMousePoint.Y) * sfr.ScaleY;

                //tlt2.X += (position.X - this.previousMousePoint.X) * sfr.ScaleX;
                //tlt2.Y += (position.Y - this.previousMousePoint.Y) * sfr.ScaleY;

                Point position = e.GetPosition(img);
                tlt.X += (position.X - this.previousMousePoint.X) * sfr.ScaleX;
                tlt.Y += (position.Y - this.previousMousePoint.Y) * sfr.ScaleY;


                for (int i = 0; i < size_chanel; i++)//size_chanel
                {
                    translateTransform_Array_Tab3[i].X += (position.X - this.previousMousePoint.X) * scaleTransform_Array_Tab3[i].ScaleX;
                    translateTransform_Array_Tab3[i].Y += (position.Y - this.previousMousePoint.Y) * scaleTransform_Array_Tab3[i].ScaleY;
                }

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

            //Point centerPoint2 = e.GetPosition(rectangle2);
            //Point pt2 = rectangle2.RenderTransform.Inverse.Transform(centerPoint2);
            //this.tlt2.X = (centerPoint2.X - pt2.X) * this.sfr2.ScaleX;
            //this.tlt2.Y = (centerPoint2.Y - pt2.Y) * this.sfr2.ScaleY;
            //this.sfr2.CenterX = centerPoint2.X;
            //this.sfr2.CenterY = centerPoint2.Y;
            //this.sfr2.ScaleX += e.Delta / 1000.0;
            //this.sfr2.ScaleY += e.Delta / 1000.0;

            for (int i = 0; i < size_chanel; i++)//size_chanel
            {
                Point centerPoint2 = e.GetPosition(rectangle_Array_Tab3[i]);
                Point pt2 = rectangle_Array_Tab3[i].RenderTransform.Inverse.Transform(centerPoint2);
                translateTransform_Array_Tab3[i].X = (centerPoint2.X - pt2.X) * scaleTransform_Array_Tab3[i].ScaleX;
                translateTransform_Array_Tab3[i].Y = (centerPoint2.Y - pt2.Y) * scaleTransform_Array_Tab3[i].ScaleY;
                scaleTransform_Array_Tab3[i].CenterX = centerPoint2.X;
                scaleTransform_Array_Tab3[i].CenterY = centerPoint2.Y;
                scaleTransform_Array_Tab3[i].ScaleX += e.Delta / 1000.0;
                scaleTransform_Array_Tab3[i].ScaleY += e.Delta / 1000.0;
            }
        }
        #endregion

        #region
        public void clear_img_canvas_Tab3()
        {
            Canvas.SetTop(img, 0);
            Canvas.SetLeft(img, 0);
        }

        public void clear_scale_Tab3()
        {
            this.sfr.CenterX = 0;
            this.sfr.CenterY = 0;
            this.sfr.ScaleX = 1;
            this.sfr.ScaleY = 1;
            for (int i = 0; i < size_chanel; i++)
            {
                scaleTransform_Array_Tab3[i].CenterX = 0;
                scaleTransform_Array_Tab3[i].CenterY = 0;
                scaleTransform_Array_Tab3[i].ScaleX = 1;
                scaleTransform_Array_Tab3[i].ScaleY = 1;
            }
        }

        public void clear_tlt_Tab3()
        {
            this.tlt.X = 0;
            this.tlt.Y = 0;
            for (int i = 0; i < size_chanel; i++)//size_chanel
            {
                translateTransform_Array_Tab3[i].X = 0;
                translateTransform_Array_Tab3[i].Y = 0;
                //System.Diagnostics.Debug.WriteLine("rectangle{0} tlt:{1} {2} scale: {3} {4}", (i + 1), translateTransform_Array[i].X, translateTransform_Array[i].Y, scaleTransform_Array[i].CenterX, scaleTransform_Array[i].CenterY);
            }
        }
        #endregion

        public void update_map_Tab3()
        {
            clear_img_canvas_Tab3();
            clear_scale_Tab3();
            clear_tlt_Tab3();

            for (int i = 0; i < size_chanel; i++)
            {
                change_XY_rectangle(rectangle_Array_Tab3[i], Convert.ToDouble(JieDianZuoBiao_Array_int[i, 0]), Convert.ToDouble(JieDianZuoBiao_Array_int[i, 1]));
            }
            img.Source = new BitmapImage(new Uri(map_LuJing));
        }

        //Tab3 用户界面
        private void Tab3_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 0;
            Init_Tab1_ComboBox();            
        }
    }
}