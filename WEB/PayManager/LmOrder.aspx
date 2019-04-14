<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LmOrder.aspx.cs" Inherits="PayManager_LmOrder" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <form id="form1" runat="server">
    <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>资源联盟分红</b></span></p>
                </h2>
               
               
            </div>
             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>
            <td align="center" style="height: 24px">标题：
            <input id="txtTitle"  style="width:100px;" type="text"  runat="server" /></td>
        <td align="center" style="height: 24px">
            订单号：
            <input id="txtNuber"  style="width:100px;" type="text"  runat="server" /></td>
        
        <td  align="center" style="height: 24px">
            发布人：<input id="txtLoginName"  style="width:100px;" type="text"  runat="server" />
        </td>
   
        <td   align="center" style="height: 24px">
            <asp:Button ID="btnSearch"  CssClass="btn"  runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
            </td>
    </tr>
    </table>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr  style="background:#bcd9e7; height:27px;">
                    
                      <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        订单号</th>
                        <th width="30%" align="center" class="tabtitle" style="height: 32px">
                        标题</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        发布人</th>
                       
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        购买人</th>
                         <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        购买金额</th>
                              <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        分红</th>
                                       <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        购买日期</th>
                        
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        管理</th>
                       
                </tr>
                <asp:Repeater ID="NewsList"   runat="server">
                    <ItemTemplate>
                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >
                   
                            
                            <td style="width: 100px">
                                  <%#Eval("OrderNo")%>
                       
                            <td >
                             <a href="http://www.topfo.com/<%#Eval("HtmlFile")%>" target="_blank">
                                        <%#Eval("Title")%>
                                    </a>
                            
                            </td>

                            <td style="width: 100px">
                                 <%#Eval("BuyName") %>
                            </td>
                            
                               <td style="width: 100px">
                                 <%#Eval("LoginName") %>
                            </td>
                            
                               <td style="width: 100px">
                                 <%#Eval("TotalAmount")%>
                            </td>
                            
                                    <td style="width: 100px">
                                 <%#Eval("ShareAmount")%>
                            </td>
                            
                               <td style="width: 100px">
                                 <%#Convert.ToDateTime(Eval("Paydate")).ToString("yyyy-MM-dd(hh:mm)")%> 
                            </td>
                            
                          
                               <td style="width: 100px">
                                   
                           <a class="bluelink" href="trade_info_details.aspx?ID=<%#Eval("OrderId") %>&status=1"><span
                                                    style="color: #0000ff">明细</span></a>

                            </td>
                         
                        </tr>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </table>
               

    <div>
    
   
        &nbsp;&nbsp;&nbsp;&nbsp;共搜索到<span style="color:red;"><%=AspNetPager.RecordCount%></span>条，共<span style="color:red;"><%=AspNetPager.PageCount%></span>页
                  <td style="text-align: left; width: 74px;" >
                                <span id="pinfo" runat="server"></span>&nbsp;</td>
						 <th align="center"  colspan="8" style="height: 32px">
                <cc1:AspNetPager ID="AspNetPager" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" CssClass="anpager" OnPageChanged="AspNetPager_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="20">
                                </cc1:AspNetPager>
                </th>
						</div>
						
      
    </form>
</body>
</html>
