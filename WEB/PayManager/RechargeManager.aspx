<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RechargeManager.aspx.cs" Inherits="PayManager_RechargeManager" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>充值卡在线充值</title>
      <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
                    <script language="javascript" src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
     <script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
</head>
<body>
       <form id="form1" runat="server">
       
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>充值卡在线充值</b></span></p>
                </h2>
               
            </div>
             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>
            <td align="center" style="height: 24px">充值卡号：
            <input id="txtNumber"  style="width:100px;" type="text"  runat="server" /></td>
   
            <td align="center" style="height: 24px">
                收费状态：

                                        <select id="sType" runat="server" name="sType">
                                            <option value="1">收费</option>
                                            <option value="2">免费</option>
  
                                            <option selected="selected" value="">---请选择---</option>
                                        </select>
                           
           </td>
       
        <td   align="center" style="height: 24px">
            <asp:Button ID="btnSearch"  CssClass="btn"  runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
            </td>
    </tr>
    </table>
               
                         
                            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                                 <tr  style="background:#bcd9e7; height:27px;">
                  
                                    <td width="13%" class="bg1" style="height: 27px">
                                        充值卡卡号</td>
                                        <td width="13%" class="bg1" style="height: 27px">
                                        金额</td>
                                  
                                    <td width="10%" class="bg1" style="height: 27px">
                                        卡号类型</td>
                                   
                                    <td width="13%" class="bg1" style="height: 27px">
                                        充值卡状态</td>
                                        
                                                                            <td width="13%" class="bg1" style="height: 27px">
                                        收费状态</td>
                                     
                                </tr>
                                <asp:Repeater runat="server" ID="NewsList">
                                    <ItemTemplate>
                                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >

                                            <td style="height: 28px">
                                                <%#Eval("NumberID")%>
                                            </td>
                                             <td style="height: 28px">
                                                <%#Eval("CardMoney","{0:N}")%>
                                            </td>
                                            <td style="height: 28px">
                                                   
                                                 
                                                        <%#(Eval("CardType")).ToString() == "1" ? "200点" : (Eval("CardType")).ToString() == "2" ? "500点":"1000"%>
                                            </td>
                                            
                                                 <td style="height: 28px">
                                                 
                                                      <%#(Eval("CardState")).ToString() == "1" ? "已使用":"未使用"%>
                                            
                                            </td>
                                            
                                              <td style="height: 28px">
                                                 
                                                   
                                                     <%#(Eval("Free")).ToString() == "0" ? "未选择" : (Eval("Free")).ToString() == "1" ? "收费" : "免费"%>
                                            
                                            </td>
                                           
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                      
                            </table>
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
                           </div> 
           
    </form>
</body>
</html>
