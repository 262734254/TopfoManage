using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Resource
{
    public interface IResource
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="crm">CRM</param>
        /// <returns></returns>
        //bool AddResource(Tz888.Model.Resource.Resource resource);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="crm">CRM</param>
        /// <returns></returns>
        bool ModfiyResource(string DeclarationId);

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="DeclarationId">DeclarationId</param>
        /// <returns></returns>
        DataTable GetResourceDetail(string DeclarationId);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="DeclarationId">DeclarationId</param>
        /// <returns></returns>
        bool DelResource(string DeclarationId);

        /// <summary>
        /// 
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
        DataTable GetResourceList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled,
            ref int PageCurrent, int PageSize, ref int TotalCount);
    }
}
