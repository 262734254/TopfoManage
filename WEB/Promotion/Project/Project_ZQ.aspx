<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Project_ZQ.aspx.cs"  ValidateRequest="false"  Inherits="Project_Project_ZQ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/Controls/ZoneSelectControl.ascx"  TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
    <%@ Register Src="~/Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>债权融资</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
     <script language="javascript"  src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>  
         <style type="text/css"> 
.f_red{color:red}
</style>
  <style type="text/css">
       
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:500px;}
        .content p{line-height:30px;        }
        </style>
     <script language="javascript" type="text/javascript">
function getvalue(i)
{
  if(i==1)
  {
      var vRbtid=document.getElementById("rblAuditing");
      var vRbtidList= vRbtid.getElementsByTagName("input");
      for(var i = 0;i<vRbtidList.length;i++)
      {
        if(vRbtidList[i].checked)
        {
           var value=vRbtidList[i].value;
           switch(value)
           {
               case "0":
               document.getElementById("span1").style.display="none";
               document.getElementById("span2").style.display="none";
               document.getElementById("span3").style.display="none";
               document.getElementById("span4").style.display="none";
               break;
               case "1":
               document.getElementById("span1").style.display="none";
               document.getElementById("span2").style.display="none";
               document.getElementById("span3").style.display="block";
               document.getElementById("span4").style.display="block";
               break
               case "2":
               document.getElementById("span1").style.display="block";
               document.getElementById("span2").style.display="block";
               document.getElementById("span3").style.display="none";
               document.getElementById("span4").style.display="none";
               break
           }
        }
      }
   }else if(i==2)
   {
      var vRbtid=document.getElementById("rblFixPrice");
      var vRbtidList= vRbtid.getElementsByTagName("input");
      for(var i = 0;i<vRbtidList.length;i++)
      {
        if(vRbtidList[i].checked)
        {
           var value=vRbtidList[i].value;
           if(value=="2")
           {
             document.getElementById("span5").style.display="block";
           }else
           {
             document.getElementById("span5").style.display="none";
           }
        }
      }
   }
}

function chkBtn()
{
if(document.getElementById("txtKeord").value=="")
	   {
	       alert("请填写网页关键字");
	       document.getElementById("txtKeord").focus();
	       return false;
	   }
	   if(document.getElementById("txtWtitle").value=="")
	   {
	       alert("请填写网页标题");
	       document.getElementById("txtWtitle").focus();
	       return false;
	   }
	    if(document.getElementById("txtDescript").value=="")
	   {
	       alert("请填写网页描述");
	       document.getElementById("txtDescript").focus();
	       return false;
	   }
	   
   if(document.getElementById("txtProjectName").value=="")
   {
       alert("请填写项目标题");
       document.getElementById("txtProjectName").focus();
       return false;
   }
   if(document.getElementById("SelectIndustryControl1_sltIndustryName_Select").options.length==0)
   {
        alert("请选择所属行业");
        document.getElementById("IndustryId").focus();
        return false;
   }
   if(document.getElementById("ZoneSelectControl1_hideProvince").value=="")
   {
          alert("请选择所属区域");
          document.getElementById("ZoneId").focus();
          return false;
   }

    var rdlValiditeTermID = "<%=this.rblYqzjdwqk.ClientID %>";//还款保证
    if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
    {
       alert("请选择还款保证！");
       document.getElementById("YqzjdwqkId").focus();
       return false;
    }
    
     var rdlValiditeTermID = "<%=this.rblXmyxqxx.ClientID %>";//项目有效期
    if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
    {
       alert("请选择项目有效期限！");
       document.getElementById("XmyxqxxID").focus();
       return false;
    }
    
//     if(document.getElementById("txtCompanyName").value=="")
//    {
//       alert("请填写项目单位名称");
//       document.getElementById("txtCompanyName").focus();
//       return false;
//    }
    
    
    if(document.getElementById("txtTel").value.length=="" && document.getElementById("txtMobile").value.length=="")
    {
        alert("手机和固定电话请至少填写一项");
         document.getElementById("txtMobile").focus();
        return false;
    }
    if(document.getElementById("txtMobile").value.length!="")
    {
    var filtMobile = /^(13|15|18)[0-9]{9}$/;
        if((!filtMobile.test(document.getElementById("txtMobile").value)))
        {
            alert("请正确填写手机号码");
            document.getElementById("txtMobile").focus();
            return false;
        }
     }
            
    if(document.getElementById("txtEmail").value=="")
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
     </script>
</head>
<body>
    <form id="form1" runat="server">
 <div class="title" align="center">
             <h2><p><span><b><a href=ProjectManage.aspx>融资频道管理</a></b></span></p></h2>
             <h2><p><span><b><a href="#">债权融资信息</a></b></span></p></h2>
             </div>
        <table width="100%" border="0" class="one_table" cellspacing="0" cellpadding="0">
            <tr>
                <th style="padding: 5px 10px;" class="f_14">
                    <span class="f_red strong">项目详细资料</span><span class="f_gray">（以下基本信息均为必填项）</span></th>
            </tr>
        </table>
        <table width="100%" class="one_table" cellspacing="0" >
            <tr>
                <td align="right" width="20%">
                    <span class="f_red">*</span> <strong>项目标题：</strong></td>
                <td align="left" width="80%">
                    <input id="txtProjectName"  runat="server"  style="width: 286px" /></td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red">*</span> <strong>网页关键字：</strong></td>
                <td align="left" width="80%">
                    <input id="txtKeord"  runat="server"  style="width: 286px" />例如;融资、投资</td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red">*</span> <strong>网页标题：</strong></td>
                <td align="left" width="80%">
                    <input id="txtWtitle"  runat="server"  style="width: 286px" /></td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red">*</span> <strong>网页描述：</strong></td>
                <td align="left" width="80%">
                    <input id="txtDescript"  runat="server"  style="width: 286px" /></td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red">*</span> <strong>所属行业：</strong></td>
                <td align="left" width="80%">
                <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                <input name="ZoneId" type="text" id="IndustryId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF;" />
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red">*</span> <strong>所属区域：</strong></td>
                <td align="left" width="80%">
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    <input name="ZoneId" type="text" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF;" />
                </td>
            </tr>
            <tr>
                <td align="right" width="20%" style="height: 26px">
                    <span class="f_red">*</span> <strong>可接收资金成本上限：</strong></td>
                <td align="left" width="80%" style="height: 26px">
                    <input id="txtCapitalTotal" type="text"  runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " />
                    万人民币&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red">*</span> <strong>还款保证：</strong></td>
                <td align="left" width="80%">
                    <asp:RadioButtonList ID="rblYqzjdwqk" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" runat="server">
                        <asp:ListItem Value="1">担保</asp:ListItem>
                        <asp:ListItem Value="2">抵押</asp:ListItem>
                        <asp:ListItem Value="3">信用</asp:ListItem>
                    </asp:RadioButtonList>
                    <input name="ZoneId" type="text" id="YqzjdwqkId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF;" />
                    </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red">*</span> <strong>期限：</strong></td>
                <td align="left" width="80%">
                    发布之日起
                    <asp:RadioButtonList ID="rblXmyxqxx" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>
                     <input name="ZoneId" type="text" id="XmyxqxxID" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF;" />
                    </td>
            </tr>
            <tr>
                <td align="right" width="20%" >
                    <span class="f_red">*</span><strong>项目介绍：</strong></td>
                <td align="left" width="80%">
                    <textarea id="tbXmqxms" style="width: 80%; height: 142px;" runat="server"  ></textarea> 
                    <br />
                </td>
            </tr>
        </table>
 
        <table width="100%" class="one_table" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <th>
                    联系方式确认</th>
            </tr>
        </table>
        <table width="100%" class="one_table" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="right" width="20%">
                    <span class="f_red"></span> <strong>项目单位名称：</strong></td>
                <td align="left" width="80%">
                    <input id="txtCompanyName" class="show" type="text" style="width: 210px" runat="server"   maxlength="30" />&nbsp;
                    </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red"></span> <strong>联系人：</strong></td>
                <td align="left" width="80%">
                    <input id="txtLinkMan" class="show" type="text" style="width: 210px" runat="server"   maxlength="16" />&nbsp;
                </td>
            </tr>
            
            <tr>
                <td align="right" width="20%">
                    <span class="f_red"></span><strong>固定电话：</strong></td>
                <td align="left" width="80%">
                    固话
                    <input id="telArea1" type="text" maxlength="3" size="3" value="+86" runat="server" />
                    <input id="txtTelStateCode" type="text"  size="5" runat="server" />
                    <input id="txtTel" type="text" size="15"  runat="server"  />
                    <input id="telFg" type="text" size="5"   runat="server" /></td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red"></span><strong>手机号码：</strong></td>
                <td align="left" width="80%">
                    <input id="txtMobile" class="show" maxlength="11" type="text" style="width: 210px"
                        runat="server" />&nbsp;
                    <span class="f_gray">（固定电话或手机至少填写一项）</span></td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red">*</span> <strong>电子邮箱：</strong></td>
                <td align="left" width="80%">
                    <input id="txtEmail" class="show" type="text" style="width: 210px" runat="server"  maxlength="40" />&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <strong>详细地址：</strong></td>
                <td align="left" width="80%">
                    <input id="txtAddress" type="text"  value="" style="width: 210px" runat="server"  maxlength="50"  /></td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <strong>单位网址：</strong></td>
                <td align="left" width="80%">
                    <input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" maxlength="40"  /><span class="f_gray">例如：http://www.topfo.com</span>&nbsp;
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="plAudit" Width="100%" runat="server">
                        <table width="100%" border="0" align="center" class="one_table"  cellpadding="1" cellspacing="1">
                            <tr>
                                <td width="20%" align="right" >
                                    <span class="f_red">*</span> <strong>审核结果：</strong></td>
                                <td width="625" >
                                   <asp:RadioButtonList id="rblAuditing" runat="server"  OnClick="getvalue(1)"  RepeatDirection="Horizontal" RepeatLayout="Flow">
						            <asp:ListItem Value="0" Selected="True">未审核</asp:ListItem>
						            <asp:ListItem Value="1">审核通过</asp:ListItem>
						            <asp:ListItem Value="2">审核未通过</asp:ListItem>
					               </asp:RadioButtonList> 
					        </td>
                          </tr>
                          <span id="span1" runat="server" style="display:none">
                            <tr >
                                <td width="20%" align="right" >
                                    <span class="hong"></span> <strong>未通过审核原因：</strong></td>
                                <td width="80%" >
                                    <table width="100%" border="0" align="center" class="one_table"  cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td >
                                                <asp:TextBox ID="tbAuditingRemark" runat="server" Width="300px" Height="52px" TextMode="MultiLine"></asp:TextBox><br />
                                                <span class="hui">原因描述尽量简单、明确，不超过20个汉字 <a href="javascript:;" onclick="document.getElementById('tbAuditingRemark').value='';">
                                                    [清除]</a></span>
                                            </td>
                                            <td>
                                                1、<a onclick="getStr('您发布的需求，项目库中已存在，不能重复录入!')" href="javascript:void(0)">您发布的需求,项目库中已存在,不能重复录入</a>!<br />
                                                2、<a onclick="getStr('项目介绍不符合规范，请按要求完善后该信息')" href="javascript:void(0)">项目介绍不符合规范，请按要求完善后该信息</a><br />
                                                3、<a onclick="getStr('您发布的信息属于商机信息，请发至“商机/创业”版块!')" href="javascript:void(0)">您发布的信息属于商机信息,请发至"商机/创业"版块!</a><br />
                                                4、<a onclick="getStr('个人专利信息请发至“商机/创业”版块！')" href="javascript:void(0)">个人专利信息请发至“商机/创业”版块!</a><br />
                                            </td>
                                        </tr>
                                    </table>

                                    <script language="javascript" type="text/javascript">
                                    function getStr(str)
                                    {
                                       document.getElementById("tbAuditingRemark").value+=str;
                                    }
                                    </script>
                                </td>
                            </tr>
                            </span>
                            <span runat="server" id="span2" style="display:none">
                            <tr >
                                <td width="20%" align="right" >
                                    <span class="hong"> </span><strong>反馈状态：</strong></td>
                                <td width="80%" >
                                    <a href="#"></a>
                                    <asp:RadioButtonList ID="rblFeedbackStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Value="1" Selected="true">可修改</asp:ListItem>
                                        <asp:ListItem Value="2">即将删除</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            </span>
                            <span runat="server" id="span3" style="display:none" >
                            <tr >
                                <td width="20%" align="right" >
                                    <span class="hong">&nbsp;</span><strong>点击数：</strong></td>
                                <td width="80%" >
                                    <asp:TextBox ID="tbHits" runat="server" ></asp:TextBox></td>
                            </tr>
                            </span>
                            <span runat="server" id="span4" style="display:none">
                            <tr>
                                <td width="20%" align="right" >
                                    <span class="hong"></span><strong>资源选项：</strong></td>
                                <td width="80%" align="left">
                                    <asp:RadioButtonList ID="rblFixPrice" OnClick="getvalue(2)" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">免费</asp:ListItem>
                                        <asp:ListItem Value="2">收费</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <span id="span5" style="display: none" runat="server">
                                        <asp:TextBox ID="txtPointCount" runat="server" >0</asp:TextBox>
                                        元</span></td>
                            </tr>
                          </span>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button runat="server" ID="btnStatus" Text="审核" CssClass="btn" OnClientClick="return chkBtn();" OnClick="btnStatus_Click" />
                    &nbsp; &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnfanhui" Text="返回" CssClass="btn" OnClick="btnfanhui_Click" />
                    </td>
            </tr>
        </table>
         <div id="imgLoding" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 104%;
   height:1652px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
    </form>
</body>
</html>
