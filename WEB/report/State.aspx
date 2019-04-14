<%@ Page Language="C#" AutoEventWireup="true" CodeFile="State.aspx.cs" Inherits="report_State" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>静态页面生成</title>
     <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" class="one_table"  cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="2">
                    静态页面生成</th>
            </tr>
            <tr>
                <td style="width: 100px" align="center">
                    <asp:Button ID="btnZs" runat="server"  Text="行业分析报告" OnClick="btnZs_Click"  /></td>
             <td style="width: 100px" align="center">
                    <asp:Button ID="btnKX" runat="server" Text="最新资讯信息" OnClick="btnKX_Click"  /></td>
            </tr>
           
            <tr>
                <td style="width: 100px" align="center"><asp:Button ID="Button1" runat="server" Text="test" OnClick="Button1_Click" Visible="False"  /></td>
                <td style="width: 100px" align="center">
                    <%--<asp:Button ID="Button6" runat="server" Text="Button" />--%></td>
            </tr>
        </table>
      
    
    </div>
    </form>
</body>
</html>
