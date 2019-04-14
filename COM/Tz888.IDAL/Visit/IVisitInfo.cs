using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Visit
{
    public interface IVisitInfo
    {
        Tz888.Model.Register.MemberInfoModel SelLogin(string name);//根据用户名找出所对应的信息
        string SelCountry(string num);//将国家翻译
        string SelCounty(string num);//将地区翻译
        string SelProvince(string num);//将省名翻译
        string SelCityID(string num);//将地区所对应的城市名称翻译
        string SelManageType(string num);//将会员类型翻译
        int AddVisit(Tz888.Model.Visit.VisitInfoModel visit);//添加回访记录
        int ModfiyVisit(Tz888.Model.Visit.VisitInfoModel visit, string name);//修改回访记录
        Tz888.Model.Visit.VisitInfoModel SelVisit(string name);//根据ID查询所对应的回访记录
        int SelLoginName(string name);// 判断用户名在访问记录表中是否存在
        DataView SelManageTypeName();//绑定类型字段
        int SelValidNew(int a, string name);// 查找有效和回访
        DataTable SelDataTable(string strWhere);

    }
}
