<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRoleGrop.aspx.cs" Inherits="ManageSystem_AddRoleGrop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    
    <div class="title"><h2><p><span><b>添加角色组</b></span></p></h2></div>
    
            <table border="0" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td style="width: 100px">
                        角色组 ID：</td>
                    <td align="left" style="width: 100px">
                        <asp:TextBox ID="txtRoleGroupID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        角色组名称：</td>
                    <td align="left" style="width: 100px">
                        <asp:TextBox ID="txtRoleGroupName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        组说明：</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtGroupRemark" runat="server" Height="52px" TextMode="MultiLine" Width="239px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server"  Text="添加" CssClass="btn" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server"  Text="修改" CssClass="btn" OnClick="Button2_Click1" /></td>
                </tr>
            </table>
 
    </div>
    </form>
</body>
</html>
