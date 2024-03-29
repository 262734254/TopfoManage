using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;
using Tz888.IDAL.Register;
using Tz888.IDAL.ProfessionalManage;
using Tz888.IDAL;
using Tz888.IDAL.report;
using Tz888.IDAL.Recomm;
namespace Tz888.DALFactory
{
    /// <summary>
    /// 反射创建数据访问逻辑层操作类
    /// </summary>
    public class DataAccess
    {
        //<add key="DAL" value="Tz888.SQLServerDAL"/>
        private static readonly string path = ConfigurationManager.AppSettings["DAL"]; //从配置文件获取数据访问逻辑层名称
        /// <summary> 
        /// 创建对象或从缓存获取 
        /// </summary>
        public static object CreateObject(string path, string CacheKey)
        {
            object objType = DataCache.GetCache(CacheKey);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(path).CreateInstance(CacheKey);//反射创建
                    DataCache.SetCache(CacheKey, objType);// 写入缓存
                }
                catch (System.Exception ex)
                {
                    string str = ex.Message.ToString();
                }
            }
            return objType;
        }

        /// <summary>
        /// 创建权限数据读取接口
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.IPermission CreatePermission()
        {
            string className = path + ".Permission";
            return (Tz888.IDAL.IPermission)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// 创建IModel数据层接口
        /// </summary>
        public static Tz888.IDAL.IModel CreateIModel()
        {
            string CacheKey = path + ".Model";
            object objType = CreateObject(path, CacheKey);
            return (IModel)objType;
        }
        public static Tz888.IDAL.Recomm.recommResourceIDAL CreaterecommResourceDAL()
        {
            string CacheKey = path + ".Recomm";
            object objType = CreateObject(path, CacheKey);
            return (recommResourceIDAL)objType;
        }
        /// <summary>
        /// 数据库读取
        /// </summary>
        public static Tz888.IDAL.IConn CreateIConn()
        {
            string CacheKey = path + ".Conn";
            object objType = CreateObject(path, CacheKey);
            return (IConn)objType;
        }
        #region  拓富助手
        /// <summary>
        /// 我的短消息
        /// </summary>
        public static Tz888.IDAL.IInnerInfo CreateIInnerInfo()
        {
            string CacheKey = path + ".InnerInfo";
            object objType = CreateObject(path, CacheKey);
            return (IInnerInfo)objType;
        }

        /// <summary>
        /// 会员资料
        /// </summary>
        public static Tz888.IDAL.IMemberResource CreateMemberResource()
        {
            string CacheKey = path + ".MemberResourceDAL";
            object objType = CreateObject(path, CacheKey);
            return (IMemberResource)objType;
        }

        /// <summary>
        /// 公司收藏
        /// </summary>
        public static Tz888.IDAL.ICollection CreateICollection()
        {
            string CacheKey = path + ".CollectionDAL";
            object objType = CreateObject(path, CacheKey);
            return (ICollection)objType;
        }

        /// <summary>
        /// 在线恰谈
        /// </summary>
        public static Tz888.IDAL.ILoginInfoIM CreateLoginInfoIM()
        {
            string CacheKey = path + ".LoginInfoIMDAL";
            object objType = CreateObject(path, CacheKey);
            return (ILoginInfoIM)objType;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public static Tz888.IDAL.ICustomInfo CreateICustomInfo()
        {
            string CacheKey = path + ".CustomInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (ICustomInfo)objType;
        }
        public static Tz888.IDAL.ProfessionalManage.ProfessionalinfoIDAL CreateMainInfo()
        {
            string CacheKey = path + ".ProfessionalManage.ProfessionalinfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (ProfessionalinfoIDAL)objType;
        }
        
        public static Tz888.IDAL.ProfessionalManage.ProfessionalLinkIDAL CreateLinkInfo()
        {
            string CacheKey = path + ".ProfessionalManage.ProfessionalLinkDAL";
            object objType = CreateObject(path, CacheKey);
            return (ProfessionalLinkIDAL)objType;
        }

        /// <summary>
        /// 信息订阅
        /// </summary>
        public static Tz888.IDAL.IPageIniControl CreateIPageIniControl()
        {
            string CacheKey = path + ".PageIniControlDAL";
            object objType = CreateObject(path, CacheKey);
            return (IPageIniControl)objType;
        }

        #region 注册/登记/拓富通审请
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.Register.LoginInfo CreateLoginInfo()
        {
            string CacheKey = path + ".Register.LoginfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (LoginInfo)objType;
        }
        public static Tz888.IDAL.ProfessionalManage.ProfessionalPleaseIDAL CreatePleaseInfo()
        {
            string CacheKey = path + ".ProfessionalManage.ProfessionalPleaseDAL";
            object objType = CreateObject(path, CacheKey);
            return (ProfessionalPleaseIDAL)objType;
        }
        public static Tz888.IDAL.ProfessionalManage.ProfessionaltalentsIDAL CreatetalentsInfo()
        {
            string CacheKey = path + ".ProfessionalManage.ProfessionaltalentsDAL";
            object objType = CreateObject(path, CacheKey);
            return (ProfessionaltalentsIDAL)objType;
        }
        /// <summary>
        /// 拓富通会员申请
        /// </summary>
        public static Tz888.IDAL.Register.IVIPMemberRegister CreateVIPMemberRegister()
        {
            string CacheKey = path + ".Register.VIPMemberRegister";
            object objType = CreateObject(path, CacheKey);
            return (IVIPMemberRegister)objType;
        }
        /// <summary>
        /// 公司登记
        /// </summary>
        public static Tz888.IDAL.Register.IEnterpriseRegister CreateEnterpriseRegister()
        {
            string CacheKey = path + ".Register.EnterpriseRegister";
            object objType = CreateObject(path, CacheKey);
            return (IEnterpriseRegister)objType;
        }
        /// <summary>
        /// 机构登记
        /// </summary>
        public static Tz888.IDAL.Register.IGovernmentRegister CreateGovernmentRegister()
        {
            string CacheKey = path + ".Register.GovernmentRegister";
            object objType = CreateObject(path, CacheKey);
            return (IGovernmentRegister)objType;
        }

        /// <summary>
        /// 机构登记
        /// </summary>
        public static Tz888.IDAL.Register.common CreateCommmonObj()
        {
            string CacheKey = path + ".Register.common";
            object objType = CreateObject(path, CacheKey);
            return (common)objType;
        }

        /// <summary>
        /// 机构登记
        /// </summary>
        public static Tz888.IDAL.Register.ISEOLoginTab CreateSEOLoginObj()
        {
            string CacheKey = path + ".Register.SEOLoginTabDAL";
            object objType = CreateObject(path, CacheKey);
            return (ISEOLoginTab)objType;
        }

        #endregion

        #region 留言管理
        public static Tz888.IDAL.ILeaveMsg CreateILeaveMsg()
        {
            string CacheKey = path + ".LeaveMsg";
            object objType = CreateObject(path, CacheKey);
            return (ILeaveMsg)objType;
        }
        #endregion

        #region 好友管理
        public static Tz888.IDAL.IGoodFriend CreateIGoodFriend()
        {
            string CacheKey = path + ".GoodFriend";
            object objType = CreateObject(path, CacheKey);
            return (IGoodFriend)objType;
        }
        #endregion

        #region 支付
        //支付密码与密码保护
        public static Tz888.IDAL.IPayPwd CreateIPayPwd()
        {
            string CacheKey = path + ".PayPwd";
            object objType = CreateObject(path, CacheKey);
            return (IPayPwd)objType;
        }

        //充值
        public static Tz888.IDAL.IStrikeOrder CreateStrikeOrder()
        {
            string CacheKey = path + ".StrikeOrder";
            object objType = CreateObject(path, CacheKey);
            return (IStrikeOrder)objType;
        }
        public static Tz888.IDAL.IPay CreateIPay()
        {
            string CacheKey = path + ".Pay";
            object objType = CreateObject(path, CacheKey);
            return (IPay)objType;
        }
        //帐户统计信息
        public static Tz888.IDAL.IAccountInfo CreateIAccountInfo()
        {
            string CacheKey = path + ".AccountInfo";
            object objType = CreateObject(path, CacheKey);
            return (IAccountInfo)objType;
        }

        //积分转换成购物券
        public static Tz888.IDAL.IVoucherConvert CreateIVoucherConvert()
        {
            string CacheKey = path + ".VoucherConvert";
            object objType = CreateObject(path, CacheKey);
            return (IVoucherConvert)objType;
        }

        public static Tz888.IDAL.ICard CreateICard()
        {
            string CacheKey = path + ".Card";
            object objType = CreateObject(path, CacheKey);
            return (ICard)objType;
        }
        #endregion

        #region 订单管理
        public static Tz888.IDAL.IOrderManage CreateOrderManage()
        {
            string CacheKey = path + ".OrderManage";
            object objType = CreateObject(path, CacheKey);
            return (IOrderManage)objType;
        }
        #endregion

        public static Tz888.IDAL.IFinance CreateFinance()
        {
            string CacheKey = path + ".Finance";
            object objType = CreateObject(path, CacheKey);
            return (IFinance)objType;
        }

        #region 手机短信发送
        public static Tz888.IDAL.IAutoSendMsg CreateAutoSendMsg()
        {
            string CacheKey = path + ".AutoSendMsg";
            object objType = CreateObject(path, CacheKey);
            return (IAutoSendMsg)objType;
        }
        public static Tz888.IDAL.IVipMsg CreateVipMsg()
        {
            string CacheKey = path + ".VipMsg";
            object objType = CreateObject(path, CacheKey);
            return (IVipMsg)objType;
        }
        public static Tz888.IDAL.ISendNotice CreateSendNotice()
        {
            string CacheKey = path + ".SendNotice";
            object objType = CreateObject(path, CacheKey);
            return (ISendNotice)objType;
        }
        #endregion

        #region 定向推广设置
        //设置
        public static Tz888.IDAL.ISubscribeSet CreateSubscribeSet()
        {
            string CacheKey = path + ".SubscribeSet";
            object objType = CreateObject(path, CacheKey);
            return (ISubscribeSet)objType;
        }

        #endregion

        #region  用户参数
        public static Tz888.IDAL.IUserParameters CreateUserParameters()
        {
            string CacheKey = path + ".UserParameters";
            object objType = CreateObject(path, CacheKey);
            return (IUserParameters)objType;
        }
        #endregion

        #region Common

        /// <summary>
        /// 行业类别数据库访问逻辑层创建
        /// </summary>
        public static Tz888.IDAL.Common.IIndustry CreateIndustry()
        {
            string CacheKey = path + ".Common.IndustryDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Common.IIndustry)objType;
        }

        /// <summary>
        /// 国家地区信息数据库访问逻辑类
        /// </summary>
        public static Tz888.IDAL.Common.IZoneSelect CreateZoneSelect()
        {
            string CacheKey = path + ".Common.ZoneSelectDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Common.IZoneSelect)objType;
        }

        /// <summary>
        /// 投融资金额设置数据库访问逻辑类
        /// </summary>
        public static Tz888.IDAL.Common.ISetCapital CreateSetCapital()
        {
            string CacheKey = path + ".Common.SetCapitalDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Common.ISetCapital)objType;
        }

        /// <summary>
        /// 招商类别设置数据库访问逻辑类
        /// </summary>
        public static Tz888.IDAL.Common.ISetMerchantAttribute CreateSetMerchantAttribute()
        {
            string CacheKey = path + ".Common.SetMerchantAttribute";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Common.ISetMerchantAttribute)objType;
        }
        /// <summary>
        /// 回访频道数据库访问逻辑类
        /// </summary>
        public static Tz888.IDAL.Visit.IVisitInfo CreateVisitInfo()
        {
            string CacheKey = path + ".Visit.VisitInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Visit.IVisitInfo)objType;
        }

        /// <summary>
        /// 广告频道数据库访问逻辑类
        /// </summary>
        public static Tz888.IDAL.advertise.IADlaunchInfo CreateADlaunchInfo()
        {
            string CacheKey = path + ".advertise.ADlaunchInfoService";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.advertise.IADlaunchInfo)objType;
        }
        /// <summary>
        /// 广告主数据库访问逻辑类
        /// </summary>
        public static Tz888.IDAL.advertise.IADchannelInfo CreateADchannelInfo()
        {
            string CacheKey = path + ".advertise.ADchannelInfoService";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.advertise.IADchannelInfo)objType;
        }
        /// <summary>
        /// 广告访问量数据库访问逻辑类
        /// </summary>
        public static Tz888.IDAL.advertise.IAdvisitInfo CreateAdvisitInfo()
        {
            string CacheKey = path + ".advertise.AdvisitInfoService";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.advertise.IAdvisitInfo)objType;
        }
        /// <summary>
        /// 广告设置数据库访问逻辑类
        /// </summary>
        public static Tz888.IDAL.advertise.IADMessageInfo CreateADMessageInfo()
        {
            string CacheKey = path + ".advertise.ADMessageInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.advertise.IADMessageInfo)objType;
        }
        /// <summary>
        /// 币种设置数据库访问逻辑类
        /// </summary>
        public static Tz888.IDAL.Common.ISetCurrency CreateSetCurrency()
        {
            string CacheKey = path + ".Common.SetCurrencyDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Common.ISetCurrency)objType;
        }

        /// <summary>
        /// 参数表
        /// </summary>
        public static Tz888.IDAL.Common.IDictionaryInfo CreateDictionaryInfo()
        {
            string CacheKey = path + ".Common.DictionaryInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Common.IDictionaryInfo)objType;
        }

        /// <summary>
        /// 公共参数设置逻辑
        /// </summary>
        public static Tz888.IDAL.Common.IParameter CreateParameter()
        {
            string CacheKey = path + ".Common.ParameterDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Common.IParameter)objType;
        }

        #endregion
        /// <summary>
        /// 发布资讯资源数据库访问逻辑类创建
        /// </summary>
        public static Tz888.IDAL.zx.INewsTableService CreateInfo_NewsTableService()
        {
            string CacheKey = path + ".zx.NewsTableService";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.zx.INewsTableService)objType;
        }
        /// <summary>
        /// 创业发布资源数据库访问逻辑类创建
        /// </summary>
        public static Tz888.IDAL.CarveOut.ICarveOutService CreateInfo_CarveOutInformation()
        {
            string CacheKey = path + ".CarveOut.CarveOutInformationDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.CarveOut.ICarveOutService)objType;
        }
        /// <summary>
        /// 服务类型
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.ProfessionalManage.ProfessionalTypeIDAL CreateTypeInfo()
        {
            string CacheKey = path + ".ProfessionalManage.ProfessionalTypeDAL";
            object objType = CreateObject(path, CacheKey);
            return (ProfessionalTypeIDAL)objType;
        }

        public static Tz888.IDAL.ProfessionalManage.ProfessionalviewIDAL CreateviewInfo()
        {
            string CacheKey = path + ".ProfessionalManage.ProfessionalviewDAL";
            object objType = CreateObject(path, CacheKey);
            return (ProfessionalviewIDAL)objType;
        }

        #region 招投融信息处理

        /// <summary>
        /// 资源信息公共数据库访问逻辑类创建
        /// </summary>
        public static Tz888.IDAL.Info.ICommon CreateInfo_Common()
        {
            string CacheKey = path + ".Info.Common";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Info.ICommon)objType;
        }

        /// <summary>
        /// 信息数据库访问逻辑类创建
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.Info.IMainInfo CreateInfo_MainInfo()
        {
            string CacheKey = path + ".Info.MainInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Info.IMainInfo)objType;
        }

        /// <summary>
        /// 招商资源数据库访问逻辑类创建
        /// </summary>
        public static Tz888.IDAL.Info.IMarchantInfo CreateInfo_MarchantInfo()
        {
            //转到SQLServerDAL.Info.MarchantInfoDAL
            string CacheKey = path + ".Info.MarchantInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Info.IMarchantInfo)objType;
        }

        /// <summary>
        /// 招商资源数据库访问逻辑类创建
        /// </summary>
        public static Tz888.IDAL.MerchantManage.IMerchant CreateInfo_MarchanInfo()
        {
            //转到SQLServerDAL.Info.MarchantInfoDAL
            string CacheKey = path + ".MerchantManage.MarchantInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.MerchantManage.IMerchant)objType;
        }


        /// <summary>
        /// 投资资源数据库访问逻辑类创建
        /// </summary>
        public static Tz888.IDAL.Info.ICapitalInfo CreateInfo_CapitalInfo()
        {
            string CacheKey = path + ".Info.CapitalInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Info.ICapitalInfo)objType;
        }
        /// <summary>
        /// 最新投资资源数据库访问逻辑类创建
        /// </summary>
        public static Tz888.IDAL.offer.ICapitalInfoService CreateInfo_CapitalInfoService()
        {
            string CacheKey = path + ".offer.CapitalInfoService";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.offer.ICapitalInfoService)objType;
        }
        public static Tz888.IDAL.Order.IndustryReportIDAL CreateIndustryReport()
        {
            string CacheKey = path + ".Order.IndustryReportDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Order.IndustryReportIDAL)objType;
        }
        public static Tz888.IDAL.Order.OrderLinkIDAL CreateOrderLink()
        {
            string CacheKey = path + ".Order.OrderLinkDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Order.OrderLinkIDAL)objType;
        }
        public static Tz888.IDAL.Order.OrderMainIDAL CreateOrderMain()
        {
            string CacheKey = path + ".Order.OrderMainDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Order.OrderMainIDAL)objType;
        }
        /// <summary>
        /// 融资资源数据库访问逻辑类创建
        /// </summary>
        public static Tz888.IDAL.Info.IProjectInfo CreateInfo_ProjectInfo()
        {
            string CacheKey = path + ".Info.ProjectInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Info.IProjectInfo)objType;
        }
        public static Tz888.IDAL.Info.IInfoContact CreateInfo_InfoContact()
        {
            string CacheKey = path + ".Info.InfoContactDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Info.IInfoContact)objType;
        }
        #endregion

        #region 拓富指数评估系统
        /// <summary>
        /// 拓富指数评估系统公共数据访问逻辑类创建
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.TFZS.ICommon CreateTFZS_Common()
        {
            string CacheKey = path + ".TFZS.Common";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.TFZS.ICommon)objType;
        }

        /// <summary>
        /// 主指标数据访问逻辑类创建
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.TFZS.IMainTarget CreateTFZS_MainTarget()
        {
            string CacheKey = path + ".TFZS.MainTargetDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.TFZS.IMainTarget)objType;
        }

        /// <summary>
        /// 表现指标数据访问逻辑类创建
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.TFZS.IExpressTarget CreateTFZS_ExpressTarget()
        {
            string CacheKey = path + ".TFZS.ExpressTargetDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.TFZS.IExpressTarget)objType;
        }

        /// <summary>
        /// 衡量目标数据访问逻辑类创建
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.TFZS.IMeasureStandard CreateTFZS_MeasureStandard()
        {
            string CacheKey = path + ".TFZS.MeasureStandardDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.TFZS.IMeasureStandard)objType;
        }

        /// <summary>
        /// 拓富指数答案数据逻辑访问类
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.TFZS.ITFZS_ProjectDetaiSub CreateTFZS_ProjectDetaiSub()
        {
            string CacheKey = path + ".TFZS.TFZS_ProjectDetaiSubDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.TFZS.ITFZS_ProjectDetaiSub)objType;
        }

        #endregion

        #region  用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.LoginInfo.ILoginInfo CreateILoginInfo_LoginInfo()
        {
            string CacheKey = path + ".LoginInfo.LoginInfo";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.LoginInfo.ILoginInfo)objType;
        }

        /// <summary>
        /// 用户登录公用
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.LoginInfo.ICommon CreateILoginInfo_Common()
        {
            string CacheKey = path + ".LoginInfo.Common";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.LoginInfo.ICommon)objType;
        }
        #endregion

        #region 公用函数
        public static Tz888.IDAL.Common.ICommonFunction CreateICommon_CommonFunction()
        {
            string CacheKey = path + ".Common.CommonFunction";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Common.ICommonFunction)objType;
        }
        #endregion

        #region 会员信息
        public static Tz888.IDAL.Register.IMemberInfo CreateIMemberInfo()
        {
            string CacheKey = path + ".Register.MemberInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Register.IMemberInfo)objType;
        }
        #endregion

        #region 会员管理信息
        public static Tz888.IDAL.IMemberInfo CreateIMemberManageInfo()
        {
            string CacheKey = path + ".MemberManageInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.IMemberInfo)objType;
        }
        #endregion

        #region 权限管理
        public static Tz888.IDAL.Manage.IPermission CreateIPermission()
        {
            string CacheKey = path + ".Manage.PermissionDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Manage.IPermission)objType;
        }
        #endregion

        #region 搜索信息
        public static Tz888.IDAL.Search.ISearchInfo CreateISearchInfo()
        {
            string CacheKey = path + ".Search.SearchInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Search.ISearchInfo)objType;
        }
        #endregion

        #region 资讯信息
        public static Tz888.IDAL.ITPMerchant CreateITPMerchant()
        {
            string CacheKey = path + ".TPMerchant";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.ITPMerchant)objType;
        }
        #endregion

        #region 视频信息
        public static Tz888.IDAL.ITPVideo CreateITPVideo()
        {
            string CacheKey = path + ".TPVideo";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.ITPVideo)objType;
        }
        #endregion

        #region 图片信息
        public static Tz888.IDAL.ITPPicture CreateITPPicture()
        {
            string CacheKey = path + ".TPPicture";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.ITPPicture)objType;
        }
        #endregion

        #region 后台管理
        public static Tz888.IDAL.Manage.IMenuPermission CreateMenuPermission()
        {
            string CacheKey = path + ".Manage.MenuPermissionDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Manage.IMenuPermission)objType;
        }
        #endregion

        #region 资源匹配
        public static Tz888.IDAL.Info.IMatchInfo CreateMatchInfo()
        {
            string CacheKey = path + ".Info.MatchInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Info.IMatchInfo)objType;
        }
        #endregion

        #region 会员信息
        public static Tz888.IDAL.LoginInfo.IMember CreateMember()
        {
            string CacheKey = path + ".LoginInfo.Member";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.LoginInfo.IMember)objType;
        }
        #endregion

        #region 信息查看收藏
        public static Tz888.IDAL.Info.IInfoViewCollection CreateInfoViewCollection()
        {
            string CacheKey = path + ".Info.InfoViewCollectionDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Info.IInfoViewCollection)objType;
        }
        #endregion

        #region 自动生成关键字类（后台管理）
        public static Tz888.IDAL.Info.ISetSubDefaultValue CreateSetSubDefaultValue()
        {
            string CacheKey = path + ".Info.SetSubDefaultValue";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Info.ISetSubDefaultValue)objType;
        }

        public static Tz888.IDAL.Info.IInfoDefaultDEF CreateInfoDefaultDEF()
        {
            string CacheKey = path + ".Info.InfoDefaultDEF";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Info.IInfoDefaultDEF)objType;
        }

        public static Tz888.IDAL.Info.ISetDefaultValue CreateSetDefaultValue()
        {
            string CacheKey = path + ".Info.SetDefaultValue";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Info.ISetDefaultValue)objType;
        }
        #endregion

        #region 新版网站调查
        public static Tz888.IDAL.Common.IInquiry CreateInquiry()
        {
            string CacheKey = path + ".Common.InquiryDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Common.IInquiry)objType;
        }
        #endregion

        #region 日志操作
        public static Tz888.IDAL.ILog CreateLog()
        {
            string CacheKey = path + ".Log";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.ILog)objType;
        }
        #endregion

        #region 资源自动静态化

        public static Tz888.IDAL.InfoStatic.IInfoStaticQueueTab CreateInfoStaticQueue()
        {
            string CacheKey = path + ".InfoStatic.InfoStaticQueueTab";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.InfoStatic.IInfoStaticQueueTab)objType;
        }

        public static Tz888.IDAL.InfoStatic.ISetInfoPageStaticTab CreateSetInfoPageStaticTab()
        {
            string CacheKey = path + ".InfoStatic.SetInfoPageStaticTab";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.InfoStatic.ISetInfoPageStaticTab)objType;
        }
        #endregion

        #region 企业名片
        public static Tz888.IDAL.Company.ICompanyInfoTab CreateCompany()
        {
            string CacheKey = path + ".Company.CompanyDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Company.ICompanyInfoTab)objType;
        }
        #endregion

        #region 企业展厅
        public static Tz888.IDAL.Company.ICompanyShow CreateCompanyShow()
        {
            string CacheKey = path + ".Company.CompanyShowDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Company.ICompanyShow)objType;
        }
        #endregion

        #region
        public static Tz888.IDAL.Company.ICompanyMade CreateCompanyMade()
        {
            string CacheKey = path + ".Company.CompanyMadeDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Company.ICompanyMade)objType;
        }
        #endregion

        #region 专题推广
        public static Tz888.IDAL.Subject.ISubjectExtend CreateSubject()
        {
            string CacheKey = path + ".Subject.SubjectExtendDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Subject.ISubjectExtend)objType;
        }
        #endregion

        #region
        public static Tz888.IDAL.ICasesInfoTab CreateCasesInfoTab()
        {
            string CacheKey = path + ".CaseInfoTabDAL";
            object objType = CreateObject(path, CacheKey);
            return (ICasesInfoTab)objType;
        }
        #endregion
        public static Tz888.IDAL.IAreaText CreateAreaText()
        {
            string CacheKey = path + ".AreaText";
            object objType = CreateObject(path, CacheKey);
            return (IAreaText)objType;
        }
        public static Tz888.IDAL.IIndex_Edit CreateIndex_Edit()
        {
            string CacheKey = path + ".Index_Edit";
            object objType = CreateObject(path, CacheKey);
            return (IIndex_Edit)objType;
        }
        public static Tz888.IDAL.IMerchantOppor CreateMerchantOppor()
        {
            string CacheKey = path + ".MerchantOppor";
            object objType = CreateObject(path, CacheKey);
            return (IMerchantOppor)objType;
        }
        public static Tz888.IDAL.IMerchantSite CreateMerchantSite()
        {
            string CacheKey = path + ".MerchantSite";
            object objType = CreateObject(path, CacheKey);
            return (IMerchantSite)objType;
        }
        public static Tz888.IDAL.IloansInfoTab CreateILoansInfoTab()
        {
            string CacheKey = path + ".loansInfoTab";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.IloansInfoTab)objType;
        }
        public static Tz888.IDAL.IloansInfo CreateILoansInfo()
        {
            string CacheKey = path + ".loansInfo";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.IloansInfo)objType;
        }
        public static Tz888.IDAL.IloanscontactsTab CreateIloanscontactsTab()
        {
            string CacheKey = path + ".loanscontactsTab";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.IloanscontactsTab)objType;
        }
        public static Tz888.IDAL.news.INewsTab CreateINewsTab()
        {
            string CacheKey = path + ".NewsTab";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.news.INewsTab)objType;
        }
        public static Tz888.IDAL.news.INewsTypeTab CreateINewsTypeTab()
        {
            string CacheKey = path + ".NewsTypeTab";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.news.INewsTypeTab)objType;
        }
        public static Tz888.IDAL.report.IndustryFromIDAL CreateIndustryFrom()
        {
            string CacheKey = path + ".report.IndustryFromDAL";
            object objType = CreateObject(path, CacheKey);
            return (IndustryFromIDAL)objType;
        }
        public static Tz888.IDAL.report.IreportTab CreateIreportTab()
        {
            string CacheKey = path + ".report.reportTabDAL";
            object objType = CreateObject(path, CacheKey);
            return (IreportTab)objType;
        }
        public static Tz888.IDAL.Express.ExpressIDAL CreateIExpress()
        {
            string CacheKey = path + ".Express.ExpressDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Express.ExpressIDAL)objType;
        }
        public static Tz888.IDAL.report.IreportView CreateIreportView()
        {
            string CacheKey = path + ".report.reportViewDAL";
            object objType = CreateObject(path, CacheKey);
            return (IreportView)objType;
        }
        public static Tz888.IDAL.news.INewsViewTab CreateINewsViewTab()
        {
            string CacheKey = path + ".NewsViewTab";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.news.INewsViewTab)objType;
        }
        public static Tz888.IDAL.IMerchantChanel CreateMerchantChanel()
        {
            string CacheKey = path + ".MerchantChanel";
            object objType = CreateObject(path, CacheKey);
            return (IMerchantChanel)objType;
        }
        public static Tz888.IDAL.Info.IInfoResource CreateInfo_InfoResource()
        {
            string CacheKey = path + ".Info.InfoResourceDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Info.IInfoResource)objType;
        }
        //商机
        public static Tz888.IDAL.Info.IOpportunityInfo CreateOpportunityInfo()
        {
            string CacheKey = path + ".Info.OpportunityInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Info.IOpportunityInfo)objType;
        }
        public static Tz888.IDAL.Info.V124.ICapitalInfo CreateCapitalInfo_V124()
        {
            string CacheKey = path + ".Info.V124.CapitalInfoDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.Info.V124.ICapitalInfo)objType;
        }


        public static Tz888.IDAL.IConsumeInfos CreateIConsumeInfos()
        {
            string CacheKey = path + ".ConsumeInfos";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.IConsumeInfos)objType;
        }

        public static Tz888.IDAL.IAuditMail CreateIAuditMail()
        {
            string CacheKey = path + ".AuditMail";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.IAuditMail)objType;
        }

        public static Tz888.IDAL.IConsumeRepay CreateIConsumeRepay()
        {
            string CacheKey = path + ".ConsumeRepay";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.IConsumeRepay)objType;
        }

        public static Tz888.IDAL.INotice CreateINotice()
        {
            string CacheKey = path + ".Notice";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.INotice)objType;
        }

        public static Tz888.IDAL.IResourcesNotice CreateIResourcesNotice()
        {
            string CacheKey = path + ".ResourcesNotice";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.IResourcesNotice)objType;
        }

        public static Tz888.IDAL.IUserInfo CreateIUserInfo()
        {
            string CacheKey = path + ".UserInfo";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.IUserInfo)objType;
        }

        public static Tz888.IDAL.IWebUnion_UserInfo CreateIWebUnion_UserInfo()
        {
            string CacheKey = path + ".WebUnion_UserInfo";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.IWebUnion_UserInfo)objType;
        }
        public static Tz888.IDAL.Info.V124.IMerchantZone CreateIMerchantZone()
        {
            string CacheKey = path + ".Info.V124.MerchantZoneDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Info.V124.IMerchantZone)objType;
        }


        #region 口碑网koubei操作
        public static Tz888.IDAL.Koubei.IJoinkoubei CreateIJoinkoubei()
        {
            string CacheKey = path + ".Koubei.JoinKoubeiDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Koubei.IJoinkoubei)objType;
        }
        #endregion

        public static Tz888.IDAL.ICommendDAL CreateICommendDAL()
        {
            string CacheKey = path + ".CommendDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.ICommendDAL)objType;
        }

        public static Tz888.IDAL.Email.IEmail CreateIEmailDAL()
        {
            string CacheKey = path + ".Email.EmailDAL";
            object objType = CreateObject(path, CacheKey);
            return (IDAL.Email.IEmail)objType;
        }

        #region 举报信息数据库访问逻辑类创建
        /// <summary>
        /// 举报信息数据库访问逻辑类创建
        /// </summary>
        /// <returns></returns>

        public static Tz888.IDAL.IReportTab CreateInfo_IReportTab()
        {
            string CacheKey = path + ".ReportTabDAL";
            object objType = CreateObject(path, CacheKey);
            return (Tz888.IDAL.IReportTab)objType;
        }
        #endregion

        #region 系统权限管理模块
        /// <summary>
        /// 创建EmployeeInfoTab数据层接口
        /// </summary>
        public static Tz888.IDAL.Sys.IEmployeeInfoTab CreateEmployeeInfoTab()
        {

            string ClassNamespace = path + ".Sys.EmployeeInfoTab";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.Sys.IEmployeeInfoTab)objType;
        }
        /// <summary>
        /// 创建SysGroupTab数据层接口
        /// </summary>
        public static Tz888.IDAL.Sys.ISysGroupTab CreateSysGroupTab()
        {

            string ClassNamespace = path + ".Sys.SysGroupTab";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.Sys.ISysGroupTab)objType;
        }
        /// <summary>
        /// 创建SysMenuTab数据层接口
        /// </summary>
        public static Tz888.IDAL.Sys.ISysMenuTab CreateSysMenuTab()
        {

            string ClassNamespace = path + ".Sys.SysMenuTab";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.Sys.ISysMenuTab)objType;
        }
        /// <summary>
        /// 创建SysPermissionTab数据层接口
        /// </summary>
        public static Tz888.IDAL.Sys.ISysPermissionTab CreateSysPermissionTab()
        {

            string ClassNamespace = path + ".Sys.SysPermissionTab";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.Sys.ISysPermissionTab)objType;
        }
        /// <summary>
        /// 创建SysRoleTab数据层接口
        /// </summary>
        public static Tz888.IDAL.Sys.ISysRoleTab CreateSysRoleTab()
        {

            string ClassNamespace = path + ".Sys.SysRoleTab";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.Sys.ISysRoleTab)objType;
        }
        /// <summary>
        /// 创建Sys数据层接口
        /// </summary>
        public static Tz888.IDAL.Sys.ISystem CreateSystem()
        {

            string ClassNamespace = path + ".Sys.System";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.Sys.ISystem)objType;
        }
        /// <summary>
        /// 创建SysMenuTab数据层接口
        /// </summary>
        public static Tz888.IDAL.dp.ISysMenuTab CreatedpMenuTab()
        {

            string ClassNamespace = path + ".dp.SysMenuTab";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.dp.ISysMenuTab)objType;
        }
        /// <summary>
        /// 创建dpPermissionTab数据层接口
        /// </summary>
        public static Tz888.IDAL.dp.ISysPermissionTab CreatedpPermissionTab()
        {

            string ClassNamespace = path + ".dp.SysPermissionTab";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.dp.ISysPermissionTab)objType;
        }
        /// <summary>
        /// 创建dp数据层接口
        /// </summary>
        public static Tz888.IDAL.dp.ISysRoleTab CreatedpRoleTab()
        {

            string ClassNamespace = path + ".dp.SysRoleTab";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.dp.ISysRoleTab)objType;
        }
        /// <summary>
        /// 创建dp数据层接口
        /// </summary>
        public static Tz888.IDAL.dp.ISystem CreatedpSystem()
        {

            string ClassNamespace = path + ".dp.System";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.dp.ISystem)objType;
        }

        /// <summary>
        /// 创建Link.LinkChannelType数据层接口
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.Link.ILinkChannelType CreateChannel()
        {
            string ClassNamespace = path + ".Link.LinkChannelType";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.Link.ILinkChannelType)objType;
        }

        /// <summary>
        /// 创建Link.LinkInfoTab数据层接口
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.Link.ILinkInfoTab CreateLink()
        {
            string ClassNamespace = path + ".Link.LinkInfoTab";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.Link.ILinkInfoTab)objType;
        }

        /// <summary>
        /// 创建Link.LinkTypeTab数据层接口
        /// </summary>
        /// <returns></returns>
        public static Tz888.IDAL.Link.ILinkTypeTab CreateLinkType()
        {
            string ClassNamespace = path + ".Link.LinkTypeTab";
            object objType = CreateObject(path, ClassNamespace);
            return (Tz888.IDAL.Link.ILinkTypeTab)objType;
        }

        #endregion
    }
}