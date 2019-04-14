<%@ Page Language="C#" AutoEventWireup="true" CodeFile="strike_details.aspx.cs" Inherits="PayManager_strike_details" %>

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
                
                <td valign="top" >
                    <div class="title">
                            <h2>
                                <p>
                                    <span><b>订单详细信息</b></span></p>
                            </h2>
                          
               
            </div>
                    <div class="rightBlock">
                        <h3>
                            <div class="tdcenter">
                                您现在查看的是订单号为 <span class="red2 bold">
                                    <asp:Label ID="Label2" runat="server"></asp:Label></span> 的充值明细情况。<br />
                            </div>
                        </h3>
                        <div class="hrline">
                        </div>
                        <div class="btnstyle3 f14b tdcenter">
                            充值明细</div>
                        <div class="alltablebgH">
                             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                                <tr>
                                    <td class="tdright f14b bg2" width="19%">
                                        订单号：</td>
                                    <td style="width: 153px">
                                        <asp:Label ID="lblOrderNo" runat="server"></asp:Label></td>
                                    <td class="tdright f14b bg2" width="19%">
                                        充值帐户：</td>
                                    <td>
                                        <asp:Label ID="lblStrikeLoginName" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2">
                                        充值人：</td>
                                    <td style="width: 153px">
                                        <asp:Label ID="lblStrikeNickName" runat="server"></asp:Label></td>
                                    <td class="tdright f14b bg2">
                                        真实姓名：</td>
                                    <td>
                                        <asp:Label ID="lblRealName" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2" style="height: 19px">
                                        电话：</td>
                                    <td style="height: 19px; width: 153px;">
                                        <asp:Label ID="lblTel" runat="server"></asp:Label></td>
                                    <td class="tdright f14b bg2" style="height: 19px">
                                        Email：</td>
                                    <td width="28%" style="height: 19px">
                                        <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                                </tr>
                                
                                <tr>
                                    <td class="tdright f14b bg2">
                                        订单状态：</td>
                                    <td style="width: 153px">
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                    <td class="tdright f14b bg2">
                                        订单生成时间：</td>
                                    <td>
                                        <asp:Label ID="lblOrderDate" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2">
                                        充值金额：</td>
                                    <td colspan="3">
                                        <asp:Label ID="lblMoeny" runat="server"></asp:Label>元</td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2">
                                        支付方式：</td>
                                    <td style="width: 153px">
                                        <asp:Label ID="lblPayType" runat="server"></asp:Label></td>
                                    <td class="tdright f14b bg2">
                                        交易号：</td>
                                    <td>
                                        <asp:Label ID="lblTradeNo" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2">
                                        支付时间：</td>
                                    <td colspan="3">
                                        <asp:Label ID="lblPayDate" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="tdright f14b bg2">
                                        备注：</td>
                                    <td colspan="3">
                                        <asp:Label ID="lblRemark" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="height: 24px">
                                        <input class="buttomal" onclick="javascript:history.go(-1)" style="width: 79px" type="button"
                                            value="关闭" /></td>
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
