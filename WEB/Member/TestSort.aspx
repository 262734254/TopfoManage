<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestSort.aspx.cs" Inherits="Member_TestSort" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF" style="text-align:center">
        <tr>
            <td colspan="2" height="2"></td>
        </tr>
        <tr>
            <td>
                菜单排序
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存"  CssClass="button" onclick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td rowspan="10">
                <asp:ListBox ID="lbxJS" runat="server" Height="355px" Width="250px"></asp:ListBox>
            </td>
            <td valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="middle">
                <asp:Button ID="btnFirst" runat="server" Text="首"  CssClass="button" Width="26px"  onclick="btnFirst_Click" />
            </td>
        </tr>
        <tr>
            <td  valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="middle">
                <asp:Button ID="Button1" runat="server" Text="上" CssClass="button" Width="26px" onclick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td  valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="middle">
                <asp:Button ID="Button4" runat="server" Text="下"  CssClass="button" Width="26px" onclick="Button4_Click" />
            </td>
        </tr>
        <tr>
            <td  valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="middle">
                <asp:Button ID="Button5" runat="server" Text="尾" CssClass="button" 
                    onclick="Button5_Click" Width="26px" Height="21px" />
            </td>
        </tr>
        <tr>
            <td  valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td  valign="middle">
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
