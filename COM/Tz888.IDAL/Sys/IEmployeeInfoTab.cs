using System;
using System.Data;
namespace Tz888.IDAL.Sys
{
    /// <summary>
    /// 接口层IEmployeeInfoTab 的摘要说明。
    /// </summary>
    public interface IEmployeeInfoTab
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int EmployeeID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Tz888.Model.Sys.EmployeeInfoTab model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(Tz888.Model.Sys.EmployeeInfoTab model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int EmployeeID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Tz888.Model.Sys.EmployeeInfoTab GetModel(int EmployeeID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);


        //同时向两个表插入数据
        int Add(Tz888.Model.LoginInfo loginModel, Tz888.Model.Sys.EmployeeInfoTab empModel, string sTem);

        //检查数据
        DataSet CheckUserLoginName(string strUserLoginName);

        //获取数据
        DataSet GetData(string strUserLoginName);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Tz888.Model.Sys.EmployeeInfoTab GetModel(string strUserLoginName);

        //同时更新两人个表
        int Update(Tz888.Model.LoginInfo loginModel, Tz888.Model.Sys.EmployeeInfoTab empModel, string strTem);


        /// <summary>
        /// 向Employeeinfotab表插入记录
        /// </summary>
        /// <param name="empMode"></param>
        /// <returns></returns>
        int Insert(Tz888.Model.Sys.EmployeeInfoTab empMode, string strTem);

        /// <summary>
        /// 更新employeeinfotab表数据
        /// </summary>
        /// <param name="empModel"></param>
        /// <returns></returns>
        int UpdateEmpTab(Tz888.Model.Sys.EmployeeInfoTab empModel);
        /// <summary>
        /// 验证员工登录及写入日志文件
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="strPassWord"></param>
        /// <param name="strIpAddress"></param>
        /// <returns></returns>
        DataTable Authenticate(
            string strLoginName,
            string strPassWord,
            string strIpAddress);

        /// <summary>
        /// 添加员工，改版后_2010-8-9
        /// </summary>
        /// <param name="empModel"></param>
        /// <param name="strTem"></param>
        /// <returns></returns>
        int Insert_V1(Tz888.Model.Sys.EmployeeInfoTab empModel, string strTem);
       
        /// <summary>
        /// 2011-03-04 design by longbin
        /// 修改用户密码
        /// 根据用户名来修改用户密码
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <returns></returns>
        int UpdatePwdByLoginName(string LoginName, byte[] pwd);
        
            /// <summary>
        /// 2011-03-04 design by longbin
        /// 修改用户密码
        /// 根据用户名来查找用户密码
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <returns></returns>
        byte[] GetPwdByLoginName(string LoginName);

        //获取表的数据
        DataTable GetData(string sIsPage, string sSuperStr, string sSort, int iPageSize, int iPageIndex, int iDoCount);


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="strLoginName">根据loginname去删除</param>
        /// <returns></returns>
        int DelEmployee(string strLoginName);
        #endregion  成员方法
    }
}
