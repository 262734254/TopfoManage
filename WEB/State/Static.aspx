<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Static.aspx.cs" Inherits="State_Static" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
                <th colspan="2">
                </th>
            </tr>
            <tr>
                <td style="width: 100px" align="center">
                    <asp:Button ID="btnZs" runat="server" Text="最新招商项目" OnClick="btnZs_Click" /></td>
                <td style="width: 100px" align="center">
                    <asp:Button ID="btnTz" runat="server" Text="最新投资项目" OnClick="btnTz_Click" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 24px;" align="center">
                    <asp:Button ID="btnRz" runat="server" Text="最新融资项目" OnClick="btnRz_Click" /></td>
                <td style="width: 100px; height: 24px;" align="center">
                    <asp:Button ID="btnFw" runat="server" Text="专业服务要求" OnClick="btnFw_Click" /></td>
            </tr>
            <tr>
                <th colspan="2">
                    搜索页面右侧静态页面</th>
            </tr>
            <tr>
                <td style="width: 100px; height: 22px;" align="center">
                    <asp:Button ID="btnZiBen" runat="server" Text="资本资源推荐" OnClick="btnZiBen_Click" /></td>
                <td style="width: 100px; height: 22px;" align="center">
                    <asp:Button ID="btnqy" runat="server" Text="企业项目资源推荐" OnClick="btnqy_Click" /></td>
            </tr>
            <tr>
                <td align="center" style="width: 100px; height: 24px;">
                    <asp:Button ID="btnzf" runat="server" Text="政府项目资源推荐" OnClick="btnzf_Click" /></td>
                <td align="center" style="width: 100px; height: 24px;">
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 100px; height: 24px">
                </td>
            
            </tr>
            <tr>
             
                <th colspan="2" style="height: 18px">
                    首页静态页面生成</th>
               
            </tr>
            <tr> 
            <td align="center" style="width: 100px; height: 24px"><asp:Button ID="btnIndex" runat="server" Text="首页静态生成" OnClick="btnIndex_Click"/></td>
               <td style="width: 100px; height: 24px;" align="center">
                    <asp:Button ID="Button1" runat="server" Text="企业招商首页静态生成" OnClick="Button1_Click"  /></td>
            </tr>
            
        </table>
      
    
    </div>
    </form>
</body>
</html>
