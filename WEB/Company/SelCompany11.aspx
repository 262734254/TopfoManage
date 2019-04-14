<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelCompany.aspx.cs" Inherits="Company_SelCompany" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>企业名片管理</title>
        <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
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
             url="CompanyAdd.aspx?CompanyId="+id+"";
             window.location.href=url;
             }else if(n==1)
             {
                var url;
                url="SelCompany.aspx?CompanyId="+id+"";
                window.location.href=url;
             }
          }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainconbox">

       <div class="title" align="center">
             <h2><p><span><b>企业名片管理</b></span></p></h2>
             </div>
     <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>
        <td align="center" >
            帐号名称：
            <input id="txtLoginName"   type="text"  runat="server" />
            </td>
            <td align="center" >
            企业名称：
            <input id="txtCompanyName"  type="text"  runat="server" />
            </td>
            <td align="center" >
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
        
          <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr >
                <th width="6%" align="center" class="tabtitle" style="height: 29px">
                    <a href="Javascript:SelectAll();">全</a>|<a href="Javascript:ReSelect();">反</a>
                </th>
                  <th align="center" width="16%" class="tabtitle" >
                            企业名称</th>
                            <th align="center" width="9%" class="tabtitle">
                            行业名称</th>
                            <th align="center" width="9%" class="tabtitle" >
                             区域名称</th>
                             <th align="center" width="8%" class="tabtitle" >
                             企业性质</th>
                             <th align="center" width="12%" class="tabtitle" >
                             发布日期</th>
                             <th align="center" width="10%" class="tabtitle" >
                             发布者</th>
                             <th align="center" width="7%" class="tabtitle" >
                             是否推广</th>
                             <th align="center" width="10%" class="tabtitle" >
                             审核状态</th>
                             <th align="center" width="10%" class="tabtitle" >
                             管理</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                         <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >  
                         <td align="center" >
                            <label>
                                <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("CompanyID") %>" />
                            </label>
                        </td>           
                        <td align="center">
                          <a href="http://card.topfo.com/<%#this.SelHtmlFile(Convert.ToString(Eval("HtmlFile"))) %>" target="_blank"> <%#Eval("CompanyName")%></a>
                        </td>            
                        <td  align="center">
                              <%#Eval("IndustryName")%>
                        </td>               
                         <td  align="center">
                               <%#Eval("RangeName")%>
                          </td>
                         <td align="center">
                              <%#Eval("NatureName") %>
                        </td>            
                        <td  align="center">
                              <%#this.PublishT(Convert.ToString(Eval("CreateDate"))) %>
                        </td>               
                         <td  align="center">
                             <%#Eval("LoginName") %>
                         </td>
                         <td  align="center">
                             <%#this.make(Convert.ToInt32(Eval("Ismake"))) %>
                         </td>
                         <td align="center">
                             <%#this.SelStatus(Convert.ToString(Eval("AuditingStatus")))%>
                        </td>            
                        <td  align="center">
                            <a href='JavaScript:Modfiy(<%#Eval("CompanyID") %>,0)'>审核</a>&nbsp &nbsp
                            <a href='JavaScript:Modfiy(<%#Eval("CompanyID") %>,1)' onclick= "if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>  
                        </td>               
                          
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="pagebox">

            <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center"  >
                <tr>
                    <td style="width: 20%;" align="left">
                    共<span id="pinfo" style="color:Red" runat="server"></span>个数据
                    </td>
                    <td style="width:80%">
                    <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO"  Width="479px">
                                </cc1:AspNetPager>
                    </td>
                </tr>
            </table>
                
        </div>
    </div>
    <%--<input id="btnProall" type="button" class="btn" value="批量生成" />--%>
    <div class="pagebox">
    <asp:Button runat="server" ID="btnSel" Text="批量生成" CssClass="btn" OnClick="btnSel_Click" />
    &nbsp &nbsp
    <asp:Button runat="server" ID="btnAll" Text="全部生成" CssClass="btn" OnClick="btnAll_Click" />
    </div>
    </form>
</body>
</html>

