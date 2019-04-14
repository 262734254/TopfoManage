using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace GZS.BLL
{
    public class Conns
    {
        GZS.DAL.Conns dal = new GZS.DAL.Conns();
        public Conns()
        { }
        public DataTable GetList(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            return dal.GetList(tblName, strGetFields, fldName, PageSize, PageIndex, doCount, OrderType, strWhere);
        }
        public DataTable GetList(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetList(TableViewName, Key, SelectStr, Criteria, Sort, ref  CurrentPage, PageSize, ref  TotalCount);
        }
        public int GetCount(string tblName, string fldName, string strWhere)
        {
            return dal.GetCount(tblName, fldName, strWhere);
        }



        public DataView GetList(string SPName, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetList(SPName, SelectStr, Criteria, Sort, ref CurrentPage, PageSize, ref TotalCount);
        }
        //public bool Delect(string tablename, string where)
        //{
        //    Tz888.SQLServerDAL.Conn con = new Tz888.SQLServerDAL.Conn();
        //    return con.Delect(tablename, where);
        //}
        //public bool Update(int psid, int ischeckup)
        //{
        //    Tz888.SQLServerDAL.Conn con = new Tz888.SQLServerDAL.Conn();
        //    return con.Update(psid, ischeckup);
        //}
    }
}
