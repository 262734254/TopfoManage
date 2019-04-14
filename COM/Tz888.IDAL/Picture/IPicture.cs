using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Picture;
using System.Data;

namespace Tz888.IDAL.Picture
{
    public interface IPicture
    {
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="picture">picture</param>
        /// <returns></returns>
        bool AddPicture(PictureInfo Picture);

        /// <summary>
        /// 修改图片
        /// </summary>
        /// <param name="picture">picture</param>
        /// <returns></returns>
        bool ModfiyPicture(PictureInfo Picture);

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="PictureId">PictureId</param>
        /// <returns></returns>
        bool DelPictureById(string PictureId);

        /// <summary>
        /// 图片详情
        /// </summary>
        /// <param name="PictureId">PictureId</param>
        /// <returns></returns>
        DataTable GetPictureDetail(string PictureId);

        /// <summary>
        /// 图片列表
        /// </summary>
        /// <param name="ObjectName">表/视图</param>
        /// <param name="Key">主键</param>
        /// <param name="ShowFiled">显示字段</param>
        /// <param name="Where">条件</param>
        /// <param name="OrderFiled">排序字段</param>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="PageSize">页码大小</param>
        /// <param name="TotalCount">总条数</param>
        /// <returns></returns>
        DataTable GetPictureList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled,
          ref int PageCurrent, int PageSize, ref int TotalCount);
    }
}
