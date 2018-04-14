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
        #region//地图功能的实现
        private void img_MouseDown_Tab6(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown_Tab6 = true;
            previousMousePoint_Tab6 = e.GetPosition(img_Tab6);
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
            if (isMouseLeftButtonDown_Tab6 == true)
            {
                Point position_Tab6 = e.GetPosition(img_Tab6);
                tlt_Tab6.X += (position_Tab6.X - this.previousMousePoint_Tab6.X) * sfr_Tab6.ScaleX;
                tlt_Tab6.Y += (position_Tab6.Y - this.previousMousePoint_Tab6.Y) * sfr_Tab6.ScaleY;

                tlt2_Tab6.X += (position_Tab6.X - this.previousMousePoint_Tab6.X) * sfr_Tab6.ScaleX;
                tlt2_Tab6.Y += (position_Tab6.Y - this.previousMousePoint_Tab6.Y) * sfr_Tab6.ScaleY;

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

            Point centerPoint2_Tab6 = e.GetPosition(rectangle1_Tab6);
            Point pt2_Tab6 = rectangle1_Tab6.RenderTransform.Inverse.Transform(centerPoint2_Tab6);
            this.tlt2_Tab6.X = (centerPoint2_Tab6.X - pt2_Tab6.X) * this.sfr2_Tab6.ScaleX;
            this.tlt2_Tab6.Y = (centerPoint2_Tab6.Y - pt2_Tab6.Y) * this.sfr2_Tab6.ScaleY;
            this.sfr2_Tab6.CenterX = centerPoint2_Tab6.X;
            this.sfr2_Tab6.CenterY = centerPoint2_Tab6.Y;
            this.sfr2_Tab6.ScaleX += e.Delta / 1000.0;
            this.sfr2_Tab6.ScaleY += e.Delta / 1000.0;
        }
        #endregion

        //地图维护
        private void Tab6_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }

        private void Tab6_DaoRuDiTu_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //img_Tab6.Source = new BitmapImage(new Uri(@"E:\biancheng\mysql\0410\WpfApplication1\WpfApplication1\bin\Debug\timg2.jpg", UriKind.Absolute));
                #region
                Microsoft.Win32.OpenFileDialog sfd = new Microsoft.Win32.OpenFileDialog();
                sfd.DefaultExt = "jpg";
                sfd.Filter = "地图(*.jpg)|*.jpg";
                if (sfd.ShowDialog() == true)
                {
                    //output_excel(sfd.FileName);
                    //OutputExcel_Button.Content = "";
                    //img_Tab6.Source = new BitmapImage(new Uri(@"E:\biancheng\mysql\0410\WpfApplication1\WpfApplication1\bin\Debug\timg2.jpg", UriKind.Absolute));
                    img_Tab6.Source = new BitmapImage(new Uri(sfd.FileName, UriKind.Absolute));
                }
                #endregion
            }
            catch
            {
                MessageBox.Show("Tab6_DaoRuDiTu_Button_Click函数报错", "你敢信？");
            }
        }
    }
}