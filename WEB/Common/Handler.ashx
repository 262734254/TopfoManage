<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using GZS.BLL.policy;
using GZS.BLL.Invest;
using GZS.BLL.Product;
using GZS.BLL.Park;
using GZS.DAL.product;
using GZS.BLL.Link;
using System.Collections.Generic;
using GZS.BLL.news;
public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string name = Convert.ToString(context.Request["userName"]);//cn001,
        string balk = context.Request["jsoncallback"];
        if (name.EndsWith(","))
        {
            string[] str = name.Split(',');
            for (int i = 0; i < str.Length - 1; i++)
            {
                GenerateStatic(str[i].ToString());
            }
        }
        else
        {
            int a = name.Length;
            name = name.Substring(1, a - 2);
            GenerateStatic(name);
        }
        context.Response.Write(balk + "({name:" + name + "})");
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    private void GenerateStatic(string name)
    {

        //产业优势 如果ID为0就是通过用户名查找
        PolicyStatic policySta = new PolicyStatic();
        policySta.StaticHtml(0, name);
        //产业优势右边iframe
        policySta.StaticHtml(name);
        //投资成本如果ID为0就是通过用户名查找
        StaticInvest InvestSta = new StaticInvest();
        InvestSta.StaticHtml(0, name);
        //产业优势
        StaticProduct ProductSta = new StaticProduct();
        ProductSta.StaticHtml(0, name);
        //产业优势Ifrom
        StaticIF staticIf = new StaticIF();
        staticIf.StaticHtml(name, 3);
        //staticIf.StaticHtml(name, 1);
        //园区特色
        StaticPark ParkSta = new StaticPark();
        ParkSta.StaticHtml(0, name);
        //联系方式
        ContactStatic sta = new ContactStatic();
        sta.StaticHtml(name);

        //区域概况
        GZS.BLL.AreaTabBLL areatabbll = new GZS.BLL.AreaTabBLL();
        int sdsas = areatabbll.StaticHtml(0, name);
        //IF
        areatabbll.StaticHtmls(name);
        //投资环境
        GZS.BLL.EnvironmentTabBLL envtabbll = new GZS.BLL.EnvironmentTabBLL();
        envtabbll.StaticHtml(name);
        //IF
        envtabbll.StaticHtmls(name);
        //友情链接
        GZS.BLL.FriendLinkBLL bll = new GZS.BLL.FriendLinkBLL();
        bll.StaticHtml(name);
        //相册列表
        GZS.BLL.ImageTabMBLL imagebll = new GZS.BLL.ImageTabMBLL();
        List<GZS.Model.ImageTabM> list = imagebll.GetAll(name);
        for (int i = 0; i < list.Count; i++)
        {
            imagebll.StaticHtmls(list[i].imageid, name);
            imagebll.StaticHtml(list[i].imageid, name);
        }
        imagebll.StaticHtmlshouye(name);
        //资讯
        NewsTabBLL newstabbll = new NewsTabBLL();
        PageStatic statics = new PageStatic();
        List<GZS.Model.news.NewsTab> list1 = newstabbll.GetNewsTabAllByUserName(name);
        for (int i = 0; i < list1.Count; i++)
        {
            int row = statics.StaticHtml(list1[i].Newsid, name);
        }
        int dzx = statics.StaticHtmls(name);
        int daze = newstabbll.StaticHtml(name);
        GZS.BLL.VideoSysBLL Videobll = new GZS.BLL.VideoSysBLL();
        List<GZS.Model.VideoSysM> lista = Videobll.GetAllModel(name);
        GZS.BLL.VideoSysPagestaticBLL staticblls = new GZS.BLL.VideoSysPagestaticBLL();
        for (int i = 0; i < lista.Count; i++)
        {
            staticblls.StaticHtml(lista[i].videoid, name);
        }
    }

}