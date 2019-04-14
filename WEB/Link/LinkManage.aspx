<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinkManage.aspx.cs" Inherits="Link_LinkManage" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>企业名片管理</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
           function SelectAll()
           {
                if(!document.getElementById("cbxSelect"))
                    return;
                var obj = document.getElementById("cbxSelect");
                elem=obj.form.elements;
                for(i=0;i<elem.length;i++)
                {          
	                if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
	                {
	                    if(elem[i].checked!=true)			
		                    elem[i].click();
	                }
                }
           } 
            function ReSelect()
            {
                if(!document.getElementById("cbxSelect"))
                    return;
                var obj = document.getElementById("cbxSelect");
                elem=obj.form.elements;
                for(i=0;i<elem.length;i++)
                {          
                    if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
                    {
                            elem[i].click();
                    }
                }
            }
            
          function Del(LinkId)
          {
             if(confirm('确定要删除!'))
             {
                 var url="LinkManage.aspx?LinkId="+LinkId;
                 window.location.href=url;
             }
          }
          
          function Modfiy(LinkId)
          {
             var url="ModfiyLink.aspx?LinkId="+LinkId;
             window.location.href=url;
          }
          
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="mainconbox">
            <div class="title" align="center">
                <h2>
                    <p><span><b>友情链接管理</b></span></p>
                </h2>
            </div>
           <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                <tr>
                    <td align="center" >
                        链接名称：
                        <input id="txtLinkName"   type="text"  runat="server" />
                        </td>
                        <td align="center">
                          所属频道:
                          <asp:DropDownList ID="DropChannel" runat="server"></asp:DropDownList>
                        </td>
                        <td align="center">
                          所属类别:
                          <asp:DropDownList ID="DropLinkType" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                        <asp:Button runat="server" ID="Search" CssClass="btn" Text="确定" OnClick="Search_Click" /></td>
                </tr>
            </table>         
               <div class=" cshibiank">
                <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table">
                    <tr>
                        <th width="8%" align="center" class="tabtitle" style="height: 29px">
                            <a href="Javascript:SelectAll();">全</a>|<a href="Javascript:ReSelect();">反</a>
                        </th>
                        <th align="center" width="18%" class="tabtitle">
                            链接名称</th>
                        <th align="center" width="14%" class="tabtitle">
                            链接地址</th>
                        <th align="center" width="14%" class="tabtitle">
                            Logo</th>
                        <th align="center" width="10%" class="tabtitle">
                            所属频道</th>
                        <th align="center" width="12%" class="tabtitle">
                            所属类型</th>
                        <th align="center" width="12%" class="tabtitle">
                            备注</th>
                        <th align="center" width="12%" class="tabtitle">
                            管理</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                                <td align="center">
                                    <label>
                                        <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("LinkInfoId") %>" />
                                    </label>
                                </td>
                                <td align="center">
                                    <%# Eval("LinkInfoName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("LinkUrl")%>
                                </td>
                                <td align="center">
                                    <a href='<%# Eval("Logo") %>'> <%# (Eval("Logo").ToString() == "") ? "&nbsp;" : Eval("Logo")%></a>
                                </td>
                                <td align="center">
                                    <%# Eval("ChannelName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("LinkName") %>
                                </td>
                                <td align="center">
                                    <%# (Eval("Remarks").ToString() == "") ? "&nbsp;" : Eval("Remarks")%>
                                </td>
                                <td align="center">
                                    <a href='JavaScript:Del(<%#Eval("LinkInfoId") %>)'>删除</a>&nbsp &nbsp
                                    <a href='JavaScript:Modfiy(<%#Eval("LinkInfoId") %>)'>修改</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="pagebox">
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
        <div>
           <input type="button" value="频道管理" class="btn" onclick="window.location.href='ChannelManage.aspx';" />
           <input type="button" value="类别管理" class="btn" onclick="window.location.href='LinkTypeManage.aspx';" />
           <input type="button" value="添加链接" class="btn" onclick="window.location.href='AddLink.aspx';" />
        </div>
    </form>
</body>
</html>
