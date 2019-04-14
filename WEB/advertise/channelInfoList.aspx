<%@ Page Language="C#" AutoEventWireup="true" CodeFile="channelInfoList.aspx.cs" Inherits="advertise_channelInfoList" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
     function modifyAchannelInfoID(fid,infoId)
{
    if(infoId=="")
    {
    var url="";
    url="UpdateAchannelInfo.aspx?id="+fid;
    window.location.href=url;
    }
    else
    {
     var url="";
    url="UpdateAchannelInfo.aspx?id="+fid+"&infoID="+infoId;
    window.location.href=url;
    }
    
}
   function modifyAchannelInfo(fid,infoId)
{
    if(infoId=="")
    {
    var url="";
    url="ADMessageInfo.aspx?id="+fid;
    window.location.href=url;
    }
    else
    {
     var url="";
    url="ADMessageInfo.aspx?id="+fid+"&infoID="+infoId;
    window.location.href=url;
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
                        <span><b>频道管理</b></span></p>
                </h2>
                <h2>
                    <p>
                        <span><b><a href="AddchannelInfo.aspx">添加频道信息</a></b></span></p>
                </h2>
            </div>
          <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr  style="background:#bcd9e7; height:27px;">
                  <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                            频道编号</th>
                    <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                       
                            频道名称</th>
                        <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                             操作管理</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >                
                        <td style="width: 100px" align="center">
                        <%#Eval("BID")%>
                             </td>             
                            <td style="width: 100px" align="center">
                                <%#Eval("BName")%>
                            </td>                           
                               <td style="width: 100px" align="center">
                            <asp:LinkButton ID="lbdel" CommandArgument='<%#Eval("BID")%>' CommandName="del"  runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton>
                             <a href='JavaScript:modifyAchannelInfoID("status","<%#Eval("BID") %>");'>修改</a>
                              <a href='JavaScript:modifyAchannelInfo("Message","<%#Eval("BID") %>");'>广告</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
               <td style="text-align:right; width: 348px;">
             <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="20">
                                </cc1:AspNetPager>&nbsp;</td>
                  <td style="text-align: left; width: 74px;" >
                                <span id="pinfo" runat="server"></span>&nbsp;</td>
        </div>
      
    </form>
</body>
</html>
