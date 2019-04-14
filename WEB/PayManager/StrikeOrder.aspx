<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StrikeOrder.aspx.cs" Inherits="PayManager_StrikeOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
 <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
  <style type="text/css">
       
        .llll{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:100px;}
        .llll p{line-height:30px;        }
        </style>
    <title>在线充值</title>
    <style type="text/css"> 
.f_red{color:red}
.f_td{width:15%;background-color:#f7f7f7;
}
</style>
<script language="javascript" type="text/javascript">
 function Depath()
 {
            
           var DDes=document.getElementById("txtLoginName");
             if(DDes.value=="")
   	        {
   	           alert("请输入充值帐号");
   	           DDes.focus();
   	           return false;
   	        }
   	         var money=document.getElementById("txtMoney");
             if(money.value=="")
   	        {
   	           alert("请输入充值金额");
   	           DDes.focus();
   	           return false;
   	        }
   	             var fee=document.getElementById("sType");
   	        if(fee.value=="0")
   	        {
   	         alert("请选择收费状态");
   	           fee.focus();
   	           return false;
   	        }
   	        
   	              var LoginName=document.getElementById("txtByName");
             if(LoginName.value=="")
   	        {
   	           alert("错误操作请重新登录");
   	       
   	           return false;
   	        }
   	            var telMobile=document.getElementById("txtMobile");
   	        if(telMobile.value!="")
            {
           
                var filtMobile = /^(13|15|18)[0-9]{9}$/;
                if(!filtMobile.test(telMobile.value))
                {
                    alert("请正确填写手机号码");
                    telMobile.focus();
                    return false;
                }
            }
             var Emiatset=document.getElementById("txtEmail");
   	        if(Emiatset.value!="")
            {
               var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
               if(!filtEmial.test(document.getElementById("txtEmail").value))
               {
   	                 alert("电子邮箱格式不正确，请重新输入");
   	                 document.getElementById("txtEmail").focus();
   	                 return false;
   	           }
   	     }
   	        document.getElementById("imgLoding").style.display="";
   	        
 }
 function GetCheckNum(checkobjectname)
    {
      
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="title" align="center">
             
             <h2><p><span><b>在线充值</b></span></p></h2>
             </div>
       <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*<span style="color: #000000; background-color: #f7f7f7">充值</span></span>帐号：</td>
                    <td>
                        <span runat="server" id="spanName" class="f_red">
                            <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox></span></td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="height: 24px">
                        <span class="f_red">*</span>充值金额：</td>
                    <td style="height: 24px">
 
                            <asp:TextBox ID="txtMoney" runat="server" onkeyup="value=value.replace(/[^\d]/g,'')"></asp:TextBox></td>
                </tr>
                    <tr>
               <td align="right" class="f_td">
              <span class="f_red">*</span>收费状态：</td>
               <td>
                                             <select id="sType" runat="server" name="sType">
                                            <option value="1">收费</option>
                                            <option value="2">免费</option>
                                            <option selected="selected" value="0">---请选择---</option>
                                        </select></td>
           </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*<span style="color: #000000; background-color: #f7f7f7">电子</span></span>邮箱：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="height: 24px">
                        <span class="f_red"></span>电话号码：</td>
                    <td style="height: 24px">
                        <input id="txtTelCountry" runat="server" type="text" size='4' value="+86" onkeyup="value=value.replace(/[^\d]/g,'')"  />
                        <input id="txtTelZoneCode" runat="server" type="text" size='7' onkeyup="value=value.replace(/[^\d]/g,'')"  />
                        <input id="txtTelNumber" runat="server" type="text" size='18' onkeyup="value=value.replace(/[^\d]/g,'')"  />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>手机号码：</td>
                    <td>
                        <input runat="server" id="txtMobile" type="text"  onkeyup="value=value.replace(/[^\d]/g,'')" />
                    </td>
                </tr>
           <tr>
               <td align="right" class="f_td">
               操作人：
               </td>
               <td>
                   <asp:TextBox ID="txtByName" runat="server" Enabled="False"></asp:TextBox></td>
           </tr>
           <tr>
               <td align="right" class="f_td">
                   备注：</td>
               <td>
                   <asp:TextBox ID="txtBank" runat="server" Height="44px" TextMode="MultiLine" Width="208px"></asp:TextBox></td>
           </tr>
             
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button runat="server" ID="btnStatus" Text="审 核" OnClientClick="return Depath();" CssClass="btn" OnClick="btnStatus_Click"  />
                        &nbsp &nbsp &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
     <%--       
       <div id="imgLoding" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 104%;
   height:200px; filter: 
   alpha(opacity=60);">

               <div class="llll">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
                </div>--%>
    </form>
</body>
</html>