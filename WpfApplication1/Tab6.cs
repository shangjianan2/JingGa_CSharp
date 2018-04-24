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

using System.IO;

//using UDP_Thread;

namespace WpfApplication1
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        TranslateTransform[] translateTransform_Array = new TranslateTransform[size_chanel];
        ScaleTransform[] scaleTransform_Array = new ScaleTransform[size_chanel];
        Rectangle[] rectangle_Array = new Rectangle[size_chanel];

        public void Init_rectangle_Array()
        {
            rectangle_Array[0] = rectangle1_Tab6;
            rectangle_Array[1] = rectangle2_Tab6;
            rectangle_Array[2] = rectangle3_Tab6;
            rectangle_Array[3] = rectangle4_Tab6;
            rectangle_Array[4] = rectangle5_Tab6;
            rectangle_Array[5] = rectangle6_Tab6;
            rectangle_Array[6] = rectangle7_Tab6;
            rectangle_Array[7] = rectangle8_Tab6;
            rectangle_Array[8] = rectangle9_Tab6;
            rectangle_Array[9] = rectangle10_Tab6;

            rectangle_Array[10] = rectangle11_Tab6;
            rectangle_Array[11] = rectangle12_Tab6;
            rectangle_Array[12] = rectangle13_Tab6;
            rectangle_Array[13] = rectangle14_Tab6;
            rectangle_Array[14] = rectangle15_Tab6;
            rectangle_Array[15] = rectangle16_Tab6;
            rectangle_Array[16] = rectangle17_Tab6;
            rectangle_Array[17] = rectangle18_Tab6;
            rectangle_Array[18] = rectangle19_Tab6;
            rectangle_Array[19] = rectangle20_Tab6;

            rectangle_Array[20] = rectangle21_Tab6;
            rectangle_Array[21] = rectangle22_Tab6;
            rectangle_Array[22] = rectangle23_Tab6;
            rectangle_Array[23] = rectangle24_Tab6;
            rectangle_Array[24] = rectangle25_Tab6;
            rectangle_Array[25] = rectangle26_Tab6;
            rectangle_Array[26] = rectangle27_Tab6;
            rectangle_Array[27] = rectangle28_Tab6;
            rectangle_Array[28] = rectangle29_Tab6;
            rectangle_Array[29] = rectangle30_Tab6;

            rectangle_Array[30] = rectangle31_Tab6;
            rectangle_Array[31] = rectangle32_Tab6;
            rectangle_Array[32] = rectangle33_Tab6;
            rectangle_Array[33] = rectangle34_Tab6;
            rectangle_Array[34] = rectangle35_Tab6;
            rectangle_Array[35] = rectangle36_Tab6;
            rectangle_Array[36] = rectangle37_Tab6;
            rectangle_Array[37] = rectangle38_Tab6;
            rectangle_Array[38] = rectangle39_Tab6;
            rectangle_Array[39] = rectangle40_Tab6;

            rectangle_Array[40] = rectangle41_Tab6;
            rectangle_Array[41] = rectangle42_Tab6;
            rectangle_Array[42] = rectangle43_Tab6;
            rectangle_Array[43] = rectangle44_Tab6;
            rectangle_Array[44] = rectangle45_Tab6;
            rectangle_Array[45] = rectangle46_Tab6;
            rectangle_Array[46] = rectangle47_Tab6;
            rectangle_Array[47] = rectangle48_Tab6;
            rectangle_Array[48] = rectangle49_Tab6;
            rectangle_Array[49] = rectangle50_Tab6;

            rectangle_Array[50] = rectangle51_Tab6;
            rectangle_Array[51] = rectangle52_Tab6;
            rectangle_Array[52] = rectangle53_Tab6;
            rectangle_Array[53] = rectangle54_Tab6;
            rectangle_Array[54] = rectangle55_Tab6;
            rectangle_Array[55] = rectangle56_Tab6;
            rectangle_Array[56] = rectangle57_Tab6;
            rectangle_Array[57] = rectangle58_Tab6;
            rectangle_Array[58] = rectangle59_Tab6;
            rectangle_Array[59] = rectangle60_Tab6;

            rectangle_Array[60] = rectangle61_Tab6;
            rectangle_Array[61] = rectangle62_Tab6;
            rectangle_Array[62] = rectangle63_Tab6;
            rectangle_Array[63] = rectangle64_Tab6;
        }

        public void Init_translateTransform_Array()
        {
            translateTransform_Array[0] = tlt1_Tab6;
            translateTransform_Array[1] = tlt2_Tab6;
            translateTransform_Array[2] = tlt3_Tab6;
            translateTransform_Array[3] = tlt4_Tab6;
            translateTransform_Array[4] = tlt5_Tab6;
            translateTransform_Array[5] = tlt6_Tab6;
            translateTransform_Array[6] = tlt7_Tab6;
            translateTransform_Array[7] = tlt8_Tab6;
            translateTransform_Array[8] = tlt9_Tab6;
            translateTransform_Array[9] = tlt10_Tab6;

            translateTransform_Array[10] = tlt11_Tab6;
            translateTransform_Array[11] = tlt12_Tab6;
            translateTransform_Array[12] = tlt13_Tab6;
            translateTransform_Array[13] = tlt14_Tab6;
            translateTransform_Array[14] = tlt15_Tab6;
            translateTransform_Array[15] = tlt16_Tab6;
            translateTransform_Array[16] = tlt17_Tab6;
            translateTransform_Array[17] = tlt18_Tab6;
            translateTransform_Array[18] = tlt19_Tab6;
            translateTransform_Array[19] = tlt20_Tab6;

            translateTransform_Array[20] = tlt21_Tab6;
            translateTransform_Array[21] = tlt22_Tab6;
            translateTransform_Array[22] = tlt23_Tab6;
            translateTransform_Array[23] = tlt24_Tab6;
            translateTransform_Array[24] = tlt25_Tab6;
            translateTransform_Array[25] = tlt26_Tab6;
            translateTransform_Array[26] = tlt27_Tab6;
            translateTransform_Array[27] = tlt28_Tab6;
            translateTransform_Array[28] = tlt29_Tab6;
            translateTransform_Array[29] = tlt30_Tab6;

            translateTransform_Array[30] = tlt31_Tab6;
            translateTransform_Array[31] = tlt32_Tab6;
            translateTransform_Array[32] = tlt33_Tab6;
            translateTransform_Array[33] = tlt34_Tab6;
            translateTransform_Array[34] = tlt35_Tab6;
            translateTransform_Array[35] = tlt36_Tab6;
            translateTransform_Array[36] = tlt37_Tab6;
            translateTransform_Array[37] = tlt38_Tab6;
            translateTransform_Array[38] = tlt39_Tab6;
            translateTransform_Array[39] = tlt40_Tab6;

            translateTransform_Array[40] = tlt41_Tab6;
            translateTransform_Array[41] = tlt42_Tab6;
            translateTransform_Array[42] = tlt43_Tab6;
            translateTransform_Array[43] = tlt44_Tab6;
            translateTransform_Array[44] = tlt45_Tab6;
            translateTransform_Array[45] = tlt46_Tab6;
            translateTransform_Array[46] = tlt47_Tab6;
            translateTransform_Array[47] = tlt48_Tab6;
            translateTransform_Array[48] = tlt49_Tab6;
            translateTransform_Array[49] = tlt50_Tab6;

            translateTransform_Array[50] = tlt51_Tab6;
            translateTransform_Array[51] = tlt52_Tab6;
            translateTransform_Array[52] = tlt53_Tab6;
            translateTransform_Array[53] = tlt54_Tab6;
            translateTransform_Array[54] = tlt55_Tab6;
            translateTransform_Array[55] = tlt56_Tab6;
            translateTransform_Array[56] = tlt57_Tab6;
            translateTransform_Array[57] = tlt58_Tab6;
            translateTransform_Array[58] = tlt59_Tab6;
            translateTransform_Array[59] = tlt60_Tab6;

            translateTransform_Array[60] = tlt61_Tab6;
            translateTransform_Array[61] = tlt62_Tab6;
            translateTransform_Array[62] = tlt63_Tab6;
            translateTransform_Array[63] = tlt64_Tab6;
        }

        public void Init_scaleTransform_Array()
        {
            scaleTransform_Array[0] = sfr1_Tab6;
            scaleTransform_Array[1] = sfr2_Tab6;
            scaleTransform_Array[2] = sfr3_Tab6;
            scaleTransform_Array[3] = sfr4_Tab6;
            scaleTransform_Array[4] = sfr5_Tab6;
            scaleTransform_Array[5] = sfr6_Tab6;
            scaleTransform_Array[6] = sfr7_Tab6;
            scaleTransform_Array[7] = sfr8_Tab6;
            scaleTransform_Array[8] = sfr9_Tab6;
            scaleTransform_Array[9] = sfr10_Tab6;

            scaleTransform_Array[10] = sfr11_Tab6;
            scaleTransform_Array[11] = sfr12_Tab6;
            scaleTransform_Array[12] = sfr13_Tab6;
            scaleTransform_Array[13] = sfr14_Tab6;
            scaleTransform_Array[14] = sfr15_Tab6;
            scaleTransform_Array[15] = sfr16_Tab6;
            scaleTransform_Array[16] = sfr17_Tab6;
            scaleTransform_Array[17] = sfr18_Tab6;
            scaleTransform_Array[18] = sfr19_Tab6;
            scaleTransform_Array[19] = sfr20_Tab6;

            scaleTransform_Array[20] = sfr21_Tab6;
            scaleTransform_Array[21] = sfr22_Tab6;
            scaleTransform_Array[22] = sfr23_Tab6;
            scaleTransform_Array[23] = sfr24_Tab6;
            scaleTransform_Array[24] = sfr25_Tab6;
            scaleTransform_Array[25] = sfr26_Tab6;
            scaleTransform_Array[26] = sfr27_Tab6;
            scaleTransform_Array[27] = sfr28_Tab6;
            scaleTransform_Array[28] = sfr29_Tab6;
            scaleTransform_Array[29] = sfr30_Tab6;

            scaleTransform_Array[30] = sfr31_Tab6;
            scaleTransform_Array[31] = sfr32_Tab6;
            scaleTransform_Array[32] = sfr33_Tab6;
            scaleTransform_Array[33] = sfr34_Tab6;
            scaleTransform_Array[34] = sfr35_Tab6;
            scaleTransform_Array[35] = sfr36_Tab6;
            scaleTransform_Array[36] = sfr37_Tab6;
            scaleTransform_Array[37] = sfr38_Tab6;
            scaleTransform_Array[38] = sfr39_Tab6;
            scaleTransform_Array[39] = sfr40_Tab6;

            scaleTransform_Array[40] = sfr41_Tab6;
            scaleTransform_Array[41] = sfr42_Tab6;
            scaleTransform_Array[42] = sfr43_Tab6;
            scaleTransform_Array[43] = sfr44_Tab6;
            scaleTransform_Array[44] = sfr45_Tab6;
            scaleTransform_Array[45] = sfr46_Tab6;
            scaleTransform_Array[46] = sfr47_Tab6;
            scaleTransform_Array[47] = sfr48_Tab6;
            scaleTransform_Array[48] = sfr49_Tab6;
            scaleTransform_Array[49] = sfr50_Tab6;

            scaleTransform_Array[50] = sfr51_Tab6;
            scaleTransform_Array[51] = sfr52_Tab6;
            scaleTransform_Array[52] = sfr53_Tab6;
            scaleTransform_Array[53] = sfr54_Tab6;
            scaleTransform_Array[54] = sfr55_Tab6;
            scaleTransform_Array[55] = sfr56_Tab6;
            scaleTransform_Array[56] = sfr57_Tab6;
            scaleTransform_Array[57] = sfr58_Tab6;
            scaleTransform_Array[58] = sfr59_Tab6;
            scaleTransform_Array[59] = sfr60_Tab6;

            scaleTransform_Array[60] = sfr61_Tab6;
            scaleTransform_Array[61] = sfr62_Tab6;
            scaleTransform_Array[62] = sfr63_Tab6;
            scaleTransform_Array[63] = sfr64_Tab6;
        }

        #region//地图功能的实现
        private void img_MouseDown_Tab6(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown_Tab6 = true;
            

            if (sender.ToString() == "System.Windows.Shapes.Rectangle")
            {
                previousMousePoint_Tab6 = e.GetPosition((System.Windows.Shapes.Rectangle)sender);
                //System.Diagnostics.Debug.WriteLine("Left {0} Top {1} tlt_x {2} tlt_y {3}", Canvas.GetLeft((System.Windows.Shapes.Rectangle)sender), Canvas.GetTop((System.Windows.Shapes.Rectangle)sender), tlt1_Tab6.X, tlt1_Tab6.Y);
            }
            else
            {
                previousMousePoint_Tab6 = e.GetPosition(img_Tab6);
                //System.Diagnostics.Debug.WriteLine("tlt_x {0} tlt_y {1}", tlt_Tab6.X, tlt_Tab6.Y);
            }
            System.Diagnostics.Debug.WriteLine("{0} {1}", sfr_Tab6.CenterX, sfr_Tab6.CenterY);
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
            //System.Diagnostics.Debug.WriteLine("sender {0}", sender);

            if (isMouseLeftButtonDown_Tab6 == true)
            {
                if(sender.ToString() == "System.Windows.Shapes.Rectangle")
                {
                    System.Windows.Shapes.Rectangle rectangle_temp = (System.Windows.Shapes.Rectangle)sender;

                    Point position_Tab6 = e.GetPosition(rectangle_temp);
                    
                    for (int i = 0; i < size_chanel; i++)
                    {
                        if (rectangle_Array[i].Name == rectangle_temp.Name)
                        {
                            position_Tab6 = e.GetPosition(rectangle_Array[i]);
                            //单独拖拽节点只会更改节点的在Canvas中的相对位置（left top），不会更改其他变量
                            Canvas.SetLeft(rectangle_Array[i], Canvas.GetLeft(rectangle_Array[i]) + (position_Tab6.X - this.previousMousePoint_Tab6.X) * scaleTransform_Array[i].ScaleX);
                            Canvas.SetTop(rectangle_Array[i], Canvas.GetTop(rectangle_Array[i]) + (position_Tab6.Y - this.previousMousePoint_Tab6.Y) * scaleTransform_Array[i].ScaleY);
                            //System.Diagnostics.Debug.WriteLine("GetLeft {0} GetTop {1}", Canvas.GetLeft(rectangle_Array[i]), Canvas.GetTop(rectangle_Array[i]));此处显示改变
                            //System.Diagnostics.Debug.WriteLine("translateTransform_Array {0} {1}", translateTransform_Array[i].X, translateTransform_Array[i].Y);此处显示不变
                            break;
                        }
                    }
                }
                else
                {
                    Point position_Tab6 = e.GetPosition(img_Tab6);
                    tlt_Tab6.X += (position_Tab6.X - this.previousMousePoint_Tab6.X) * sfr_Tab6.ScaleX;
                    tlt_Tab6.Y += (position_Tab6.Y - this.previousMousePoint_Tab6.Y) * sfr_Tab6.ScaleY;
                    

                    for (int i = 0; i < size_chanel; i++)//size_chanel
                    {
                        translateTransform_Array[i].X += (position_Tab6.X - this.previousMousePoint_Tab6.X) * scaleTransform_Array[i].ScaleX;
                        translateTransform_Array[i].Y += (position_Tab6.Y - this.previousMousePoint_Tab6.Y) * scaleTransform_Array[i].ScaleY;
                    }
                }

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

            //Point centerPoint2_Tab6 = e.GetPosition(rectangle2_Tab6);
            //Point pt2_Tab6 = rectangle2_Tab6.RenderTransform.Inverse.Transform(centerPoint2_Tab6);
            //this.tlt2_Tab6.X = (centerPoint2_Tab6.X - pt2_Tab6.X) * this.sfr2_Tab6.ScaleX;
            //this.tlt2_Tab6.Y = (centerPoint2_Tab6.Y - pt2_Tab6.Y) * this.sfr2_Tab6.ScaleY;
            //this.sfr2_Tab6.CenterX = centerPoint2_Tab6.X;
            //this.sfr2_Tab6.CenterY = centerPoint2_Tab6.Y;
            //this.sfr2_Tab6.ScaleX += e.Delta / 1000.0;
            //this.sfr2_Tab6.ScaleY += e.Delta / 1000.0;

            for(int i = 0; i < size_chanel; i++)//size_chanel
            {
                Point centerPoint2_Tab6 = e.GetPosition(rectangle_Array[i]);
                Point pt2_Tab6 = rectangle_Array[i].RenderTransform.Inverse.Transform(centerPoint2_Tab6);
                translateTransform_Array[i].X = (centerPoint2_Tab6.X - pt2_Tab6.X) * scaleTransform_Array[i].ScaleX;
                translateTransform_Array[i].Y = (centerPoint2_Tab6.Y - pt2_Tab6.Y) * scaleTransform_Array[i].ScaleY;
                scaleTransform_Array[i].CenterX = centerPoint2_Tab6.X;
                scaleTransform_Array[i].CenterY = centerPoint2_Tab6.Y;
                scaleTransform_Array[i].ScaleX += e.Delta / 1000.0;
                scaleTransform_Array[i].ScaleY += e.Delta / 1000.0;
            }
        }
        #endregion

        

        #region//导入地图的配置文件
        private void Tab6_DaoRuDiTu_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Point point = rectangle1_Tab6.TranslatePoint(new Point(150,200), Tab6_Canvas);//获取点坐标
                //Canvas.SetLeft(rectangle2_Tab6, 500);//测试使用，无实际意义
                //Canvas.SetTop(rectangle2_Tab6, 500);//测试使用，无实际意义
                #region
                Microsoft.Win32.OpenFileDialog sfd = new Microsoft.Win32.OpenFileDialog();
                sfd.DefaultExt = "txt";
                sfd.Filter = "文本文件(*.txt)|*.txt";
                if (sfd.ShowDialog() == true)
                {
                    System.IO.StreamReader rd = System.IO.File.OpenText(sfd.FileName);
                    string s = rd.ReadToEnd();
                    s = s.Replace("\r\n", " ");
                    string[] ss = s.Split(' ');
                    if(ss.Length != size_chanel * 3 + 1)
                    {
                        MessageBox.Show("文件格式错误", "提示");
                        return;
                    }

                    update_map(sfd.FileName);//为"地图维护界面"和"用户界面"更新地图
                }
                
                #endregion
            }
            catch
            {
                MessageBox.Show("Tab6_DaoRuDiTu_Button_Click函数报错", "你敢信？");
            }
        }

        public void change_XY_rectangle(Rectangle rectangle_tt, double x, double y)
        {
            Canvas.SetLeft(rectangle_tt, x);
            Canvas.SetTop(rectangle_tt, y);
        }
        #endregion


        #region//导入地图的图片
        private void Tab6_DaoRuTuPian_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Point point = rectangle1_Tab6.TranslatePoint(new Point(150,200), Tab6_Canvas);//获取点坐标
                //Canvas.SetLeft(rectangle2_Tab6, 500);//测试使用，无实际意义
                //Canvas.SetTop(rectangle2_Tab6, 500);//测试使用，无实际意义
                #region
                Microsoft.Win32.OpenFileDialog sfd = new Microsoft.Win32.OpenFileDialog();
                sfd.DefaultExt = "jpg";
                sfd.Filter = "图片(*.jpg)|*.jpg";
                if (sfd.ShowDialog() == true)
                {
                    img_Tab6.Source = new BitmapImage(new Uri(sfd.FileName));
                }
                #endregion
            }
            catch
            {
                MessageBox.Show("Tab6_DaoRuDiTu_Button_Click函数报错", "你敢信？");
            }
        }
        #endregion

        #region//导出地图配置文件
        private void Tab6_DaoChuDiTu_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder stringBuilder_tt = new StringBuilder();
                string[] get_absolute = new string[3];
                string get_absolute_str = null;

                for (int i = 0; i < size_chanel; i++)
                {
                    stringBuilder_tt.AppendFormat("{0} {1} {2}\r\n", (i + 1), (Canvas.GetLeft(rectangle_Array[i])), (Canvas.GetTop(rectangle_Array[i])));
                }
                get_absolute_str = img_Tab6.Source.ToString().Replace("///", ",");
                get_absolute = get_absolute_str.Split(',');
                get_absolute[1] = get_absolute[1].Replace('/', '\\');
                stringBuilder_tt.AppendFormat(get_absolute[1]);
                //System.Diagnostics.Debug.WriteLine(get_absolute[1]);

                //开始保存配置信息
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                sfd.DefaultExt = "txt";
                sfd.Filter = "文本文件(*.txt)|*.txt";
                if(sfd.ShowDialog() == true)
                {
                    FileStream fs_tt = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
                    using (StreamWriter writer = new StreamWriter(fs_tt))
                    {
                        writer.Write(stringBuilder_tt);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Tab6_DaoRuDiTu_Button_Click函数报错", "你敢信？");
            }
        }
        #endregion

        public void clear_img_canvas()
        {
            Canvas.SetTop(img_Tab6, 0);
            Canvas.SetLeft(img_Tab6, 0);
        }

        public void clear_scale()
        {            
            this.sfr_Tab6.CenterX = 0;
            this.sfr_Tab6.CenterY = 0;
            this.sfr_Tab6.ScaleX = 1;
            this.sfr_Tab6.ScaleY = 1;
            for (int i = 0; i < size_chanel; i++)
            {
                scaleTransform_Array[i].CenterX = 0;
                scaleTransform_Array[i].CenterY = 0;
                scaleTransform_Array[i].ScaleX = 1;
                scaleTransform_Array[i].ScaleY = 1;
            }
        }

        public void clear_tlt()
        {
            this.tlt_Tab6.X = 0;
            this.tlt_Tab6.Y = 0;
            for (int i = 0; i < size_chanel; i++)//size_chanel
            {
                translateTransform_Array[i].X = 0;
                translateTransform_Array[i].Y = 0;
                //System.Diagnostics.Debug.WriteLine("rectangle{0} tlt:{1} {2} scale: {3} {4}", (i + 1), translateTransform_Array[i].X, translateTransform_Array[i].Y, scaleTransform_Array[i].CenterX, scaleTransform_Array[i].CenterY);
            }
        }


        //返回按键
        private void Tab6_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }
    }
}