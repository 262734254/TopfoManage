<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberAddRole.aspx.cs" Inherits="System_MemberAddRole" %>
<%@ Register Src="../UserControl/RoleControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加用户角色</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="../css/style1.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="title"><h2><p><span><b>
               添加用户角色</b></span></p></h2></div>
                <table border="0" cellpadding="0" cellspacing="0" class="one_table" style="width: 612px; height: 124px">
                <tr>
                 <td style="width: 23%" align="center">添加角色：</td>
                  
                  <td align="left"  valign="middle">
                   <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server"/> </td>
                  
              </tr>
               <tr>
         <td style="width: 23%" align="center"> &nbsp;&nbsp;&nbsp;&nbsp;</td>
        
           <td align="left"  style="text-align:center;">
            <asp:Button ID="Modify_btn" runat="server" CssClass="btn" Text="修 改" OnClick="Modify_btn_Click"   />
               <asp:Button ID="re_btn" runat="server" CssClass="btn" Text="取消/返回" OnClick="re_btn_Click" />
          </td>
          </tr>
          
                </table>
    
    </div>
    </form>
</body>
</html>
