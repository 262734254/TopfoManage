using System;
using System.Data;
using Tz888.Model;
namespace Tz888.BLL
{
    /// <summary>
    /// ҵ���߼���setServiesBigTab ��ժҪ˵����
    /// </summary>
    public class ServiesType
    {
        Tz888.SQLServerDAL.ServiesType dal = new Tz888.SQLServerDAL.ServiesType();
        public ServiesType()
        { }
        #region  ��Ա����
        /// <summary>
        ///  ��Ӵ���
        /// </summary>
        public bool AddServiesB(string ServiesBName, int IndexNum, string Remark)
        {
            return dal.AddServiesB(ServiesBName, IndexNum, Remark);
        }
        /// <summary>
        ///  ���С��
        /// </summary>
        public bool AddServiesM(int ServiesBID, string ServiesMName, int IndexNum, string Remark)
        {
            return dal.AddServiesM(ServiesBID, ServiesMName, IndexNum, Remark);
        }
        /// <summary>
        ///  ���´���
        /// </summary>
        public bool UpdateServiesB(int ServiesBID, string ServiesBName, int IndexNum, string Remark, bool isShow)
        {
            return dal.UpdateServiesB(ServiesBID, ServiesBName, IndexNum, Remark, isShow);
        }
        public bool UpdateServiesB(int ServiesBID, string ServiesBName, int IndexNum)
        {
            return dal.UpdateServiesB(ServiesBID, ServiesBName, IndexNum);
        }
        /// <summary>
        ///  ����С��
        /// </summary>
        public bool UpdateServiesM(int ServiesMID, int ServiesBID, string ServiesMName, int IndexNum, string Remark, bool isShow)
        {
            return dal.UpdateServiesM(ServiesMID, ServiesBID, ServiesMName, IndexNum, Remark, isShow);
        }
        public bool UpdateServiesM(int ServiesMID, string ServiesMName, int IndexNum)
        {
            return dal.UpdateServiesM(ServiesMID, ServiesMName, IndexNum);
        }
        /// <summary>
        /// �����Ƿ���ʾ
        /// </summary>
        /// <param name="ServiesBID"></param>
        /// <param name="isShow"></param>
        /// <returns></returns>
        public bool ShowBServies(int ServiesBID, bool isShow)
        {
            return ShowBServies(ServiesBID,isShow);
        }
         /// <summary>
         /// С���Ƿ���ʾ
         /// </summary>
         /// <param name="ServiesMID"></param>
         /// <param name="isShow"></param>
         /// <returns></returns>

        public bool ShowMServies(int ServiesMID, bool isShow)
        {
            return ShowMServies(ServiesMID, isShow);
        }
        /// <summary>
        ///  ��������
        /// </summary>
        public bool UpdateServiesIndex(int ID, int IndexNum)
        {
            return dal.UpdateServiesIndex(ID, IndexNum);
        }
        public bool UpdateServiesIndex()
        {
            return dal.UpdateServiesIndex();
        }
        /// <summary>
        /// ɾ������
        /// </summary>
        public bool DeleteServiesB(int ServiesBID)
        {
            return dal.DeleteServiesB(ServiesBID);
        }
        /// <summary>
        /// ɾ��С��
        /// </summary>
        public bool DeleteServiesM(int ServiesMID)
        {
            return dal.DeleteServiesM(ServiesMID);
        }
       /// <summary>
        /// ����һ�������б�
       /// </summary>
        /// <param name="isShow">isShowΪtrue ��ʾ��isshow=1��,������ʾ������</param>
       /// <returns></returns>
        public DataView GetServiesList(bool isShow)
        {
            Tz888.SQLServerDAL.Common2 dal = new Tz888.SQLServerDAL.Common2();
            return dal.GetServiesList(isShow);
        }
       /// <summary>
        /// ������������б�
       /// </summary>
        /// <param name="isShow">isShowΪtrue ��ʾ��isshow=1��,������ʾ������</param>
       /// <returns></returns>
        public DataView GetServiesList(int ServiesBID,bool isShow)
        {
            Tz888.SQLServerDAL.Common2 dal = new Tz888.SQLServerDAL.Common2();
            return dal.GetServiesList(ServiesBID, isShow);
        }
        /// <summary>
        /// ����һ����������
        /// </summary>
        /// <returns></returns>
        public string GetServiesBNameByID(int ServiesBID)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("setServiesBigTab", "ServiesBName", "ServiesBID", 1, 1, 0, 1, "ServiesBID=" + ServiesBID);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ServiesBName"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ���������������
        /// </summary>
        /// <returns></returns>
        public string GetServiesMNameByID(int ServiesMID)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("setServiesSmallTab", "ServiesMName", "ServiesMID", 1, 1, 0, 1, "ServiesMID=" + ServiesMID);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ServiesMName"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ���з����б�����
        /// </summary>
        /// <returns></returns>
        public DataView GetServiesAllList()
        {
            Tz888.SQLServerDAL.Common2 dal = new Tz888.SQLServerDAL.Common2();
            return dal.GetServiesAllList();
        }
        /// <summary>
        /// ����IDȡ��BID ServicesVIW
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetServiesBID(int ID)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("ServicesVIW", "sid,lvl", "id", 1, 1, 0, 1, "lvl=0 and ID=" + ID);
            string bid = "";
            if (dt.Rows.Count > 0)
            {
                    bid = dt.Rows[0]["sid"].ToString();
            }
            return bid;
        }
        /// <summary>
        /// ����IDȡ��BID ServicesVIW
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetServiesMID(int ID)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("ServicesVIW", "sid,lvl", "id", 1, 1, 0, 1, "lvl=1 and ID=" + ID);
            string mid = "";
            if (dt.Rows.Count > 0)
            {
                    mid=dt.Rows[0]["sid"].ToString();

            }
            return mid;
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string GetServiesNameByID(int ID)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("ServicesVIW", "ServiesName", "ID", 1, 1, 0, 1, "ID=" + ID);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ServiesName"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        public string GetServiesIDBySID(int SID)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("ServicesVIW", "ID", "ID", 1, 1, 0, 1, "SID=" + SID);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ID"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// �������ƻ�ȡSID
        /// </summary>
        /// <param name="ServiesName"></param>
        /// <returns></returns>
        public string GetSIDByName(string ServiesName,int lv)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("ServicesVIW", "SID", "ID", 1, 1, 0, 1, "ServiesName='" + ServiesName + "' and lvl="+lv);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SID"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ����SID ȡ��NAME
        /// </summary>
        /// <param name="SID"></param>
        /// <returns></returns>
        public string GetNameBySID(int SID)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("ServicesVIW", "ServiesName", "ID", 1, 1, 0, 1, "SID=" + SID );
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ServiesName"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ����С��IDȡ�ô���Name
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public string GetBNameByMID(int MID)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("setServiesbigtab", "ServiesbName", "ServiesBID", 1, 1, 0, 1, "ServiesBID=(select ServiesBID from setServiessmalltab where ServiesMID=" + MID + ")");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ServiesbName"].ToString();
            }
            else
            {
                return "";
            }
        }

        public string GegBID(int MID)
        {

            Conn dal = new Conn();
            DataTable dt = dal.GetList("ServicesMViw", "ServiesBID", "ServiesMID", 1, 1, 0, 1, "ServiesMID=" + MID);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ServiesBID"].ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion  ��Ա����
    }
}
 
