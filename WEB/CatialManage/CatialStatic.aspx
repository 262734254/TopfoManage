<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CatialStatic.aspx.cs" Inherits="CatialManage_CatialStatic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script language="javascript" type="text/javascript">
       function CheckProvince()
       {
           var Province=document.getElementById("Province");
           if(Province.options[Province.selectedIndex].value=="")
           {
              alert("请选择区域!");
              Province.focus();
              return false;
           }
       }
       
       function CheckInduy()
       {
           var Induy=document.getElementById("Induy");
           if(Induy.options[Induy.selectedIndex].value=="")
           {
              alert("请选择行业!");
              Induy.focus();
              return false;
           }
       }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        区域：<asp:DropDownList ID="Province" runat="server">
                     <asp:ListItem Value="">==请选择==</asp:ListItem>
                     <asp:ListItem Value="1098">北京</asp:ListItem>
                     <asp:ListItem Value="1002">安徽</asp:ListItem>
                     <asp:ListItem Value="1103">福建</asp:ListItem>
                     <asp:ListItem Value="1181">甘肃</asp:ListItem>
                     <asp:ListItem Value="1277">广西</asp:ListItem>
                     <asp:ListItem Value="1382">贵州</asp:ListItem>
                     <asp:ListItem Value="1474">海南</asp:ListItem>
                     <asp:ListItem Value="1511">河北</asp:ListItem>
                     <asp:ListItem Value="1670">河南</asp:ListItem>
                     <asp:ListItem Value="1816">黑龙江</asp:ListItem>
                     <asp:ListItem Value="2728">山西</asp:ListItem>
                     <asp:ListItem Value="1908">湖北</asp:ListItem>
                     <asp:ListItem Value="2002">湖南</asp:ListItem>
                     <asp:ListItem Value="2218">吉林</asp:ListItem>
                     <asp:ListItem Value="2177">江苏</asp:ListItem>
                     <asp:ListItem Value="2434">内蒙古</asp:ListItem>
                     <asp:ListItem Value="2536">宁夏</asp:ListItem>
                     <asp:ListItem Value="2561">青海</asp:ListItem>
                     <asp:ListItem Value="2610">上海</asp:ListItem>
                     <asp:ListItem Value="2614">广东</asp:ListItem>
                     <asp:ListItem Value="2847">山东</asp:ListItem>
                     <asp:ListItem Value="2973">陕西</asp:ListItem>
                     <asp:ListItem Value="3078">四川</asp:ListItem>
                     <asp:ListItem Value="3256">天津</asp:ListItem>
                     <asp:ListItem Value="3262">重庆</asp:ListItem>
                     <asp:ListItem Value="3290">西藏</asp:ListItem>
                     <asp:ListItem Value="3371">新疆</asp:ListItem>
                     <asp:ListItem Value="3478">浙江</asp:ListItem>
                     <asp:ListItem Value="3559">云南</asp:ListItem>
                     <asp:ListItem Value="2258">江西</asp:ListItem>
                     <asp:ListItem Value="2361">辽宁</asp:ListItem>
              </asp:DropDownList>
              &nbsp;&nbsp;&nbsp;
        行业：<asp:DropDownList ID="Induy" runat="server">
                    <asp:ListItem Value="">==请选择==</asp:ListItem>
                    <asp:ListItem Value="all">所有行业</asp:ListItem> 
                    <asp:ListItem Value="#">批发零售</asp:ListItem>
                    <asp:ListItem Value="$">房地产业</asp:ListItem>
                    <asp:ListItem Value="A">农林牧渔</asp:ListItem>
                    <asp:ListItem Value="B">食品饮料</asp:ListItem>
                    <asp:ListItem Value="C">冶金矿产</asp:ListItem>
                    <asp:ListItem Value="D">机械制造</asp:ListItem>
                    <asp:ListItem Value="E">汽车汽配</asp:ListItem>
                    <asp:ListItem Value="F">能源动力</asp:ListItem>
                    <asp:ListItem Value="G">石油化工</asp:ListItem>
                    <asp:ListItem Value="H">纺织服装</asp:ListItem>
                    <asp:ListItem Value="I">环境保护</asp:ListItem>
                    <asp:ListItem Value="J">医疗保健</asp:ListItem>
                    <asp:ListItem Value="K">生物科技</asp:ListItem>
                    <asp:ListItem Value="L">教育培训</asp:ListItem>
                    <asp:ListItem Value="M">印刷出版</asp:ListItem>
                    <asp:ListItem Value="N">广告传媒</asp:ListItem>
                    <asp:ListItem Value="O">影视娱乐</asp:ListItem>
                    <asp:ListItem Value="P">电子通讯</asp:ListItem>
                    <asp:ListItem Value="Q">建筑建材</asp:ListItem>
                    <asp:ListItem Value="R">信息产业</asp:ListItem>
                    <asp:ListItem Value="S">高新技术</asp:ListItem>
                    <asp:ListItem Value="T">基础设施</asp:ListItem>
                    <asp:ListItem Value="U">交通运输</asp:ListItem>
                    <asp:ListItem Value="V">物流仓储</asp:ListItem>
                    <asp:ListItem Value="W">金融投资</asp:ListItem>
                    <asp:ListItem Value="X">旅游休闲</asp:ListItem>
                    <asp:ListItem Value="Y">社会服务</asp:ListItem>
                    <asp:ListItem Value="Z">酒店餐饮</asp:ListItem>
                    <asp:ListItem Value="*">其他行业</asp:ListItem>
              </asp:DropDownList>
              &nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButStatic" runat="server" Text="生 成" OnClientClick="return Check();" OnClick="ButStatic_Click" />
        <br /><br />
        <%--生成所有区域下的所有项目--%>
        <asp:Button ID="Btn1" runat="server" Text="生成所有区域下的项目" OnClick="Btn1_Click" />
        <br /><br />
        <%--生成全国行业--%>
        <asp:Button ID="Btn2" runat="server" Text="生成所有行业项目(全国)" OnClientClick="return CheckInduy();"  OnClick="Btn2_Click" />
        <br /><br />
        <%--生成所有区域下的所有行业--%>
        <asp:Button ID="Btn3" runat="server" Text="生成所有区域下的所有行业下的项目" OnClick="Btn3_Click" />
    </form>
</body>
</html>
