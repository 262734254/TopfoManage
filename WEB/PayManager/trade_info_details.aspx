<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trade_info_details.aspx.cs" Inherits="PayManager_trade_info_details" %>
                                                        
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>详细信息</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
       <form id="Form1" method="post" runat="server">
     
                <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
            <tr>
               
                <td valign="top">
                    
                    <div class="rightBlock">
                        <div class="hrline">
                        </div>
                        <div class="btnstyle3 f14b tdcenter">
                            交易明细</div>
                        <div class="alltablebgH">
                            <table border="0" cellpadding="0" cellspacing="1" width="100%">
                                <tr>
                                    <td class="tdleft f14b bg2" colspan="4">
                                        （一）交易信息</td>
                                </tr>
                                <tr>
                                    <td class="tdleft" colspan="4">
                                        购买资源：<span style="color: #0000ff"><asp:Label ID="lblTitle" runat="server"></asp:Label></span></td>
                                </tr>
                                <tr style="color: #0000ff">
                                    <td class="tdright f14b bg2" width="19%">
                                        交易号:</td>
                                    <td>
                                        <span class="red2 bold" style="color: #000000">
                                            <asp:Label ID="lblOrder" runat="server" ForeColor="Blue"></asp:Label></span></td>
                                    <td class="tdright f14b bg2" style="color: #000000" width="19%">
                                        交易完成时间：</td>
                                    <td>
                                        <asp:Label ID="lblTime" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2" style="height: 29px">
                                        应付金额:</td>
                                    <td width="34%" style="height: 29px">
                                        <asp:Label ID="lblPoint1" runat="server"></asp:Label>元
                                    </td>
                                    <td class="tdright f14b bg2" style="height: 29px">
                                        支付方式：</td>
                                    <td width="28%" style="height: 29px">
                                        <asp:Label ID="lblPayType" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2">
                                        交易状态:</td>
                                    <td colspan="3">
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2" style="height: 75px">
                                        备注:</td>
                                    <td colspan="3" style="height: 75px">
                                        <asp:Label ID="lblRemark" runat="server">无</asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdleft" colspan="4">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tdleft f14b bg2" colspan="4">
                                        （二）购买用户信息</td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2">
                                        用户昵称：</td>
                                    <td>
                                        <asp:Label ID="lblLoginName" runat="server"></asp:Label></td>
                                    <td class="tdright f14b bg2">
                                        手机：</td>
                                    <td>
                                        <asp:Label ID="lblMobile" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2">
                                        固定电话：</td>
                                    <td>
                                        <asp:Label ID="lblTel" runat="server"></asp:Label></td>
                                    <td class="tdright f14b bg2">
                                        姓名：</td>
                                    <td>
                                        <asp:Label ID="lblRealName" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2">
                                        电子邮箱：</td>
                                    <td colspan="3">
                                        <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="height: 30px">
                                        &nbsp;<input class="buttomal" onclick="javascript:history.go(-1)" style="width: 96px"
                                            type="button" value="关闭" /></td>
                                </tr>
                            </table>
                        </div>
                     
                    </div>
                </td>
            </tr>
           
        </table>
    </form>
</body>
</html>
