<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    
    <div class="title"><h2><p><span><b>管理菜单</b></span></p></h2></div>
    
            <table border="0" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td>
                        名称：</td>
                    <td >
                        <asp:TextBox ID="TextMName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        URL：</td>
                    <td>
                        <asp:TextBox ID="TextURL" runat="server" Width="237px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        备注：</td>
                    <td>
                        <asp:TextBox ID="TextMDoc" runat="server" Height="52px" TextMode="MultiLine" Width="239px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server"  Text="添加" CssClass="btn" />
                        <asp:Button ID="Button2" runat="server"  Text="返回" CssClass="btn" /></td>
                </tr>
            </table>
 
    </div>
    </form>
</body>
</html>
