using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Menu;
using GZS.DAL.Menu;

namespace GZS.BLL.Menu
{
    /// <summary>
    /// 业务逻辑类EmployeeInfoTab 的摘要说明。
    /// </summary>
    public class EmployeeInfoTab
    {
        private readonly GZS.DAL.Menu.EmployeeInfoTab dal = new GZS.DAL.Menu.EmployeeInfoTab();
        public EmployeeInfoTab()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int EmployeeID)
        {
            return dal.Exists(EmployeeID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GZS.Model.Menu.EmployeeInfoTab model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(GZS.Model.Menu.EmployeeInfoTab model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int EmployeeID)
        {

            dal.Delete(EmployeeID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GZS.Model.Menu.EmployeeInfoTab GetModel(int EmployeeID)
        {

            return dal.GetModel(EmployeeID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public GZS.Model.Menu.EmployeeInfoTab GetModelByCache(int EmployeeID)
        {

            string CacheKey = "EmployeeInfoTabModel-" + EmployeeID;
            object objModel = dal.GetModel(EmployeeID);

            return (GZS.Model.Menu.EmployeeInfoTab)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GZS.Model.Menu.EmployeeInfoTab> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GZS.Model.Menu.EmployeeInfoTab> DataTableToList(DataTable dt)
        {
            List<GZS.Model.Menu.EmployeeInfoTab> modelList = new List<GZS.Model.Menu.EmployeeInfoTab>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GZS.Model.Menu.EmployeeInfoTab model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GZS.Model.Menu.EmployeeInfoTab();
                    if (dt.Rows[n]["EmployeeID"].ToString() != "")
                    {
                        model.EmployeeID = int.Parse(dt.Rows[n]["EmployeeID"].ToString());
                    }
                    model.LoginName = dt.Rows[n]["LoginName"].ToString();
                    model.EmployeeName = dt.Rows[n]["EmployeeName"].ToString();
                    if (dt.Rows[n]["Sex"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Sex"].ToString() == "1") || (dt.Rows[n]["Sex"].ToString().ToLower() == "true"))
                        {
                            model.Sex = true;
                        }
                        else
                        {
                            model.Sex = false;
                        }
                    }
                    model.NickName = dt.Rows[n]["NickName"].ToString();
                    if (dt.Rows[n]["Birthday"].ToString() != "")
                    {
                        model.Birthday = DateTime.Parse(dt.Rows[n]["Birthday"].ToString());
                    }
                    model.CertificateID = dt.Rows[n]["CertificateID"].ToString();
                    model.CertificateNumber = dt.Rows[n]["CertificateNumber"].ToString();
                    model.CountryCode = dt.Rows[n]["CountryCode"].ToString();
                    model.ProvinceID = dt.Rows[n]["ProvinceID"].ToString();
                    model.CityID = dt.Rows[n]["CityID"].ToString();
                    model.CountyID = dt.Rows[n]["CountyID"].ToString();
                    model.Address = dt.Rows[n]["Address"].ToString();
                    model.PostCode = dt.Rows[n]["PostCode"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
                    model.Mobile = dt.Rows[n]["Mobile"].ToString();
                    model.FAX = dt.Rows[n]["FAX"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.DeptID = dt.Rows[n]["DeptID"].ToString();
                    model.WorkType = dt.Rows[n]["WorkType"].ToString();
                    model.DegreeID = dt.Rows[n]["DegreeID"].ToString();
                    if (dt.Rows[n]["Enable"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Enable"].ToString() == "1") || (dt.Rows[n]["Enable"].ToString().ToLower() == "true"))
                        {
                            model.Enable = true;
                        }
                        else
                        {
                            model.Enable = false;
                        }
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 添加一条数据，同事向两人个表添加
        /// </summary>
        /// <param name="loginModel"></param>
        /// <param name="empModel"></param>
        /// <returns></returns>
        public int Add(Tz888.Model.LoginInfo loginModel, GZS.Model.Menu.EmployeeInfoTab empModel,string sTem)
        {
            return dal.Add(loginModel, empModel, sTem);
        }

        //检查数据
        public DataSet CheckUserLoginName(string strUserLoginName)
        {
            return dal.CheckUserLoginName(strUserLoginName);
        }

        //获取数据
        public DataSet GetData(string strUserLoginName)
        {
            return dal.GetData(strUserLoginName);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GZS.Model.Menu.EmployeeInfoTab GetModel(string strUserLoginName)
        {
            return dal.GetModel(strUserLoginName);
        }

        //同时更新两人个表
        public int Update(Tz888.Model.LoginInfo loginModel, GZS.Model.Menu.EmployeeInfoTab empModel, string strTem)
        {
            return dal.Update(loginModel, empModel, strTem);
        }


        /// <summary>
        /// 向Employeeinfotab表插入记录
        /// </summary>
        /// <param name="empMode"></param>
        /// <returns></returns>
        public int Insert(GZS.Model.Menu.EmployeeInfoTab empMode, string strTem)
        {
            return dal.Insert(empMode, strTem);
        }

        /// <summary>
        /// 更新employeeinfotab表数据
        /// </summary>
        /// <param name="empModel"></param>
        /// <returns></returns>
        public int UpdateEmpTab(GZS.Model.Menu.EmployeeInfoTab empModel)
        {
            return dal.UpdateEmpTab(empModel);
        }


          /// <summary>
        /// 验证员工登录及写入日志文件
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="strPassWord"></param>
        /// <param name="strIpAddress"></param>
        /// <returns></returns>
        public DataTable Authenticate(
            string strLoginName,
            string strPassWord,
            string strIpAddress)
        {
            return dal.Authenticate(strLoginName, strPassWord, strIpAddress);
        }


        /// <summary>
        /// 添加员工，改版后_2010-8-9
        /// </summary>
        /// <param name="empModel"></param>
        /// <param name="strTem"></param>
        /// <returns></returns>
        public int Insert_V1(GZS.Model.Menu.EmployeeInfoTab empModel, string strTem)
        {
            return dal.Insert_V1(empModel,strTem);
        }
       
        /// <summary>
        /// 2011-03-04 design by longbin
        /// 修改用户密码
        /// 根据用户名来修改用户密码
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <returns></returns>
        public int UpdatePwdByLoginName(string LoginName, byte[] pwd)
        {
            return dal.UpdatePwdByLoginName(LoginName,pwd);
        }
        /// <summary>
        /// 2011-03-04 design by longbin
        /// 修改用户密码
        /// 根据用户名来查找用户密码
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <returns></returns>
        public byte[] GetPwdByLoginName(string LoginName)
        {
            return dal.GetPwdByLoginName(LoginName);
        }
        //获取表的数据
        public DataTable GetData(string sIsPage, string sSuperStr, string sSort, int iPageSize, int iPageIndex, int iDoCount)
        {
            return dal.GetData(sIsPage ,sSuperStr ,sSort ,iPageSize,iPageIndex,iDoCount);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="strLoginName">根据loginname去删除</param>
        /// <returns></returns>
        public int DelEmployee(string strLoginName)
        {
            return dal.DelEmployee(strLoginName);
        }


        #endregion  成员方法
    }
}

