using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Park;
using GZS.DAL.Park;
using System.Data;
namespace GZS.BLL.Park
{
    public class ParkImgBLL
    {
        ParkImgDAL dal = new ParkImgDAL();
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ParkImgM model)
        {
            return dal.Add(model);
        }
        public bool DeleteByParkId(int ParkId)
        {
            return dal.DeleteByParkId(ParkId);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ParkImgM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int imgId)
        {

            return dal.Delete(imgId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string imgIdlist)
        {
            return dal.DeleteList(imgIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ParkImgM GetModel(int imgId)
        {

            return dal.GetModel(imgId);
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
        public List<ParkImgM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ParkImgM> DataTableToList(DataTable dt)
        {
            List<ParkImgM> modelList = new List<ParkImgM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ParkImgM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ParkImgM();
                    if (dt.Rows[n]["imgId"].ToString() != "")
                    {
                        model.imgId = int.Parse(dt.Rows[n]["imgId"].ToString());
                    }
                    if (dt.Rows[n]["parkId"].ToString() != "")
                    {
                        model.parkId = int.Parse(dt.Rows[n]["parkId"].ToString());
                    }
                    model.imgName = dt.Rows[n]["imgName"].ToString();
                    model.imgexplain = dt.Rows[n]["imgexplain"].ToString();
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
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}
