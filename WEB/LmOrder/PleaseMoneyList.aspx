<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PleaseMoneyList.aspx.cs" Inherits="LmOrder_PleaseMoneyList" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
     <script language="javascript" src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
</head>
<body>
    <form id="form1" runat="server">
        <div class="list">
            <div>
                <h2 style="margin-bottom:8px;">
                    <p>
                        <span><b>提现记录</b></span></p>
                </h2>
            </div>
            <table width="100%" border="0" align="center" cellpadding="1" class="one_table" cellspacing="1">
            <thead>
                <tr >
                    
                       <th colspan="3" style="height: 27px">
                           交易日期：<input runat="server" id="txtBeginTime" onClick="WdatePicker({lang:'zh-cn'})"/>
                        <img onclick="WdatePicker({el:$dp.$('txtBeginTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                        -
                        <input id="txtEndTime" runat="server" onClick="WdatePicker({lang:'zh-cn'})" />
                        <img onclick="WdatePicker({el:$dp.$('txtEndTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" /> 申请人：<input id="txtLoginName" runat="server" style="width: 76px" type="text" />  审核状态：
                        <asp:DropDownList runat="server" ID="ddlStatus">
                            <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                            <asp:ListItem Value="0">审核中</asp:ListItem>
                            <asp:ListItem Value="1">已结账</asp:ListItem>
                            <asp:ListItem Value="1">审核未通过</asp:ListItem>

                        </asp:DropDownList>
                        <asp:Button ID="btnSearch" class="buttomal" runat="server" Text="查  询" OnClick="btnSearch_Click" /></th>
               
               
                </tr>
                 </thead></table>
          <table width="100%" border="0" align="center" cellpadding="1" class="one_table" cellspacing="1">
            <thead>
                <tr style="background-color:#eee">
                    <th align="center" class="tabtitle" style="height: 31px; width: 7%;">
                        编号</th>
                      <th width="10%" align="center" class="tabtitle" style="height: 31px">
                        提现金额</th>
                        <th align="center" class="tabtitle" style="height: 31px; width: 10%;">
                        申请日期</th>
                          <th align="center" class="tabtitle" style="height: 31px; width: 10%;">
                        申请人</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 31px">
                        状态</th>
                             <th width="10%" align="center" class="tabtitle" style="height: 31px">
                        管理</th>
                       
                </tr>
                </thead>
                          <asp:Repeater ID="NewsList"   runat="server">
                    <ItemTemplate>
                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >
                   
                            
                            <td  align="center">
                                  <%#Eval("atmid")%>
                       
                            <td align="center">
                             
                                        <%#Eval("atmcount", "{0:N}")%>
                                  
                                 
                            
                            </td>
                    
                            <td style="width: 100px" align="center">
                            <%#Convert.ToDateTime(Eval("createTime")).ToString("yyyy-MM-dd")%> 
                                
                            </td>
                            <td style="width: 100px" align="center">
                            <%#Eval("LoginName")%> 
                                
                            </td>
                            <td style="width: 100px" align="center">
                           <%#this.getStatu(Convert.ToInt32(Eval("StateID")))%>
                                  
                                
                            </td>
                            
                            
                            
                          
                               <td style="width: 100px" align="center">
                                   
                           <a class="bluelink" href="info_details.aspx?atmid=<%#Eval("atmid") %>"><span
                                                    style="color: #0000ff">审核</span></a>

                            </td>
                         
                        </tr>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </table>

            <br />

         <span style="color: #ff0033">
        &nbsp;&nbsp;&nbsp;&nbsp;共搜索到<span style="color:red;"><%=AspNetPager.RecordCount%></span>条，共<span style="color:red;"><%=AspNetPager.PageCount%></span>页
                  <td style="text-align: left; width: 74px;" >
                                <span id="pinfo" runat="server"></span>&nbsp;</td>
						 <th align="center"  colspan="8" style="height: 32px">
                <cc1:AspNetPager ID="AspNetPager" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" CssClass="anpager" OnPageChanged="AspNetPager_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="10">
                                </cc1:AspNetPager>
                                
                </th>
						</div>
    </form>
</body>
</html>
