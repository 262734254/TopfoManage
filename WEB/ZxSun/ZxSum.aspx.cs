using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ZxSun_ZxSum : System.Web.UI.Page
{
    Tz888.BLL.zx.ZxSumBLL zxsum = new Tz888.BLL.zx.ZxSumBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 投资资讯
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTzZx_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国投资资讯|中国投资资讯分类信息|中国投资资讯频道_中国招商投资网";
            string keyWords = "投资资讯,中国投资资讯，投资资讯分类信息，投资资讯频道";
            string desc = "有关中国投资资讯发布资讯信息汇总,中国投资资讯频道。全国最新投资资讯分类信息发布,让投资者更快找到中国投资资讯信息相关的投资信息和投资项目。";
            count(1, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }
    }
    /// <summary>
    /// 融资资讯
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRzZx_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国融资资讯|中国融资资讯分类信息|中国融资资讯频道_中国招商投资网";
            string keyWords = "融资资讯,中国融资资讯，融资资讯分类信息，融资资讯频道";
            string desc = "有关中国融资资讯发布资讯信息汇总,中国融资资讯频道。全国最新融资资讯分类信息发布,让融资者更快找到中国融资资讯信息相关的融资信息和融资项目。";
            count(2, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }
    }
    /// <summary>
    /// 招商资讯
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnZsZx_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国招商资讯|中国招商资讯分类信息|中国招商资讯频道_中国招商投资网";
            string keyWords = "招商资讯,中国招商资讯，招商资讯分类信息，招商资讯频道";
            string desc = "有关中国招商资讯发布资讯信息汇总,中国招商资讯频道。全国最新招商资讯分类信息发布,让招商者更快找到中国招商资讯信息相关的招商信息和招商项目。";
            count(3, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }
    }
    /// <summary>
    /// 创业资讯
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCyZx_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国创业资讯|中国创业资讯分类信息|中国创业资讯频道_中国招商投资网";
            string keyWords = "创业资讯,中国创业资讯，创业资讯分类信息，创业资讯频道";
            string desc = "有关中国创业资讯发布资讯信息汇总,中国创业资讯频道。全国最新创业资讯分类信息发布,让创业者更快找到中国创业资讯信息相关的创业信息和创业项目";
            count(4, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }
    }
    /// <summary>
    /// 商机资讯
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSjZx_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国商机资讯|中国商机资讯分类信息|中国商机资讯频道_中国招商投资网";
            string keyWords = "商机资讯,中国商机资讯，商机资讯分类信息，商机资讯频道";
            string desc = "有关中国商机资讯发布资讯信息汇总,中国商机资讯频道。全国最新商机资讯分类信息发布,让商机者更快找到中国商机资讯信息相关的商机信息和商机项目。";
            count(5, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }
    }
    /// <summary>
    /// 经济要闻
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnJjYw_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国经济资讯|中国经济资讯分类信息|中国经济资讯频道_中国招商投资网";
            string keyWords = "经济资讯,中国经济资讯，经济资讯分类信息，经济资讯频道  ";
            string desc = "有关中国经济资讯发布资讯信息汇总,中国经济资讯频道。全国最新经济资讯分类信息发布,让投资者更快找到中国经济资讯信息相关的经济信息和最新经济资讯。";
            count(6, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }
    }
    /// <summary>
    /// 会展资讯
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnHzZx_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国会展资讯|中国会展资讯分类信息|中国会展资讯频道_中国招商投资网";
            string keyWords = "会展资讯,中国会展资讯，会展资讯分类信息，会展资讯频道";
            string desc = "有关中国会展资讯发布资讯信息汇总,中国会展资讯频道。全国最新会展资讯分类信息发布,让投资者更快找到中国会展资讯信息相关的会展信息和最新会展资讯。";
            count(7, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }
    }
    /// <summary>
    /// 成功案例
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCgAl_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国招商投资网－成功案例";
            string keyWords = "中国招商投资网－成功案例";
            string desc = "中国招商投资网－成功案例";
            count(8, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }

    }
    /// <summary>
    /// 投资环境
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTzHj_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国投资环境|中国投资环境分类信息|中国投资环境频道_中国招商投资网";
            string keyWords = "投资环境,中国投资环境，投资环境分类信息，投资环境频道";
            string desc = "有关中国投资环境发布资讯信息汇总,中国投资环境频道。全国最新投资环境分类信息发布,让投资者更快找到中国投资环境信息相关的投资信息和最新投资环境。";
            count(10, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }

    }
    /// <summary>
    /// 精英人物
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnJyRw_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国精英人物|中国精英人物分类信息|中国精英人物频道_中国招商投资网";
            string keyWords = "精英人物,中国精英人物，精英人物分类信息，精英人物频道 ";
            string desc = "有关中国精英人物发布资讯信息汇总,中国精英人物频道。全国最新精英人物分类信息发布,让投资者更快找到中国精英人物信息相关的精英人物信息和最新精英人物。";
            count(11, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }

    }
    /// <summary>
    /// 招商政策
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnZsZc_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国招商政策|中国招商政策分类信息|中国招商政策频道_中国招商投资网";
            string keyWords = "招商政策,中国招商政策，招商政策分类信息，招商政策频道";
            string desc = "有关中国招商政策发布资讯信息汇总,中国招商政策频道。全国最新招商政策分类信息发布,让投资者更快找到中国招商政策信息相关的招商政策信息和招商引资政策。";
            count(12, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }
    }
    /// <summary>
    /// 招商活动
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnZsHd_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
           string title = "中国招商投资网－招商活动";
            string keyWords = "中国招商投资网－招商活动";
            string desc = "中国招商投资网－招商活动";
            count(13, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }

    }
    /// <summary>
    /// 投资学苑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTzXy_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国招商投资网－投资学苑";
            string keyWords = "中国招商投资网－投资学苑";
            string desc = "中国招商投资网－投资学苑";
            count(14, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }

    }
    /// <summary>
    /// 融资学苑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRzXy_Click(object sender, EventArgs e)
    {
        bool num = false;
        try
        {
            string title = "中国招商投资网－融资学苑";
            string keyWords = "中国招商投资网－融资学苑";
            string desc = "中国招商投资网－融资学苑";
            count(15, title, keyWords, desc);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Response.Write("<script>alert('生成成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('生成失败')</script>");
        }

    }
    /// <summary>
    /// 公共的方法
    /// </summary>
    /// <param name="type">类型所对应的编号</param>
    /// <param name="title">给静态页面起个前缀</param>
    private void count(int type, string title, string keyWords, string desc)
    {
        int num = zxsum.pageS(type);
        for (int i = 1; i <= num; i++)
        {
            zxsum.SelState(i, type, title, keyWords, desc);
        }
    }
}
