<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateCard.aspx.cs" Inherits="PayManager_CreateCard" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>会员余额列表</title>
       <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <form id="form1" runat="server">
    <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>会员余额列表</b></span></p>
                </h2>
               
            </div>
             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>
        
        <td  align="center" style="height: 24px">
            登录名：<input id="txtLoginName"  style="width:100px;" type="text"  runat="server" />
        </td>
        <td   align="center" style="height: 24px">
            <asp:Button ID="btnSearch"  CssClass="btn"  runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
            </td>
    </tr>
    </table>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr  style="background:#bcd9e7; height:27px;">
                      <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        编号</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        登录名</th>
                       
                          
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        余额</th>
                        <th width="10%" align="center" class="tabtitle" style="height: 32px">
                              日期</th>
                       
                </tr>
                <asp:Repeater ID="NewsList"  runat="server">
                    <ItemTemplate>
                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >
                       
                            
                            <td style="width: 100px">
                                  <%#Eval("ID") %>
                       
                            <td style="width: 100px">
                            
                             <%#Eval("LoginName") %>

                            </td>

                            <td style="width: 100px">
                                 <%#Convert.ToDecimal(Eval("WorthPoint", "{0:N}")) + "元"%>
                            </td>
                               <td style="width: 100px">
                                 <%#Convert.ToDateTime(Eval("ChangeTime")).ToString("yyyy-MM-dd")%> 
                            </td>
                          
         
                         
                        </tr>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </table>
   共搜索到<span style="color:red;"><%=AspNetPager.RecordCount%></span>条，共<span style="color:red;"><%=AspNetPager.PageCount%></span>页
        每页显示<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem Selected="True">15</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>

            </asp:DropDownList>条记录 &nbsp;
      
               <td style="text-align:right; width: 348px;">
                   &nbsp;&nbsp;</td>
                  <td style="text-align: left; width: 74px;" >
                                <span id="pinfo" runat="server"></span>&nbsp;</td>
						 <th align="center"  colspan="8" style="height: 32px">
                <cc1:AspNetPager ID="AspNetPager" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" CssClass="anpager" OnPageChanged="AspNetPager_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="20">
                                </cc1:AspNetPager>
                </th>
				<tr>
                                    <td align="center" colspan="4" style="height: 30px">
                                        &nbsp;<input class="buttomal" onclick="javascript:history.go(-1)" style="width: 96px"
                                            type="button" value="返回" /></td>
                                </tr>		
						
			  </div>			
      
    </form>
</body>
</html>
