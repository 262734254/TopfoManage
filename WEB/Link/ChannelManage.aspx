<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChannelManage.aspx.cs" Inherits="Link_ChannelManage" %>
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
            
          function Modfiy(id)
          {
             var url="ChannelExamine.aspx?ChannelId="+id;
             window.location.href=url;
          }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainconbox">

       <div class="title" align="center"><h2><p><span><b>频道管理</b></span></p></h2></div>
             <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
                <tr>
                    <td align="center" >
                        频道名称：
                        <input id="txtChannelName"   type="text"  runat="server" />
                        </td>
                        <td align="center" >
                        审核状态：
                        <asp:DropDownList runat="server" ID="Status">
                        <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                        <asp:ListItem Value="1">审核通过</asp:ListItem>
                        <asp:ListItem Value="2">审核未通过</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td>
                        <asp:Button runat="server" ID="ChannelSearch" CssClass="btn" Text="确定" OnClick="ChannelSearch_Click" />
                         </td>
                </tr>
            </table>
        <div class=" cshibiank">
        
          <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr >
                  <th width="6%" align="center" class="tabtitle" style="height: 29px">
                    <a href="Javascript:SelectAll();">全</a>|<a href="Javascript:ReSelect();">反</a> </th>
                            <th align="center" width="6%" class="tabtitle">序号</th>
                            <th align="center" width="12%" class="tabtitle" >频道名称</th>
                            <th align="center" width="10%" class="tabtitle" >审核状态</th>
                            <th align="center" width="15%" class="tabtitle" >备注</th>
                            <th align="center" width="12%" class="tabtitle" >管理</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                         <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >  
                         <td align="center" >
                            <label>
                                <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%# Eval("ChannelId") %>" />
                            </label>
                        </td>                      
                         <td align="center">
                              <%# Container.ItemIndex + 1 %>
                        </td>            
                        <td  align="center">
                              <%# Eval("ChannelName") %>
                        </td>               
                         <td  align="center">
                             <%# Eval("CheckId").ToString() == "0" ? "未审核" : "审核通过" %>
                         </td>
                         <td  align="center">
                             <%# (Eval("Remarks").ToString() == "") ? "&nbsp;" : Eval("Remarks")%>
                         </td>           
                        <td  align="center">
                            <a href='JavaScript:Modfiy(<%# Eval("ChannelId") %>)'>审核</a>&nbsp &nbsp
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
    <div>
           <input type="button" value="添加频道" class="btn" onclick="window.location.href='AddChannel.aspx';" />
           <input type="button" value="返回首页" class="btn" onclick="window.location.href='LinkManage.aspx';" />
        </div>
    </form>
</body>
</html>

