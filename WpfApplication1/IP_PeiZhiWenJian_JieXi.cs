using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace IP_PeiZhiWenJian_JieXi
{
    public class IP_PZWJ_JieXi
    {
        private byte[] ip_private = new byte[4];
        private UInt16 DuanKou_private;
        /// <summary>
        ///  ��������IP�����ļ������ݽ�����IP��ַ���˿ںţ�����������������е���Ӧ������
        /// </summary>
        /// <param name="FileName">�ļ�������·��</param>
        /// <returns>��</returns>
        public IP_PZWJ_JieXi(string FileName)
        {
            //Point point = rectangle1_Tab6.TranslatePoint(new Point(150,200), Tab6_Canvas);//��ȡ������
            //Canvas.SetLeft(rectangle2_Tab6, 500);//����ʹ�ã���ʵ������
            //Canvas.SetTop(rectangle2_Tab6, 500);//����ʹ�ã���ʵ������
            #region
            System.IO.StreamReader rd = System.IO.File.OpenText(FileName);
            string s = rd.ReadToEnd();
            s = s.Replace("\r\n", ";");//���س���("\r\n")����";"
            string[] s_Array_str = s.Split('.', ':', ';');//�ԷֺŽ������ļ��еĶ��ip��ַ����Ӧ�˿ںŷָ�

            if(s_Array_str.Length < 5)//��ⳤ�ȣ�������������5
            {
                throw (new System.Exception("IP_PZWJ_JieXi error"));
            }

            for(int i = 0; i < 4; i++)//��ǰ�ĸ���Ϊip��ַ
            {
                ip_private[i] = Convert.ToByte(s_Array_str[i]);
            }
            DuanKou_private = Convert.ToUInt16(s_Array_str[4]);//���������Ϊ�˿�
            #endregion
        }

        public byte[] IP
        {
            get { return ip_private; }
            set
            {
                if (value == null)
                {
                    ip_private = new byte[] {127, 0, 0, 1};
                }
                else
                {
                    ip_private = value;
                }
            }
        }

        public UInt16 DuanKou
        {
            get { return DuanKou_private; }
            set
            {
                if (value < 0)
                {
                    DuanKou_private = 8080;
                }
                else
                {
                    DuanKou_private = value;
                }
            }
        }
    }
}