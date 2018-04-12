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

        private bool isMouseLeftButtonDown_Tab6 = false;
        Point previousMousePoint_Tab6 = new Point(0, 0);

        const int size_chanel = 64;
        public test5_mem[] test5_Mem_array = new test5_mem[size_chanel];

        public MainWindow()
        {
            InitializeComponent();
            Init_Tab1_ComboBox();
            Init_Tab2_ComboBox();
            Init_test5_mem_array(test5_Mem_array, size_chanel, Tab3_CurrentStatus_ListView);
        }

        public void Init_test5_mem_array(test5_mem[] test5_Mem_array_tt, int size_chanel_tt, ListView listView_tt)
        {
            listView_tt.ItemsSource = test5_Mem_array_tt;
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
    }

    public class test5_mem
    {
        private string id;
        private string name;
        private string type;
        private string gas_type;
        private string danwei;

        private string status;
        private string nongdu;
        private string dixian;
        private string gaoxian;
        private string dianliang;

        private string wendu;
        private string date;

        public string ID
        {
            get { return id; }
            set
            {
                if(value == null)
                {
                    id = " ";
                }
                else
                {
                    id = value;
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if(value == null)
                {
                    name = " ";
                }
                else
                {
                    name = value;
                }
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                if(value == null)
                {
                    type = " ";
                }
                else
                {
                    type = value;
                }
            }
        }

        public string Gas_Type
        {
            get { return gas_type; }
            set
            {
                if(value == null)
                {
                    gas_type = " ";
                }
                else
                {
                    gas_type = value;
                }
            }
        }

        public string DanWei
        {
            get { return danwei; }
            set
            {
                if(value == null)
                {
                    danwei = " ";
                }
                else
                {
                    danwei = value;
                }
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                if(value == null)
                {
                    status = " ";
                }
                else
                {
                    status = value;
                }
            }
        }

        public string NongDu
        {
            get { return nongdu; }
            set
            {
                if(value == null)
                {
                    nongdu = " ";
                }
                else
                {
                    nongdu = value;
                }
            }
        }

        public string DiXian
        {
            get { return dixian; }
            set
            {
                if(value == null)
                {
                    dixian = " ";
                }
                else
                {
                    dixian = value;
                }
            }
        }

        public string GaoXian
        {
            get { return gaoxian; }
            set
            {
                if(value == null)
                {
                    gaoxian = " ";
                }
                else
                {
                    gaoxian = value;
                }
            }
        }

        public string DianLiang
        {
            get { return dianliang; }
            set
            {
                if(value == null)
                {
                    dianliang = " ";
                }
                else
                {
                    dianliang = value;
                }
            }
        }

        public string WenDu
        {
            get { return wendu; }
            set
            {
                if(value == null)
                {
                    wendu = " ";
                }
                else
                {
                    wendu = value;
                }
            }
        }

        public string Date
        {
            get { return date; }
            set
            {
                if(value == null)
                {
                    date = " ";
                }
                else
                {
                    date = value;
                }
            }
        }
    }
}
