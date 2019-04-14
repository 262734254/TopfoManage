using System;
using System.Data;
using System.Collections.Generic;
using GZS.Model.Menu;
using GZS.DAL.Menu;

namespace GZS.BLL.Menu
{
    /// <summary>
    /// ҵ���߼���EmployeeInfoTab ��ժҪ˵����
    /// </summary>
    public class EmployeeInfoTab
    {
        private readonly GZS.DAL.Menu.EmployeeInfoTab dal = new GZS.DAL.Menu.EmployeeInfoTab();
        public EmployeeInfoTab()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int EmployeeID)
        {
            return dal.Exists(EmployeeID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GZS.Model.Menu.EmployeeInfoTab model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(GZS.Model.Menu.EmployeeInfoTab model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int EmployeeID)
        {

            dal.Delete(EmployeeID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GZS.Model.Menu.EmployeeInfoTab GetModel(int EmployeeID)
        {

            return dal.GetModel(EmployeeID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public GZS.Model.Menu.EmployeeInfoTab GetModelByCache(int EmployeeID)
        {

            string CacheKey = "EmployeeInfoTabModel-" + EmployeeID;
            object objModel = dal.GetModel(EmployeeID);

            return (GZS.Model.Menu.EmployeeInfoTab)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<GZS.Model.Menu.EmployeeInfoTab> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
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
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// ���һ�����ݣ�ͬ�������˸������
        /// </summary>
        /// <param name="loginModel"></param>
        /// <param name="empModel"></param>
        /// <returns></returns>
        public int Add(Tz888.Model.LoginInfo loginModel, GZS.Model.Menu.EmployeeInfoTab empModel,string sTem)
        {
            return dal.Add(loginModel, empModel, sTem);
        }

        //�������
        public DataSet CheckUserLoginName(string strUserLoginName)
        {
            return dal.CheckUserLoginName(strUserLoginName);
        }

        //��ȡ����
        public DataSet GetData(string strUserLoginName)
        {
            return dal.GetData(strUserLoginName);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GZS.Model.Menu.EmployeeInfoTab GetModel(string strUserLoginName)
        {
            return dal.GetModel(strUserLoginName);
        }

        //ͬʱ�������˸���
        public int Update(Tz888.Model.LoginInfo loginModel, GZS.Model.Menu.EmployeeInfoTab empModel, string strTem)
        {
            return dal.Update(loginModel, empModel, strTem);
        }


        /// <summary>
        /// ��Employeeinfotab������¼
        /// </summary>
        /// <param name="empMode"></param>
        /// <returns></returns>
        public int Insert(GZS.Model.Menu.EmployeeInfoTab empMode, string strTem)
        {
            return dal.Insert(empMode, strTem);
        }

        /// <summary>
        /// ����employeeinfotab������
        /// </summary>
        /// <param name="empModel"></param>
        /// <returns></returns>
        public int UpdateEmpTab(GZS.Model.Menu.EmployeeInfoTab empModel)
        {
            return dal.UpdateEmpTab(empModel);
        }


          /// <summary>
        /// ��֤Ա����¼��д����־�ļ�
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
        /// ���Ա�����İ��_2010-8-9
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
        /// �޸��û�����
        /// �����û������޸��û�����
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <returns></returns>
        public int UpdatePwdByLoginName(string LoginName, byte[] pwd)
        {
            return dal.UpdatePwdByLoginName(LoginName,pwd);
        }
        /// <summary>
        /// 2011-03-04 design by longbin
        /// �޸��û�����
        /// �����û����������û�����
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <returns></returns>
        public byte[] GetPwdByLoginName(string LoginName)
        {
            return dal.GetPwdByLoginName(LoginName);
        }
        //��ȡ�������
        public DataTable GetData(string sIsPage, string sSuperStr, string sSort, int iPageSize, int iPageIndex, int iDoCount)
        {
            return dal.GetData(sIsPage ,sSuperStr ,sSort ,iPageSize,iPageIndex,iDoCount);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="strLoginName">����loginnameȥɾ��</param>
        /// <returns></returns>
        public int DelEmployee(string strLoginName)
        {
            return dal.DelEmployee(strLoginName);
        }


        #endregion  ��Ա����
    }
}

