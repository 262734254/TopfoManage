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
        /// ����һ������
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
        /// ����һ������
        /// </summary>
        public bool Update(ParkImgM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int imgId)
        {

            return dal.Delete(imgId);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string imgIdlist)
        {
            return dal.DeleteList(imgIdlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ParkImgM GetModel(int imgId)
        {

            return dal.GetModel(imgId);
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
        public List<ParkImgM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
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
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}
