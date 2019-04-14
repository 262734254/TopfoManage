<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyShowAdd.aspx.cs" Inherits="Company_CompanyShowAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
    <title>无标题页</title>
    <style type="text/css"> 
.f_red{color:red}
.f_td{width:15%;background-color:#f7f7f7;
}
</style>
<script language="javascript" type="text/javascript">
 function Depath()
 {
       var rdlValiditeTermID = "<%=this.rbtValid.ClientID %>";//项目有效期
	    if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
        {
           alert("请选择有效期限！");
           return false;
        }
 }
 function GetCheckNum(checkobjectname)
    {
        var truei2 = 0;
        checkobject = document.getElementsByName(checkobjectname);
        var inum = checkobject.length;
        if (isNaN(inum))
        {
	        inum = 0;
        }
        for(i=0;i<inum;i++){
	        if (checkobject[i].checked == 1){
		        truei2 = truei2 + 1;
	        }
        }
        return truei2;
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="title" align="center">
             <h2><p><span><b><a href="SelCompanyShow.aspx">企业展厅管理</a></b></span></p></h2>
             <h2><p><span><b>审核企业展厅信息</b></span></p></h2>
             </div>
       <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>用户名：</td>
                    <td>
                        <span runat="server" id="spanName" class="f_red"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>对应类型：</td>
                    <td>
                        <span runat="server" id="spanType" class="f_red"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>有效期：</td>
                    <td>
                        <asp:RadioButtonList ID="rbtValid" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="3">3个月</asp:ListItem>
                            <asp:ListItem Value="6">半年</asp:ListItem>
                            <asp:ListItem Value="12">一年</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red"></span>电话号码：</td>
                    <td>
                        <input id="txtTelCountry" runat="server" type="text" size='4' value="+86" />
                        <input id="txtTelZoneCode" runat="server" type="text" size='7' />
                        <input id="txtTelNumber" runat="server" type="text" size='18' />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>手机号码：</td>
                    <td>
                        <input runat="server" id="txtMobile" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="height: 24px">
                        <span class="f_red">*</span>电子邮箱：</td>
                    <td style="height: 24px">
                        <input runat="server" id="txtEmail" type="text" />
                    </td>
                </tr>
                         <tr>
                    <td align="right" class="f_td">
                网页标题：
                </td>
                <td align="left" style="color: #000000; height: 24px;">
                 <asp:TextBox ID="txtWtitle" runat="server" Columns="50" Width="426px"></asp:TextBox>
                   </td>
            </tr>
            <tr style="color: #000000">
                    <td align="right" class="f_td">
                  网页关键字：
                </td>
                <td align="left" style="height: 24px">
                <asp:TextBox ID="txtKeord" runat="server" Columns="50" Width="427px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                                <td align="right" class="f_td">

                 网页描述：
                </td>
                <td align="left">
                 <asp:TextBox ID="txtDescript" runat="server" Columns="50" Width="426px"></asp:TextBox>
                    </td>
            </tr>
           <tr>
               <td align="right" class="f_td">
                   角色：</td>
               <td>
                   <asp:DropDownList ID="ddlRole" runat="server">
                   </asp:DropDownList></td>
           </tr>
                <tr>
                <td align="right" class="f_td">
                    审核：
                </td>
                <td>
                <asp:RadioButtonList id="rblAuditing" runat="server"   RepeatDirection="Horizontal" RepeatLayout="Flow">
	            <asp:ListItem Value="0" >未审核</asp:ListItem>
	            <asp:ListItem Value="1">审核通过</asp:ListItem>
	            <asp:ListItem Value="2">审核未通过</asp:ListItem>
               </asp:RadioButtonList> 
                </td>
                </tr>
             
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button runat="server" ID="btnStatus" Text="审 核" OnClientClick="return Depath();" CssClass="btn" OnClick="btnStatus_Click"  />
                        &nbsp &nbsp
                        <input type="button" class="btn" value="返 回" onclick="window.location.href='SelCompanyShow.aspx'" />
                    </td>
                </tr>
            </table>
            
         <%--<div id="imgLoding" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 104%;
   height:1652px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>--%>
    </form>
</body>
</html>