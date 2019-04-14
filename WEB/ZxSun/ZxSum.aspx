<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZxSum.aspx.cs" Inherits="ZxSun_ZxSum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title" align="center"><h2><p><span><b><a>资讯详细页面生成</a></b></span></p></h2></div>
     <table border="1" width="100%" cellpadding="0" cellspacing="0" class="one_table" >
            <tr>
                <th colSpan="2">
                  <div align="center">
                      资讯类别静态页面生成</div>     
                </th>
            </tr>
             <tr>
                <td align="center" width="50%" style="height: 26px">
                  <asp:Button runat="server" ID="btnTzZx" Text="投资资讯" CssClass="btn" OnClick="btnTzZx_Click"  />
                  </td>
                <td align="center" width="50%" style="height: 26px">
                    <asp:Button runat="server" ID="btnRzZx" Text="融资资讯" CssClass="btn" OnClick="btnRzZx_Click"  />
                </td>
            </tr>
            <tr>
                <td align="center" width="50%" style="height: 26px">
                  <asp:Button runat="server" ID="btnZsZx" Text="招商资讯" CssClass="btn" OnClick="btnZsZx_Click" Width="78px"  />
                  </td>
                <td align="center" width="50%" style="height: 26px">
                    <asp:Button runat="server" ID="btnCyZx" Text="创业资讯" CssClass="btn" OnClick="btnCyZx_Click"  />
                </td>
            </tr>
            <tr>
                <td align="center" width="50%" style="height: 26px">
                  <asp:Button runat="server" ID="btnSjZx" Text="商机资讯" CssClass="btn" OnClick="btnSjZx_Click"  />
                  </td>
                <td align="center" width="50%" style="height: 26px">
                    <asp:Button runat="server" ID="btnJjYw" Text="经济要闻" CssClass="btn" OnClick="btnJjYw_Click"  />
                </td>
            </tr>
            <tr>
                <td align="center" width="50%">
                  <asp:Button runat="server" ID="btnHzZx" Text="会展资讯" CssClass="btn" OnClick="btnHzZx_Click"  />
                  </td>
                <td align="center" width="50%">
                    <asp:Button runat="server" ID="btnCgAl" Text="成功案例" CssClass="btn" OnClick="btnCgAl_Click"  />
                </td>
            </tr>
            <tr>
                <td align="center" width="50%">
                  <asp:Button runat="server" ID="btnTzHj" Text="投资环境" CssClass="btn" OnClick="btnTzHj_Click"  />
                  </td>
                <td align="center" width="50%">
                    <asp:Button runat="server" ID="btnJyRw" Text="精英人物" CssClass="btn" OnClick="btnJyRw_Click"  />
                </td>
            </tr>
            <tr>
                <td align="center" width="50%">
                  <asp:Button runat="server" ID="btnZsZc" Text="招商政策" CssClass="btn" OnClick="btnZsZc_Click"  />
                  </td>
                <td align="center" width="50%">
                    <asp:Button runat="server" ID="btnZsHd" Text="招商活动" CssClass="btn" OnClick="btnZsHd_Click"  />
                </td>
            </tr>
            <tr>
                <td align="center" width="50%">
                  <asp:Button runat="server" ID="btnTzXy" Text="投资学苑" CssClass="btn" OnClick="btnTzXy_Click"  />
                  </td>
                <td align="center" width="50%">
                    <asp:Button runat="server" ID="btnRzXy" Text="融资学苑" CssClass="btn" OnClick="btnRzXy_Click"  />
                </td>
            </tr>
    
   </table>
       
    </form>
</body>
</html>
