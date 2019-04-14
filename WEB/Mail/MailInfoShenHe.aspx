<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailInfoShenHe.aspx.cs" Inherits="Mail_MailInfoShenHe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加用户页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />

    <script src="../js/JScriptloans.js" type="text/javascript" language="javascript"></script>

    <script type="text/javascript" language="javascript">
           function postnewtabs()
   {
     var s=document.getElementById("txtMail").value;
  if(document.getElementById ("txtUserName").value.length==0)
   {
     document.getElementById ("showtxtnewsTitle").innerHTML="*";
     document.getElementById ("showtxtnewsTitle").style .display ="inline";
     document.getElementById ("txtUserName").focus();
     return false;
   }
     if(document.getElementById ("txtPanyName").value.length==0)
   {
     document.getElementById ("showpany").innerHTML="*";
     document.getElementById ("showpany").style .display ="inline";
     document.getElementById ("txtPanyName").focus();
     return false;
   }
    if(s.length!=0)
{
   if((s.charAt(0)=="@")||(s.charAt(0)=="."))
	   { 
	   	document.getElementById ("showMail").innerHTML="电子邮件的格式不能以@或者.开头!";
        document .getElementById ("showMail").style.display ="inline";
        document.getElementById ("txtMail").focus();
		return false;
	   }
//	  if(s.length==0)
//         {
//		 document.getElementById ("showMail").innerHTML="*";
//          document .getElementById ("showMail").style.display ="inline";
//          document.getElementById ("txtMail").focus();
//		 return false;
//		 }
	  if(s.indexOf("@",0)==-1)
	     {
	      document.getElementById ("showMail").innerHTML="电子邮件格式不正确\n必须包含@符号!";
          document .getElementById ("showMail").style.display ="inline";
          document.getElementById ("txtMail").focus();
		  return false;
	     }
	if(s.indexOf(".",0)==-1)
	  {
	  document.getElementById ("showMail").innerHTML="电子邮件格式不正确\n必须包含.符号!";
      document .getElementById ("showMail").style.display ="inline";
      document.getElementById ("txtMail").focus();
	  return false;
	  }
	if(escape(s).indexOf("%u")!=-1)
      {
      document.getElementById ("showMail").innerHTML="邮件中不能包含汉字";
      document .getElementById ("showMail").style.display ="inline";
      document.getElementById ("txtMail").focus();
      return false ;
}	
    }
//     if(document.getElementById ("txtMoblie").value.length==0)
//   {
//     document.getElementById ("showMoblie").innerHTML="*";
//     document.getElementById ("showMoblie").style .display ="inline";
//      document.getElementById ("txtMoblie").focus();
//     return false;
//   }
      if(document.getElementById ("txtMoblie").value.length>0&&document.getElementById ("txtMoblie").value.length<11)
   {
     document.getElementById ("showMoblie").innerHTML="手机号码填写不正确";
     document.getElementById ("showMoblie").style .display ="inline";
     document.getElementById ("txtMoblie").focus();
     return false;
   }    

      if(document.getElementById ("txtLinkUrl").value.length>0)
      {
         var siteStr = document.getElementById("<%=txtLinkUrl.ClientID %>").value;           var siteStrs=/(\w+):\/\/([^/:]+)(:\d*)?([^# ]*)/;              if(!siteStrs.test(siteStr))
              {  
                  document.getElementById ("showLinkUrl").innerHTML="请输入正确的网站";
                  document.getElementById ("showLinkUrl").style .display ="inline";
                  document.getElementById("<%=txtLinkUrl.ClientID %>").focus();
                  return false;
              }
              }
   else
   {
    document.getElementById ("imgLoding").style .display ="";
    return true;
}
}
    </script>

</head>
<body>
    <form id="form1" runat="server" action="">
        <div>
            <div class="title">
                <h2>
                    <p>
                        <span><b>用户审核</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <th colspan="2">
                        <div align="center">
                            用户信息审核</div>
                    </th>
                </tr>
                <tr>
                    <td>
                        <span style="color: Red">*</span>用户名称：</td>
                    <td>
                        <asp:TextBox ID="txtUserName" onblur="outpostcode(this,'showtxtnewsTitle')" runat="server"
                            Width="278px"></asp:TextBox>&nbsp;<div id="showtxtnewsTitle" style="display: none;
                                color: Red; font-size: 12px">
                                *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span style="color: Red">*</span>公司名称：</td>
                    <td>
                        <asp:TextBox ID="txtPanyName" onblur="outpostcode(this,'showpany')" runat="server"
                            Width="278px"></asp:TextBox>&nbsp;<div id="showpany" style="display: none; color: Red;
                                font-size: 12px">
                                *</div>
                    </td>
                </tr>
                <tr>
                    <td style="height: 22px">
                        <span style="color: Red">*</span>地域：</td>
                    <td style="height: 22px">
                        <asp:DropDownList ID="ddrprovice" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddrprovice_SelectedIndexChanged">
                        </asp:DropDownList>&nbsp
                        <asp:DropDownList ID="ddrcity" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span style="color: Red"></span>行业：</td>
                    <td>
                        <asp:DropDownList ID="ddrxingye" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        邮件：</td>
                    <td>
                        <asp:TextBox ID="txtMail" onblur="outemail(this,'showMail')" runat="server" Width="278px"></asp:TextBox>&nbsp;<div
                            id="showMail" style="display: none; color: Red; font-size: 12px">
                            </div>
                    </td>
                </tr>
                <tr>
                <td class="f_td">
                    <span class="f_red"></span>联系电话：</td>
                <td>
                    <input id="txtTelCountry" runat="server" type="text" size='4' value="+86" />
                    <input id="txtTelZoneCode" onkeyup="value=value.replace(/[^0-9]/g,'')" runat="server"
                        type="text" size='7' />
                    <input id="txtTelNumber" onkeyup="value=value.replace(/[^0-9]/g,'')" runat="server"
                        type="text" size='18' />
                    <span id="spTel"></span>
                </td>
            </tr>
                <tr>
                    <td>
                       手机：</td>
                    <td>
                        <asp:TextBox ID="txtMoblie" onblur="outphone(this,'showMoblie')" onkeyup="value=value.replace(/[^\d]/g,'') "
                            MaxLength="11" runat="server" Width="278px"></asp:TextBox>&nbsp;<div id="showMoblie"
                                style="display: none; color: Red; font-size: 12px">
                                *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span style="color: Red"></span>地址：</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" Width="278px"></asp:TextBox>&nbsp;<div
                            id="showAddress" style="display: none; color: Red; font-size: 12px">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span style="color: Red"></span>网址：</td>
                    <td>
                        <asp:TextBox ID="txtLinkUrl" runat="server" Width="278px"></asp:TextBox>&nbsp;<div
                            id="showLinkUrl" style="display: none; color: Red; font-size: 12px">
                            *</div>
                        （如：http://www.topfo.com）</td>
                </tr>
                <tr>
                    <td>
                        <span style="color: Red"></span>职位：</td>
                    <td>
                        <asp:DropDownList ID="ddrzhiwei" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <span style="color: Red"></span>组：</td>
                    <td>
                        <asp:DropDownList ID="ddrzu" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <span style="color: Red"></span>类型：</td>
                    <td>
                        <asp:DropDownList ID="ddrleixing" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span style="color: Red"></span>是否审核：</td>
                    <td>
                        <asp:RadioButtonList ID="radioaudit" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="0">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span style="color: Red"></span>说明：</td>
                    <td>
                        <asp:TextBox ID="txtDescript" runat="server" Height="180px" TextMode="MultiLine"
                            Width="528px"></asp:TextBox>&nbsp;<div id="showdescript" style="display: none; color: Red;
                                font-size: 12px">
                                *</div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnSave" runat="server" OnClientClick="return postnewtabs()" CssClass="btn"
                            Text="审 核" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;<input type="button" id="Button3" onclick="javascript:location.href='MailInfoManage.aspx'"
                            value="返 回" class="btn" /></td>
                </tr>
            </table>
        </div>
    </form>
    <%--    <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1135px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif"alt="Loading" />
                </div>
   </div>--%>
</body>
</html>
