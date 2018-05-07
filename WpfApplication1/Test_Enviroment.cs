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

using System.Data;
using MySQL_Funtion;

using UDP_Thread;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using IP_PeiZhiWenJian_JieXi;
using Map_PeiZhiWenJian_JieXi;
using MySQL_PeiZhiWenJian_JieXi;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        #region//�������ļ��л�ȡIP��ַ
        public void Init_PeiZhiIPAddress(ref byte[] temp_byte_array, ref UInt16 temp_duankou_int, ref byte[] remote_byte_array, ref UInt16 remote_duankou_int)
        {
            try
            {
                #region

                IP_WJ_JieXi = new IP_PZWJ_JieXi("C:\\NBIoT\\IP.txt");
                temp_byte_array = IP_WJ_JieXi.IP;
                temp_duankou_int = IP_WJ_JieXi.DuanKou;
                remote_byte_array = IP_WJ_JieXi.Remote_IP;
                remote_duankou_int = IP_WJ_JieXi.Remote_DuanKou;
                #endregion
            }
            catch
            {
                MessageBox.Show("IP�����ļ�����ʧ��", "����ʧ��");
                Application.Current.Shutdown();
            }
        }
        #endregion


        #region//���ip��ַ�Ƿ����
        public void Init_IP_right_or_not(byte[] array_byte_tt, UInt16 port_tt, byte[] NBIoT_IP_Byte_Array, UInt16 NBIoT_DuanKou)
        {
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try
            {
                IPAddress ip = new IPAddress(array_byte_tt);
                newsock.Bind(new IPEndPoint(ip, port_tt));//�趨ip��ַ���˿ں�
            }
            catch
            {
                MessageBox.Show("����ip��ַ���ó���", "error");
                Application.Current.Shutdown();
            }

            try
            {
                Init_NBIoT(NBIoT_IP_Byte_Array, NBIoT_DuanKou, ref mysql_Thread);//��NBIoT��Զ�̵�ַ������Ӧ��"UDP_Communication"��������͵�һ��ע����
            }
            catch
            {
                MessageBox.Show("Զ��ip��ַ���ó���", "error");
                Application.Current.Shutdown();
            }
            newsock.Dispose();//�������׽��֣���Ϊ���׽���ֻ�����ڼ��
        }
        #endregion

        #region
        public void Init_UDP()
        {
            Init_PeiZhiIPAddress(ref Local_IP_Byte_Array, ref Local_DuanKou, ref NBIoT_IP_Byte_Array, ref NBIoT_DuanKou);//��������IP�����ļ������ݸ�ȫ�ֱ�����ֵ
            //��ʼ��udpͨѶ��
            mysql_Thread = new UDP_Communication(Local_IP_Byte_Array, Local_DuanKou);
            //ע���¼�
            mysql_Thread.rev_New2 += new recNewMessage2(rec2_NewMessage_Form1);
            //mysql_Thread.recThread_Start();

            Init_NBIoT(NBIoT_IP_Byte_Array, NBIoT_DuanKou, ref mysql_Thread);//��NBIoT��Զ�̵�ַ������Ӧ��"UDP_Communication"��������͵�һ��ע����

            //��Ӷ�ʱ������Ϊ��ʱ����λ��������λ������ָ����λ������ƽ̨�����
            SendToIoT = new System.Threading.Timer(new System.Threading.TimerCallback(SendToIoTCall), this, 3000, 3000);
        }
        #endregion

        #region//�й����ݿ���أ�������ݿ�����Ƿ�����
        public void Init_MySQL()
        {
            string[] array_str = mysql_PZWJ_JieXi.read_mysql_PeiZhiWenJian("C:\\NBIoT\\mysql.txt");
            if (array_str == null)
                throw new Exception("mysql.txt �����ļ�������Ϊ��");
            ShuJuKu = new mysql_PZWJ_JieXi(array_str[0], array_str[1], array_str[2], array_str[3]);
        }
        #endregion

        public void Init_QiDongJianCe()
        {
            try
            {
                Init_MySQL();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "error");
                Environment.Exit(0);//�������ʹ�������������"Application.Current.Shutdown();"��"Application.Current.Shutdown();"���ܽ��������̹ر�
            }

            try
            {
                Init_UDP();//��ʼ��udpͨѶ��

                byte[] recData = new byte[1024];
                EndPoint senderRemote = new IPEndPoint(IPAddress.Any, 0);
                int n = mysql_Thread.newsock.ReceiveFrom(recData, ref senderRemote);//���Ե�һ�η�������

                mysql_Thread.recThread_Start();//����������߳�
            }
            catch
            {
                MessageBox.Show("UDPͨѶ��ʼ��ʧ��", "error");
                Application.Current.Shutdown();
            }

            
        }
    }
}