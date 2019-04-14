using System;
using System.Data;
namespace Tz888.IDAL.Sys
{
    /// <summary>
    /// �ӿڲ�IEmployeeInfoTab ��ժҪ˵����
    /// </summary>
    public interface IEmployeeInfoTab
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int EmployeeID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Tz888.Model.Sys.EmployeeInfoTab model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Tz888.Model.Sys.EmployeeInfoTab model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int EmployeeID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Tz888.Model.Sys.EmployeeInfoTab GetModel(int EmployeeID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// ���ݷ�ҳ��������б�
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);


        //ͬʱ���������������
        int Add(Tz888.Model.LoginInfo loginModel, Tz888.Model.Sys.EmployeeInfoTab empModel, string sTem);

        //�������
        DataSet CheckUserLoginName(string strUserLoginName);

        //��ȡ����
        DataSet GetData(string strUserLoginName);

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Tz888.Model.Sys.EmployeeInfoTab GetModel(string strUserLoginName);

        //ͬʱ�������˸���
        int Update(Tz888.Model.LoginInfo loginModel, Tz888.Model.Sys.EmployeeInfoTab empModel, string strTem);


        /// <summary>
        /// ��Employeeinfotab������¼
        /// </summary>
        /// <param name="empMode"></param>
        /// <returns></returns>
        int Insert(Tz888.Model.Sys.EmployeeInfoTab empMode, string strTem);

        /// <summary>
        /// ����employeeinfotab������
        /// </summary>
        /// <param name="empModel"></param>
        /// <returns></returns>
        int UpdateEmpTab(Tz888.Model.Sys.EmployeeInfoTab empModel);
        /// <summary>
        /// ��֤Ա����¼��д����־�ļ�
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
        /// ���Ա�����İ��_2010-8-9
        /// </summary>
        /// <param name="empModel"></param>
        /// <param name="strTem"></param>
        /// <returns></returns>
        int Insert_V1(Tz888.Model.Sys.EmployeeInfoTab empModel, string strTem);
       
        /// <summary>
        /// 2011-03-04 design by longbin
        /// �޸��û�����
        /// �����û������޸��û�����
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <returns></returns>
        int UpdatePwdByLoginName(string LoginName, byte[] pwd);
        
            /// <summary>
        /// 2011-03-04 design by longbin
        /// �޸��û�����
        /// �����û����������û�����
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <returns></returns>
        byte[] GetPwdByLoginName(string LoginName);

        //��ȡ�������
        DataTable GetData(string sIsPage, string sSuperStr, string sSort, int iPageSize, int iPageIndex, int iDoCount);


        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="strLoginName">����loginnameȥɾ��</param>
        /// <returns></returns>
        int DelEmployee(string strLoginName);
        #endregion  ��Ա����
    }
}
