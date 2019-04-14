using System;
using System.Collections.Generic;
using System.Text;
using GZS.DAL.Menu;
using System.Data;
namespace GZS.BLL.Menu
{
    public class CompanyShow
    {
        GZS.DAL.Menu.CompanyShow com = new GZS.DAL.Menu.CompanyShow();
        public GZS.Model.Menu.CompanyShow SelAllShow(string loginName)
        {
            return com.SelAllShow(loginName);
        }
        /// <summary>
        /// �����û���ֻ��ѯ��ҵ����
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetCompanyNameByLoginName(string loginName)
        {
            return com.GetCompanyNameByLoginName(loginName);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GZS.Model.Menu.CompanyShow model)
        {
            return com.Add(model);
        }
        public int updateById(int userId)
        {
            return com.updateById(userId);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(GZS.Model.Menu.CompanyShow model)
        {
            return com.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int CompanyID)
        {

            return com.Delete(CompanyID);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string CompanyIDlist)
        {
            return com.DeleteList(CompanyIDlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GZS.Model.Menu.CompanyShow GetModel(int CompanyID)
        {

            return com.GetModel(CompanyID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return com.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return com.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<GZS.Model.Menu.CompanyShow> GetModelList(string strWhere)
        {
            DataSet ds = com.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<GZS.Model.Menu.CompanyShow> DataTableToList(DataTable dt)
        {
            List<GZS.Model.Menu.CompanyShow> modelList = new List<GZS.Model.Menu.CompanyShow>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                GZS.Model.Menu.CompanyShow model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GZS.Model.Menu.CompanyShow();
                    if (dt.Rows[n]["CompanyID"].ToString() != "")
                    {
                        model.CompanyID = int.Parse(dt.Rows[n]["CompanyID"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    if (dt.Rows[n]["UserPwd"].ToString() != "")
                    {
                        model.UserPwd = (byte[])dt.Rows[n]["UserPwd"];
                    }
                    model.TelPhone = dt.Rows[n]["TelPhone"].ToString();
                    model.Mobile = dt.Rows[n]["Mobile"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    if (dt.Rows[n]["Audit"].ToString() != "")
                    {
                        model.Audit = int.Parse(dt.Rows[n]["Audit"].ToString());
                    }
                    if (dt.Rows[n]["StartTime"].ToString() != "")
                    {
                        model.StartTime = DateTime.Parse(dt.Rows[n]["StartTime"].ToString());
                    }
                    if (dt.Rows[n]["Valid"].ToString() != "")
                    {
                        model.Valid = int.Parse(dt.Rows[n]["Valid"].ToString());
                    }
                    model.TypeName = dt.Rows[n]["TypeName"].ToString();
                    if (dt.Rows[n]["Hit"].ToString() != "")
                    {
                        model.Hit = int.Parse(dt.Rows[n]["Hit"].ToString());
                    }
                    if (dt.Rows[n]["RoleId"].ToString() != "")
                    {
                        model.RoleId = int.Parse(dt.Rows[n]["RoleId"].ToString());
                    }
                    model.CompanyName = dt.Rows[n]["CompanyName"].ToString();
                    if (dt.Rows[n]["levels"].ToString() != "")
                    {
                        model.Levels = int.Parse(dt.Rows[n]["levels"].ToString());
                    }
                    model.LevelName = dt.Rows[n]["LevelName"].ToString();
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
    }
}
