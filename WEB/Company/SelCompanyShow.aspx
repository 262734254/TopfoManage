<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelCompanyShow.aspx.cs" Inherits="Company_SelCompanyShow" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>企业名片管理</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />

    <script language="javascript" src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

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
            
          function Modfiy(id,n)
          {
             if(n==0)
             {
                 var url;
                 url="CompanyShowAdd.aspx?CompanyId="+id+"";
                 window.location.href=url;
             }

             else if(n==1)
             {
                var url;
                url="SelCompanyShow.aspx?CompanyId="+id+"";
                window.location.href=url;
             }
          }
    </script>

    <script language="javascript" type="text/javascript" src="http://www.topfo.com/js/jquery.js"></script>

    <script language="javascript" type="text/javascript">
        
        function sendHit(cn)
        {
            var url="http://dp.topfo.com/Comm/Handler.ashx?userName='"+cn+"'&jsoncallback=?";
            $.getJSON(url,function(msg)
            {
                
            });
            alert('数据恢复成功!');
        }
        
        function shows(cn,roleid)
        {
            if(roleid==1)
            {
                sendHit(cn);
            }
            else
            {
            window.location.href="SelCompanyShow.aspx?userName="+cn;
            }
        }
         
        function show()
        {
            var a=document.getElementById("namevalue").value;
            if(a!=null && a!="")
            {
                alert(a);
                sendHit(a);
                document.getElementById("namevalue").value="";
             }
        }
         
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="mainconbox">
            <input id="namevalue" runat="server" style="display: none" />
            <div class="title" align="center">
                <h2>
                    <p>
                        <span><b>企业展厅管理</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    <td style="width: 385px">
                        开始时间：
                        <input runat="server" id="txtBeginTime" class="Wdate" onclick="WdatePicker({lang:'zh-cn'})"
                            style="width: 110px; height: 20px" />
                        &nbsp;结束时间：
                        <input id="txtEndTime" runat="server" class="Wdate" onclick="WdatePicker({lang:'zh-cn'})"
                            style="width: 110px; height: 20px" />
                    </td>
                    
                     <td align="center">
                        角色：
                        <asp:DropDownList runat="server" ID="ddlJs">
                            <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                            <asp:ListItem Value="1">招商拓富通</asp:ListItem>
                            <asp:ListItem Value="3">资源联盟</asp:ListItem>
                            <asp:ListItem Value="4">融资拓富通</asp:ListItem>
                            <asp:ListItem Value="5">投资拓富通</asp:ListItem>
                             
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        帐号名称：
                        <input id="txtLoginName" type="text" runat="server" />
                    </td>
                    <td align="center">
                        类型：
                        <input id="txtCompanyName" type="text" runat="server" />
                    </td>
                    <td align="center">
                        审核状态：
                        <asp:DropDownList runat="server" ID="ddlStatus">
                            <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                            <asp:ListItem Value="0">未审核</asp:ListItem>
                            <asp:ListItem Value="1">审核通过</asp:ListItem>
                            <asp:ListItem Value="2">审核未通过</asp:ListItem>
                            <asp:ListItem Value="3">已过期</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnOK" CssClass="btn" Text="确定" OnClick="btnOK_Click" />
                    </td>
                </tr>
            </table>
            <div class=" cshibiank">
                <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table">
                    <tr>
                        <th width="5%" align="center" class="tabtitle" style="height: 29px">
                            <a href="Javascript:SelectAll();">全选</a>|<a href="Javascript:ReSelect();">反选</a>
                        </th>
                        <th align="center" width="9%" class="tabtitle">
                            用户名</th>
                        <th align="center" width="9%" class="tabtitle">
                            类型</th>
                        <th align="center" width="10%" class="tabtitle">
                            发布时间</th>
                        <th align="center" width="10%" class="tabtitle">
                            角色</th>
                        <th align="center" width="8%" class="tabtitle">
                            审核状态</th>
                        <th align="center" width="6%" class="tabtitle">
                            点击率</th>
                        <th align="center" width="8%" class="tabtitle">
                            有效期限</th>
                              <th align="center" width="8%" class="tabtitle">
                            分红余额</th>
                        <th align="center" width="15%" class="tabtitle">
                            管理</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                                <td align="center">
                                    <label>
                                        <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("CompanyID") %>" />
                                    </label>
                                </td>
                                <td align="center">
                                    <%--<a href="http://<%#Eval("UserName")%>.topfo.com/" target="_blank">
                                        <%#Eval("UserName")%></a>--%>
                                         <asp:HyperLink ID="hlTitle" runat="server"></asp:HyperLink>
                                </td>
                                <td align="center">
                                    <%#Eval("TypeName")%>
                                </td>
                                <td align="center">
                                    <%#this.DateTime(Convert.ToString(Eval("StartTime")))%>
                                </td>
                                <td align="center">
                                    <%#GetRoleId(Convert.ToInt32(Eval("RoleId")))%>
                                </td>
                                <td align="center">
                                    <%#this.AuditName(Convert.ToInt32(Eval("Audit"))) %>
                                </td>
                                <td align="center">
                                    <%#Convert.ToString(Eval("Hit")) == "" ? "0" : Convert.ToString(Eval("Hit"))%>
                                </td>
                                <td align="center">
                                    <%#Eval("Valid") %>
                                    个月
                                </td>
                                     <td align="center">
                                    <%#Eval("MoneyCount") %>
                                 
                                </td>
                                <td align="center">
                                    <a href='JavaScript:Modfiy(<%#Eval("CompanyID") %>,0)'>审核</a>&nbsp &nbsp
                                    <%--    <a href='JavaScript:Modfiy(<%#Eval("CompanyID") %>,1)'>删除</a>  --%>
                                    <asp:LinkButton ID="lbdel" CommandArgument='<%#Eval("CompanyID")%>' CommandName="del"
                                        runat="server" OnCommand="LinkButton1_Command" ToolTip="生成静态页面" OnClientClick="return confirm('确认生成此文件?');">生成静态</asp:LinkButton>
                                   <a href='JavaScript:shows("<%#Eval("UserName")%>",<%#Eval("RoleId")%>);'>数据恢复</a>
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
        <%--<input id="btnProall" type="button" class="btn" value="批量生成" />--%>
        <div class="pagebox">
            &nbsp; &nbsp; &nbsp;
            <%--      &nbsp &nbsp
    <asp:Button runat="server" ID="btnRes" Text="数据恢复" CssClass="btn" OnClick="btnRes_Click"  />--%>
        </div>
    </form>
</body>
</html>
