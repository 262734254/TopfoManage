using System;
using System.Collections.Generic;
using System.Text;
using Tz888.SQLServerDAL.Picture;
using Tz888.Model.Picture;
using System.Data;

namespace Tz888.BLL.Picture
{
    public class PictureBLL
    {
        private readonly PictureDAL dal = new PictureDAL();

        /// <summary>
        /// ÃÌº”Õº∆¨
        /// </summary>
        /// <param name="Picture">Picture</param>
        /// <returns></returns>
        public bool AddPicture(PictureInfo Picture)
        {
            return dal.AddPicture(Picture);
        }

        /// <summary>
        /// –ﬁ∏ƒÕº∆¨
        /// </summary>
        /// <param name="Picture">Picture</param>
        /// <returns></returns>
        public bool ModfiyPicture(PictureInfo Picture)
        {
            return dal.ModfiyPicture(Picture);
        }

        /// <summary>
        /// …æ≥˝Õº∆¨
        /// </summary>
        /// <param name="PictureId"></param>
        /// <returns></returns>
        public bool DelPictureById(string PictureId)
        {
            return dal.DelPictureById(PictureId);
        }

        public bool DelPictureByIds(string PictureIds)
        {
            return dal.DelPictureByIds(PictureIds);
        }

        /// <summary>
        ///  Õº∆¨œÍ«ÈÕº∆¨
        /// </summary>
        /// <param name="PictureId">PictureId</param>
        /// <returns></returns>
        public DataTable GetPictureDetail(string PictureId)
        {
            return dal.GetPictureDetail(PictureId);
        } 

        /// <summary>
        /// Õº∆¨¡–±Ì
        /// </summary>
        /// <param name="ObjectName">±Ì/ ”Õº</param>
        /// <param name="Key"></param>
        /// <param name="ShowFiled"></param>
        /// <param name="OrderFiled"></param>
        /// <param name="Where"></param>
        /// <param name="PageCurrnt"></param>
        /// <param name="PageSize"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataTable GetPictureList(string ObjectName, string Key, string ShowFiled,string OrderFiled, string Where, ref int PageCurrnt, int PageSize, ref int TotalCount)
        {
            return dal.GetPictureList(ObjectName, Key, ShowFiled, Where, OrderFiled, ref PageCurrnt, PageSize, ref TotalCount);
        }
    }
}
