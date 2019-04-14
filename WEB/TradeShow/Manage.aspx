<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="TradeShow_Manage" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>企业名片管理</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="../js/Common1.js"></script>
    <script language="javascript" type="text/javascript">
          function Del(Id)
          {
              if(confirm('确定要删除!'))
              {
                 var url="Manage.aspx?Id="+Id;
                 window.location.href=url;
              }
          }
          
          function Modfiy(Id)
          {
             var url="Modify.aspx?Id="+Id;
             window.location.href=url;
          }
          
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="mainconbox">
            <div class="title" align="center">
                <h2>
                    <p><span><b>参会名单管理</b></span></p>
                </h2>
            </div>
               <div class=" cshibiank">
                <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table">
                      <tr>
                        <th width="8%" align="center" class="tabtitle" style="height: 29px"><a href="Javascript:js.IsSelect(true,'Cbox');">全</a>|<a href="Javascript:js.IsSelect(false,'Cbox');">反</a></th>
                        <th align="center" width="6%" class="tabtitle">序号</th>
                        <th align="center" width="20%" class="tabtitle">标题</th>
                        <th align="center" width="15%" class="tabtitle">类别</th>
                        <th align="center" width="15%" class="tabtitle">拟邀人员</th>
                        <th align="center" width="15%" class="tabtitle">职务</th>
                        <th align="center" width="15%" class="tabtitle"> 发布时间</th>
                        <th align="center" width="14%" class="tabtitle">管理</th>
                    </tr>    
                    <asp:Repeater ID="RepTradeShow" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                                <td align="center">
                                     <asp:CheckBox runat="server" ID="Cbox" ToolTip='<%# Eval("Id") %>' />
                                </td>
                                <td align="center">
                                  <%# Container.ItemIndex + 1 %>
                                </td>
                                <td align="center">
                                   <%# Eval("Title")%>
                                </td>
                                <td align="center">
                                   <%# Eval("UserName")%>
                                </td>
                                <td align="center">
                                   <%# Eval("Job")%>
                                </td>
                                <td align="center">
                                   <%# ((Eval("Types").ToString() == "1") ? "政府招商" : (Eval("Types").ToString() == "2") ? "资本机构" : "融资项目") %>
                                </td>
                                <td align="center">
                                   <%# Convert.ToDateTime(Eval("PublishTime")).ToString("yyyy-MM-dd") %>
                                </td>
                                <td align="center">
                                    <a href="JavaScript:Del('<%# Eval("Id") %>')">删除</a>&nbsp &nbsp
                                    <a href='JavaScript:Modfiy(<%#Eval("Id") %>)'>修改</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="pagebox" style="margin-left:5px; margin-top:5px;">
                <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td style="width: 20%;" align="left">
                            共<span id="pinfo" style="color: Red" runat="server"></span>个数据
                        </td>
                        <td style="width: 80%">
                            <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false" NextPageText="下一页"
                                OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowInputBox="Always"
                                SubmitButtonText="GO" Width="479px">
                            </cc1:AspNetPager>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="margin-left:5px; margin-top:5px;">
           <input type="button" value="添 加" class="btn" onclick="window.location.href='Add.aspx';" />
           <asp:Button ID="BtnDel" runat="server" CssClass="btn" OnClientClick='return js.DelChecked("Cbox","请选择删除项","")' Text="删 除" OnClick="BtnDel_Click" />
        </div>
    </form>
</body>
</html>
