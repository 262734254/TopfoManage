<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelPromotion.aspx.cs" Inherits="Promotion_SelPromotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
</head>
<body>
       <form id="form1" runat="server">
 <div class="title" align="center">
             <h2><p><span><b><a href="#">查看推广位置</a></b></span></p></h2>
             <h2><p><span><b><a href="Promotion.aspx">添加推广位置</a></b></span></p></h2>
             </div>
        <table width="50%" border="0" class="one_table" cellspacing="0" cellpadding="0">
            <tr>
                <th width="20%">
                编号
                    </th>
                    <th width="20%">
                推广位置
                    </th>
            </tr>
            <asp:Repeater runat="server" ID="rpLisht">
            <ItemTemplate>
               <tr>
                    <td align="center">
                    <%#Eval("Coding")%>
                    </td>
                    <td align="center">
                    <%#Eval("PromotionName")%>
                    </td>
               </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
        <input type="button" class="btn" onclick="window.location.href='Promotion.aspx'" value="添加"/>
    </form>
</body>
</html>
