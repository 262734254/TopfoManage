<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertGroup.aspx.cs" Inherits="System_InsertGroup" %>

<%@ Register Src="../UserControl/RoleControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2"%>
    <%@ Register Src="../UserControl/MemberList.ascx" TagName="MemberList"
    TagPrefix="uc3"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
   
    <style type="text/css">
    
     ul{list-style-type:none; float:left; width:500px;height:300px; border:0px solid green;}
     ul li{float:left; margin:0px; margin-top:3px; width:600px; height:30px;}
     
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div >
             <div class="title"><h2><p><span><b>
               添加组</b></span></p></h2></div>
              <table border="0" cellpadding="0" cellspacing="0" class="one_table" style="width: 612px; height: 124px">
                <tr>
                 <td style="width: 23%" align="center">组名称：</td>
                  
                  <td align="left"  valign="middle">
              <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                 <td style="width: 23%" align="center">组描述：</td>
    
          <td align="left"  valign="middle">
         <textarea id="TxtSRDoc" runat="server" style="width: 240px; height: 100px"></textarea>
         </td>
          </tr>
          <tr>
                 <td style="width: 23%" align="center"> 角色：</td>
        
           <td align="left"  valign="middle">
           <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server"/>
        </td>
           </tr>
           <tr>
                 <td style="width: 23%" align="center"> 员工列表:</td>
                 
                <td>
              <uc3:MemberList ID="MemberList1" runat="server" /> </td>
        </tr>
        
        <tr>
         <td style="width: 23%" align="center"> &nbsp;&nbsp;&nbsp;&nbsp;</td>
        
           <td align="left"  style="text-align:center;">
       <asp:Button ID="Add_btn" runat="server"  CssClass="btn" Text="添 加" OnClick="Add_btn_Click" />
           
        <asp:Button ID="Button1" runat="server" Text="取消/返回" CssClass="btn" OnClick="Button1_Click" />
        </td>
          </tr>
          </table>
    </div>
    </form>
</body>
</html>
