<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateCarveOut.aspx.cs" validateRequest="false" Inherits="CarveNews_UpdateCarveOut" %>
<%--<%@ Register Src="../Controls/MerchantInfoAddressInfo1.ascx" TagName="MerchantInfoAddressInfo"
  TagPrefix="uc4" %>--%>  
  <%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
 <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
  <style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:500px;}
        .content p{line-height:30px;        }
        </style>
      <script language="javascript" type="text/javascript">
  
	function chkBtn()
	{
	   if(document.getElementById("txtTitle").value=="")
	   {
	       alert("请填写标题");
	       document.getElementById("txtTitle").focus();
	       return false;
	   }
	   if(document.getElementById("ZoneSelectControl2_hideProvince").value=="")
	   {
	          alert("请选择所属区域");
	          return false;
	   }
	   	   if(document.getElementById("ddlIndustry").options.length==0)
	   {
	         alert("请选择所属行业");
	         document.getElementById("ddlIndustry").focus();
	         return false;
	   }
	   var  rdlValiditeTermID="<%=this.rdbtXM.ClientID %>";
	    if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
        {
           alert("项目有效期不能为空！");
           return false;
        }
	   var telzone=document.getElementById("txtTelZoneCode") ;
	   var telNumber=document.getElementById("txtTelNumber");
	   var telMobile=document.getElementById("txtMobile");
	    if(telNumber.value.length=="" && telMobile.value.length=="")
        {
            alert("手机和固定电话请至少填写一项");
             document.getElementById("txtMobile").focus();
            return false;
        }else
        {
            var filtMobile = /^(13|15|18)[0-9]{9}$/;
            if(!filtMobile.test(document.getElementById("txtMobile").value))
            {
                alert("请正确填写手机号码");
                document.getElementById("txtMobile").focus();
                return false;
            }
        }
    var email=document.getElementById("txtEmail");
        if(email.value=="")
        {
           alert("请输入电子邮箱");
           document.getElementById("txtEmail").focus();
           return false;
        } else  
        {
            var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
            if(!filtEmial.test(document.getElementById("txtEmail").value))
            {
       	         alert("电子邮箱格式不正确，请重新输入");
       	         document.getElementById("txtEmail").focus();
       	         return false;
       	     }
        }
          document.getElementById("imgLoding").style.display="block";


           
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
     <div class="mainconbox" style="text-align:center">

        <div  id="switchtext" style="text-align:left">
          <div class="title">
                <h2>
                    <p>
                        <span><b><a href="UpdateCarveOut.aspx">创业信息审核</a></b></span></p>
                </h2>
                  <h2>
                    <p>
                        <span><b><a href="CarveOutList.aspx">创业信息管理</a></b></span></p>
                </h2>
            </div></div>
			 <div class='dottedlline'>  </div>
			  <div class="blank6"> </div>
			 <!--这是后来招商信息的div-->
			 <div id="ProjectDiv" style="display:block;" >
			
        <div class="infozi" style="text-align:center">
            </div>
            <!--以下是修改的部分-->
        <table border="0" cellpadding="0" cellspacing="0"  style="width: 751px"  class="one_table" >
          <%--  <tr>
                <td align="center"bgcolor="#f7f7f7" colspan="2" style="height: 42px">
                    资金找项目</td>
            </tr>--%>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 20px">
                 <span class="hong"> * </span> <strong>类型：</strong>
                </td>
                <td align="left" style="height: 20px">
                	<asp:RadioButtonList id="rdoType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
										<asp:ListItem Value="0">项目找资金</asp:ListItem>
										<asp:ListItem Value="1">资金找项目</asp:ListItem>
									</asp:RadioButtonList> 
                </td>
            </tr>
             <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong"> * </span> <strong>创业标题：</strong></td>
                <td align="left">
                    <asp:TextBox ID="txtTitle" runat="server" Width="270px" Height="21px"></asp:TextBox>
                    <span id="spMerchantTopic" style="color:buttonshadow">填写5个字以上</span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <strong>关键字：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtKeyWord"  runat="server" Columns="50" Width="270px" Height="21px"></asp:TextBox>
                    <span id="Span1" style="color:buttonshadow">关键词间必须用逗号分隔 </span>
                </td>
            </tr>
               <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong"></span>  <strong>网页描述：</strong></td>
                <td align="left"> 
                    <asp:TextBox id="txtDescript" runat="server" Columns="50" TextMode="MultiLine" Height="78px" Width="418px"></asp:TextBox>
                    <span id="Span2"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong"></span>  <strong>网页标题：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtDisplayTitle" runat="server" Columns="50" Height="21px"></asp:TextBox>
                    <span id="Span3"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <strong>短标题：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtShortTitle" runat="server" Columns="50" Height="21px"></asp:TextBox>
                    <span id="Span4"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <strong>短内容：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtShortContent" runat="server" Columns="50" Height="21px"></asp:TextBox>
                    <span id="Span5"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <strong>广告语：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtAdTitle" runat="server" Height="21px" Width="275px"></asp:TextBox>
                    <span id="Span6"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong">* </span>  <strong>所属区域：</strong></td>
                <td align="left">
                   <uc1:ZoneSelectControl ID="ZoneSelectControl2" runat="server" />
                    <span id="Span8"></span>
                    <input name="ZoneId" type="text" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong">* </span>  <strong>所属行业：</strong></td>
                <td align="left">
                   <span id="Span9"></span>
                    <asp:DropDownList ID="ddlIndustry" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                <span class="hong">* </span> <strong>所需资金：</strong>
                </td>
                <td align="left">
                    <%--<asp:DropDownList ID="ddlCapital" runat="server" DataTextField="CapitalName" DataValueField="CapitalID">
                    </asp:DropDownList>--%>
                         <asp:DropDownList ID="ddlMerchantCurrency" runat="server" Enabled="False">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddlMerchantTotal" runat="server" >
                    </asp:DropDownList></td>
            </tr>

            <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 42px">
                  <span class="hong"> </span>  <strong>  预览图片：</strong></td>

                    <td align="left">       <asp:LinkButton ID="LbLook" Font-Underline="true" runat="server" OnClick="LbLook_Click" ForeColor="#0000C0">预览图片</asp:LinkButton>
        <asp:Label ID="lblMessage" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 42px">
                <span class="hong"> </span>  <strong>合作对象：</strong>
                </td>
                <td align="left" style="height: 42px">
                    <asp:RadioButtonList ID="rblInvestObject" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="1">个人</asp:ListItem>
                        <asp:ListItem Value="2">公司</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">不限制</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
            
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong">&nbsp;</span><strong>详细内容：</strong></td>
                <td align="left">
                   <%--<asp:TextBox id="txtContent" runat="server" Columns="60" TextMode="MultiLine" Rows="5" Height="117px"></asp:TextBox>
                    <span id="Span12">--%>
                    <CE:Editor ID="txtContent" AutoConfigure="Minimal" SecurityPolicyFile="Admin.config" Width="540" Height="266px" runat="server"></CE:Editor>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 101px">
                  <strong>回报形式：</strong></td>
                <td align="left" style="height: 101px">
                   <asp:TextBox id="txtInvestReturn" runat="server" Columns="60"  TextMode="MultiLine"
																					Rows="5" Height="93px"></asp:TextBox>
                    <span id="Span13"></span>
                </td>
            </tr>
             <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong"> </span>  <strong>备    注：</strong></td>
                <td align="left">
                  <asp:TextBox id="txtRemark" runat="server" Columns="60"  TextMode="MultiLine"
																					Rows="5" Height="91px"></asp:TextBox>
                    <span id="Span16"></span>
                </td>
            </tr>
             <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 20px">
                  <span class="hong">* </span>  <strong>有效期：</strong></td>
                <td align="left" style="height: 20px">
                    <asp:RadioButtonList ID="rdbtXM" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                     
                    </asp:RadioButtonList>
           </td>
            </tr>
<%--            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 42px"> <strong>发布时效：</strong>
                </td>
                <td align="left" style="height: 42px">
                    <asp:DropDownList ID="ddlValidateDate" runat="server" DataTextField="ValidateName"
                        DataValueField="ValidateID">
                    </asp:DropDownList></td>
            </tr>--%>
    <%--        <tr>
                <td align="right" bgcolor="#f7f7f7">
                <span class="hong">* </span><strong>开始日期：</strong>
                </td>
                <td align="left">
                    <cc1:DateTimeBox ID="txtValidateStartTime" runat="server"></cc1:DateTimeBox>
                
                </td>
            </tr>--%>
            <tr style="DISPLAY: none">
                <td align="right" bgcolor="#f7f7f7" > <strong>模版号：</strong>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlTemplate" runat="server" Width="64px">
                        <asp:ListItem Value="001">001</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>

         
        </table>
        <div class="blank0">
        </div>

        <!--联系方式开始将之隐藏 -->
        <div id="ContactDiv" style="display:block;">
        <div class="infozi" style="text-align:left">
            <strong style="text-align:center"></strong>&nbsp;</div>
            <!--这里是添加联系方式-->
      <div>
      <table border="0" cellpadding="0" cellspacing="0" style="width: 751px"class="one_table">
          <tr>
              <td align="center" bgcolor="#f7f7f7" colspan="2" >
                  <strong>联系方式确认</strong></td>
          </tr>

    
    <tr>
        <td align="right" bgcolor="#F7F7F7" style="height: 48px; width: 92px;">
            <span class="hong">*</span> <strong>公司名称：</strong></td>
        <td align="left" style="height: 48px; width: 638px;">
            <asp:TextBox id="txtComName" runat="server" Columns="40" Height="21px"></asp:TextBox>
            <span id="spCAComName" ></span>
            </td>
    </tr>
    <tr id="tr2" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7" style="width: 92px">
            <strong>联 系 人：</strong></td>
        <td align="left" style="width: 638px">
           <asp:TextBox id="txtLinkMan" runat="server"  Columns="40" Height="21px" ></asp:TextBox></td>
    </tr>

    <tr>
        <td align="right" bgcolor="#F7F7F7" style="width: 92px">
            <span class="hong"></span> <strong>联系电话：</strong></td>
        <td valign="top" align="left" style="width: 638px">
            <asp:TextBox ID="txtTelCountry"  runat="server" size='4' Height="21px"></asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode"  runat="server" size='7'  Height="21px"/>
            <asp:TextBox ID="txtTelNumber"  runat="server" size='18' Height="21px" />
            <span id="spTel" ></span>
        </td>
    </tr>
     <tr id="tr1" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7" style="width: 92px">
            <strong>手机：</strong></td>
        <td align="left" style="width: 638px">
           <asp:TextBox id="txtMobile" runat="server"  Columns="40" Height="21px" ></asp:TextBox>
           <span id="Span10" style="color:buttonshadow">为了方
           便联系，联系电话和手机至少填写一个</span>
           </td>
    </tr>
     <tr id="tr8" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7" style="width: 92px; height: 29px;">
            <strong>联系地址：</strong></td>
        <td align="left" style="width: 638px; height: 29px;">
            <asp:TextBox id="txtAddress" runat="server" Columns="40" Height="21px"></asp:TextBox></td>
    </tr>
     <tr id="tr5" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7" style="width: 92px; height: 29px;">
            <strong>邮编：</strong></td>
        <td align="left" style="width: 638px; height: 29px;">
           <asp:TextBox id="txtPostCode" runat="server" Columns="15" MaxLength="6" Height="21px"></asp:TextBox></td>
    </tr>
     <tr id="tr6" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7" style="width: 92px">
            <strong>网址：</strong></td>
        <td align="left" style="width: 638px">
           <asp:TextBox id="txtWebSite" runat="server" Columns="40" Height="21px"></asp:TextBox></td>
    </tr>

    <tr id="tr3" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7" style="width: 92px; height: 29px;">
            <span class="hong">*</span><strong>电子邮箱：</strong></td>
        <td align="left" style="width: 638px; height: 29px;">
            <asp:TextBox ID="txtEmail"  onchange="checkEmail();" runat="server" Height="21px" size='18' Width="233px" />
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span> 
        </td>
    </tr> 
          <tr name="trswitchpublish">
              <td align="right" bgcolor="#f7f7f7" style="width: 92px">
                 <span class="hong">*</span><strong>审核状态：</strong></td>
              <td align="left" style="width: 638px">
              	<div align="left"><span class="style4">&nbsp;
									<asp:RadioButtonList id="rblAuditing" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
										<asp:ListItem Value="0">未审核</asp:ListItem>
										<asp:ListItem Value="1">审核通过</asp:ListItem>
										<asp:ListItem Value="2">审核未通过</asp:ListItem>
									</asp:RadioButtonList> </span>
                </div>
              </td>
          </tr>
          <tr name="trswitchpublish">
              <td align="right" bgcolor="#f7f7f7" style="width: 92px; height: 22px;">
               <span class="hong">*</span><strong>评分：</strong>
              </td>
              <td align="left" style="width: 638px; height: 22px;">
              <asp:DropDownList ID="ddlSetGrade" runat="server">
                       </asp:DropDownList>
              </td>
          </tr>
          <tr name="trswitchpublish">
              <td align="right" bgcolor="#f7f7f7" style="width: 92px; height: 22px">
               <span class="hong">*</span><strong>人气：</strong>
              </td>
              <td align="left" style="width: 638px; height: 22px">
                  <asp:TextBox ID="txtHit" runat="server" Columns="15" Height="21px" MaxLength="6"></asp:TextBox></td>
          </tr>
          <tr name="trswitchpublish" style="display:none">
              <td align="right" bgcolor="#f7f7f7"style="display:none">
              </td>
              <td align="left"style="display:none">
                  <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox></td>
          </tr>
      
    <tr>


</table></div>
   <div class="mbbuttom">
<%--            <asp:ImageButton ID="IbtnSubmit" OnClientClick="return chkBtn();"  ImageUrl="../images/publish/buttom_tywftk.gif" runat="server" OnClick="IbtnSubmit_Click" />--%>
       <asp:Button ID="IbtnSubmit" CssClass="btn"  OnClientClick="return chkBtn();" OnClick="IbtnSubmit_Click" runat="server" Text="确定" /></div>
        
        </div>
          
     </div>
     </div>
      <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1384px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif" alt="Loading" />
                </div>
   </div>
    </form>
</body>
</html>
