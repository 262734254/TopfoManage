﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecommendManage.aspx.cs" Inherits="Recommend_RecommendManage" %>

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
            
          function Del(Id)
          {
             if(confirm('确定要删除!'))
             {
                 var url="RecommendManage.aspx?Id="+Id;
                 window.location.href=url;
             }
          }
          
          function Modfiy(Id)
          {
              var url="ModfiyRecommend.aspx?Id="+Id;
              window.location.href=url;
          }
          
    </script>

</head>
<body>
    <form id="form2" runat="server">
        <div class="mainconbox">
            <div class="title" align="center">
                <h2>
                    <p><span><b>项目推荐管理</b></span></p>
                </h2>
            </div>
           <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                <tr>
                    <td align="center" >
                            标题：
                        <input id="txtTitle"   type="text"  runat="server" />
                        </td>
                        <td align="center">
                          类型:
                           <asp:DropDownList ID="DropIdentity" Width="200" runat="server">
                               <asp:ListItem Value="-1">请选择</asp:ListItem>
                               <asp:ListItem Value="0">招商方</asp:ListItem>
                               <asp:ListItem Value="1">投资方</asp:ListItem>
                               <asp:ListItem Value="2">融资方</asp:ListItem>
                               <asp:ListItem Value="3">热点资源项目</asp:ListItem>
                               <asp:ListItem Value="4">重大热点资源项目</asp:ListItem>
                               <asp:ListItem Value="5">重大投资项目</asp:ListItem>
                           </asp:DropDownList>
                        </td>
                        <td>
                        <asp:Button runat="server" ID="Search" CssClass="btn" Text="确定" OnClick="Search_Click" /></td>
                </tr>
            </table>         
               <div class=" cshibiank">
                <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table">
                    <tr>
                        <th width="10%" align="center" class="tabtitle" style="height: 29px">
                            <a href="Javascript:SelectAll();">全</a>|<a href="Javascript:ReSelect();">反</a>
                        </th>
                        <th align="center" width="10%" class="tabtitle">
                            序号</th>
                        <th align="center" width="22%" class="tabtitle">
                            标题</th>
                        <th align="center" width="18%" class="tabtitle">
                            类型</th>
                        <th align="center" width="14%" class="tabtitle">
                            是否推荐</th>
                        <th align="center" width="13%" class="tabtitle">
                            显示位置</th>
                        <th align="center" width="13%" class="tabtitle">
                            管理</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                                <td align="center">
                                    <label>
                                        <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%# Eval("Id") %>" />
                                    </label>
                                </td>
                                <td align="center">
                                   <%# Container.ItemIndex + 1 %>
                                </td>
                                <td align="center">
                                    <%# Eval("Title") %>
                                </td>
                                <td align="center">
                                     <%#this.Verify(Convert.ToInt32(Eval("Identity")))%>
                                </td>
                                <td align="center">
                                  <%# (Eval("IsRecommend").ToString() == "0") ? "否" : "是" %>
                                </td>
                                <td align="center">
                                  <%# GetFenzhanName(Eval("ProvinceID").ToString().Trim())  %>
                                </td>
                                <td align="center">
                                    <a href='JavaScript:Del(<%# Eval("Id") %>)'>删除</a>
                                    <a href='JavaScript:Modfiy(<%# Eval("Id") %>)'>修改</a>&nbsp &nbsp
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
        <input id="BtnRecommend" onclick="location.href='AddRecommend.aspx'" type="button" class="btn" value="新增" />
    </div>
    </form>
</body>
</html>

