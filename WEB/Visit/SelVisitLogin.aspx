<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelVisitLogin.aspx.cs" Inherits="Visit_SelVisitLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>会员信息显示</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
    <script language="javascript" src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
    <script language="javascript" type="text/javascript">
    function SelAdd(name,id)
    {
      var a;
      a="AddVisit.aspx?LoginName="+name+"&num="+id;
      window.location.href=a;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainconbox">

       <div class="title" align="center">
             <h2><p><span><b>会员频道管理</b></span></p></h2>
             <h2><p><span><b><a href="#">查看会员信息</a></b></span></p></h2>
             </div>
        <div class=" cshibiank">
            <table width="100%" border="0" align="center" class="one_table"  cellpadding="0" cellspacing="0">
                <tr>
                    <td >编号：
                        <asp:TextBox ID="txtLoginID" runat="server"></asp:TextBox></td>
                   
                    <td >帐号：
                        <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    <td >名称：
                        <asp:TextBox ID="txtNickName" runat="server"></asp:TextBox></td>
                    
                    <td >地域：<uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    </td>
                    
                </tr>
                <tr>
                    <td  >类型：
                        <asp:DropDownList ID="ddlTypeID" runat="server">
                        </asp:DropDownList></td>
                   
                    <td  >注册日期：<input  type="text" runat="server" id="txtTime" onClick="WdatePicker({lang:'zh-cn'})" />
                     <img onclick="WdatePicker({el:$dp.$('txtTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="3" align="center"><asp:Button runat="server" ID="btnSel" CssClass="btn" Text="查询" OnClick="btnSel_Click" />
                    </td>
                </tr>
            </table>
       
        
            <table width="100%" border="0" align="center" class="one_table"  cellpadding="0" cellspacing="0">
                <tr>
                    <th width="8%" align="center" class="tabtitle" style="height: 32px">
                        编号                   </th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        登录ID                    </th>
                     <th width="10%" align="center" class="tabtitle" style="height: 32px">
                       用户名称                   </th>
                    <th width="18%" align="center" class="tabtitle" style="height: 32px">
                        注册日期                  </th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        是否有效</th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                    是否回访</th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                    详细信息</th>
                   <%-- <th width="15%" align="center" class="tabtitle" style="height: 32px">
                        发布项目
                    </th>--%>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#(Eval("LoginID"))%>
                            </td>
                             <td align="center">
                               <%#(Eval("MemberID"))%>
                            </td>
                            <td align="center">
                                <a href='JavaScript:SelAdd("<%#(Eval("LoginName")).ToString().Trim()%>",2);'><%#Eval("LoginName")%></a> 
                          </td>
                            <td align="center">
                                <%#(Eval("RegisterTime"))%>
                          </td>
                            <td>
                            <%#this.Province(1,Convert.ToString(Eval("LoginName").ToString().Trim()))%>
                          </td>
                             <td align="center">
                              <%#this.Province(2, Convert.ToString(Eval("LoginName").ToString().Trim()))%>
                          </td>
                           <td align="center">
                            <a href='JavaScript:SelAdd("<%#(Eval("LoginName")).ToString().Trim()%>",2);'>查看</a>
                          </td>
                            <%--<td align="center">
                            
                            <a href='#'>修改</a>
                            <a href='#'>添加</a> 
                            </td>--%>
                    </ItemTemplate>
                </asp:Repeater>
          </table>
        </div>
        <div class="pagebox">

            <div class="right" style="text-align:right">
            <cc1:Pager ID="Pager1" runat="server" BackColor="Transparent" BorderStyle="None"
                PagerStyle="CustomAndNumeric" ControlToPaginate="RfList" PagingMode="NonCached"
                UseCustomDataSource="False" ShowCount="True" SortColumn="PublishT" SortType="DESC"
                TableViewName="MainInfoVIW" KeyColumn="InfoID"
                ShowPageCount="False"></cc1:Pager>
                &nbsp;</div>
                
           <%--<div class="clear">
           <input id="btnAdd" class="btn" runat="server"
                    type="button" value="添加" />
                    <input id="btnfanhui" class="btn" type="button" value="返回"  />
           </div>--%>
        </div>
    </div>
    </form>
</body>
</html>
