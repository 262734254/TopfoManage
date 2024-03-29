﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModefiyProTalent.aspx.cs"
    Inherits="ProfessionalManage_ModefiyProTalent" %>

<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>修改专业人才</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="../css/css.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

    <script language="javascript">
     function ConAudit(i)
    {
        switch(i)
        {
            case 0:
       
                document.getElementById("trAuditingRemark").className = "trnone";
                //document.getElementById("trFeedbackStatus").className = "trnone";
                document.getElementById("trFee").className = "trnone";
                document.getElementById("trHit").className = "trnone";
                break;
                
            case 1:
                document.getElementById("trAuditingRemark").className = "trnone";
                //document.getElementById("trFeedbackStatus").className = "trnone";
                document.getElementById("trFee").className = "";
                document.getElementById("trHit").className = "";
                break;
            case 2:
                document.getElementById("trAuditingRemark").className = "";
                //document.getElementById("trFeedbackStatus").className = "";
                document.getElementById("trFee").className = "trnone";
                document.getElementById("trHit").className = "trnone";
                break;
            default:
                break;
        }
}
function ShowPoint(src)
{
    if(src==0)
    {
		document.getElementById("spShowPoint").style.display="none";
    }
     if(src==1)
    {
    document.getElementById("spShowPoint").style.display="";
		
    }
}

    </script>

</head>
<body>
    <form id="Form1" runat="server">
        <div align="center">
            <div class="title">
                <h2>
                    <p>
                        <span><b>专业人才审核</b></span></p>
                </h2>
                <h2>
                    <p>
                        <span><b><a href="ProfessionalManage.aspx">资源管理</a></b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td>
                        标题 :<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtTitle" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        网页title:<span class="hong">*</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtWtitle" Height="22px" runat="server" Columns="50" Width="285px"></asp:TextBox>
                         <span class="hui">（如：专业人才详情页-中国招商投资网）</span></td>
                </tr>
                <tr>
                    <td>
                        搜索关键字:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtKeyword1" runat="server" Width="153px" Height="22px"></asp:TextBox>
                         <span class="hui">（如：专业服务,专业机构,专业人才）</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        网页描述:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtWebDesr" runat="server" Height="49px" TextMode="MultiLine" Width="413px"></asp:TextBox>
                         <span class="hui">（如：中国招商投资网）</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        所属地域:<span class="hong">*</span></td>
                    <td align="left">
                        <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        服务类型：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlServiceType" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        人才类别：</td>
                    <td align="left">
                        <asp:DropDownList ID="DropIndustry" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        创建时间：</td>
                    <td align="left">
                        <%--onFocus="WdatePicker({lang:'zh-cn'})" CssClass="Wdate"--%>
                        <asp:TextBox ID="txtRegistYear" runat="server" Height="23px" ReadOnly="true" Width="113px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="imageDis" runat="server" style="display: none">
                        <td>
                            个人照片：
                        </td>
                        <td valign="middle" align="left">
                            <asp:Image ID="Image1" runat="server" Height="106px" Width="98px"></asp:Image>
                            <%-- <asp:label id="lblImages" runat="server" backcolor="White" bordercolor="White" forecolor="#C00000"></asp:label>--%>
                        </td>
                </tr>
                <tr>
                    <td>
                        个人照片：</td>
                    <td align="left">
                        <asp:FileUpload ID="uploadPic" runat="server" Width="235px" />
                        &nbsp;<asp:Button ID="btnUpload2" runat="server" OnClick="btnUpload2_Click" Text="上 传" />
                        <asp:Label ID="LblMessage2" runat="server" BackColor="White" BorderColor="White"
                            ForeColor="#C00000"></asp:Label>
                        <br />
                        <span class="hui">(图片须为jpg、bmp、gif格式，大小不超过500K )</span>
                    </td>
                    <td>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        申请说明:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtContent" runat="server" Height="95px" Width="424px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>--%>
                <%--<tr>
                    <td>
                        来源：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlFrom" runat="server">
                            
                            <asp:ListItem Value="1">会员中心</asp:ListItem>
                            <asp:ListItem Value="2">业务员</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        个人简历：</td>
                    <td align="left">
                        <asp:TextBox ID="txtresume" runat="server" Height="97px" TextMode="MultiLine" Width="534px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        个人特长：</td>
                    <td align="left">
                        <asp:TextBox ID="txtspecialty" runat="server" Height="84px" TextMode="MultiLine"
                            Width="534px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        成功案例：</td>
                    <td align="left">
                        <asp:TextBox ID="txtSuccess" runat="server" Height="84px" TextMode="MultiLine" Width="534px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        项目有效期:</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        申 请 人:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtLinkMan" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        职务：<span style="color: #ff6600">*</span>
                    </td>
                    <td align="left">
                        <input id="txtPosition" runat="server" type="text" style="width: 153px; height: 23px;" /></td>
                </tr>
                <tr>
                    <td>
                        单位名称:<span class="hong">*</span></td>
                    <td align="left">
                        <asp:TextBox ID="txtCompany" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        地址:</td>
                    <td align="left">
                        <asp:TextBox ID="txtAddress" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
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
                        联系电话:<span class="hong">*</span></td>
                  
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
                        传真号码:</td>
                    <td align="left">
                        <asp:TextBox ID="txtFax" runat="server" Width="153px" Height="22px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        电子邮箱：<span class="hong">*</span>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" runat="server" Width="153px" Height="22px"></asp:TextBox>
                        <span id="spEmail" class="hui">(请填写您最常用的电子邮箱)</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        网址:</td>
                    <td align="left">
                        <asp:TextBox ID="txtSite" runat="server" Width="280px" Height="22px"></asp:TextBox>
                        <span class="hui"> &nbsp;&nbsp;(如http://www.topfo.com)</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        刷新时间:</td>
                    <td align="left">
                        <asp:TextBox ID="txtReTime" Height="20px" ReadOnly="true" runat="server" Width="90px"></asp:TextBox></td>
                </tr>
                <%--<tr>
                    <td>
                        是否推荐:</td>
                    <td align="left">
                        <asp:RadioButton ID="rdoNoAct" GroupName="rblActitv1" runat="server" Text="不推荐" />
                        <asp:RadioButton ID="rdoYesAct" GroupName="rblActitv1" runat="server" Text="推荐" /></td>
                </tr>--%>
                <%--<tr>
                    <td>
                        状态:</td>
                    <td align="left">
                        <asp:RadioButton ID="rdoNoEnable" GroupName="rblActitv" runat="server" Text="无效" />
                        <asp:RadioButton ID="rdoYesEnable" GroupName="rblActitv" runat="server" Text="有效" />
                        <asp:RadioButton ID="rdoOverTime" GroupName="rblActitv" runat="server" Text="己过期" /></td>
                </tr>--%>
                <tr>
                    <td>
                        审核结果:</td>
                    <td align="left">
                        <asp:RadioButton ID="rdAudit" GroupName="rblAuditingStatus" runat="server" onclick="ConAudit(0)"
                            Text="未审核" />
                        <asp:RadioButton ID="rdPass" GroupName="rblAuditingStatus" runat="server" onclick="ConAudit(1)"
                            Text="审核通过" />
                        <asp:RadioButton ID="rdNopass" GroupName="rblAuditingStatus" runat="server" onclick="ConAudit(2)"
                            Text="审核未通过" />
                            <asp:RadioButton ID="rdDelete" GroupName="rblAuditingStatus" runat="server" onclick="ConAudit(0)"
                            Text="己删除" />
                            </td>
                </tr>
                <tr id="trAuditingRemark" runat="server">
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span> <strong>未通过审核原因：</strong></td>
                    <td align="left" style="height: 138px">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="one_table">
                            <tr>
                                <td bgcolor="#f7f7f7">
                                    <asp:TextBox ID="tbAuditingRemark" runat="server" Width="334px" Height="92px" TextMode="MultiLine"></asp:TextBox><br />
                                    <span class="hui">原因描述尽量简单、明确，不超过20个汉字 <a href="javascript:;" onclick="document.getElementById('tbAuditingRemark').value='';">
                                        [清除]</a></span>
                                </td>
                                <td>
                                    1、<a onclick="getStr('该需求在库中已存在!')" href="javascript:void(0)">该需求在库中已存在!</a><br />
                                    2、<a onclick="getStr('该需求应发布到“商机/创业”版块!')" href="javascript:void(0)">该需求应发布到"商机/创业"版块!</a><br />
                                    3、<a onclick="getStr('该需求应发布到“融资”版块!')" href="javascript:void(0)">该需求应发布到"融资"版块!</a><br />
                                    4、<a onclick="getStr('需求介绍不符合规范，请按要求完善后发布!')" href="javascript:void(0)">需求介绍不符合规范，请按要求完善后发布!</a><br />
                                    5、<a onclick="getStr('该信息不符合投资资源标准!')" href="javascript:void(0)">该信息不符合投资资源标准!</a><br />
                                </td>
                            </tr>
                        </table>

                        <script>function getStr(str)
        {
           document.getElementById("tbAuditingRemark").value+=str;
        }
                        </script>

                    </td>
                </tr>
                <tr id="trFee" runat="server">
                    <td>
                        资源选项：<span class="hong">*</span></td>
                    <td align="left">
                        <asp:RadioButton ID="rdomian" onclick="ShowPoint(0)" runat="server" GroupName="rdoMainShou"
                            Text="免费"></asp:RadioButton>
                        <asp:RadioButton ID="rdoShou" onclick="ShowPoint(1)" runat="server" GroupName="rdoMainShou"
                            Text="收费"></asp:RadioButton>
                        <span id="spShowPoint" style="display: none; display: inline" runat="server">
                            <asp:TextBox ID="txtPrice" runat="server" Width="50px"></asp:TextBox>元 </span>
                    </td>
                </tr>
                <tr id="trHit" runat="server">
                    <td>
                        点击数:</td>
                    <td align="left">
                        <asp:TextBox ReadOnly="true" ID="txtClick" runat="server" Width="50px" Height="20px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="审核" OnClick="btnSubmit_Click" />
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
            if($("<%=txtTitle.ClientID %>").value==""){alert('请填写标题.');$("<%=txtTitle.ClientID %>").focus();return false;}
            if($("<%=txtWtitle.ClientID %>").value==""){alert('请填写网页标题.');$("<%=txtWtitle.ClientID %>").focus();return false;}
            if($("<%=txtKeyword1.ClientID %>").value==""){alert('请填写搜索关键字.');$("<%=txtKeyword1.ClientID %>").focus();return false;}
            if($("<%=txtWebDesr.ClientID %>").value==""){alert('请填写网页描述.');$("<%=txtWebDesr.ClientID %>").focus();return false;}
            if($("CountryListCN").value==""||$("CountryListCN").value==0){alert('请选择国家.');$("CountryListCN").focus();return false;}
            if($("provinceCN").value==""||$("provinceCN").value==0){alert('请选择省份.');$("provinceCN").focus();return false;}
            if($("capitalCN").value==""||$("capitalCN").value==0){alert('请选择城市.');$("capitalCN").focus();return false;} 
            if($("<%=DropIndustry.ClientID %>").value==""){alert('请选择人才类别.');return false;}
            
            if($("<%=txtRegistYear.ClientID %>").value=="")
            {
                 alert('请填写创建时间.');$("<%=txtRegistYear.ClientID %>").focus();return false;
            }
            
            if($("<%=txtPrice.ClientID %>").value==""){alert('请填写价格.');$("<%=txtPrice.ClientID %>").focus();return false;}
            var reg = /^(?=.{1,11}$)((0|[1-9]\d+)\.\d|(0|[1-9]\d*))$/;
            var strs = $("<%=txtPrice.ClientID %>").value;
            if(!reg.test(strs)){ alert('请正确填写价格'); $("<%=txtPrice.ClientID %>").focus();return false;}
            if($("<%=txtLinkMan.ClientID %>").value==""){alert('请填写申请人.');$("<%=txtLinkMan.ClientID %>").focus();return false;}
            if($("<%=txtPosition.ClientID %>").value==""){alert('请填写职务.');return false;}
            if($("<%=txtCompany.ClientID %>").value==""){alert('请填写单位名称.');$("<%=txtCompany.ClientID %>").focus();return false;}
           
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
//          if($("<%=txtTel.ClientID %>").value==""){alert('请填写联系电话.');$("<%=txtTel.ClientID %>").focus();return false;}
//	        if($("<%=txtPhone.ClientID %>").value==""){alert('请填写手机号码.');$("<%=txtPhone.ClientID %>").focus();return false;}
             if($("<%=txtFax.ClientID %>").value!="")
            {
                var str1 = document.getElementById("<%=txtFax.ClientID %>").value;
    	        var patn = /^[\+0-9]+$/;
    	        if(!patn.test(str1)){ alert('请正确填写您的传真号码'); $("<%=txtFax.ClientID %>").focus();return false;}
    	    }
    	    if($("<%=txtEmail.ClientID %>").value==""){alert('请填写电子邮箱.');$("<%=txtEmail.ClientID %>").focus();return false;} 
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
//            if($("<%=txtClick.ClientID %>").value==""){alert('请填写点击率');$("<%=txtClick.ClientID %>").focus();return false;}
//            var str5 = document.getElementById("<%=txtClick.ClientID %>").value;
//    	    var patn1 = /^[\+0-9]+$/;
//    	    if(!patn1.test(str5)){ alert('请正确填写点击率'); $("<%=txtClick.ClientID %>").focus();return false;}
             //if($("<%=txtSite.ClientID %>").value==""){alert('请填写网址.');$("<%=txtSite.ClientID %>").focus();return false;}
            document.getElementById("imgLoding").style.display="";
        }    </script>

        <%--    //var siteStr = $("<%=txtSite.ClientID %>").value;
           //var siteStrs=/(\w+):\/\/([^/:]+)(:\d*)?([^# ]*)/;
                //var siteStrs=^(?:([a-zA-Z]+):)?(\/{0,3})([0-9.\-a-zA-Z]+)(?::(\d+))?(?:\/([^?#])*)?(?:\?([^#]*))?(?:#(.*))?$
              //if(!siteStrs.test(siteStr)){ alert('请正确填写您的网址'); $("<%=txtSite.ClientID %>").focus();return false;}
           
            //if($("validCode").value==""){alert('请填写验证码.');$("validCode").focus();return false;}
              
//        if($("validCode").value.toUpperCase() != code )   
//       {   
//          alert("验证码输入错误！");  createCode();//刷新验证码   
//           $("validCode").focus();
//       	    return false;
//       }   
       
//          function ValidErr()
//            {
//                var c="";
//                alert('验证码错误,请重新输入！');
////                document.getElementById(c+"ImageCode").focus();
////                document.getElementById(c+"ImageCode").select();
//                document.getElementById("ImageCode").focus();
//                document.getElementById("ImageCode").select();
//            }
--%>
           <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: -1px; left: 0px; width: 100%; height: 1343px; filter: alpha(opacity=60);">
            <%--<div class="content">--%>
            <div style="position:absolute; left: 436px; top: 520px;">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
            </div>
        </div>
        <%--
        <script language="javascript">  createCode();</script>--%>
    </form>
</body>
</html>
