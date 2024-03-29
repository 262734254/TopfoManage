﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarveOutList.aspx.cs" Inherits="CarveNews_CarveOutList" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>创业信息</title>
       <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
         <script type="text/javascript"  src="../js/Common.js"></script>
         <script type="text/javascript" src="../js/CheckAll.js"></script>
         	<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:30px;}
        .content p{line-height:30px;        }
        
    </style>  
                    <script type="text/javascript">

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

function modifyNavigate(fid,infoId)
{
    if(infoId=="")
    {
    var url="";
    url="UpdateNews.aspx?fid="+fid;
    window.location.href=url;
    }
    else
    {
     var url="";
    url="UpdateCarveOut.aspx?fid="+fid+"&infoID="+infoId;
    window.location.href=url;
    }
    
}

function DelNav(id)
{
    var url="";
    url="CarveOutList.aspx?fID="+id;
    window.location.href = url;
}

function DelPart()
{

   document.getElementById("divPart").style.display="block";
}
function Fun()
{
  document.getElementById("imgLoding").style.display="block";
  
}


 </script>

</head>
<body>
     <form id="form1" runat="server">
    <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>创业信息列表</b></span></p>
                </h2>
            </div>
             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>
        <td align="center" style="height: 24px">编号：
            <input id="txtNuber"  style="width:100px;" type="text"  runat="server" /></td>
        
        <td  align="center" style="height: 24px">
            类型：
            <asp:DropDownList ID="ddlCarveOutInfoType"   runat="server" >
             <asp:ListItem Value="5">全部类型</asp:ListItem>
                <asp:ListItem Value="0">项目找资金</asp:ListItem>
                <asp:ListItem Value="1">资金找项目</asp:ListItem>
      </asp:DropDownList></td>
       
        <td align="center" style="height: 24px">状态：
            <asp:DropDownList ID="ddlStatus" runat="server">
                 <asp:ListItem Value="5">全部状态</asp:ListItem>
                <asp:ListItem Value="2">审核未通过</asp:ListItem>
                <asp:ListItem Value="1">审核通过</asp:ListItem>
                <asp:ListItem Value="0">未审核</asp:ListItem>
            </asp:DropDownList></td>
        <td   align="center" style="height: 24px">
            <asp:Button ID="btnSearch"  CssClass="btn" OnClientClick="return Fun();" runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
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
                            创业标题</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        类型</th>
                         <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        状态</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        发布日期</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        发布人</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        管理</th>
                       
                </tr>
                <asp:Repeater ID="NewsList" runat="server">
                    <ItemTemplate>
                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >
                        <td style="width: 100px">
                          <label>
                                <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("InfoID")%>" />
                       
                          </label>
                           </td>
                            
                            <td style="width: 100px">
                                <%#(Eval("InfoID"))%>
                       
                            <td style="width: 100px">
                           <a href="http://cr.topfo.com/<%#Eval("HtmlFile") %>" target="_blank" title="<%#Eval("Title") %>">
                                <%#StrLength(Eval("Title"))%>

                            </td>
                            <td style="width: 100px">

                              <%#this.InfoType(Convert.ToInt32(Eval("CarveOutInfoType")))%>
                            </td>
                            <td style="width: 100px">
                               <%#this.Verify(Convert.ToInt32(Eval("AuditingStatus")))%>
                            </td>
                               <td style="width: 100px">
                               <%#Eval("publishT","{0:yyyy-MM-dd}")%>
                            </td>
                               <td style="width: 100px">
                               <%#Eval("LoginName")%>
                            </td>
                               <td style="width: 100px">
                                   
                            <a href='JavaScript:modifyNavigate("status","<%#Eval("InfoID") %>");'>审核</a>

                           <a href='JavaScript:DelNav("<%#Eval("InfoID") %>");' onclick= "if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                            </td>
                         
                        </tr>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
            <tr>
                <th align="center"  colspan="3" style="height: 32px">
                     <a href="Javascript:SelectAll();">全选</a>/<a
                    href="Javascript:ReSelect();">反选</a>&nbsp;将选中的资讯<asp:Button ID="Button1" runat="server"
                        OnClick="Button1_Click" Text="删除"   CssClass="btn" />
        <asp:Button ID="btnStatic" runat="server" OnClientClick="return Fun();" CssClass="btn" OnClick="btnStatic_Click"
            Text="批量生成" /></th>
                <th align="center" class="tabtitle" colspan="5" style="height: 32px">
                       共搜索到<span style="color:red;"><%=AspNetPager.RecordCount%></span>条，共<span style="color:red;"><%=AspNetPager.PageCount%></span>
                     每页显示<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem Selected="True">15</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>条记录
            <asp:DropDownList ID="ddlTypea"  runat="server">
            <asp:ListItem Value="0">项目找资金</asp:ListItem>
                <asp:ListItem Value="1">资金找项目</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnType" runat="server" OnClientClick="return Fun();" Text="类型生成" CssClass="btn" OnClick="btnType_Click"  />
                </th>
            </tr>
            <tr>
                <th align="center"  colspan="8" style="height: 32px">
                <cc1:AspNetPager ID="AspNetPager" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" CssClass="anpager" OnPageChanged="AspNetPager_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="2">
                                </cc1:AspNetPager>
                </th>
            </tr>
        </table>
 
    </form>
    <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1000px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif"alt="Loading" />
                </div>
   </div>
</body>
</html>
