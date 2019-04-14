using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Visit
{
    public class VisitInfoDAL:Tz888.IDAL.Visit.IVisitInfo
    {



        
        #region IVisitInfo 成员


        /// <summary>
        /// 根据用户名条件所对应的信息
        /// </summary>
        /// <param name="name"></param>
        /// <return s></returns>
        public DataTable SelDataTable(string strWhere)
        {
            DataTable dt = new DataTable();
            return dt = DbHelperSQL.Query(strWhere).Tables[0];
        }
        /// <summary>
        /// 根据用户名找出所对应的信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Tz888.Model.Register.MemberInfoModel SelLogin(string name)
        {
            Tz888.Model.Register.MemberInfoModel member = new Tz888.Model.Register.MemberInfoModel();
            string sql = "select a.LoginName,a.MemberName,a.NickName,a.CountryCode,a.ProvinceID,a.CountyID,a.Address,a.PostCode,"
                + "a.Tel,a.Mobile,a.Email,a.ManageTypeID from MemberInfoQueryVIW20110224 as a where a.LoginName=@name";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql, para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                member.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                member.MemberName = ds.Tables[0].Rows[0]["MemberName"].ToString();
                member.NickName = ds.Tables[0].Rows[0]["NickName"].ToString();
                member.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                member.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                member.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                member.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                member.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                member.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                member.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                member.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                member.ManageTypeID = ds.Tables[0].Rows[0]["ManageTypeID"].ToString();
               // member.OrganizationName = ds.Tables[0].Rows[0]["OrganizationName"].ToString();
            }
            return member;
        }
        /// <summary>
        /// 将国家翻译
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelCountry(string num)
        {
            string name = "";
            if(num=="")
            {
                name = "全国";
                return name;
            }
            if (num != "")
            {
                string sql = "select CountryName from SetCountryTab where CountryCode=@num";
                SqlParameter[] para ={ 
                new SqlParameter("@num",SqlDbType.VarChar,200)
                };
                para[0].Value = num;
                name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
                
            }
            return name;
   
            
        }
        /// <summary>
        /// 将地区翻译
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelCounty(string num)
        {
            string name = "";
            if (num != "")
            {
                string sql = "select CountyName from SetCountyTab where CountyID=@num";
                SqlParameter[] para ={ 
                new SqlParameter("@num",SqlDbType.VarChar,200)
                };
                para[0].Value = num;
                name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            }
            return name;
        }
        /// <summary>
        /// 将省名翻译
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelProvince(string num)
        {
             string name = "";
            if (num == "")
            {
                name = "全国";
                return name;
            }
           
            if (num != "")
            {
                string sql = "select ProvinceName from SetProvinceTab where ProvinceID=@num";
                SqlParameter[] para ={ 
                new SqlParameter("@num",SqlDbType.VarChar,200)
                };
                para[0].Value = num;
                name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            }
            return name;
        }
        /// <summary>
        /// 将地区所对应的城市名称翻译
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelCityID(string num)
        {
            string name = "";
            if (num != "")
            {
                string sql = "select CityName from SetCityTab where CityID=@num";
                SqlParameter[] para ={ 
                    new SqlParameter("@num",SqlDbType.VarChar,200)
                };
                para[0].Value = num;
                name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            }
            return name;
        }
        /// <summary>
        /// 将会员类型翻译
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelManageType(string num)
        {
            string name = "";
            if (num != "")
            {
                string sql = "select ManageTypeName from SetManageTypeTab where ManageTypeID=@num";
                SqlParameter[] para ={ 
                new SqlParameter("@num",SqlDbType.VarChar,200)
                };
                para[0].Value = num;
                name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            }
            return name;
        }
        /// <summary>
        /// 添加回访记录
        /// </summary>
        /// <param name="visit"></param>
        /// <returns></returns>
        public int AddVisit(Tz888.Model.Visit.VisitInfoModel visit)
        {
            string sql = "insert into VisitInfoTab(LoginName,Valid,Mobile,Email,Disposition,Caption,Remark,VisitNew,VisitTime) values "
                + "(@LoginName,@Valid,@Mobile,@Email,@Disposition,@Caption,@Remark,@VisitNew,@VisitTime)";
            SqlParameter[] para ={ 
                new SqlParameter("@LoginName",SqlDbType.VarChar,20),
                new SqlParameter("@Valid",SqlDbType.Int,4),
                new SqlParameter("@Mobile",SqlDbType.VarChar,50),
                new SqlParameter("@Email",SqlDbType.VarChar,50),
                new SqlParameter("@Disposition",SqlDbType.VarChar,20),
                new SqlParameter("@Caption",SqlDbType.VarChar,5000),
                new SqlParameter("@Remark",SqlDbType.VarChar,5000),
                new SqlParameter("@VisitNew",SqlDbType.Int,4),
                new SqlParameter("@VisitTime",SqlDbType.DateTime,100)
            };
            para[0].Value = visit.LoginName;
            para[1].Value = visit.Valid;
            para[2].Value = visit.Mobile;
            para[3].Value = visit.Email;
            para[4].Value = visit.Disposition;
            para[5].Value = visit.Caption;
            para[6].Value = visit.Remark;
            para[7].Value = visit.VisitNew;
            para[8].Value = visit.VisitTime;
            object  name = DbHelperSQL.GetSingle(sql, para);
            if (name == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(name);
            }
        }
        /// <summary>
        /// 修改回访记录
        /// </summary>
        /// <param name="visit"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyVisit(Tz888.Model.Visit.VisitInfoModel visit, string name)
        {
            string sql = "update VisitInfoTab set Valid=@Valid,Mobile=@Mobile,Email=@Email,Disposition=@Disposition,Caption=@Caption,"
                + "Remark=@Remark,VisitNew=@VisitNew,VisitTime=@VisitTime where LoginName=@name";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,20),
                new SqlParameter("@Valid",SqlDbType.Int,10),
                new SqlParameter("@Mobile",SqlDbType.VarChar,50),
                new SqlParameter("@Email",SqlDbType.VarChar,50),
                new SqlParameter("@Disposition",SqlDbType.VarChar,20),
                new SqlParameter("@Caption",SqlDbType.VarChar,5000),
                new SqlParameter("@Remark",SqlDbType.VarChar,5000),
                new SqlParameter("@VisitNew",SqlDbType.Int,4),
                new SqlParameter("VisitTime",SqlDbType.DateTime,50)
            };
            para[0].Value = name;
            name = visit.LoginName;
            para[1].Value = visit.Valid;
            para[2].Value = visit.Mobile;
            para[3].Value = visit.Email;
            para[4].Value = visit.Disposition;
            para[5].Value = visit.Caption;
            para[6].Value = visit.Remark;
            para[7].Value = visit.VisitNew;
            para[8].Value = visit.VisitTime;
            object num = DbHelperSQL.GetSingle(sql, para);
            if (num == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(num);
            }
        }
        /// <summary>
        /// 根据ID查询所对应的回访记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tz888.Model.Visit.VisitInfoModel SelVisit(string name)
        {
            Tz888.Model.Visit.VisitInfoModel visit = new Tz888.Model.Visit.VisitInfoModel();
            string sql = "select Valid,Mobile,Email,Disposition,Caption,Remark,VisitNew,VisitTime from VisitInfoTab where LoginName=@name";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,20)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql,para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                visit.Valid = Convert.ToInt32(ds.Tables[0].Rows[0]["Valid"].ToString());
                visit.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                visit.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                visit.Disposition = ds.Tables[0].Rows[0]["Disposition"].ToString();
                visit.Caption = ds.Tables[0].Rows[0]["Caption"].ToString();
                visit.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                visit.VisitNew = Convert.ToInt32(ds.Tables[0].Rows[0]["VisitNew"].ToString());
                visit.VisitTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["VisitTime"].ToString());
            }
            return visit;
        }
        /// <summary>
        /// 判断用户名在访问记录表中是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SelLoginName(string name)
        {
            string sql = "select count(LoginName) from VisitInfoTab where LoginName=@name";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,20)
            };
            para[0].Value = name;
            string num =Convert.ToString(DbHelperSQL.GetSingle(sql, para));
            if (num =="0")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        /// <summary>
        /// 绑定类型字段
        /// </summary>
        /// <returns></returns>
        public DataView SelManageTypeName()
        {
            string sql = "select ManageTypeID,ManageTypeName from SetManageTypeTab ";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 查找有效和回访
        /// </summary>
        /// <param name="a"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SelValidNew(int a, string name)
        {
            string sql = "";
            string num="";
            if (a == 1)
            {
                sql = "select Valid from VisitInfoTab where LoginName=@name";
                SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,20)
                };
                para[0].Value = name;
                num = Convert.ToString(DbHelperSQL.GetSingle(sql, para));
                if (num == "")
                {
                    return 0;
                }
                //else
                //{
                //    return Convert.ToInt32(num);
                //}
            }
            else if (a == 2)
            {
                sql = "select VisitNew from VisitInfoTab where LoginName=@name";
                SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,20)
                };
                para[0].Value = name;
                num = Convert.ToString(DbHelperSQL.GetSingle(sql, para));
                if (num == "")
                {
                    return 0;
                }
                //else
                //{
                //    return Convert.ToInt32(num);
                //}
            }
            return Convert.ToInt32(num);
        }
        #endregion
    }
}
