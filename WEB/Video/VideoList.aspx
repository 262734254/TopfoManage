﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoList.aspx.cs" Inherits="Video_VideoList" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>企业名片管理</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />
    <script language="javascript" type="text/jscript" src="../js/Common1.js"></script>
    <script language="javascript" type="text/javascript">
          function Del(Id)
          {
             if(confirm('确定要删除!'))
             {
                 var url="VideoList.aspx?Id="+Id;
                 window.location.href=url;
             }
          }
          
          function Modfiy(Id)
          {
             var url="ModfiyVideo.aspx?Id="+Id;
             window.location.href=url;
          }
          
          function Check()
          {
               var DropType=js.$("<%=DropType.ClientID %>");
               if(DropType.options[DropType.selectedIndex].value=="-1")
               {
                   alert("请选生成类别!");
                   DropType.focus();
                   return false;
               }
               return true;
          }
          
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="mainconbox">
            <div class="title" align="center">
                <h2>
                    <p><span><b>视频/专题管理</b></span></p>
                </h2>
            </div>
             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                <tr>
                    <td align="center" >
                        标题：
                        <input id="txtTitle" type="text" runat="server" />
                        </td>
                        <td align="center">
                          是否推荐：
                         <asp:DropDownList ID="DropRecommend" runat="server">
                           <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                           <asp:ListItem Value="1">是</asp:ListItem>
                           <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td align="center">
                          展示位置:
                         <asp:DropDownList ID="ShowPosition" runat="server">
                        </asp:DropDownList>
                        </td>
                        <td align="center">
                        <asp:Button runat="server" ID="Search" CssClass="btn" Text="确定" OnClick="Search_Click"/></td>
                </tr>
            </table>
               <div class=" cshibiank">
                <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table">
                      <tr>
                        <th width="7%" align="center" class="tabtitle" style="height: 29px"><a href="Javascript:js.IsSelect(true,'Cbox');">全</a>|<a href="Javascript:js.IsSelect(false,'Cbox');">反</a></th>
                        <th align="center" width="7%" class="tabtitle">序号</th>
                        <th align="center" width="18%" class="tabtitle">标题</th>
                       <%-- <th align="center" width="18%" class="tabtitle"> 图片</th>--%>
                        <th align="center" width="12%" class="tabtitle"> 类型</th>
                        <th align="center" width="10%" class="tabtitle"> 是否推荐</th>
                        <th align="center" width="14%" class="tabtitle"> 展示位置</th>
                        <th align="center" width="14%" class="tabtitle">管理</th>
                    </tr>    
                    <asp:Repeater ID="VideoList" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                                <td align="center">
                                     <asp:CheckBox runat="server" ID="Cbox" ToolTip='<%# Eval("id") %>' />
                                </td>
                                <td align="center">
                                  <%# Container.ItemIndex + 1 %>
                                </td>
                                <td align="center">
                                <a href='<%# Eval("VideoUrl") %>' target="_blank"><%# Eval("Title")%></a>
                                </td>
                               <%-- <td align="center">
                                   <%# Eval("ImgUrl")%>
                                </td>--%>
                               <td align="center">
                                   <%# (Eval("VideoType").ToString() == "0") ? "招商方" : (Eval("VideoType").ToString() == "1") ? "投资方" : (Eval("VideoType").ToString() == "2") ? "融资方" : (Eval("VideoType").ToString() == "3") ? "展会" : "资金贷款" %>
                                   (<%# (Eval("Type").ToString() == "0") ? "视频" :"专题"%>)
                                </td>
                                <td align="center">
                                  <%# (Eval("IsRecommend").ToString()=="0")?"否":"是" %>
                                </td>
                                <td align="center">
                                 <%# GetFenZhanName(Eval("ShowId").ToString())%>
                                </td>
                                <td align="center">
                                    <a href='JavaScript:Del(<%#Eval("Id") %>)'>删除</a>&nbsp &nbsp
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
           <input type="button" value="添加资源" class="btn" onclick="window.location.href='AddVideo.aspx';" />
            <asp:Button ID="ButCreateIndex" OnClientClick="return Check();" CssClass="btn" runat="server" Text="生成首页" OnClick="ButCreateIndex_Click" />
            <asp:DropDownList runat="server" ID="DropType">
               <asp:ListItem Value="-1">请选择</asp:ListItem>
               <asp:ListItem Value="0">视频</asp:ListItem>
               <asp:ListItem Value="1">专题</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>

