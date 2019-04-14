<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateADlaunchInfo.aspx.cs" Inherits="advertise_UpdateADlaunchInfo" %>
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.DateTimeBox" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>修改广告主</title>
     <link href="../css/style.css" type="text/css" rel="stylesheet">
        <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
 <script language="javascript" type="text/javascript">
         
 
	function chkBtn()
	{

     if(document.getElementById("txtStardate").value=="")
               {              
                       alert("开始日期不能为空");
                        return false;
               }   
                      if(document.getElementById("txtenddate").value=="")
               {              
                       alert("结束日期不能为空");
                        return false;
                 }  
                      if(document.getElementById("txtGivindate").value=="")
               {              
                       alert("赠送日期不能为空");
                        return false;
                 }  
                 
	   if(document.getElementById("txtLoginName").value=="")
	   {
	       alert("请输入频道名称");
	       document.getElementById("txtLoginName").focus();
	       return false;
	   }
   }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title" align="center">
             <h2><p><span><b>广告主修改</b></span></p></h2>
             <h2><p><span><b><a href="ADlaunchInfoList.aspx">广告主管理</a></b></span></p></h2>
             </div>
    <div>
      <table style="border-color:#678897; border-style:solid;  border-collapse:collapse; height:180px; "
					borderColor="#004f71" cellSpacing="0" cellPadding="3" border="1" align="center" class="">
                <tr><td style="height: 43px; width: 120px;" >
                    广告主：</td><td style="height: 43px" >
                    <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox></td></tr>
          <tr>
              <td style="height: 43px; width: 120px;" >
                  
                      开始日期：</td>
              <td style="height: 43px" >
                  <cc1:DateTimeBox ID="txtStardate" runat="server"></cc1:DateTimeBox></td>
          </tr>
          <tr>
              <td style="height: 43px; width: 120px;" >
                  
                      结束日期：</td>
             <td style="height: 43px" >
                  <cc1:DateTimeBox ID="txtenddate" runat="server"></cc1:DateTimeBox></td>
          </tr>
          <tr>
             <td style="height: 43px; width: 120px;" >
 
                 
                      赠送日期：</td>
           <td style="height: 43px" >
                  <cc1:DateTimeBox ID="txtGivindate" runat="server"></cc1:DateTimeBox></td>
          </tr>
          <tr>
              <td style="height: 43px; width: 120px;" >
                
                      业务员 ：</td>
             <td style="height: 43px" >
                  <asp:TextBox ID="txtsalesman" runat="server"></asp:TextBox></td>
          </tr>
                <tr><td style="width: 120px" >备注：</td><td >
                    <textarea id="txtDoc" runat="server" ></textarea></td></tr>
          <tr>
              <td style="width: 120px; height: 22px">
                  访问量：</td>
              <td style="height: 22px">
                  <asp:TextBox ID="txtCount" runat="server"></asp:TextBox></td>
          </tr>
                <tr><td style="width: 120px; height: 31px;" >&nbsp;</td><td style="width: 357px; height: 31px;">
                    <asp:Button ID="btnAdd" runat="server" Text="确认修改"    OnClientClick="return chkBtn();" OnClick="BtnAdd_Click" CssClass="btn" /></td></tr>
                </table>
    </div>
    </form>
</body>
</html>
