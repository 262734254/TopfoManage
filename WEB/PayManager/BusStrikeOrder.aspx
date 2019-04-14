<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusStrikeOrder.aspx.cs" Inherits="PayManager_BusStrikeOrder" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>业务员充值订单管理</title>
      <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
                    <script language="javascript" src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
     <script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
</head>
<body>
       <form id="Form1" method="post" runat="server">
       
          <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
            <tr>
            
                <td width="3" >
                </td>
                <td valign="top" width="100%">
                    <div>
                      <div class="title">
                          
                            <h2>
                                <p>
                                    <span><b>业务员充值记录</b></span></p>
                            </h2>
               
            </div>
                        
                        <div class="alltablebgH">
                               <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                                <tr>
                                    <td style="height: 24px" >
                                        充值帐户：</td>
                                    <td style="height: 24px" >
                                        <input id="txtStrikeLoginName" type="text" name="textfield2" class="tWidth100px borderCor5" runat="server" /></td>
                               
                                    <td id="txtLoginNam" style="height: 24px">
                                        充值人：</td>
                                    <td style="height: 24px">
                                        <input type="text" name="textfield2" class="tWidth100px borderCor5" id="txtLoginName" runat="server" /></td>
                                        
                                </tr>
                                 
                                <tr>
                                    <td c>
                                        充值方式：</td>
                                    <td >
                                        <select id="sType" runat="server" name="sType">
                                         <option value="card">充值卡</option>
                                            <option value="pnr">天天付</option>
                                            <option value="ebilling">ebilling电话</option>
                                            <option value="alipay">支付宝</option>
                                            <option value="yeepay">yeepay电话</option>
                                            <option value="szx">神州行</option>
                                            <option value="PostOffice">邮局汇款</option>
                                            <option value="bank">银行汇款</option>
                                            <option selected="selected" value="">---请选择---</option>
                                        </select>
                                    </td>
                               
                                   
                                    <td>
                                        生成时间：<td style="width: 477px">
                        
                        <input runat="server" id="txtBeginTime" onClick="WdatePicker({lang:'zh-cn'})"/>
                        <img onclick="WdatePicker({el:$dp.$('txtBeginTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                        -
                        <input id="txtEndTime" runat="server" onClick="WdatePicker({lang:'zh-cn'})" />
                        <img onclick="WdatePicker({el:$dp.$('txtEndTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                        </td>
                                        
                                        
                                </tr>
                                 <tr>
                                    <td style="height: 24px" >
                                        收费状态：</td>
                                    <td style="height: 24px" >
                                     <select id="Mtype" runat="server" name="sType">
                                         <option value="1">收费</option>
                                            <option value="2">免费</option>
                                       
                               
                                            <option selected="selected" value="">---请选择---</option>
                                        </select></td>
                        
                                        
                                </tr>
                                
                                    
                                    
                                     
                                   
                               
                                        
                        
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Button ID="Button1" runat="server" Text="查   询" CssClass="buttomal" Width="105px" OnClick="Button1_Click1" />&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                        <div class="hrline">
                        </div>
                   
                             <div class="alltablebg">
                             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                                 <tr  style="background:#bcd9e7; height:27px;">
                  
                                    <td width="13%" class="bg1" style="height: 27px">
                                        充值账户</td>
                                        <td width="13%" class="bg1" style="height: 27px">
                                        充值人</td>
                                    <td width="10%" class="bg1" style="height: 27px">
                                        充值金额(元)</td>
                                    <td width="10%" class="bg1" style="height: 27px">
                                        生成时间</td>
                                   
                                    <td width="13%" class="bg1" style="height: 27px">
                                        充值方式</td>
                                     <td width="13%" class="bg1" style="height: 27px">
                                        收费状态</td>
                                    <td width="13%" class="bg1" style="height: 27px">
                                        邮箱</td>
                                         
                                    <td width="13%" class="bg1" style="height: 27px">
                                        手机号码</td>
                                    <td width="15%" class="bg1" style="height: 27px">
                                        操作</td>
                                </tr>
                                <asp:Repeater runat="server" ID="NewsList">
                                    <ItemTemplate>
                                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >

                                            <td style="height: 28px">
                                                <%#Eval("LoginName")%>
                                            </td>
                                             <td style="height: 28px">
                                                <%#Eval("ChangeBy")%>
                                            </td>
                                            <td style="height: 28px">
                                                <%#Eval("PointCount", "{0:N}")%>
                                            </td>
                                            <td style="height: 28px">
                                                <%#Eval("ChangeTime")%>
                                            </td>
                                           
                                            <td style="height: 28px">
                                                <%#GetPayType(Eval("StrikeType"))%>
                                            </td>
                                                <td style="height: 28px">
                                                 
                                                     <%#(Eval("Free")).ToString() == "0" ? "未选择" : (Eval("Free")).ToString() == "1" ? "收费" : "免费"%>
                                            
                                            </td>
                                             <td style="height: 28px">
                                                <%#(Eval("Email")).ToString() == "" ? "未填写" : Eval("Email")%>
                                            </td>
                                                <td style="height: 28px">
                                                <%#(Eval("Mobile")).ToString() == "" ? "未填写" : Eval("Mobile")%>
                                            </td>
                                            <td style="height: 28px">
                                                <a href="strike_details.aspx?order_no=<%#Eval("CardNo") %>" class="bluelink">查看</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td colspan="8" class="tdspan">
                                        <table>
                                            <tr>
                                                <td colspan="3" style="height: 34px; text-align: left">
                                                    共搜索到<span style="color:red;"><%=AspNetPager.RecordCount%></span>条，共<span style="color:red;"><%=AspNetPager.PageCount%></span>页
        每页显示<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem Selected="True">15</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>

            </asp:DropDownList>条记录 &nbsp; &nbsp; <span id="pinfo" runat="server"></span>&nbsp;</td>
						 <th align="center"  colspan="8" style="height: 34px">
                <cc1:AspNetPager ID="AspNetPager" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" CssClass="anpager" OnPageChanged="AspNetPager_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="20">
                                </cc1:AspNetPager>
                </th> 
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <div class="tdright mar4">
                                &nbsp;</div>
                        </div>
                    </div>
                </td>
            </tr>
          
        </table>
    </form>
</body>
</html>
