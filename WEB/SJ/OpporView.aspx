<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpporView.aspx.cs" Inherits="SJ_OpporView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>商机信息</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
    <script type="text/javascript" language="javascript">
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
    url="OpporStatus.aspx?fid="+fid;
    window.location.href=url;
    }
    else
    {
     var url="";
    url="OpporStatus.aspx?fid="+fid+"&infoID="+infoId;
    window.location.href=url;
    }
    
}

function DelNav(id)
{
    var url="";
    url="OpporView.aspx?fID="+id;
    window.location.href = url;
}

function DelPart()
{

   document.getElementById("divPart").style.display="block";
}

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

    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="mainconbox">

       <div>
          
        </div>
        <div class=" cshibiank">
        
            <table width="100%" border="0" align="center" class="one_table"  cellpadding="0" cellspacing="0">
                <tr>
                    <th width="10%" align="center"  style="height: 32px">
                        <a href="Javascript:SelectAll();">全选</a>/<a
                    href="Javascript:ReSelect();">反选</a></th>
                    <th width="8%" align="center" class="tabtitle" style="height: 32px">
                        编号                    </th>
                    <th width="24%" align="center" class="tabtitle" style="height: 32px">
                        商机名称                    </th>
                     <th width="10%" align="center" class="tabtitle" style="height: 32px">
                       所属行业                   </th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        状态                   </th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        发布人</th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                    发布日期</th>
                    <th width="15%" align="center" class="tabtitle" style="height: 32px">
                        管理
                    </th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <label>
                                    <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#this.StrLength(Eval("InfoID"))%>" />
                                </label>
                            </td>
                            <td align="center">
                                <%#(Eval("InfoID"))%>
                            </td>
                             <td align="center">
                              <a href="http://ss.topfo.com/<%#Eval("HtmlFile") %>" target="_blank" title="<%#Eval("Title") %>">
                                <%#this.StrLength(Eval("Title"))%>
                            </td>
                            <td align="center">
                                <%#this.industyName(Convert.ToInt32(Eval("IndustryOpportunityID")))%></a>
                          </td>
                            <td align="center">
                                <%#this.Verify(Convert.ToInt32(Eval("AuditingStatus")))%></a>
                          </td>
                            <td>
                            <%#Eval("LoginName") %>
                          </td>
                             <td align="center">
                              <label title="<%#this.GetValiditeInfo(Eval("InfoOverdueTime")) %>">
                                <%#Convert.ToDateTime(Eval("PublishT")).ToString("yyyy-MM-dd") %>
                                </label>
                          </td>
                            <td align="center">
                            
                            <a href='JavaScript:modifyNavigate("status","<%#Eval("InfoID") %>");'>审核</a>

                           <a href='JavaScript:DelNav("<%#Eval("InfoID") %>");' onclick= "if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                            </td>
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
                
            <div class="clear">
            <asp:Button runat="server" ID="btnAll" CssClass="btn" Text="全部生成" OnClick="btnAll_Click"  />
              &nbsp; 
             <asp:Button runat="server"   ID="btnStatic" CssClass="btn" Text="批量生成" OnClick="btnStatic_Click"  />
            
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<input id="btnAdd" class="btn" runat="server" onclick="modifyNavigate('insert','');"
                    type="button" value="添加" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                
                
                <asp:Button ID="btnDelPart" runat="server" CssClass="btn" Text="批量删除" OnClick="btnDelPart_Click"  /></div>
            <div style="display:block" id="divPart">
                按编号生成:
             <input runat="server" id="begInfo" onkeyup="value=value.replace(/[^0-9]/g,'')" onblur="value=value.replace(/[^0-9]/g,'')"  style="width: 121px"  />--
            <input  runat="server" id="endInfo" onkeyup="value=value.replace(/[^0-9]/g,'')" onblur="value=value.replace(/[^0-9]/g,'')"  style="width: 112px"/>
            <asp:Button runat="server" ID="btnShare" CssClass="btn" Text="生成"  OnClientClick="return SelPart();" OnClick="btnShare_Click" />
            </div>
           
        </div>
    </div>
    
    </form>
</body>
</html>
