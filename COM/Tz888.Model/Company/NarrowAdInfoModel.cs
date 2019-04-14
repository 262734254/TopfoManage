using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    public class NarrowAdInfoModel
    {
        #region Model
        private int _adid;//编号 主键
        private string _username;//发布人
        private DateTime? _createdate;//发布时间    
        private string _title;//标题
        private string _descript;//内容
        private string _url;//路径
        private string _infotypename;//会员类型
        private string _countrycode;//所对应国家
        private string _provinceid;//省份
        private string _cityid;//城市
        private string _countyid;//地区
        private string _industrybid;//行业
        /// <summary>
        /// 编号 主键
        /// </summary>
        public int AdID
        {
            set { _adid = value; }
            get { return _adid; }
        }
        /// <summary>
        /// 发布人
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
        /// <summary>
        /// 路径
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 会员类型
        /// </summary>
        public string InfoTypeName
        {
            set { _infotypename = value; }
            get { return _infotypename; }
        }
        /// <summary>
        /// 所对应国家
        /// </summary>
        public string CountryCode
        {
            set { _countrycode = value; }
            get { return _countrycode; }
        }
        /// <summary>
        /// 省份
        /// </summary>
        public string ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 城市
        /// </summary>
        public string CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 地区
        /// </summary>
        public string CountyId
        {
            set { _countyid = value; }
            get { return _countyid; }
        }
        /// <summary>
        /// 行业
        /// </summary>
        public string IndustryBID
        {
            set { _industrybid = value; }
            get { return _industrybid; }
        }
        #endregion Model
    }
}
