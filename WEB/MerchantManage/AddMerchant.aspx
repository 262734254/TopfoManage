<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMerchant.aspx.cs" Inherits="MerchantManage_AddMerchant" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
 <%@ Register Src="~/Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
      <title>添加招商信息</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
 <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
  <style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:500px;}
        .content p{line-height:30px;        }
        </style>
   
        
     <script type="text/javascript" language="javascript">
function checkIndustry()
{
    var id = "<%=this.SelectIndustryControl1.ClientID %>";
    return eval(id+"_SelectIndustry.check()"); 
}

    </script>

    <script type="text/javascript" language="javascript">  
  function ConAudit(i)
{
    switch(i)
    {
        case 0:

             document.getElementById("trIsVip").className="trnone";
            document.getElementById("trHit").className = "trnone";

            break;
        case 1:

            document.getElementById("trIsVip").className="";
            document.getElementById("trHit").className = "";

            break;
        case 2:

            document.getElementById("trHit").className = "trnone";
             document.getElementById("trIsVip").className="trnone";

            break;
        default:
            break;
    }
}

      function ShowPoint(src)
{
    if(src==1)
    {
		document.getElementById("spShowPoint").style.display="";
    }
     if(src==2)
    {
		document.getElementById("spShowPoint").style.display="none";
    }
}
        function switchPublish()
        {
            var tag = document.getElementById("hdswitchpublish").value;
            var objs = document.getElementsByName("trswitchpublish");
            if(objs == null)
                return;
            var style = "";
            if(tag == 1){
                style = "trnone";  
                document.getElementById("hdswitchpublish").value = 0;
                document.getElementById("switchtext").innerHTML = '带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到完整发布</a>）</span>';
            }
            else{
                document.getElementById("hdswitchpublish").value = 1;
                document.getElementById("switchtext").innerHTML = '带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）';
            }
            //alert(objs.length);
            for(var i=0; i <objs.length; i++)
            {
                objs[i].className = style;
            }
        }
            function GetMessageLength(str)    {        var oEditor = FCKeditorAPI.GetInstance(str) ;        var oDOM = oEditor.EditorDocument ;        var iLength ;        if (document.all)        // If Internet Explorer.        {            iLength = oDOM.body.innerText.length ;        }        else                    // If Gecko.        {            var r = oDOM.createRange() ;            r.selectNodeContents( oDOM.body ) ;            iLength = r.toString().length ;        }    //oEditor.InsertHtml('')    return iLength    }  
        function TopFo()
        {
          var c="";

           var ZoneId= "<%=this.ZoneId.ClientID %>";//所属区域
           var Zone = document.getElementById(ZoneId);
           var txtZoneAbout = "<%=this.txtZoneAbout.ClientID %>";//招商项目介绍
           var zone=document.getElementById(txtZoneAbout);  
           var IndustryId= "<%=this.IndustryId.ClientID %>";//所属行业
           var Industry = document.getElementById(IndustryId);
           var rdlTerm= "<%=this.rdlTerm.ClientID %>";//有效期隐藏域
           var Term = document.getElementById(rdlTerm);
           var rdlValiditeTermID = "<%=this.rdlValiditeTerm.ClientID %>";//项目有效期
          if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
            {
               alert("项目有效期不能为空！");
               Term.focus();
               return false;
            }
//         if(document.getElementById("ZoneSelectControl1_hideProvince").value=="")
//	        {
//	          alert("请选择所属区域");
//	          Zone.focus();
//	          return false;
//	        }
	       if(document.getElementById("SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	        {
	         alert("请选择所属行业");
	         Industry.focus();
	         return false;
	        }
         //投资额
           var Cap = document.getElementById("txtCapitalTotal"); 
             if(Cap.value!="")
            {
                var filter = /^\d+(\.\d+)*$/;
                if( !filter.test(Cap.value))
                {
                   alert("总投资额必须为数字，请正确填写！");
                   Cap.focus();
                   return false;
                }
            }
            if(Cap.value=="")
            {
             alert("总投资额不能为空！");
               Cap.focus();
               return false;
            }
              if(GetMessageLength("<%=txtZoneAbout.ClientID %>")=='0')
               {
                  alert("请输入招商简介！");
                 return false;
               }   
          //招商标题
           var Merchan=document.getElementById("txtMerchantTopic");
             if(Merchan.value=="")
   	        {
   	           alert("请输入招商标题");
   	           Merchan.focus();
   	           return false;
   	        }

//         //电子邮箱
//           var email = document.getElementById("txtEmail");
//   	        if(email.value=="")
//   	        {
//   	           alert("请输入电子邮箱");
//   	           email.focus();
//   	           return false;
//   	        } 
//   	        else  
//   	        {
//   	         
//   	            var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
//   	            if(!filtEmial.test(trim(email.value)))
//   	            {
//           	         alert("电子邮箱格式不正确，请重新输入");
//           	         email.focus();
//           	         return false;
//           	     }
//           	    
//   	        }
   	          var CompanyName = document.getElementById("txtCompanyName");
   	        if(CompanyName.value=="")
   	        {
   	           alert("请输入招商机构名称");
   	           CompanyName.focus();
   	           return false;
   	        } 
   	           var Name = document.getElementById("txtName");
   	        if(Name.value=="")
   	        {
   	           alert("请输入联系人");
   	           Name.focus();
   	           return false;
   	        } 
   	       
   	        

            //电话号码
            var telzone = document.getElementById("txtTelZoneCode");
            var telNumber=document.getElementById("txtTelNumber");
           //手机号码
            var telMobile=document.getElementById("txtMobile");
           if(telNumber.value.length=="" && telMobile.value.length=="")
        
            {
              alert("手机和固定电话请至少填写一项");
                 telMobile.focus();
                return false;
            
            }
          
          if(telMobile.value!="")
            {
           
                var filtMobile = /^(13|15|18)[0-9]{9}$/;
                if(!filtMobile.test(trim(telMobile.value)))
                {
                    alert("请正确填写手机号码");
                    telMobile.focus();
                    return false;
                }
            }
       
      document.getElementById("imgLoding").style.display="";


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
           //////////////////////
//去除字符串两边空格的函数
//参数：mystr传入的字符串
//返回：字符串mystr
function trim(mystr){
while ((mystr.indexOf(" ")==0) && (mystr.length>1)){
mystr=mystr.substring(1,mystr.length);
}//去除前面空格
while ((mystr.lastIndexOf(" ")==mystr.length-1)&&(mystr.length>1)){
mystr=mystr.substring(0,mystr.length-1);
}//去除后面空格
if (mystr==" "){
mystr="";
}
return mystr;
}


//替换掉字符串空格
function repl(obj)
{
    if(obj.value.length>0)
    {
        obj.value=trim(obj.value);
    }
}
//////////////////////////
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div  id="switchtext" style="text-align:left">
          <div class="title">
                <h2>
                    <p>
                        <span><b>招商信息添加</b></span></p>
                </h2>
                  <h2>
                    <p>
                        <span><b><a href="MerchantManage.aspx">招商信息管理</a></b></span></p>
                </h2>
            </div></div>
       <table  border="0" cellpadding="0" cellspacing="0" width="100%"  class="one_table"> 
             <tr>
                <td bgcolor="#F7F7F7">
                  <span class="hong">* </span>  <strong>项目标题：</strong></td>
                    <td align="left">
                    <asp:TextBox ID="txtMerchantTopic"   runat="server" Width="326px"></asp:TextBox>
                    <span id="spMerchantTopic"></span>
                </td>
            </tr>

            <tr>
                <td bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>所属区域：</strong></td>
                 <td align="left" >
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    <input type="text" runat="server" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>所属行业：</strong></td>
                  <td align="left" >
                <input type="text" runat="server" id="IndustryId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF; height:2px;" />
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#F7F7F7">
                  <span class="hong">*</span>   <strong>总投资：</strong></td>
              <td align="left" >
                    <asp:DropDownList ID="ddlCapitalCurrency" runat="server">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCapitalTotal"   runat="server"  Width="75px" MaxLength="10" onkeyup="value=value.replace(/[^\d]/g,'')" ></asp:TextBox>
                    万元 <span id="spCapitalTotal"></span>
                </td>
            </tr>
           <tr>
               <td bgcolor="#f7f7f7">
                 <span class="hong">*</span>   <strong>回报率：</strong></td>
               <td align="left">
                 <asp:TextBox ID="txtHuiBao" runat="server" Width="71px"  MaxLength="4" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox>%
               </td>
           </tr>
              <tr>
                <td bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>项目有效期：</strong></td>
                <td align="left" >
                <input id="Vaildite" type="hidden" name="Vaildite" visible="false" />
                     <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                      </asp:RadioButtonList>
                      <input type="text" runat="server" id="rdlTerm" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                     <span id="spValiditeTerm"></span>
                          
             </td>
            </tr>
              
            <tr>
                <td bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>招商项目简介：</strong>
                    <br /></td>
                <td  align="left">
                      <FCKeditorV2:FCKeditor ID="txtZoneAbout" Height="300" BasePath="~/Vfckeditor/"  runat="server">
                    </FCKeditorV2:FCKeditor><span id="content"></span>

                  
                        <span id="spZoneAboutB"></span>
                           
                </td>
            </tr>
            <!--以下是要添加的部分-->
            <!--结束处-->
            <tr >
                <td bgcolor="#F7F7F7">
                    <strong>上传图片：</strong></td>
                <td align="left" >
                    <uc3:FilesUploadControl ID="FilesUploadControl1" InfoType="Merchant"
                        runat="server" />
                </td>
            </tr>
    <tr>
        <td bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>招商机构名称：</strong></td>
        <td align="left" >
            <asp:TextBox ID="txtCompanyName"   runat="server" Width="324px" />
            <span id="spCAComName" ></span>
            </td>
    </tr>
    <tr>
        <td bgcolor="#F7F7F7"> 
            <span class="hong">*</span> <strong>联系人：</strong></td>
        <td align="left" >
          
            <asp:TextBox id="txtName"  width="127px" runat="server" />
        </td>
    </tr>
    <tr>
        <td bgcolor="#F7F7F7">
             <strong>联系电话：</strong></td>
        <td align="left" >
   <asp:TextBox ID="txtTelCountry" runat="server" size='4'>+86</asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode"  runat="server" size='7' />
            <asp:TextBox ID="txtTelNumber" runat="server" size='18' />
             <span class="f_gray">（如：+86-0755-89805588）</span>
            <span id="spTel" ></span>
          <%--  手机<asp:TextBox id="txtMobile"  width="127px" runat="server" /><span>（固定电话或手机至少填写一项）</span>       --%>
        </td>
    </tr>
      <tr>
        <td bgcolor="#F7F7F7" style="height: 24px">
            <span class="hong">*</span><strong >手机号码：</strong></td>
        <td align="left" style="height: 24px" >
            <asp:TextBox id="txtMobile"  width="127px" runat="server" /><span>（固定电话或手机至少填写一项）</span>  
        </td>
    </tr>
    <tr>
        <td bgcolor="#F7F7F7">
           <span class="hong">*</span> <strong >电子邮箱：</strong></td>
        <td  align="left" >
            <asp:TextBox ID="txtEmail"  runat="server" size='18' Width="269px" />
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span> 
        </td>
    </tr>
   
    
    <tr>
        <td bgcolor="#F7F7F7">
            <strong >联系地址：</strong></td>
      <td align="left" >
            <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" />      
            </td>            
    </tr>
            <tr>
                <td bgcolor="#F7F7F7" style="height: 20px" >
                    <span class="hong">*</span> <strong>审核结果：</strong></td>
                <td align="left" style="height: 20px" >
                    &nbsp;<asp:RadioButton ID="rdAudit" GroupName="rblAuditingStatus" runat="server"
                        onclick="ConAudit(0)" Text="未审核" />
                    <asp:RadioButton ID="rdPass" GroupName="rblAuditingStatus" runat="server" onclick="ConAudit(1)"
                        Text="审核通过" />
                    <asp:RadioButton ID="rdNopass" GroupName="rblAuditingStatus" runat="server" onclick="ConAudit(2)"
                        Text="审核未通过" /></td>
            </tr>
            <tr id="trHit">
                <td bgcolor="#F7F7F7">
                    <span class="hong">*</span><strong>点击数：</strong></td>
                 <td align="left">
                    <asp:TextBox ID="tbHits" runat="server" Width="94px" onkeyup="value=value.replace(/[^\d]/g,'') ">50</asp:TextBox></td>
            </tr>
               <tr id="trFee" runat="server">
                        <td bgcolor="#f7f7f7" style="height: 24px; width: 146px;">
                            <span class="hong">* </span><strong>资源选项：</strong></td>
                        <td align="left" style="height: 24px">
                            <asp:RadioButton ID="rbFree" Text="免费" runat="server" onclick="ShowPoint(2)" GroupName="rsSystem">
                            </asp:RadioButton>
                            <asp:RadioButton ID="chkIsPoint" runat="server" onclick="ShowPoint(1)" Text="收费"
                                GroupName="rsSystem"></asp:RadioButton>
                            <span id="spShowPoint" style="display: none" runat="server">
                                <asp:TextBox ID="txtPointCount" runat="server" Width="88px" MaxLength="5" onkeyup="value=value.replace(/[^\d]/g,'') ">0</asp:TextBox>元</span></td>
                </tr>
            <tr id="trIsVip"  >
                <td bgcolor="#F7F7F7" >
                    <strong>推荐理由</strong>：
                </td>
                <td >
                       <table  border="0" cellpadding="0" cellspacing="0" width="100%"  class="one_table"> 
                        <tr>
                            <td align="left">
                                <input type="checkbox" runat="server" id="chkIsVip" />设置为重大投资商机
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:TextBox ID="txtIsVipAbout" runat="server" Height="46px" TextMode="MultiLine"
                                    Width="339px"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr>
              <td align="center"  colspan="2" style="height: 8px">
          <asp:Button ID="btnUpdate" runat="server" Width="144px" Text="添加" OnClientClick="return TopFo();"  OnClick="btnUpdate_Click" /></td>
          </tr> 
        </table>
          

<div id="imgLoding" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: -1px; left: 0px; width: 100%;
   height:1519px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif"  alt="Loading" />
                </div>
        </div>
    </form>
</body>
</html>

