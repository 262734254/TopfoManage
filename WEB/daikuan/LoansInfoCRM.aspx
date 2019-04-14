<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoansInfoCRM.aspx.cs" Inherits="daikuan_test" %>
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CRM管理贷款</title>
          <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
         <script type="text/javascript"  src="../js/Common.js"></script>
         <script type="text/javascript" src="../js/CheckAll.js"></script>
    <script type ="text/javascript" language ="javascript">
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

function DelNav(id)
{
    var url="";
    url="LoansInfoCRM.aspx?LoansInfoID="+id;
    window.location.href = url;
}

function shenhe(ithisid,idd)
{
  if(ithisid==0)
  {
      url="LoansShenHePerSon.aspx?str="+idd;
      window.location.href = url;
  }
  else if(ithisid==1)
  {
        url="LoansShenHeEnprise.aspx?str="+idd;
        window.location.href = url;
  }
}
    </script>
</head>
<body>
    <form id="form1" runat="server">

          <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>贷款信息列表</b></span></p>
                </h2>
            </div>
             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>
        <td align="center" style="height: 24px">编号：
            <input id="txtNuber"  style="width:100px;" type="text"  runat="server" /></td>
        
        <td  align="center" style="height: 24px; width: 122px;">
            类型：
            <asp:DropDownList ID="ddlType" runat="server" >
            <asp:ListItem Value ='2' Selected="True">请选择</asp:ListItem>
                <asp:ListItem Value="0">个人</asp:ListItem>
                <asp:ListItem Value="1">企业</asp:ListItem>
      </asp:DropDownList></td>
       
        <td align="center" style="height: 24px; width: 148px;">状态：
            <asp:DropDownList ID="ddlStatus" runat="server">
             <asp:ListItem Value ='2' Selected="True">请选择</asp:ListItem>
                <asp:ListItem Value="0">未审核</asp:ListItem>
                <asp:ListItem Value="1">审核已通过</asp:ListItem>
                <asp:ListItem Value="3">审核未通过</asp:ListItem>
                <asp:ListItem Value ="5">已删除</asp:ListItem>
            </asp:DropDownList></td>
                    <td  align="center" style="height: 24px">
            发布人：
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        <td   align="center" style="height: 24px">
            <asp:Button ID="btnSearch"  CssClass="btn"  runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
            </td>
    </tr>
    </table>
     <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr  style="background:#bcd9e7; height:27px;">
                     <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                        选择</th>
                      <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        编号</th>
                        <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        标题</th>
                         <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        状态</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        发布人</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        发布日期</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        管理</th>
                       
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >
                        <td style="width: 100px">
                          <label>
                                <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("LoansInfoID")%>" />
                       
                          </label>
                           </td>
                            
                            <td style="width: 100px">
                                        <%#(Eval("LoansInfoID"))%>
                       
                            <td style="width: 100px">
                                   <a href ="http://www.topfo.com/<%# Eval("Url") %>" target="_blank"><asp:Label ID="Label2" runat="server"  Text='<%#  FormatNull(Convert.ToString(Eval("LoansTitle")), 10) %>'></asp:Label></a>

                            </td>
                            <td style="width: 100px">

                                <asp:Label ID="labstatu" runat="server" Text='<%# GetStatu(Convert.ToInt32(Eval("AuditID"))) %>'></asp:Label>
                            </td>
                            <td style="width: 100px">
                               <%# Eval("LoginName")%>
                            </td>
                               <td style="width: 100px">
                                   <asp:Label ID="Label1" runat="server" Text='<%# GetTime(Convert.ToString(Eval("Loansdate"))) %>'></asp:Label> 
                            </td>
                               <td style="width: 100px">
                                   
                          <a href="javascript:shenhe(<%# Eval("BorrowingType") %>,<%#Eval("LoansInfoID") %>);">审核</a>

                           <a href='JavaScript:DelNav("<%#Eval("LoansInfoID") %>");' onclick= "if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                            </td>
                         
                        </tr>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br />
    <div class="pagebox" style ="text-align:left" >
         <a href="Javascript:SelectAll();">全选</a>/<a
                    href="Javascript:ReSelect();">反选</a>&nbsp;将选中的资讯<asp:Button ID="Button1" runat="server"
                        OnClick="Button1_Click" Text="删除"   CssClass="btn" />&nbsp;<asp:Button ID="btnpublic" CssClass ="btn" runat="server"
                            Text="批量生成" OnClick="btnpublic_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;  <div style="text-align:right">
            <cc1:Pager ID="Pager1" runat="server" BackColor="Transparent" BorderStyle="None"
                PagerStyle="CustomAndNumeric" ControlToPaginate="RfList" PagingMode="NonCached"
                UseCustomDataSource="False" ShowCount="True" SortColumn="PublishT" SortType="DESC"
                TableViewName="MainInfoVIW" KeyColumn="InfoID"
                ShowPageCount="False"></cc1:Pager>
                &nbsp;</div>
        </div>

</div>

 
    </form>
</body>
</html>
