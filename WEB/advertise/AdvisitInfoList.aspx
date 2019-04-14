<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdvisitInfoList.aspx.cs" Inherits="advertise_AdvisitInfoList" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
    url="ADlaunchInfoList.aspx?id="+fid;
    window.location.href=url;
    }
    else
    {
     var url="";
    url="ADlaunchInfoList.aspx?id="+fid+"&infoID="+infoId;
    window.location.href=url;
    }
    
}

function BtnSel()
{
    var url;
    url="ADlaunchInfoList.aspx";
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
                        <span><b>广告访问量管理</b></span></p>
                </h2>
           
            </div>
      <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table" >
    <tr>
        <td align="center" style="height: 24px" colspan="4">
            访问帐号：
            <input id="txtNuber"  style="width:100px;" type="text"  runat="server" /><asp:Button ID="btnSearch"  CssClass="btn"  runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
            </td>
    </tr>
    </table>
          <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr >
                  <th align="center" width="20%" class="tabtitle" >
                            访问帐号</th>
                            <th align="center" width="60%" class="tabtitle">
                            访问日期</th>
                        <th align="center" width="20%" class="tabtitle" >
                             操作管理</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>
                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >             
                        <td width="20%" align="center">
                       <a href="SelLoginName.aspx?Login=<%#Eval("LoginID").ToString().Trim()%>"><%#Eval("LoginID")%></a>
                      
                        </td>            
                        <td style="width: 60%" align="center">
                               <%#Convert.ToDateTime(Eval("VDate")).ToString("yyyy-MM-dd hh:mm:ss")%>
                        </td>
                                             
                               <td style="width: 20%" align="center">
                            <asp:LinkButton ID="lbdel" CommandArgument='<%#Eval("visitID")%>' CommandName="del"  runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center"  >
                <tr>
                    <td style="width: 20%; height: 25px;" align="left">
                    共<span id="pinfo" style="color:Red" runat="server"></span>个访问者
                    </td>
                    <td style="width:80%; height: 25px;">
                    <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO" PageSize="10" Width="479px">
                                </cc1:AspNetPager>&nbsp;
                    </td>
                </tr>
            </table>
             
        </div>
      <input id="sss" type="button" class="btn" value="返回" onclick="BtnSel();" />
    </form>
</body>
</html>
