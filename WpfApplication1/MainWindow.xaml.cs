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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isMouseLeftButtonDown = false;
        Point previousMousePoint = new Point(0, 0);

        public MainWindow()
        {
            InitializeComponent();
            Init_Tab1_ComboBox();
            Init_Tab2_ComboBox();
        }

        public void Init_Tab1_ComboBox()
        {
            Tab1_ComboBox.Items.Clear();
            Tab1_ComboBox.Items.Add("root");
            Tab1_ComboBox.Items.Add("用户1");
            Tab1_ComboBox.Items.Add("用户2");
            //Tab1_ComboBox.Items.Add(" ");
        }

        private void Tab1_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab1_ComboBox.SelectedItem == null)
                return;
            if (Tab1_ComboBox.SelectedItem.ToString() == "root")
            {
                tabcontrol.SelectedIndex = 1;//管理员界面
            }
            else
            {
                tabcontrol.SelectedIndex = 2;//用户界面
            }
        }

        private void Tab1_Button_Click(object sender, RoutedEventArgs e)
        {
            //Tab2.Visibility = System.Windows.Visibility.Visible;
            tabcontrol.SelectedIndex = 1;
        }


        //tab2
        public void Init_Tab2_ComboBox()
        {
            Tab2_ComboBox.Items.Clear();
            Tab2_ComboBox.Items.Add("用户维护");
            Tab2_ComboBox.Items.Add("节点维护");
            Tab2_ComboBox.Items.Add("地图维护");
            Tab2_ComboBox.Items.Add("其他");
            //Tab2_ComboBox.Items.Add(" ");
        }

        private void Tab2_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab2_ComboBox.SelectedItem == null)
                return;
            switch (Tab2_ComboBox.SelectedItem.ToString())
            {
                case "用户维护":
                    tabcontrol.SelectedIndex = 3;
                    break;
                case "节点维护":
                    tabcontrol.SelectedIndex = 4;
                    break;
                case "地图维护":
                    tabcontrol.SelectedIndex = 5;
                    break;
                case "其他":
                    tabcontrol.SelectedIndex = 6;
                    break;
            }
        }

        private void Tab2_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 0;
            Init_Tab1_ComboBox();
        }

        //Tab3 用户界面
        private void Tab3_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 0;
            Init_Tab1_ComboBox();
        }

        //Tab用户维护
        private void Tab4_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }

        //节点维护
        private void Tab5_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }

        //地图维护
        private void Tab6_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
        }

        //其他
        private void Tab7_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedIndex = 1;
            Init_Tab2_ComboBox();
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
                Point position = e.GetPosition(img);
                tlt.X += (position.X - this.previousMousePoint.X) * sfr.ScaleX;
                tlt.Y += (position.Y - this.previousMousePoint.Y) * sfr.ScaleY;

                tlt2.X += (position.X - this.previousMousePoint.X) * sfr.ScaleX;
                tlt2.Y += (position.Y - this.previousMousePoint.Y) * sfr.ScaleY;

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

            Point centerPoint2 = e.GetPosition(rectangle1);
            Point pt2 = rectangle1.RenderTransform.Inverse.Transform(centerPoint2);
            this.tlt2.X = (centerPoint2.X - pt2.X) * this.sfr2.ScaleX;
            this.tlt2.Y = (centerPoint2.Y - pt2.Y) * this.sfr2.ScaleY;
            this.sfr2.CenterX = centerPoint2.X;
            this.sfr2.CenterY = centerPoint2.Y;
            this.sfr2.ScaleX += e.Delta / 1000.0;
            this.sfr2.ScaleY += e.Delta / 1000.0;
        }
        #endregion
    }
}
