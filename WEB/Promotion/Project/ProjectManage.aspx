<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectManage.aspx.cs" Inherits="Project_ProjectManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>融资资源管理</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
     <script language="javascript" src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
     <script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
    <script language="javascript" type="text/javascript">
    function SelPart()
{
  var beg=document.getElementById("begInfo").value;
  var end=document.getElementById("endInfo").value;
  if(beg=="")
  {
      alert("请输入起始编号");
      document.getElementById("begInfo").focus();
      return false;
  }
  if(end=="")
  {
      alert("请输入结束编号");
      document.getElementById("endInfo").focus();
      return false;
  } 
  if(parseInt(beg) >parseInt(end))
  {
      alert("您输入的起始编号不能大于结束编号");
      document.getElementById("begInfo").value="";
      document.getElementById("endInfo").value="";
      document.getElementById("begInfo").focus();
      return false;
  }
}
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
function Fun()
{
  document.getElementById("imgLoding").style.display="block";
  }

function Sel(info,id)
{
  if(id==9)
  {
  var url;
  url="Project_ZQ.aspx?id="+info;
  window.location.href=url;
  }else if(id==10)
  {
   var url;
  url="Project_GQ.aspx?id="+info;
  window.location.href=url;
  }
}
function recommNavigate(infoID)
{
    if(infoID!="")
    {
    var url="";
    url="../MerchantManage/RecommResource.aspx?typeId=1&infoID="+infoID;
    window.location.href=url;
    }
}
function Del(info)
{
  var url;
  url="ProjectManage.aspx?id="+info;
  window.location.href=url;
}

function bianhao()
{
  $("#haoma").toggle()
}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainconbox">

       <div class="title" id="cc" runat="server" align="center">
             <h2><p><span><b>融资频道管理</b></span></p></h2>
             </div>
             <table width="100%" border="0" align="center" class="one_table"  cellpadding="0" cellspacing="0">
                <tr width="100%">
                    <td style="width: 477px">时间：
                        
                        <input runat="server" id="txtBeginTime" onClick="WdatePicker({lang:'zh-cn'})"/>
                        <img onclick="WdatePicker({el:$dp.$('txtBeginTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                        -
                        <input id="txtEndTime" runat="server" onClick="WdatePicker({lang:'zh-cn'})" />
                        <img onclick="WdatePicker({el:$dp.$('txtEndTime')})" src="../My97DatePicker/skin/datePicker.gif" align="absmiddle" style="cursor:pointer" />
                        </td>
                        <td style="width: 210px" >
                        用户名:<input type="text"  runat="server" id="btnName" />
                        </td>
                        <td >
                         融资状态:<asp:DropDownList ID="rblrz" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" runat="server">
                        <asp:ListItem Value="1000">请选择</asp:ListItem>
                        <asp:ListItem Value="9">债券融资</asp:ListItem>
                        <asp:ListItem Value="10">股权融资</asp:ListItem>
                    </asp:DropDownList>
                        </td>
                    
                </tr>
                <tr width="100%">
                    <td style="width: 477px">编号：
                        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                        标题：<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
                    <td style="width: 210px">审核状态：
                    <asp:DropDownList ID="rblStatus" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" runat="server">
                        <asp:ListItem Value="1000">请选择</asp:ListItem>
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                        <asp:ListItem Value="1">审核通过</asp:ListItem>
                        <asp:ListItem Value="2">审核未通过</asp:ListItem>
                    </asp:DropDownList>
                        </td>
                    <td width="30%">
                    <asp:Button runat="server" ID="btnSel" CssClass="btn" Text="查询" OnClick="btnSel_Click" />
                    </td>
                    
                </tr>
            </table>
         <table width="100%" border="0" align="center" cellpadding="1" class="one_table" cellspacing="1">
            <tr>
                <th width="6%" align="center" class="tabtitle" style="height: 29px">
                    <a href="Javascript:SelectAll();">全</a>|<a href="Javascript:ReSelect();">反</a>
                </th>
                <th width="6%" align="center" class="tabtitle" style="height: 29px">
                    ID
                </th>
                <th width="20%" align="center" class="tabtitle" style="height: 29px">
                    标题
                </th >
                
                <th width="7%" align="center" class="tabtitle" style="height: 29px">
                类型
                </th>
                <th width="6%" align="center" class="tabtitle" style="height: 29px">
                    价格
                </th>
                <th width="10%" align="center" class="tabtitle" style="height: 29px">
                    发布人
                </th>
                <th width="15%" align="center" class="tabtitle" style="height: 29px">
                    发布时间</th>
                <th width="10%" align="center" class="tabtitle" style="height: 29px">
                    状态</th>
                <th align="center" class="tabtitle" style="height: 29px; width: 8%;">
                    管理
                </th>
            </tr>
            <asp:Repeater ID="RfList"  runat="server">
                <ItemTemplate>
                    <tr >
                        <td align="center" >
                            <label>
                                <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("InfoID") %>" />
                            </label>
                        </td>
                        <td align="center" >
                            <label>
                                <%#Eval("InfoID") %>
                                
                             
                            </label>
                        </td>
                        <td align="left" >
                           <a href="http://www.topfo.com/<%#Eval("HtmlFile") %>" target="_blank"> <%#this.StrLength(Eval("ProjectName"))%>   <%#this.InfoOriginRoleName(Convert.ToString(Eval("InfoOriginRoleName")))%></a>
                        </td>
                        <td align="center">
                           <%#this.DemType(Convert.ToInt32(Eval("CooperationDemandType")))%>
                        </td>
                        <td align="center" >
                            <label>
                                <%#Eval("MainPointCount")%>
                            </label>
                        </td>
                        <td align="center" >
                            <%#Eval("LoginName") %>
                        </td>
                        <td align="center" >
                            <label title="<%#this.GetValiditeInfo(Eval("InfoOverdueTime")) %>">
                                <%#Convert.ToDateTime(Eval("PublishT")).ToString("yyyy-MM-dd(hh:mm)") %>
                            </label>
                        </td>
                        <td align="center" >
                           <%#this.Verify(Convert.ToInt32(Eval("AuditingStatus")))%>
                        </td>
                        <td align="center">
                            <a href='JavaScript:Sel(<%#(Eval("InfoID")).ToString().Trim() %>,<%#(Eval("CooperationDemandType")).ToString().Trim() %>)'>审核</a> 
                         <a href='JavaScript:recommNavigate("<%#Eval("InfoID") %>");'><%#getStatu(Convert.ToInt32(Eval("AuditingStatus")))%></a>
                         <asp:LinkButton ID="lbdel" CommandArgument='<%#Eval("InfoID")%>' CommandName="del"  runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton>    </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        </div>
        <div class="pagebox">

            <table width="100%" border="0" align="center" cellpadding="0" class="one_table" cellspacing="0">
            <tr>
            <td width="30%" style="height: 28px"><asp:Button ID="btnBatch" runat="server" OnClientClick="return Fun();" CssClass="btn" Text="批量生成" OnClick="btnBatch_Click" />
                &nbsp; &nbsp;&nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn" OnClientClick="return Fun();" Text="批量删除" OnClick="BtnDelete_Click"  />&nbsp;
            <asp:Button ID="btnAll" runat="server" CssClass="btn" OnClientClick="return Fun();" Text="全部生成" OnClick="btnAll_Click" /></td>
            <td width="100%" style="text-align:right; height: 28px;"><cc1:Pager ID="Pager1" runat="server" BackColor="Transparent" BorderStyle="None"
                PagerStyle="CustomAndNumeric" ControlToPaginate="RfList" PagingMode="NonCached"
                UseCustomDataSource="false" ShowCount="True" SortColumn="PublishT" SortType="DESC"
                TableViewName="MainInfoVIW" KeyColumn="InfoID"
                ShowPageCount="False"></cc1:Pager></td>
            </tr>
                <tr>
                    <td colspan="2" style="height: 28px">
                        招商首页生成：<asp:TextBox ID="txtIndex" runat="server" Width="226px">http://rz.topfo.com/index.aspx</asp:TextBox>&nbsp;
   <asp:Button ID="btnIndexStatic"  CssClass="btn"  OnClientClick="return Fun();" runat="server" Text=" 生成" OnClick="btnIndexStatic_Click" /></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 28px">
                       按编号生成:
             <input runat="server" id="begInfo" onkeyup="value=value.replace(/[^0-9]/g,'')" onblur="value=value.replace(/[^0-9]/g,'')"  style="width: 121px"  />--
            <input  runat="server" id="endInfo" onkeyup="value=value.replace(/[^0-9]/g,'')" onblur="value=value.replace(/[^0-9]/g,'')"  style="width: 112px"/>
            <asp:Button runat="server" ID="btnShare" CssClass="btn" Text="生成"  OnClientClick="return SelPart();"  OnClick="btnShare_Click"/><br />
                    </td>
                </tr>
            <tr>
         
            
            </tr>
            </table>
            
           <br />
                
        </div>
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
    </form>
</body>
</html>
