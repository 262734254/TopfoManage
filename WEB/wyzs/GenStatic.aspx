<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenStatic.aspx.cs" Inherits="wyzs_GenStatic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>静态页面生成</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" class="one_table" cellpadding="0" cellspacing="0">
                <tr>
                    <th colspan="4">
                        静态页面生成</th>
                </tr>
                <tr>
                    <td style="width: 100px" align="center">
                        <asp:Button ID="btnIndex" runat="server" CssClass="btn" Text="首页" OnClick="btnIndex_Click" /></td>
                    <td style="width: 100px" align="center">
                        <asp:Button ID="btnWrite" CssClass="btn" runat="server" Text="写字楼" OnClick="btnWrite_Click" /></td>
                    <td style="width: 100px; height: 24px;" align="center">
                        <asp:Button ID="btnRetailShop" CssClass="btn" runat="server" Text="产业园" OnClick="btnRetailShop_Click" /></td>
                    <td style="width: 100px; height: 24px;" align="center">
                        <asp:Button ID="btnYardHouse" CssClass="btn" runat="server" Text="厂房" OnClick="btnYardHouse_Click" /></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 23px;" align="center">
                        <asp:Button ID="btnShopCenter" CssClass="btn" runat="server" Text="购物中心" OnClick="btnShopCenter_Click" /></td>
                    <td style="width: 100px; height: 23px;" align="center">
                        <asp:Button ID="btnBusinessStreet" CssClass="btn" runat="server" Text="商业街" OnClick="btnBusinessStreet_Click" /></td>
                    <td style="width: 100px; height: 23px;" align="center">
                        <asp:Button ID="btnSale" CssClass="btn" runat="server" Text="批发市场" OnClick="btnSale_Click" /></td>
                    <td style="width: 100px; height: 23px;" align="center">
                        <asp:Button ID="btnMatingService" CssClass="btn" runat="server" Text="配套服务" OnClick="btnMatingService_Click" /></td>
                </tr>
                
                <tr>
                    <td colspan="4" style="width: 100px; height: 24px;" align="center">
                        <asp:Button ID="btnAllGenerate" CssClass="btn" runat="server" Text="全部生成" OnClick="btnAllGenerate_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
