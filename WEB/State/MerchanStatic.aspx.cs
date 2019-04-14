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
using Tz888.BLL.MerchantManage;
public partial class State_MerchanStatic : System.Web.UI.Page
{
    MerchantManage bll = new MerchantManage();
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void btnZs_Click(object sender, EventArgs e)
    {
        int areid =Convert.ToInt32( this.Are.Value.ToString().Trim());
        bool num = false;
        try
        {
            count(areid);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
        }
    }
        /// <summary>
    /// 公共的方法
    /// </summary>
    /// <param name="type">类型所对应的编号</param>
    /// <param name="title">给静态页面起个前缀</param>
    private void count(int areid)
    {
        int num = bll.pageS(areid);
        for (int i = 1; i <= num; i++)
        {
            bll.SelState(i, areid);
        }
    }

 


    private void Induycount(int areid,string Induy)
    {
        int num = bll.InduypageS(areid,Induy);
        for (int i = 1; i <= num; i++)
        {
            bll.InduySelState(i, areid,Induy);
        }
    }
    protected void btnZsInduy_Click(object sender, EventArgs e)
    {
        bool num = false;
        string Number = this.Induy.Value.ToString().Trim();

        int areid = Convert.ToInt32(this.Are.Value.ToString().Trim());
     
        if (Number == "MM")
        {
     

            string[] values = { "#", "$", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "*" };
            foreach (string str in values)
            {
                try
                {
                    Induycount(areid, str.Trim());
                    num = true;
                }
                catch (Exception)
                {
                    num = false;

                }
                if (num == false)
                {
                    Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
                }

            }
        }
        else
        { 
      
        string Induy = this.Induy.Value.ToString().Trim();
      
      
        try
        {
            Induycount(areid,Induy);
            num = true;
        }
        catch (Exception)
        {
            num = false;

        }
        if (num)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
        }
    }
    }




    private void InduycountList( string Induy)
    {
        int num = bll.InduypageSList(Induy);
        for (int i = 1; i <= num; i++)
        {
            bll.InduySelStateList(i,  Induy);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool num = false;
        string Number = this.Induy.Value.ToString().Trim();
        if (Number == "MM")
        {
            string[] values = { "#", "$", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            foreach (string str in values)
            {
                try
                {
                    InduycountList(str.Trim());
                    num = true;
                }
                catch (Exception)
                {
                    num = false;

                }
                if (num == false)
                {
                    Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
                }

            }
        }

        else
        {
            string induy1 = this.Induy.Value.ToString().Trim();

            try
            {
                InduycountList(induy1);
                num = true;
            }
            catch (Exception )
            {
                num = false;

            }
            if (num)
            {
                Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
            }
        }
    }
}
