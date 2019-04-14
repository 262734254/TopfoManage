using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace GZS.DAL
{
    public class AreaIndexDAL
    {
        private string areabe = ConfigurationManager.AppSettings["areabe"].ToString(); //����������ɵľ�̬ҳ����·��
      // private string areaMa = ConfigurationManager.AppSettings["areaMa"].ToString(); //�������ģ��ҳ���·��
        
        public void AreaHtml(string name,int num)
        {
            GZS.DAL.product.CommStatic comm = new GZS.DAL.product.CommStatic();
            string areaMa="J:/topfo/tzWeb/Corporation/cn001/index.htm";
            //string areaMa = "F:/zf/topfo001/index.html";
            string[] ar = areaMa.Split('/');
            string nn = ar[ar.Length - 2].ToString();
            string ma = nn.Replace(nn, name);

            string bb = "J:\\topfo\\tzWeb\\Corporation\\"+ma+"\\index.htm";
           // string bb = "F:\\zf\\"+ma+"\\index.html";
            string TempFileName = bb.ToString();
            string Tem = Compage.Reader(TempFileName); //��ȡģ������
            #region �滻ģ��
            string TempSoure = Tem;
            if (num == 1)//��Ʒ����
            {
                string industry= comm.GetListUIByloginName(name);
                TempSoure = TempSoure.Replace("$industry$", industry);
            }
            else if (num == 2)//Ͷ�ʻ���
            {

            }
            else if (num == 3)//԰����ɫ
            {
                string land = comm.GetParkListUIByLoginName(name);
                TempSoure = TempSoure.Replace("$Land$",land);
            }
            else if (num == 4)//Ͷ�ʳɱ�
            {
                string project = comm.GetInvestListUIByLoginName(name);
                TempSoure = TempSoure.Replace("$Project$",project);
            }
            else if (num == 5)//�������
            {
                string area = SelArea(name);
                TempSoure = TempSoure.Replace("$area$", area);
            }
            else if (num == 6)//��������
            {
                string friend = comm.GetListFriend(name);
                TempSoure = TempSoure.Replace("$friendship$", friend);
            }
            else if (num == 7)//���ͼƬ
            {
                string pic = comm.GetImageList(name);
                TempSoure = TempSoure.Replace("$pic$", pic);
            }
            else if (num == 8)//�Ż�����
            {
                string Policy = comm.GetPolicyListUIByLoginName(name);
                TempSoure = TempSoure.Replace("$Policy$", Policy);
            }
            #endregion

            string wenjian = areabe + name;
            if (Directory.Exists(wenjian) == false)
            {
                Directory.CreateDirectory(wenjian);
            }
            string htmlpaths = wenjian + "\\" + "index.htm";
            Compage.Writer(htmlpaths, TempSoure);
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string SelArea(string name)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 1 a.Chineseintroduced ,a.htmlurl,b.ImageUrl from areaTab as a inner join areaimg as b  "
                + " on a.areaid=b.areaid where a.loginName=@name order by b.areaimgid desc";
            SqlParameter[] para={
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value=name;
            DataSet ds = DBHelper.Query(sql, para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                string chinese = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                string image = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                sb.Append("<div class=\"index-gk\"> <img src='http://dp.topfo.com/img/"+image+"' width=\"213px\" height=\"42px\"  />");
                sb.Append("<p><a href='Regionaloverview.htm'>" + selName(100, chinese) + "</a></p>");
                sb.Append("</div>");
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="m">��ȡ���ٸ�</param>
        /// <param name="title">��ȡ���ֶ�</param>
        /// <returns></returns>
        public string selName(int m,string title)
        {
            string num=title.Trim();
           
            if (num.Length > m)
            {
                num = num.Substring(0, m - 1) + "... <����>";
            }
            else
            {
                num = num + "<����>";
            }
           
            return num;
        }
    }
}
