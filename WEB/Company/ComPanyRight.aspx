<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComPanyRight.aspx.cs" Inherits="Company_ComPanyRight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>企业名片右侧静态页面生成</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
   
     <table border="1" width="100%" cellpadding="0" cellspacing="0" class="one_table" >
            <tr>
                <th colSpan="2">
                  <div align="center">
                      企业名片右侧静态页面生成</div>     
                </th>
            </tr>
             <tr>
                <td align="center" width="50%"  >
                  <asp:Button runat="server" ID="btnHit" Text="会员排行" CssClass="btn" OnClick="btnHit_Click"  />
                  </td>
                <td align="center" width="50%">
                    <asp:Button runat="server" ID="btnTime" Text="最新加入企业" CssClass="btn" OnClick="btnTime_Click"   />
                </td>
            </tr>
   </table>
       
    </form>
</body>
</html>