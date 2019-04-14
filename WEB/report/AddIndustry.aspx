<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddIndustry.aspx.cs" Inherits="report_AddIndustry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=title %>
    </title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>添加合作机构</b></span></p>
                </h2>
                <h2>
                    <p>
                        <span><b><a href="IndustryManage.aspx">资源管理</a></b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td>
                        机构名称 :<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtIndustryName" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        申 请 人:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtLinkMan" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        QQ:</td>
                    <td align="left">
                        <asp:TextBox ID="txtQQ" onkeyup="value=value.replace(/[^\d]/g,'') " runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        手机:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtPhone" runat="server" Width="153px" Height="22px"></asp:TextBox>
                        <span style="color: #808080">(为了方便联系，手机和联系电话至少填写一个)</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        联系电话:</td>
                    <td align="left">
                        <asp:TextBox ID="txtcontactsTel" MaxLength="4" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                            runat="server" Width="43px"></asp:TextBox>-
                        <asp:TextBox ID="txtTel" MaxLength="8" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                            runat="server" Width="95px"></asp:TextBox>-
                        <asp:TextBox ID="txttel2" MaxLength="4" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                            runat="server" Width="41px"></asp:TextBox><span style="color: #808080">(请输入数字&nbsp;&nbsp;格式如:0755-89805588-8028)</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        传真号码:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtFax" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        电子邮箱：<span class="hong">*</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" runat="server" Width="153px" Height="22px"></asp:TextBox>
                        <%--<span id="spEmail" class="hui">(请填写您最常用的电子邮箱)</span>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        单位名称:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtCompany" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        网址:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtSite" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        地址:</td>
                    <td align="left">
                        <asp:TextBox ID="txtAddress" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        备 注：</td>
                    <td align="left">
                        <asp:TextBox ID="txtMeo" runat="server" Height="81px" TextMode="MultiLine" Width="410px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAudit" runat="server" CssClass="btn" Text="修改" OnClick="btnAudit_Click" />
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="添加" OnClick="btnSubmit_Click" />
                        <input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" /></td>
                </tr>
            </table>
        </div>

        <script language="javascript" type="text/javascript">
        function $(id)
        {
            return document.getElementById(id);
        }
        function CheckForm(){
            if($("<%=txtIndustryName.ClientID %>").value==""){alert('请填写机构名称.');$("<%=txtIndustryName.ClientID %>").focus();return false;}
          if($("<%=txtLinkMan.ClientID %>").value==""){alert('请填写申请人.');$("<%=txtLinkMan.ClientID %>").focus();return false;}
            
            
            if($("<%=txtTel.ClientID %>").value.length==0&&$("<%=txtPhone.ClientID %>").value.length==0)
            { alert('手机和电话至少填一个');$("<%=txtPhone.ClientID %>").focus();return false;}
            else
            {
             if($("<%=txtTel.ClientID %>").value.length>0){
                var str = $("<%=txtTel.ClientID %>").value;
    	        var patn = /^[\+0-9]+$/;
    	        if(!patn.test(str)){ alert('请正确填写您的联系电话'); $("<%=txtTel.ClientID %>").focus();return false;}
    	      }else{
    	            if($("<%=txtPhone.ClientID %>").value.length>0 &&$ ("<%=txtPhone.ClientID %>").value.length<11){alert('手机号码填写不正确.');$("<%=txtPhone.ClientID %>").focus();return false;}
                   }
            }
            if($("<%=txtFax.ClientID %>").value==""){alert('传真号码不能为空'); $("<%=txtFax.ClientID %>").focus();return false;}
           else
            {
                var str1 = document.getElementById("<%=txtFax.ClientID %>").value;
    	        var patn = /^[\+0-9]+$/;
    	        if(!patn.test(str1)){ alert('请正确填写您的传真号码'); $("<%=txtFax.ClientID %>").focus();return false;}
    	    }
            if($("<%=txtEmail.ClientID %>").value==""){alert('请填写电子邮箱.');$("<%=txtEmail.ClientID %>").focus();return false;}             if($("<%=txtEmail.ClientID %>").value!="")
             {
                var emailStr = document.getElementById("<%=txtEmail.ClientID %>").value;
                var emailPat=/^(.+)@(.+)$/;
                var matchArray = emailStr.match(emailPat);
                if (matchArray==null)
                {
                    alert("电子邮件的格式不正确！");
                    $("<%=txtEmail.ClientID %>").focus();
                    return false;
                }
            }
            if($("<%=txtCompany.ClientID %>").value==""){alert('请填写单位名称.');$("<%=txtCompany.ClientID %>").focus();return false;}
           
            
    	    document.getElementById("imgLoding").style.display="";
        }    </script>

        <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: -1px; left: 0px; width: 100%; height: 1055px; filter: alpha(opacity=60);">
            <div style="position: absolute; left: 436px; top: 520px;">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
            </div>
        </div>
    </form>
</body>
</html>
