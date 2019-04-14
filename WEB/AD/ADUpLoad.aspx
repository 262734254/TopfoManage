<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADUpLoad.aspx.cs" Inherits="AD_ADUpLoad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="title"><h2><p><span><b>管理菜单</b></span></p></h2></div>
    <div>
        <div style="text-align: center">
            <table style="width: 492px; height: 96px; font-size:12px;" class="one_table">
                <tr>
                    <td>
                        上传图片：</td>
                    <td align="left">
                        <asp:FileUpload ID="FileUp" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        链接地址：</td>
                    <td align="left">
                        <asp:TextBox ID="txtLinkAdr" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="上传文件" CssClass="btn" OnClick="Button1_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" CssClass="btn" Text="返  回" Width="78px" /></td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>
