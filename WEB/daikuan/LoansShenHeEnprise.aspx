<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoansShenHeEnprise.aspx.cs" Inherits="daikuan_LoansShenHeEnprise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Src="../Controls/CapitalAddressInfo.ascx" TagName="CapitalAddressInfo"
    TagPrefix="uc4" %>
<%@ Register Src="../Controls/ZoneMoreSelectControl.ascx" TagName="ZoneMoreSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>贷款审核</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <script  type="text/javascript" src= "../js/JScriptloans.js" language ="javascript"></script>
    <script language ="javascript" type="text/javascript" >
    function changgereson(divid)
    {
      if(divid==0)
      {
       document.getElementById("shenhe").style.display="none";
       document.getElementById("tuijian").style.display="none";
      }
      if(divid==1)
      {
       document.getElementById("tuijian").style.display="block";
        document.getElementById("shenhe").style.display="none";
      }
      if(divid==3)
      {
         document.getElementById("tuijian").style.display="none";
       document.getElementById("shenhe").style.display="block";
      }
      if(divid==5)
      {
         document.getElementById("tuijian").style.display="none";
       document.getElementById("shenhe").style.display="none";
      }
    }
           function checkallloansshenhes()
   {
  if(document.getElementById ("txtCapitalTitle").value.length==0)
   {
     document.getElementById ("showtitle").innerHTML="*";
     document.getElementById ("showtitle").style .display ="inline";
     document.getElementById ("txtCapitalTitle").focus();
     return false;
   }
   if(document.getElementById ("txtCapitalMoney").value.length==0)
   {
     document.getElementById ("showmoney").innerHTML="*";
     document.getElementById ("showmoney").style .display ="inline";
     document.getElementById ("txtCapitalMoney").focus();
     return false;
   }
    if(document.getElementById ("txttitle").value.length==0)
   {
     document.getElementById ("showtitles").innerHTML="*";
     document.getElementById ("showtitles").style .display ="inline";
     document.getElementById ("txttitle").focus();
     return false;
   }
   if(document.getElementById ("txtkeywords").value.length==0)
   {
     document.getElementById ("showkeywords").innerHTML="*";
     document.getElementById ("showkeywords").style .display ="inline";
     document.getElementById ("txtkeywords").focus();
     return false;
   }
      if(document.getElementById ("txtdescript").value.length==0)
   {
     document.getElementById ("showdescripta").innerHTML="*";
     document.getElementById ("showdescripta").style .display ="inline";
     document.getElementById ("txtdescript").focus();
     return false;
   }
   
       if(document.getElementById ("txtCapitalMoney").value.substring(0,1)=="0"&&document.getElementById ("txtCapitalMoney").value.length>0)
   {
      document.getElementById ("showmoney").innerHTML="无效的数据";
     document.getElementById ("showmoney").style .display ="inline";
     document.getElementById ("txtCapitalMoney").focus();
     return false;

   }
      if(document.getElementById ("txtCapitalIntent").value.length==0)
   {
     document.getElementById ("showdescript").innerHTML="*";
     document.getElementById ("showdescript").style .display ="inline";
     document.getElementById ("txtCapitalIntent").focus();
     return false;
   }
        if(document.getElementById ("txtenpricename").value.length==0)
     {
       document.getElementById ("showenpricename").innerHTML="*";
       document.getElementById ("showenpricename").style .display ="inline";
       document.getElementById ("txtenpricename").focus();
       return false;
      }
        if(document.getElementById ("txtcontactsName").value.length==0)
     {
       document.getElementById ("showname").innerHTML="*";
       document.getElementById ("showname").style .display ="inline";
       document.getElementById ("txtcontactsName").focus();
       return false;
      }

   
   if(document.getElementById ("txtcontactsphone").value.length==0&&document.getElementById ("txtcontactsTel").value.length==0)
   {
     document.getElementById ("showtel").innerHTML="*";
     document.getElementById ("showtel").style .display ="inline";
      document.getElementById ("txtcontactsTel").focus();
     return false;
   }
   if(document.getElementById ("txtcontactsphone").value.length==0&&document.getElementById ("txttel1").value.length==0)
   {
     document.getElementById ("showtel").innerHTML="*";
     document.getElementById ("showtel").style .display ="inline";
      document.getElementById ("txttel1").focus();
     return false;
   }
      if(document.getElementById ("txtcontactsphone").value.length==0&&document.getElementById ("txttel2").value.length==0)
   {
     document.getElementById ("showtel").innerHTML="*";
     document.getElementById ("showtel").style .display ="inline";
      document.getElementById ("txttel2").focus();
     return false;
   }
         if(document.getElementById ("txtcontactsphone").value.length>0&&document.getElementById ("txtcontactsphone").value.length<11)
   {
     document.getElementById ("showMoblie").innerHTML="手机号码不正确";
     document.getElementById ("showMoblie").style .display ="inline";
     document.getElementById ("txtcontactsphone").focus();
     return false;
   }
       var s=document.getElementById("txtcontactsemail").value;
      
	   if((s.charAt(0)=="@")||(s.charAt(0)=="."))
	   { 
	   	document.getElementById ("showemail").innerHTML="电子邮件的格式不能以@或者.开头!";
        document .getElementById ("showemail").style.display ="inline";
        document.getElementById ("txtcontactsemail").focus();
		return false;
	   }
	  if(s.length==0)
         {
		 document.getElementById ("showemail").innerHTML="*";
          document .getElementById ("showemail").style.display ="inline";
          document.getElementById ("txtcontactsemail").focus();
		 return false;
		 }
	  if(s.indexOf("@",0)==-1)
	     {
	      document.getElementById ("showemail").innerHTML="电子邮件格式不正确\n必须包含@符号!";
          document .getElementById ("showemail").style.display ="inline";
          document.getElementById ("txtcontactsemail").focus();
		  return false;
	     }
	if(s.indexOf(".",0)==-1)
	  {
	  document.getElementById ("showemail").innerHTML="电子邮件格式不正确\n必须包含.符号!";
      document .getElementById ("showemail").style.display ="inline";
      document.getElementById ("txtcontactsemail").focus();
	  return false;
	  }
	if(escape(s).indexOf("%u")!=-1)
      {
      document.getElementById ("showemail").innerHTML="邮件中不能包含汉字";
      document .getElementById ("showemail").style.display ="inline";
      document.getElementById ("txtcontactsemail").focus();
      return false ;

    }

   else{

     document.getElementById("imgLoding").style.display="";
    return true;
    }
    }
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <div >
 
        <div>
            带 <span style ="color:Red">*</span> 的为必填项
        </div>
		 <div >  </div>
		   <div > </div>
        <div  runat ="server" id="switchtext">
            企业贷款审核</div>
        <table class="one_table" style="width: 751px" >
            <tr>
                <td>
                    <span style ="color:Red">*</span> <strong>贷款标题：</strong></td>
                <td>
                    <strong>
                        <asp:TextBox ID="txtCapitalTitle" runat="server"
                         onblur="outpostcode(this,'showtitle')"   Width="299px"></asp:TextBox></strong>&nbsp;<div id="showtitle" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
                <tr>
                <td >
                    <span style ="color:Red" >*</span> <strong>页面标题：</strong></td>
                <td width="625">
                    <strong>
                        <asp:TextBox ID="txttitle" runat="server"
                         onblur="outpostcode(this,'showtitles')"   Width="299px" ></asp:TextBox></strong>&nbsp;<div id="showtitles" style ="display:none; color:Red ; font-size:12px">*</div>(页面标题如：中国招商投资网)
                </td>
            </tr>
                            <tr>
                <td >
                    <span style ="color:Red">*</span> <strong>关键字：</strong></td>
                <td >
                    <strong>
                        <asp:TextBox ID="txtkeywords" runat="server"
                         onblur="outpostcode(this,'showkeywords')"   Width="299px"></asp:TextBox></strong>&nbsp;<div id="showkeywords" style ="display:none; color:Red ; font-size:12px">*</div>(关键字如：招商投资融资)
                </td>
            </tr>
                            <tr>
                <td >
                    <span style ="color:Red">*</span> <strong>描述：</strong></td>
                <td >
                    <strong>
                        <asp:TextBox ID="txtdescript" runat="server"
                         onblur="outpostcode(this,'showdescripta')"   Width="299px"></asp:TextBox></strong>&nbsp;<div id="showdescripta" style ="display:none; color:Red ; font-size:12px">*</div>(描述：招商投资网)
                </td>
            </tr>
            <tr>
                <td >
                    <span style ="color:Red">*</span> <strong>地域：</strong></td>
                <td>
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    <input type="text" runat="server" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                    <span id="spCapitalType"></span>
                </td>
            </tr>
            <tr>
                <td >
                    <span style ="color:Red">*</span> <strong>贷款总金额：</strong></td>
                <td>
                    <asp:TextBox ID="txtCapitalMoney" onblur="outmoney(this,'showmoney')"  onkeydown="return checkinputshuzi(this,9,'showmoney')" onkeyup="return checkinputshuzi(this,9,'showmoney')" runat="server"></asp:TextBox> &nbsp;<div id="showmoney" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
            <tr>
                <td>
                    <span style ="color:Red" >* </span><strong>贷款期限：</strong></td>
                <td>
                  <input id="Vaildite" type="hidden" name="Vaildite" visible="false" />
                     <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                      </asp:RadioButtonList>
                      <input type="text" runat="server" id="rdlTerm" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                     <span id="spValiditeTerm"></span>
                          
                </td>
            </tr>
          
           <tr>
                <td>
                    <span style ="color:Red">* </span><strong>担保方式：</strong></td>
                <td>
                    <asp:RadioButtonList ID="radiodanbao" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">担保</asp:ListItem>
                        <asp:ListItem Value="1">抵押</asp:ListItem>
                        <asp:ListItem Value="2">信用</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
           <tr>
                <td >
                    <span style ="color:Red">* </span><strong>项目有效期限：</strong></td>
                <td>
                  <input id="Hidden1" type="hidden" name="Vaildite" visible="false" />
                     <asp:RadioButtonList ID="rdlValiditeSystem" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                      </asp:RadioButtonList>
                      <input type="text" runat="server" id="Text1" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />

                </td>
            </tr>
            <tr>
                <td>
                    <span style ="color:Red">*</span> <strong>贷款用途及还款说明：</strong>
                    <br /></td>
                <td>
                    <label>
                        <textarea  onblur="outpostcode(this,'showdescript')"  id="txtCapitalIntent"  runat="server"
                            cols="50" rows="10" style="width: 558px; height: 200px"></textarea>
                    </label>
                    &nbsp;<div id="showdescript" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
                             <tr>
                <td >
                    <strong>联系方式：</strong></td>
                <td >
                    &nbsp;                </td>
            </tr>
                       <tr>
                <td >
                    <span style ="color:Red">*</span><strong>企业名称：</strong></td>
                <td >
                    <strong>
                        <asp:TextBox ID="txtenpricename" onblur="outpostcode(this,'showenpricename')" runat="server"
                            Width="299px"></asp:TextBox></strong> &nbsp;<div id="showenpricename" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
            <tr>
                <td >
                    <span style ="color:Red">*</span><strong>联系人：</strong></td>
                <td>
                    <strong>
                        <asp:TextBox ID="txtcontactsName" onblur="outpostcode(this,'showname')" runat="server"
                            Width="299px"></asp:TextBox></strong> &nbsp;<div id="showname" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
            <tr>
                <td >
                    <span ></span> <strong>手机：</strong></td>
                <td>
                    <asp:TextBox ID="txtcontactsphone"  onblur="outphone(this,'showMoblie')" onkeydown="return checkinputphone(this,11,'showMoblie')" onkeyup="return checkinputphone(this,11,'showMoblie')" runat="server"
                            Width="299px" ></asp:TextBox>
                    &nbsp;<div id="showMoblie" style ="display:none; color:Red ; font-size:12px">请输入数字</div>
                </td>
            </tr>
            <tr>
                <td>
                    <span style ="color:Red">*</span> <strong>联系电话：</strong></td>
                <td>
                    <asp:TextBox ID="txtcontactsTel" MaxLength="4" Width ="80px"  onkeyup="value=value.replace(/[^\d]/g,'') " runat="server"></asp:TextBox>-<asp:TextBox ID="txttel1" MaxLength ="8"  Width ="115px" onkeyup="value=value.replace(/[^\d]/g,'') " runat="server"></asp:TextBox>-<asp:TextBox ID="txttel2" MaxLength ="4" onkeyup="value=value.replace(/[^\d]/g,'') "  Width ="80px" runat="server"></asp:TextBox> &nbsp;(格式如:0755-89805588-8028)<div id="showtel" style ="display:none; color:Red ; font-size:12px">请输入数字</div><br/><font color="red" >（手机，电话至少填一个）</font>

                </td>
            </tr>
            <tr>
                <td>
                    <span style ="color:Red">* </span><strong>邮件：</strong></td>
                <td>
                <asp:TextBox ID="txtcontactsemail" onblur="outemail(this,'showemail')"  runat="server"
                            Width="299px"></asp:TextBox>&nbsp;<div id="showemail" style ="display:none; color:Red ; font-size:12px">请输入数字</div>
                </td>
            </tr>
            <tr>
                <td>
                    <span></span><strong>
                        公司地址：</strong></td>
                <td>
                <asp:TextBox ID="txtcontactsaddress" runat="server"
                            Width="299px"></asp:TextBox>
                </td>
            </tr>
                     <tr>
                <td>
                    <span></span><strong>审核：</strong></td>
                <td>
                <input  type="radio" id="shen" name="shenz" runat ="server" onclick="changgereson('0')" value ="0"/>未审核 <input  type="radio" id="shens" name="shenz" runat ="server" onclick="changgereson('1')" value ="1"/>审核 <input id="shensss" name="shenz" runat ="server"  type="radio" onclick="changgereson('3')" value ="3"/>审核未通过<input id="shenssss" name="shenz" runat ="server"  type="radio" onclick="changgereson('5')" value ="5"/>已删除
                </td>
            </tr>
               <tr id="tuijian"  style ="display:none";  runat ="server">
                <td >
                    <span></span><strong>是否推荐：</strong></td>
                <td >
                    <asp:RadioButtonList ID="radiotuijian" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">不推荐</asp:ListItem>
                        <asp:ListItem Value="1">推荐</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
               <tr id="shenhe"  style ="display:none";  runat ="server">
                <td>
                    未通过审核原因：</td>
                <td>
                                      <table border="0" cellpadding="0" cellspacing="0" width="100%" class="one_table">
                            <tr>
                                <td bgcolor="#f7f7f7">
                                    <asp:TextBox ID="txtreson" runat="server" Width="334px" Height="92px" TextMode="MultiLine"></asp:TextBox><br />
                                    <span class="hui">原因描述尽量简单、明确，不超过20个汉字 <a href="javascript:;" onclick="document.getElementById('txtreson').value='';">
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
           document.getElementById("txtreson").value=str;
        }
                        </script>
                </td>
            </tr>
          <tr>
          <td colspan="2" align="center"> &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClientClick="return checkallloansshenhes()"  CssClass="btn" OnClick="btnUpdate_Click" Text="审 核" />&nbsp;&nbsp; <input type="button" id="Button3" onclick="history.back();" value="返 回" class="btn" />
</td>
          </tr>
        </table>

    </div>
    </form>
     <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1135px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif"alt="Loading" />
                </div>
   </div>
</body>
</html>
