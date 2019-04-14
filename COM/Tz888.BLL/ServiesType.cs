using System;
using System.Data;
using Tz888.Model;
namespace Tz888.BLL
{
    /// <summary>
    /// 业务逻辑类setServiesBigTab 的摘要说明。
    /// </summary>
    public class ServiesType
    {
        Tz888.SQLServerDAL.ServiesType dal = new Tz888.SQLServerDAL.ServiesType();
        public ServiesType()
        { }
        #region  成员方法
        /// <summary>
        ///  添加大类
        /// </summary>
        public bool AddServiesB(string ServiesBName, int IndexNum, string Remark)
        {
            return dal.AddServiesB(ServiesBName, IndexNum, Remark);
        }
        /// <summary>
        ///  添加小类
        /// </summary>
        public bool AddServiesM(int ServiesBID, string ServiesMName, int IndexNum, string Remark)
        {
            return dal.AddServiesM(ServiesBID, ServiesMName, IndexNum, Remark);
        }
        /// <summary>
        ///  更新大类
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
        ///  更新小类
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
        /// 大类是否显示
        /// </summary>
        /// <param name="ServiesBID"></param>
        /// <param name="isShow"></param>
        /// <returns></returns>
        public bool ShowBServies(int ServiesBID, bool isShow)
        {
            return ShowBServies(ServiesBID,isShow);
        }
         /// <summary>
         /// 小类是否显示
         /// </summary>
         /// <param name="ServiesMID"></param>
         /// <param name="isShow"></param>
         /// <returns></returns>

        public bool ShowMServies(int ServiesMID, bool isShow)
        {
            return ShowMServies(ServiesMID, isShow);
        }
        /// <summary>
        ///  更新排列
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
        /// 删除大类
        /// </summary>
        public bool DeleteServiesB(int ServiesBID)
        {
            return dal.DeleteServiesB(ServiesBID);
        }
        /// <summary>
        /// 删除小类
        /// </summary>
        public bool DeleteServiesM(int ServiesMID)
        {
            return dal.DeleteServiesM(ServiesMID);
        }
       /// <summary>
        /// 服务一级分类列表
       /// </summary>
        /// <param name="isShow">isShow为true 显示出isshow=1的,否则显示出所有</param>
       /// <returns></returns>
        public DataView GetServiesList(bool isShow)
        {
            Tz888.SQLServerDAL.Common2 dal = new Tz888.SQLServerDAL.Common2();
            return dal.GetServiesList(isShow);
        }
       /// <summary>
        /// 服务二级分类列表
       /// </summary>
        /// <param name="isShow">isShow为true 显示出isshow=1的,否则显示出所有</param>
       /// <returns></returns>
        public DataView GetServiesList(int ServiesBID,bool isShow)
        {
            Tz888.SQLServerDAL.Common2 dal = new Tz888.SQLServerDAL.Common2();
            return dal.GetServiesList(ServiesBID, isShow);
        }
        /// <summary>
        /// 服务一级分类名称
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
        /// 服务二级分类名称
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
        /// 所有服务列表（排序）
        /// </summary>
        /// <returns></returns>
        public DataView GetServiesAllList()
        {
            Tz888.SQLServerDAL.Common2 dal = new Tz888.SQLServerDAL.Common2();
            return dal.GetServiesAllList();
        }
        /// <summary>
        /// 根据ID取出BID ServicesVIW
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
        /// 根据ID取出BID ServicesVIW
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
        /// 服务名称
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
        /// 服务ID
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
        /// 根据名称获取SID
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
        /// 根据SID 取得NAME
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
        /// 根据小类ID取得大类Name
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
        #endregion  成员方法
    }
}
 
