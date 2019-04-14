<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddLink.aspx.cs" Inherits="admin_AddLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <%--<link rel="stylesheet" type="text/css" href="http://dp.topfo.com/css/common.css" />
    <link rel="stylesheet" type="text/css" href="http://dp.topfo.com/css/css.css" />--%>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
#uploadPic{
	width:200px;
	border:1px solid maroon;
}
#uploadPic1{
	width:0px;
	border:0px solid green;
	
}
</style>

    <script language="javascript">
    function upPicture(file){ 
  var ImageFileExtend = ".gif,.png,.jpg,.bmp"; 
      if(file.value.length>0)   
       {
　　        //判断后缀        
　　        var fileExtend=file.value.substring(file.value.lastIndexOf('.')).toLowerCase();
　　        if(ImageFileExtend.indexOf(fileExtend)>-1)      
　　        {   
　　            //显示预览 
                return true;      
　　        }  
　　         else       
　　        {          
                alert("请上传" + ImageFileExtend + "格式的图片");  
                return false;    
　　        }  
　　　 }
 }
    </script>

</head>
<body>
    <form id="form2" runat="server">
        <input type="hidden" id="policyId" runat="server" />
        <div class="title">
            <h2>
                <p>
                    <span><b>修改联系方式</b></span></p>
            </h2>
        </div>
        <table border="0" cellpadding="0" class="one_table" cellspacing="0" style="width: 100%;">
            <tr>
                <td style="width: 10%" align="center">
                    姓名：<span style="color: Red;">*</span></td>
                <td style="text-align: left" valign="middle">
                    <asp:TextBox ID="txtLinkMan" runat="server" Width="153px" Height="22px"></asp:TextBox>
                    <span style="color: #808080">(填写您的真实姓名，以方便客户联系)</span>
                </td>
            </tr>
            <tr>
                <td align="center">
                    手机:<span style="color: Red;">*</span></td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtPhone" runat="server" Width="153px" Height="22px"></asp:TextBox>
                    <span style="color: #808080">(为了方便联系，手机和联系电话至少填写一个)</span>
                </td>
            </tr>
            <tr>
                <td align="center">
                    联系电话:<span style="color: Red;">*</span></td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtcontactsTel" MaxLength="4" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                        runat="server" Width="43px"></asp:TextBox>-
                    <asp:TextBox ID="txtTel" MaxLength="8" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                        runat="server" Width="95px"></asp:TextBox>-
                    <asp:TextBox ID="txttel2" MaxLength="4" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                        runat="server" Width="41px"></asp:TextBox><span style="color: #808080">(请输入数字&nbsp;&nbsp;格式如:0755-89805588-8028)</span>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="center">
                    传真号码:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtFax" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center">
                    其它联系方式:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtOther" runat="server" Width="153px" Height="22px"></asp:TextBox>
                    <span style="color: #808080">(填写您的QQ以及其它联系方式)</span>
                </td>
            </tr>
            <tr>
                <td align="center">
                    电子邮箱：<%--<span class="hong">*</span>--%>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtEmail" runat="server" Width="153px" Height="22px"></asp:TextBox>
                    <span style="color: #808080">(请填写您最常用的电子邮箱)</span>
                </td>
            </tr>
            <tr>
                <td align="center">
                    地址:</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtAddress" runat="server" Width="318px" Height="22px"></asp:TextBox></td>
            </tr>
            <tr id="imageDis" runat="server" style="display: none">
                <td align="center">
                    公司地图：
                </td>
                <td valign="middle" style="text-align: left">
                    <asp:Image ID="Image1" runat="server" Height="306px" Width="209px"></asp:Image>
                    <%-- <asp:label id="lblImages" runat="server" backcolor="White" bordercolor="White" forecolor="#C00000"></asp:label>--%>
                </td>
            </tr>
            <tr>
                <td align="center">
                    上传图片<br>
                    (公司地图)：</td>
                <td style="text-align: left">
                    <asp:FileUpload ID="uploadPic" Height="24px" onchange="upPicture(this)" runat="server" />
                    &nbsp;<asp:Button ID="btnUpload2" runat="server" CssClass="btn" OnClick="btnUpload2_Click"
                        Text="上 传" Height="23px" Width="66px" />
                    <asp:Label ID="LblMessage2" runat="server" BackColor="White" BorderColor="White"
                        ForeColor="#C00000"></asp:Label>
                    <br />
                    <span style="color: #808080">(图片须为jpg、bmp、gif格式，大小不超过500K )</span>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="text-align: center">
                        <asp:Button ID="Button1" runat="server" OnClientClick="return CheckForm()" CssClass="btn"
                            Text="添加" OnClick="Button1_Click" Height="26px" Width="66px" />
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn" OnClientClick="return CheckForm()"
                            Text="修改" Visible="False" OnClick="btnUpdate_Click" Height="25px" Width="66px" />
                        <input type="button" id="Button3" onclick="history.back();" value="返 回" class="btn"
                            onfocus="this.blur()" /></div>
                    <%-- <input type="button" id="Button3" onclick="history.back();" value="返回" class="button1" />--%>
                </td>
            </tr>
        </table>
        <%--  <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: -1px; left: 0px; width: 100%; height: 1055px; filter: alpha(opacity=60);">
            <div style="position: absolute; left: 520px; top: 110px;">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif" alt="Loading" />
            </div>
        </div>--%>

        <script language="javascript" type="text/javascript">
        function $(id)
        {
            return document.getElementById(id);
        }
        function CheckForm(){
            
            if($("<%=txtLinkMan.ClientID %>").value==""){alert('请填写姓名');$("<%=txtLinkMan.ClientID %>").focus();return false;}
           
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
//             if($("<%=txtFax.ClientID %>").value!="")
//            {
//                var str1 = document.getElementById("<%=txtFax.ClientID %>").value;
//    	        var patn = /^[\+0-9]+$/;
//    	        if(!patn.test(str1)){ alert('请正确填写您的传真号码'); $("<%=txtFax.ClientID %>").focus();return false;}
//    	    }
    	    //if($("<%=txtEmail.ClientID %>").value==""){alert('请填写电子邮箱.');$("<%=txtEmail.ClientID %>").focus();return false;} 
             if($("<%=txtEmail.ClientID %>").value!="")
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
            //document.getElementById("imgLoding").style.display="";
        }    </script>

    </form>
</body>
</html>
