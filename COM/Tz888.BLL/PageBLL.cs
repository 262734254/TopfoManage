using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.BLL
{
   public class PageBLL
    {
     private static  PageStatic2 statedal = new PageStatic2();
       private static Tz888.BLL.zx.PageStatic stataidal = new Tz888.BLL.zx.PageStatic();
       private static ProjectState project = new ProjectState();
       public PageBLL()
       {

       }
       #region
       /// <summary>
       /// �ɹ�������̬ҳ����ʾ
       /// </summary>
       /// <param name="NewsID">���</param>
       /// <param name="title">����</param>
       /// <param name="publishT">ʱ��</param>
       /// <param name="Content">��ϸ����</param>
       public void StaticHtml(int NewsID, string InfoID, string title, string publishT, string laiyuan, string zuozhe, string Content, string TypeID)
       {
           statedal.StaticHtml(NewsID,InfoID,title,publishT,laiyuan,zuozhe,Content,TypeID);
       }
       public void ModifyHtmlFile(int infoId)
       {
            statedal.ModifyHtmlFile(infoId);
       }
        /// <summary>
       /// ����ID��ѯ�ɹ�������Ϣ
       /// </summary>
       public  PageStatic2 cgyl(int infoId)
       {
           return  statedal.cgyl(infoId);
       }
       
       /// <summary>
       /// ����ID��ѯ������Ѷ��Ϣ
       /// </summary>
       public Tz888.BLL.zx.PageStatic NewsIdAll(int infoId)
       {
           return stataidal.NewsIdAll(infoId);
       }
       /// <summary>
       /// �������Ͳ鿴������Ϣ
       /// </summary>
       public string SetType(string type)
       {
           return stataidal.SetType(type);
       }
       /// <summary>
       /// ���ž�̬ҳ����ʾ
       /// </summary>
       /// <param name="NewsID">���</param>
       /// <param name="title">����</param>
       /// <param name="publishT">ʱ��</param>
       /// <param name="Content">��ϸ����</param>
       public void  NewsStaticHtml(int NewsID, string title, string publishT, string Content)
       {
           stataidal.StaticHtml(NewsID, title, publishT, Content);
       }
       public void NewsModifyHtmlFile(int infoId)
       {
           stataidal.ModifyHtmlFile(infoId);
       }

       /// <summary>
       /// ��ѯ���гɹ�������Ϣ
       /// </summary>
       public string selInfoId()
       {
           return statedal.selInfoId();
       }
       /// <summary>
       /// ���ݱ�������ѯ�����ڵı��
       /// </summary>
       public string selInfoIdRegion(int beginfo, int endinfo)
       {
           return statedal.selInfoIdRegion(beginfo,endinfo);
       }

       public  string ZFZS(int auId, string TypeId, string proId, string Industry)
       {
           string com = ""; 
           com = statedal.XShi(auId, TypeId, proId, Industry);
           return com;
       }

       public  string huiyuan(long TypeId)
       {
           string com = "";
           com = statedal.QTZY(TypeId);
           return com;
       }

       public  string ZXun(int auId, string Industry)
       {
           string com = "";
           com = statedal.XGZX(auId,Industry);
           return com;
       }

       public PageStatic2 SJInfo(int infoId)
       {
           return statedal.SJInfo(infoId);
       }
       #endregion

       public void ProjectZqHtml(string InfoID, string ProjectName, string ComAbout, string CountryCode, string ProvinceID,
            string CItyID, string CountyID, string IndustryBID, string CapitalTotal, string iZqYqjjdwqk,
                string iZqXmyxqs, string PublishT, string ComBrief, string ManageTeamAbout, string DisplayTitle, string KeyWord,
            string Descript, int num, string lated, string MainPoint, string FixPriceID)
       {
           project.ProjectZqHtml(InfoID, ProjectName, ComAbout, CountryCode, ProvinceID, CItyID, CountyID, IndustryBID, CapitalTotal, iZqYqjjdwqk,
               iZqXmyxqs, PublishT, ComBrief, ManageTeamAbout,DisplayTitle,KeyWord,Descript,num,lated,MainPoint,FixPriceID);
       }

       public ProjectState SelProjectM(string InfoID)
       {
           return project.SelProjectM(InfoID);
       }
       public string SelProjectAll()
       {
           return project.SelProjectAll();
       }
       /// <summary>
        /// ������ҵ������ص���Ϣ
        /// </summary>
        /// <param name="infoId"></param>
       public string SelIndustryLated(string Industry)
       {
           return project.SelIndustryLated(Industry);
       }
       /// <summary>
        /// �ж�htmlFile�Ƿ����
        /// </summary>
        /// <param name="infoID"></param>
        /// <returns></returns>
       public string SelHtmlFile(string infoID)
       {
           return project.SelHtmlFile(infoID);
       }
        /// <summary>
        /// ������Դ�շ���������Ϣ
        /// </summary>
        /// <returns></returns>
       public string SelMainPoint()
       {
           return project.SelMainPoint();
       }
       /// <summary>
        /// ����ҵ��ŷ��������
        /// </summary>
        /// <returns></returns>
       public string SelIndustryName(string IndustryBID)
       {
           return project.SelIndustryName(IndustryBID);
       }
       /// <summary>
        /// ����Ŀ�����ڷ���
        /// </summary>
        /// <returns></returns>
       public string SelDictName(string DictID)
       {
           return project.SelDictName(DictID);
       }
   }
}
