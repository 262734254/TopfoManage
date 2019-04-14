using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL
{
   public class ImageUrlTabMBLL
    {
       GZS.DAL.ImageUrlTabMDAL dal = new GZS.DAL.ImageUrlTabMDAL();
       public int Add(GZS.Model.ImageUrlTabM model) 
       {
           return dal.Add(model);
       }
       public List<GZS.Model.ImageUrlTabM> GetAllByImageId(int imageid)
       {
           return dal.GetAllByImageId(imageid);
       }
       public int Delete(int parktypeid)
       {
           return dal.Delete(parktypeid);
       }
       public int DeleteByImageid(int Imageid)
       {
           return dal.DeleteByImageid(Imageid);
       }
    }
}
