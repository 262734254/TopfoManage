<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddWyzsType.aspx.cs" Inherits="wyzs_AddWyzsType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>添加物业类型</b></span></p>
                </h2>
                <h2>
                    <p>
                        <span><b><a href="typeManage.aspx">资源管理</a></b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table">
              <tr>
                    <td>
                        类型名称:</td>
                    <td align="left">
                        <asp:TextBox ID="txtTitle" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAudit" runat="server" CssClass="btn" Text="修改" OnClick="btnAudit_Click" />
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="添加" OnClick="btnSubmit_Click" />
                        <%--<input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" />--%></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
