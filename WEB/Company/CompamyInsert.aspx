<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompamyInsert.aspx.cs" Inherits="Company_CompamyInsert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript">
function jg(id)
{
   return document.getElementById("ctl00_ContentPlaceHolder1_"+id);
}
function bus()
{
   if(jg("txtCompanyName").value=="")
   {
        alert("请填写企业名称!");
        jg("txtCompanyName").focus();
        return false;
   }
   var b = document.getElementById("<%=ddlRangeID.ClientID %>");
   var Range = b.options[b.selectedIndex].value;
   if(Range==-1)
   {
       alert("请选择所在区域");
       jg("txtRange").focus();
       return false;
   }
   var a = document.getElementById("<%=ddlIndustryID.ClientID %>");
   var Industry = a.options[a.selectedIndex].value;
   if(Industry==-1)
   {
      alert("请选择所在行业");
      jg("txtIndustry").focus();
      return false;
      
   }
    var rdlValiditeTermID = "<%=this.rblNatureID.ClientID %>";//项目有效期
   if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
   {
      alert("请选择企业性质");
      jg("txtNature").focus();
      return false;
   }
   if(jg("txtServiceProce").value=="")
   {
      alert("请填写经营范围!");
      jg("txtServiceProce").focus();
      return false;
   }
   if(jg("txtServiceProce").value.length>400)
   {
       alert("内容过长!");
       jg("txtServiceProce").focus();
       return false;
   }
    if(jg("txtIntroduction").value=="")
   {
      alert("请填写企业简介");
      jg("txtIntroduction").focus();
      return false;
   }
   if(jg("txtIntroduction").value.length>2000)
   {
       alert("内容过长!");
       jg("txtIntroduction").focus();
       return false;
   }
   if(jg("txtLinkName").value=="")
   {
       alert("联系人不能为空!");
       jg("txtLinkName").focus();
       return false;
   }
    var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
    if(!filtEmial.test(jg("txtEmail").value))
    {
         alert("电子邮箱格式不正确，请重新输入");
         jg("txtEmail").focus();
         return false;
     }
   var inputCode = document.getElementById("validCode").value;   
   if(inputCode.length <=0)   
   {   
       alert("请输入验证码！"); 
        document.getElementById("validCode").focus();
   	         return false;  
   }   
   else if(inputCode.toUpperCase() != code )   
   {   
      alert("验证码输入错误！");   
      createCode();//刷新验证码   
      document.getElementById("validCode").focus();
   	  return false;
   } 
   jg("imgLoding").style.display="block";
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
             <h2><p><span><b><a href="SelCompany.aspx">企业名片管理</a></b></span></p></h2>
             <h2><p><span><b>审核企业名片信息</b></span></p></h2>
             </div>
       <table width="100%" cellpadding="0" cellspacing="0" class="publica" class="one_table">
                <tr>
                    <td class="publica-td-left">
                        <span class="hong">*</span>企业名称：</td>
                    <td>
                        <input id="txtCompanyName" runat="server" type="text" style="width: 238px; height: 20px" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong">*</span>所属区域：</td>
                    <td>
                        <asp:DropDownList ID="ddlRangeID" runat="server">
                            <asp:ListItem Value="-1">请选择地区</asp:ListItem>
                            <asp:ListItem Value="0">不限</asp:ListItem>
                            <asp:ListItem Value="1">华东地区</asp:ListItem>
                            <asp:ListItem Value="2">华南地区</asp:ListItem>
                            <asp:ListItem Value="3">华中地区</asp:ListItem>
                            <asp:ListItem Value="4">华北地区</asp:ListItem>
                            <asp:ListItem Value="5">西北地区</asp:ListItem>
                            <asp:ListItem Value="6">西南地区</asp:ListItem>
                            <asp:ListItem Value="7">东北地区</asp:ListItem>
                            <asp:ListItem Value="8">台港澳地区</asp:ListItem>
                            <asp:ListItem Value="9">其它</asp:ListItem>
                        </asp:DropDownList>
                        <input type="text" runat="server" id="txtRange" style="border: 1px solid #FFFFFF" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong">*</span>所属行业：</td>
                    <td>
                        <asp:DropDownList ID="ddlIndustryID" runat="server">
                            <asp:ListItem Value="-1">请选择行业</asp:ListItem>
                            <asp:ListItem Value="1">商务贸易</asp:ListItem>
                            <asp:ListItem Value="2">房产建筑</asp:ListItem>
                            <asp:ListItem Value="3">工业制造</asp:ListItem>
                            <asp:ListItem Value="4">电脑通讯</asp:ListItem>
                            <asp:ListItem Value="5">生活服务</asp:ListItem>
                            <asp:ListItem Value="6">医疗卫生</asp:ListItem>
                            <asp:ListItem Value="7">农林牧渔</asp:ListItem>
                            <asp:ListItem Value="0">其它行业</asp:ListItem>
                        </asp:DropDownList>
                        <input type="text" runat="server" id="txtIndustry" style="border: 1px solid #FFFFFF" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong"></span>员工人数：</td>
                    <td>
                        <input id="txtEmployees" runat="server" type="text" onkeyup="value=value.replace(/[^0-9]/g,'')"
                            onblur="value=value.replace(/[^0-9]/g,'')" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong">*</span>企业性质：</td>
                    <td>
                        <asp:RadioButtonList ID="rblNatureID" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="1">国有</asp:ListItem>
                            <asp:ListItem Value="2">私营</asp:ListItem>
                            <asp:ListItem Value="3">集体</asp:ListItem>
                            <asp:ListItem Value="4">股份</asp:ListItem>
                        </asp:RadioButtonList>
                        <input type="text" runat="server" id="txtNature" style="border: 1px solid #FFFFFF" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong"></span>成立日期：</td>
                    <td>
                        <input type="text" runat="server" id="txtEstablishMent" onkeyup="value=value.replace(/[^0-9]/g,'')"
                            onblur="value=value.replace(/[^0-9]/g,'')" />年 <span class="hong">(例：2002)</span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong"></span>注册资金：</td>
                    <td>
                        <input type="text" runat="server" id="txtCapital" onkeyup="value=value.replace(/[^0-9]/g,'')"
                            onblur="value=value.replace(/[^0-9]/g,'')" />万元
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong"></span>Logo：</td>
                    <td width="618">
                        <asp:FileUpload ID="uploadPic" runat="server" Width="235px" />&nbsp;<asp:Button ID="btnUpload2"
                            runat="server" CssClass="btn-002" Text="上 传" OnClick="btnUpload2_Click" />
                        <asp:Label ID="LblMessage" runat="server" CssClass="hong"></asp:Label><br />
                        <span class="hong">图片须为jpg或gif格式，大小不超过100K </span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong">*</span> 主营介绍：</td>
                    <td width="618">
                        <textarea runat="server" id="txtServiceProce" style="width: 390px; height: 141px"></textarea>
                        <span class="hong">请填写200个字以内</span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong">*</span>企业简介：</td>
                    <td>
                        <textarea runat="server" id="txtIntroduction" style="width: 387px; height: 145px"></textarea>
                        <span class="hong">请填写1000个字以内</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <span class="f_14px strong f_cen">联系人详细信息</span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong">*</span>联系人：</td>
                    <td>
                        <input type="text" id="txtLinkName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong">*</span>联系电话：</td>
                    <td>
                        <input id="txtTelCountry" runat="server" type="text" size='4' value="+86" />
                        <input id="txtTelZoneCode" runat="server" type="text" size='7' />
                        <input id="txtTelNumber" runat="server" type="text" size='18' />
                        <span id="spTel"></span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        手机号码：</td>
                    <td>
                        <input id="txtMobile" runat="server" type="text" style="width: 150px; height: 19px" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong">*</span>电子邮箱：</td>
                    <td>
                        <input type="text" id="txtEmail" runat="server" style="width: 224px; height: 21px" />
                        <span class="hong">(示例:xxx@xx.com)</span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        详细地址：</td>
                    <td>
                        <input type="text" id="txtAddress" runat="server" style="width: 225px; height: 19px" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="hong"></span>单位网址：
                    </td>
                    <td>
                        <input type="text" id="txtURL" runat="server" value="http://" style="width: 225px;
                            height: 19px" />
                        <span class="hong">(示例:http://www.topfo.com/)</span>
                    </td>
                </tr>
                <asp:Panel runat="server" ID="panS">
                <tr>
                    <td class="publica-td-left">
                        验证码：</td>
                    <td>
                        <input type="text" id="validCode" />
                        <input type="text" onClick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width: 80px;cursor:pointer"  />

                    </td>
                </tr>
                </asp:Panel>
                <tr>
                  <td><input type="reset" value="重置" /></td>
                  <td><asp:Button ID="btnSave" runat="server" Text="提交" /></td>
                </tr>
            </table>
    </form>
</body>
</html>
