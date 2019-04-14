using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Resource
{
    public class Resource
    {
        /// <summary>
        /// 主键
        /// </summary>
        private int _DeclarationId;
        public int DeclarationId { get { return _DeclarationId; } set { _DeclarationId = value; } }

        /// <summary>
        ///主题  
        /// </summary>
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }

        /// <summary>
        /// 身份类型(投资方|融资方|招商方)
        /// </summary>
        private int _Identity;
        public int Identity { get { return _Identity; } set { _Identity = value; } }

        /// <summary>
        /// 行业类型
        /// </summary>
        private string _Industry;
        public string Industry { get { return _Industry; } set { _Industry = value; } }

        /// <summary>
        ///省份
        /// </summary>
        private int _ProvinceId;
        public int ProvinceId { get { return _ProvinceId; } set { _ProvinceId = value; } }

        /// <summary>
        /// 城市
        /// </summary>
        private int _CityId;
        public int CityId { get { return _CityId; } set { _CityId = value; } }

        /// <summary>
        /// 具体说明
        /// </summary>
        private string _Funds;
        public string Funds { get { return _Funds; } set { _Funds = value; } }

        /// <summary>
        /// 说明
        /// </summary>
        private string _Explain;
        public string Explain { get { return _Explain; } set { _Explain = value; } }

        /// <summary>
        /// 联系人
        /// </summary>
        private string _Contact;
        public string Contact { get { return _Contact; } set { _Contact = value; } }

        /// <summary>
        /// 电话
        /// </summary>
        private string _Phone;
        public string Phone { get { return _Phone; } set { _Phone = value; } }

        /// <summary>
        /// 邮件
        /// </summary>
        private string _Email;
        public string Email { get { return _Email; } set { _Email = value; } }

        /// <summary>
        /// 状态
        /// </summary>
        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        /// <summary>
        /// 备注
        /// </summary>
        private string _Remarks;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

        /// <summary>
        /// 业务员帐号
        /// </summary>
        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; } }

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _DateTimes;
        public DateTime DateTimes { get { return _DateTimes; } set { _DateTimes = value; } }
    }
}
