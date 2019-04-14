using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.MerchantManage
{
    /// <summary>
	/// 招商信息实体类MerchantInfoTab 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
         public class MerchantModel
    {


         public MerchantModel()
		{}
		#region Model
		private long _infoid;
		private string _merchanttypeid;
		private string _industryclasslist;
		private string _countrycode;
		private string _provinceid;
		private string _countyid;
		private string _zoneabout;
		private string _zoneaboutbrief;
		private string _remark;
		private string _capitalcurrency;
		private decimal? _capitaltotal;
		private string _cityid;
		private string _cooperationdemandtype;
		private string _merchantcurrency;
		private int? _merchantorganization;
		private string _merchanttotal;
		private string _receiveorganization;
		private bool _isvip;
		private string _vipabout;
		private int? _pricebyuser;
		private string _economicindicators;
		private string _investmentenvironment;
		private string _projectstatus;
		private string _market;
		private int? _evaluationpop;
		private int? _topcertification;
		private int? _informationintegrity;
		private string _benefit;
		/// <summary>
		/// InfoID
		/// </summary>
		public long InfoID
		{
			set{ _infoid=value;}
			get{return _infoid;}
		}
		/// <summary>
		/// MerchantTypeID
		/// </summary>
		public string MerchantTypeID
		{
			set{ _merchanttypeid=value;}
			get{return _merchanttypeid;}
		}
		/// <summary>
		/// IndustryClassList
		/// </summary>
		public string IndustryClassList
		{
			set{ _industryclasslist=value;}
			get{return _industryclasslist;}
		}
		/// <summary>
		/// CountryCode
		/// </summary>
		public string CountryCode
		{
			set{ _countrycode=value;}
			get{return _countrycode;}
		}
		/// <summary>
		/// ProvinceID
		/// </summary>
		public string ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// CountyID
		/// </summary>
		public string CountyID
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}
		/// <summary>
		/// ZoneAbout
		/// </summary>
		public string ZoneAbout
		{
			set{ _zoneabout=value;}
			get{return _zoneabout;}
		}
		/// <summary>
		/// 区域介绍提炼
		/// </summary>
		public string ZoneAboutBrief
		{
			set{ _zoneaboutbrief=value;}
			get{return _zoneaboutbrief;}
		}
		/// <summary>
		/// Remrk
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// CapitalCurrency
		/// </summary>
		public string CapitalCurrency
		{
			set{ _capitalcurrency=value;}
			get{return _capitalcurrency;}
		}
		/// <summary>
		/// CapitalTotal
		/// </summary>
		public decimal? CapitalTotal
		{
			set{ _capitaltotal=value;}
			get{return _capitaltotal;}
		}
		/// <summary>
		/// CityID
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// CooperationDemandType
		/// </summary>
		public string CooperationDemandType
		{
			set{ _cooperationdemandtype=value;}
			get{return _cooperationdemandtype;}
		}
		/// <summary>
		/// MerchantCurrency
		/// </summary>
		public string MerchantCurrency
		{
			set{ _merchantcurrency=value;}
			get{return _merchantcurrency;}
		}
		/// <summary>
		/// MerchantOrganization
		/// </summary>
		public int? MerchantOrganization
		{
			set{ _merchantorganization=value;}
			get{return _merchantorganization;}
		}
		/// <summary>
		/// MerchantTotal
		/// </summary>
		public string MerchantTotal
		{
			set{ _merchanttotal=value;}
			get{return _merchanttotal;}
		}
		/// <summary>
		/// ReceiveOrganization
		/// </summary>
		public string ReceiveOrganization
		{
			set{ _receiveorganization=value;}
			get{return _receiveorganization;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ISVIP
		{
			set{ _isvip=value;}
			get{return _isvip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VIPABOUT
		{
			set{ _vipabout=value;}
			get{return _vipabout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PriceByUser
		{
			set{ _pricebyuser=value;}
			get{return _pricebyuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EconomicIndicators
		{
			set{ _economicindicators=value;}
			get{return _economicindicators;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InvestmentEnvironment
		{
			set{ _investmentenvironment=value;}
			get{return _investmentenvironment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectStatus
		{
			set{ _projectstatus=value;}
			get{return _projectstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Market
		{
			set{ _market=value;}
			get{return _market;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EvaluationPop
		{
			set{ _evaluationpop=value;}
			get{return _evaluationpop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TopCertification
		{
			set{ _topcertification=value;}
			get{return _topcertification;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? InformationIntegrity
		{
			set{ _informationintegrity=value;}
			get{return _informationintegrity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Benefit
		{
			set{ _benefit=value;}
			get{return _benefit;}
		}
		#endregion Model

	}
}
