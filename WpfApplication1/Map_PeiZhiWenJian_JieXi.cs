using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Map_PeiZhiWenJian_JieXi
{
    public class map_PZWJ_JieXi
    {
        /// <summary>
        ///  �������õ�ͼ�����ļ������ݽ�����ÿ���ڵ��������Ϣ
        /// </summary>
        /// <param name="FileName">�ļ�������·��</param>
        /// <param name="size">����֮��ĳ���</param>
        /// <param name="size">�������֮��Ľڵ���������</param>
        /// <returns>������������㣬�������һ</returns>
        public static bool get_JieDianZuoBiao(string FileName, int size, ref int[,] JieDian_ZuoBiao_Array)
        {
            try
            {
                System.IO.StreamReader rd = System.IO.File.OpenText(FileName);
                string s = rd.ReadToEnd();
                s = s.Replace("\r\n", " ");

                string[] s_Array = s.Split(' ');
                if(s_Array.Length != (size * 3 + 2))
                {
                    throw (new System.Exception("the length of s_Array is wrong"));
                }

                if(JieDian_ZuoBiao_Array.Length != (size * 2))
                {
                    throw (new System.Exception("the length of JieDian_ZuoBiao_Array is wrong"));
                }

                for(int i = 0; i < size; i++)
                {
                    JieDian_ZuoBiao_Array[i, 0] = Convert.ToInt16(s_Array[i * 3 + 1]);
                    JieDian_ZuoBiao_Array[i, 1] = Convert.ToInt16(s_Array[i * 3 + 2]);
                }


                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}