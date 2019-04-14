<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADlaunchInfoList.aspx.cs" Inherits="advertise_ADlaunchInfoList" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
     
 function modifyAchannelInfo(fid,infoId)
{
    if(infoId=="")
    {
    var url="";
    url="UpdateADlaunchInfo.aspx?id="+fid;
    window.location.href=url;
    }
    else
    {
     var url="";
    url="UpdateADlaunchInfo.aspx?id="+fid+"&infoID="+infoId;
    window.location.href=url;
    }
    
}
function modifyAchannelInfoA(fid,infoId)
{
    if(infoId=="")
    {
    var url="";
    url="AdvisitInfoList.aspx?id="+fid;
    window.location.href=url;
    }
    else
    {
     var url="";
    url="AdvisitInfoList.aspx?id="+fid+"&infoID="+infoId;
    window.location.href=url;
    }
    
}
function BtnSel()
{
   var url="";
   url="ADMessageInfo.aspx";
   window.location.href=url;
}
     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>广告主管理</b></span></p>
                </h2>
           
            </div>
                 <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>
        <td align="center" style="height: 24px" colspan="4">
            广告主：
            <input id="txtNuber"  style="width:100px;" type="text"  runat="server" /><asp:Button ID="btnSearch"  CssClass="btn"  runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
            </td>
    </tr>
    </table>
          <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr  style="background:#bcd9e7; height:27px;">
                <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                            编号</th>
                  <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                            广告主</th>
                               <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                            广告名称</th>
                               <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                            频道名称</th>
                            <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                            开始日期</th>
                            <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                            结束日期</th>
                            <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                            赠送日期</th>
                            <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                            访问数量</th>
                        <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                             操作管理</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >     
                         <td style="width: 100px" align="center">
                        <%#Eval("advertiserID")%>
                        </td>             
                        <td style="width: 100px" align="center">
                        <%#Eval("LoginName")%>
                        </td>   
                        <td style="width: 100px" align="center">
                          <%#this.TypeName(Convert.ToInt32(Eval("positionID")))%>
                        </td>   
                        <td style="width: 100px" align="center">
                        <%#this.ADName(Convert.ToInt32(Eval("BID")))%>
                        </td>             
                        <td style="width: 100px" align="center">
                               <%#Convert.ToDateTime(Eval("Stardate")).ToString("yyyy-MM-dd")%>


                        </td>
                        <td style="width: 100px" align="center">
                            <%#Convert.ToDateTime(Eval("enddate")).ToString("yyyy-MM-dd")%>
                            
                        </td>
                        <td style="width: 100px" align="center">
                             <%#Convert.ToDateTime(Eval("Givindate")).ToString("yyyy-MM-dd")%>
                           
                        </td>
                        <td style="width: 100px" align="center">
                            <%#Eval("countID")%>
                        </td>                           
                               <td style="width: 100px" align="center">
                            <asp:LinkButton ID="lbdel" CommandArgument='<%#Eval("advertiserID")%>' CommandName="del"  runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton>
                             <a href='JavaScript:modifyAchannelInfo("status","<%#Eval("advertiserID") %>");'>修改</a>
                              <a href='JavaScript:modifyAchannelInfoA("Message","<%#Eval("advertiserID") %>");'>访问量</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater> 
            </table>
               <td style="text-align:right; width: 348px;">
             <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="10">
                                </cc1:AspNetPager>&nbsp;</td>
                  <td style="text-align: left; width: 74px;" >
                                <span id="pinfo" runat="server"></span>&nbsp;</td>
        </div>
          <input type="button" id="btncc" class="btn" value="返回" onclick="BtnSel();" />
    </form>
</body>
</html>
