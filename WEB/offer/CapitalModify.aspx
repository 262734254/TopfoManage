<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapitalModify.aspx.cs" ValidateRequest="false"
    Inherits="offer_CapitalModify" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="Controls/ZoneSelect.ascx" TagName="ZoneSelect" TagPrefix="uc1" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>审核投资信息</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:500px;}
        .content p{line-height:30px;        }
        </style>

    <script type="text/javascript">
     function ConAudit(i)
{
    switch(i)
    {
        case 0:
   
            document.getElementById("trAuditingRemark").className = "trnone";
            document.getElementById("trFeedbackStatus").className = "trnone";
            document.getElementById("trFee").className = "trnone";
            document.getElementById("trHit").className = "trnone";
            break;
            
        case 1:
  
            document.getElementById("trAuditingRemark").className = "trnone";
            document.getElementById("trFeedbackStatus").className = "trnone";
            document.getElementById("trFee").className = "";
            document.getElementById("trHit").className = "";
            break;
        case 2:
     
            document.getElementById("trAuditingRemark").className = "";
            document.getElementById("trFeedbackStatus").className = "";
            document.getElementById("trFee").className = "trnone";
            document.getElementById("trHit").className = "trnone";
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
function checkCooperationDemand()
{
    var chkLstCooperationDemandID = "<%=this.chkLstCooperationDemand.ClientID %>";
    
    if(GetCheckBoxListCheckNum(chkLstCooperationDemandID) <= 0){
        document.getElementById("spCooperationDemand").innerHTML = "请选择投资方式";
        document.getElementById("spCooperationDemand").className = "noteawoke";
        document.getElementById(chkLstCooperationDemandID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spCooperationDemand").innerHTML = "";
        document.getElementById("spCooperationDemand").className = "";
		return true;
	}
}
  function chkpost()
   {  

       
          var c="ctl00_ContentPlaceHolder1_";
            var kj="";
            var zt="";
            var obj="";
                 //网页标题
           var Dtitle=document.getElementById("txtWtitle");
             if(Dtitle.value=="")
   	        {
   	           alert("请输入网页标题");
   	           Dtitle.focus();
   	           return false;
   	        }
   	                 //网页描述
           var DDes=document.getElementById("txtDescript");
             if(DDes.value=="")
   	        {
   	           alert("请输入网页描述");
   	           DDes.focus();
   	           return false;
   	        }
   	                 //关键字
           var WKeWord=document.getElementById("txtKeord");
             if(WKeWord.value=="")
   	        {
   	           alert("请输入网页关键字");
   	           WKeWord.focus();
   	           return false;
   	        }          
            //标题
            var ProjectName="txtCapitalName";
            if(trim(document.getElementById(ProjectName).value)=="")
            {
                alert("项目标题不能为空...");
                document.getElementById(ProjectName).focus();
                return false;
            }
        //行业
	   if(document.getElementById("SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	   {     
	   
	         alert("请选择所属行业...");
	         document.getElementById("SelectIndustryControl1_sltIndustryName_Select").focus();
	         return false;
	   }
        //地域
	   if(document.getElementById("ZoneMoreSelectControl1_sltZone_Select").options.length==0)
	   {     
	   
	         alert("请选择所属地域最多添加5个..");
	         document.getElementById("ZoneMoreSelectControl1_sltZone_Select").focus();
	         return false;
	   }    
	         //借款金额
            if(!ChkRbl("<%=this.rblCurreny.ClientID %>","单项目可投资金额"))
            {
             document.getElementById("touzje").focus();  
                return false ;
            }
               
         //   意向有效期限
           if(!ChkCbl("<%=this.rdlValiditeTerm.ClientID %>","意向有效期限"))
            {
              document.getElementById("ValiditeTerm").focus();  
                return false ;
            }
   
            //投资意向详细说明
                var ProjectName1="txtCapitalIntent";
            if(trim(document.getElementById(ProjectName1).value)=="")
            {
                alert("投资意向详细说明不能为空...");
                document.getElementById(ProjectName1).focus();
                return false;
            }
            
       
       if(document.getElementById("txtGovName").value=="")
	    {
	       alert("机构名称不能为空..");
	       document.getElementById("txtGovName").focus();
	       return false;
	    }
         if(document.getElementById("txtLinkMan").value=="")
	    {
	       alert("联系人不能为空..");
	       document.getElementById("txtLinkMan").focus();
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
          
        if(document.getElementById("txtMobile").value.length!="")
        {
           var filtMobile = /^(13|15|18)[0-9]{9}$/;
            if(!filtMobile.test(trim(document.getElementById("txtMobile").value)))
            {
                alert("请正确填写手机号码");
                document.getElementById("txtMobile").focus();
                return false;
            }
        }
        
                var objWebSite = document.getElementById("txtWebSite").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(trim(objWebSite)))
             { 
                alert("网址填写不正确!");
			    document.getElementById("txtWebSite").focus();
                return false;
             }
		}
//        if(document.getElementById("txtEmail").value=="")
//        {
//           alert("请输入电子邮箱");
//           document.getElementById("txtEmail").focus();
//           return false;
//        } else  
//        {
//            var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
//            if(!filtEmial.test(trim(document.getElementById("txtEmail").value)))
//            {
//       	         alert("电子邮箱格式不正确，请重新输入");
//       	         document.getElementById("txtEmail").focus();
//       	         return false;
//       	     }
//        }
      


        
        document.getElementById("imgLoding").style.display="";



   }
   
    //---------------------------公用，单选框的判断----------------------
    function ChkRbl(kjID,kjName)
    {
        var kjVal=kjID.replace(/_/g,"$");
        if(GetCheckNum(kjVal)<=0)
        {
            alert("请选择"+kjName);
            document.getElementById(kjID).focus();
            return false;
        }
        else 
        {
            return true;
        }
    }
    function checkValiditeTerm()
{
    var rdlValiditeTermID = "<%=this.rdlValiditeTerm.ClientID %>";
    var rdlValiditeTermIDName = rdlValiditeTermID.replace(/_/g,"$");
    if(GetCheckNum(rdlValiditeTermIDName) <= 0){
    
        document.getElementById(rdlValiditeTermID).focus();
		return false;
	}
	else
	{
	 
		return true;
	}
}
    function GetCheckNum(checkobjectname)
    {
	    var truei2 = 0;
	    var checkobject = document.getElementsByName(checkobjectname);
    //	var checkobject = eval("document.all." + checkobjectname + "");
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
    //----------------------END-----------------------------------
   

    //-------------------公用 ，选择checkbox------------------------
    function ChkCbl(kjID,kjName)
    {
        if(GetCheckBoxListCheckNum(kjID)<=0)
        {
            alert("请选择"+kjName);
            document.getElementById(kjID).focus();
            return false;
        }
        else
        {
            return true;
        }
    }
    function GetCheckBoxListCheckNum(checkobjectid)
    {
        var selectedItemCount = 0;
        var liIndex = 0;
        var currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
        while (currentListItem != null)
        {
            if (currentListItem.checked) selectedItemCount++;
            liIndex++;
            currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
        }
        return selectedItemCount;
    }
    //-------------------------------END----------------------------------
    
    //判断多少个汉字,限制汉字
    function checkByteLength(str,minlen,maxlen) 
    {
	if (str == null) return false;
	var l = str.length;
	var blen = 0;
	for(i=0; i<l; i++) {
		if ((str.charCodeAt(i) & 0xff00) != 0) {
			blen ++;
		}
		blen ++;
	}
	if (blen > maxlen || blen < minlen) {
		return false;
	}
	return true;
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
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <div id="switchtext" style="text-align: left">
                    <div class="title">
                        <h2>
                            <p>
                                <span><b><a href="">投资信息审核</a></b></span></p>
                        </h2>
                        <h2>
                            <p>
                                <span><b><a href="CapitalManage.aspx">投资信息管理</a></b></span></p>
                        </h2>
                    </div>
                </div>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="one_table">
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">* </span><strong>网页标题：</strong>
                    </td>
                    <td align="left" style="color: #000000">
                        <asp:TextBox ID="txtWtitle" runat="server" Columns="50" Width="326px"></asp:TextBox>
                        （如：政府招商详情页-中国招商投资网）</td>
                </tr>
                <tr style="color: #000000">
                    <td bgcolor="#f7f7f7" style="height: 24px">
                        <span class="hong">* </span><strong>网页关键字：</strong>
                    </td>
                    <td align="left" style="height: 24px">
                        <asp:TextBox ID="txtKeord" runat="server" Columns="50" Width="326px"></asp:TextBox>
                        （如：招商，投资，融资）</td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">* </span><strong>网页描述：</strong>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDescript" runat="server" Columns="50"></asp:TextBox>
                        （如：中国招商投资网）</td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7" style="height: 28px">
                        <span class="hong">*</span><strong>投资需求标题：</strong></td>
                    <td align="left" style="height: 28px">
                        <asp:TextBox ID="txtCapitalName" runat="server" Height="20px" Width="266px"></asp:TextBox>
                        <span id="spCapitalName">请正确填写标题，30字以内</span> <span class="f_gray"></span>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span><strong>拟投资行业：</strong></td>
                    <td align="left">
                        <uc3:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span><strong>拟投向区域：</strong></td>
                    <td align="left">
                        <uc1:ZoneSelect ID="ZoneMoreSelectControl1" runat="server"></uc1:ZoneSelect>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span><strong>项目可投资金额：</strong></td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblCurreny" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        </asp:RadioButtonList><input name="ZoneId" type="text" id="touzje" style="width: 0;
                            border-color: #FFFFFF; border: 1px solid #FFFFFF" />
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span><strong>投资方式：</strong></td>
                    <td align="left">
                        <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" /><span id="spCooperationDemand"></span>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span> <strong>意向有效期限：</strong></td>
                    <td align="left">
                        <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                        <input name="ZoneId" type="text" id="ValiditeTerm" style="width: 0; border-color: #FFFFFF;
                            border: 1px solid #FFFFFF" />
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                  <strong>投资回报率：</strong>  
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtHBao" runat="server" Width="63px" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox>%</td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span> <strong>投资意向详细说明：</strong></td>
                    <td align="left">
                        <%--   <CE:Editor ID="txtCapitalIntent" AutoConfigure="Minimal" SecurityPolicyFile="Admin.config" Width="540" Height="266px" runat="server"></CE:Editor>
                    <%--    <textarea id="txtCapitalIntent" runat="server" cols="50" rows="10" style="width: 558px; height: 204px"></textarea>--%>
                        <FCKeditorV2:FCKeditor ID="txtCapitalIntent" Height="300" BasePath="~/Vfckeditor/"
                            runat="server">
                        </FCKeditorV2:FCKeditor>
                        <span id="content"></span><span id="spCapitalIntent"></span>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7" style="height: 19px">
                        <strong>上传图片：</strong></td>
                    <td align="left" style="height: 19px">
                        <uc4:FilesUploadControl ID="FilesUploadControl1" InfoType="Capital" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span> <strong>投资机构名称：</strong></td>
                    <td align="left">
                        <asp:TextBox ID="txtGovName" Width="246px" runat="server" />
                        <span id="SpGovName"></span>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span> <strong>联系人：</strong></td>
                    <td align="left">
                        <asp:TextBox ID="txtLinkMan" Width="246px" runat="server" />
                        <span id="splinkMan"></span>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <strong>固定电话：</strong></td>
                    <td align="left">
                        <asp:TextBox ID="txtTelCountry" runat="server" size='4'>+86</asp:TextBox>
                        <asp:TextBox ID="txtTelZoneCode" runat="server" size='8' onkeyup="value=value.replace(/[^\d]/g,'') " />
                        <asp:TextBox ID="txtTelNumber" runat="server" size='8' onkeyup="value=value.replace(/[^\d]/g,'') " />
                        <span id="Span1" class="hui">（如：+86-0755-89805588）</span> <span id="spMobile"></span>
                        <span id="spMobile2"></span>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span> <strong>手机：</strong></td>
                    <td align="left">
                        <asp:TextBox ID="txtMobile" Width="127px" runat="server" />
                        <span id="spMobile1"></span>
                    </td>
                </tr>
                <tr id="trswitchpublish" name="trswitchpublish">
                    <td bgcolor="#f7f7f7">
                        <span class="hong">*</span> <strong>电子邮箱：</strong></td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" runat="server" size='18' Width="269px" />
                        <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span>
                    </td>
                </tr>
                <tr id="tr3" name="trswitchpublish3">
                    <td bgcolor="#f7f7f7">
                        <strong>投资机构地址：</strong></td>
                    <td align="left">
                        <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" /></td>
                </tr>
                <tr>
                    <td>
                        <strong>网站：</strong></td>
                    <td align="left">
                        <asp:TextBox ID="txtWebSite" runat="server" size='18' Width="269px" /></td>
                </tr>
                <tr>
                    <tr>
                        <td bgcolor="#f7f7f7">
                            <span class="hong">*</span> <strong>审核结果：</strong></td>
                        <td align="left">
                            <asp:RadioButton ID="rdAudit" GroupName="rblAuditingStatus" runat="server" onclick="ConAudit(0)"
                                Text="暂不审核" />
                            <asp:RadioButton ID="rdPass" GroupName="rblAuditingStatus" runat="server" onclick="ConAudit(1)"
                                Text="审核通过" />
                            <asp:RadioButton ID="rdNopass" GroupName="rblAuditingStatus" runat="server" onclick="ConAudit(2)"
                                Text="审核未通过" /></td>
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
                    <tr id="trFeedbackStatus" runat="server">
                        <td bgcolor="#f7f7f7">
                            <span class="hong">* </span><strong>反馈状态：</strong></td>
                        <td align="left" style="height: 45px">
                            <a href="#"></a>
                            <asp:RadioButtonList ID="rblFeedbackStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Selected="True">可修改</asp:ListItem>
                                <asp:ListItem Value="2">即将删除</asp:ListItem>
                            </asp:RadioButtonList></td>
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
                                <asp:TextBox ID="txtPointCount" runat="server" Width="88px">0</asp:TextBox>元</span></td>
                    </tr>
                    <tr id="trHit" runat="server">
                        <td bgcolor="#f7f7f7" style="height: 24px; width: 146px;">
                            <span class="hong">* </span><strong>点击数：</strong></td>
                        <td align="left" style="height: 24px">
                            <asp:TextBox ID="tbHits" runat="server" Width="73px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>设置该资源为：</strong>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlIsVip" runat="server">
                                <asp:ListItem Value="0">不设置</asp:ListItem>
                                <asp:ListItem Value="1">重点资本推荐</asp:ListItem>
                                <asp:ListItem Value="2">重大投资计划</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="IbtnSubmit" runat="server" Text="确认" OnClientClick="return chkpost()"
                                OnClick="btnUpdate_Click" />
                        </td>
                    </tr>
            </table>
        </div>
        <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: 0px; left: 0px; width: 100%; height: 1500px; filter: alpha(opacity=60);">
            <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
            </div>
        </div>
    </form>
</body>
</html>
