<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PublishNews.aspx.cs" Inherits="zx_PublishNews" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc2" %>
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.DateTimeBox" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<style type="text/css">
     
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:250px;}
        .content p{line-height:30px;        }
        
    </style>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link href="../css/style1.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
    <title>信息发布</title>
    <script type="text/jscript">
    			function Show(title)
		{
			var t1=document.getElementById("txtTitle");
			var t2=document.getElementById("txtDisplayTitle");
			var t3=document.getElementById("txtShortTitle");
			var t4=document.getElementById("txtSubTitle");
			t4.value =t3.value = t2.value  =title;
			ShowFontCount(t3);
		}


		function ShowFontCount(theControl)
		{
			var txtShortFontCount = document.Form1.txtShortFontCount;			
			if (txtShortFontCount != null)
			{
				txtShortFontCount.value = theControl.value.length;
			}
		}
				
	
		
		function ChangeAreaOrIndustry()
		{
			var Area = document.Form1.rdArea.checked;			
			var Industry = document.Form1.rdIndustry.checked;			
			if (Area){
				document.Form1.ddlArea.style.display="block";
				document.Form1.ddlIndustry.style.display="none";
				}
			if (Industry){
				document.Form1.ddlArea.style.display="none";			
				document.Form1.ddlIndustry.style.display="block";
				}			
		}
		
		function ChangeRedirect()
		{
			var IsRedirect = document.Form1.chkIsRedirect.checked;
			if (IsRedirect)
			{
				tabRedirect.style.display="none";					
				if (document.Form1.txtRedirectUrl.value == "")				
					document.Form1.txtRedirectUrl.value = "http://";				
			}
			else
			{
				tabRedirect.style.display="block";				
				document.Form1.txtRedirectUrl.value = "";
			}
		}
		
		function CheckNewsContent(source, arguments)
		{
			if (document.Form1.txtContent.value == "" && document.Form1.chkIsRedirect.checked == false)			
				arguments.IsValid = false;
			else
				arguments.IsValid = true;			
		}
		
		function CheckRedirect(source, arguments)
		{
			if ((document.Form1.txtRedirectUrl.value == "" || document.Form1.txtRedirectUrl.value == "http://") && document.Form1.chkIsRedirect.checked == true)			
				arguments.IsValid = false;
			else
				arguments.IsValid = true;			
		}
		
		function ChangeIndexTop()
		{
			var IsIndexTop = document.Form1.chkIndexTop.checked;
			if (IsIndexTop)
			{
				document.Form1.txtIndexOrderNum.value = '5';
			}
			else
			{
				document.Form1.txtIndexOrderNum.value = '0';
			}
		}
		
		function ChangeInfoTypeTop()
		{
			var IsInfoTypeTop = document.Form1.chkInfoTypeTop.checked;
			if (IsInfoTypeTop)
			{
				document.Form1.txtInfoTypeOrderNum.value = '5';
			}
			else
			{
				document.Form1.txtInfoTypeOrderNum.value = '0';
			}
		}
		</script>
<script language="javascript" type="text/javascript">

</script>
</head>
<body >
    <form  id="Form1" method="post" runat="server" align="center">
    <div>
        <table  border="0" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td colspan="2" align="center">
                    资讯信息发布</td>
            </tr>
            <tr>
                <td><font color="red">*</font>
                    资讯类别：</td>
                <td>
                    <asp:DropDownList ID="ddlNewsType" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td ><font color="red">*</font>
                    资讯标题：</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" onblur="Show(this.value);" Width="423px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><font color="red">*</font>
                关键字 ：</td>
                <td >
                    <asp:TextBox ID="txtKeyword" runat="server" Width="421px"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    网页描述：</td>
                <td>
                    <asp:TextBox ID="txtDescript" runat="server" TextMode="MultiLine" Width="421px"></asp:TextBox>(不填自动取咨讯摘要信息)</td>
            </tr>
            <tr>
                <td style="width: 70px">
                    显示标题：</td>
                <td>
                    <asp:TextBox ID="txtDisplayTitle" runat="server" Width="417px"></asp:TextBox>(网页标题)</td>
            </tr>
            <tr>
                <td >
                    <span style="color: #ff0000">*</span>短标题：</td>
                <td>
                    <asp:TextBox ID="txtShortTitle"   onkeyup="ShowFontCount(this);" runat="server" Width="413px"></asp:TextBox>
                    <asp:TextBox ID="txtShortFontCount" runat="server" Width="20px"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="字"></asp:Label>(首页标题列表)</td>
            </tr>
            <tr>
                <td style="width: 70px" >
                    &nbsp; 短内容：</td>
                <td >
                    <asp:TextBox ID="txtShortContent"  runat="server" Width="413px"></asp:TextBox>(头条简介)</td>
            </tr>
            <tr>
                <td style="width: 70px">
                    <div align="left">
                        &nbsp; 小标题：</div>
                </td>
                <td >
                    <asp:TextBox ID="txtSubTitle" runat="server" Width="413px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 24px" >
                    <span style="color: #ff0000">*</span>资讯来源：</td>
                <td style="height: 24px" >
                    <asp:TextBox ID="txtOrigin" runat="server" Width="413px"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    &nbsp;资讯作者：</td>
                <td >
                    <asp:TextBox ID="txtAuthor" runat="server" Width="129px"></asp:TextBox></td>
            </tr>
            <tr>
               <td style="height: 42px" >
                    <span style="color: #ff0000">*</span>资讯标签：</td>
                <td style="height: 42px" >
                <input value="0" name="AreaOrIndustry" id="rdArea" type="radio" onclick="ChangeAreaOrIndustry();" runat="server" Checked=true />
                <lable for="rdArea">地域</lable> 
                <input value="1" name="AreaOrIndustry" id="rdIndustry" type="radio" onclick="ChangeAreaOrIndustry();"  runat="server" />
                <lable for="rdIndustry">行业</lable>
                    <br />
                    <asp:DropDownList ID="ddlArea" runat="server" DataTextField="AreaName" DataValueField="AreaID">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlIndustry" runat="server" style="display:none" DataTextField="NewsIndustryName" DataValueField="NewsIndustryID" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="height: 24px" >
                    <div align="left">
                        &nbsp; 转向链接:</div>
                </td>
                <td style="height: 24px" >
                    <asp:TextBox ID="txtRedirectUrl" runat="server" Width="259px"></asp:TextBox>
                    <input id="chkIsRedirect" type="checkbox" name="chkIsRedirect" runat="server" onclick="ChangeRedirect();" /><label for="chkIsRedirect">使用转向链接</label>&nbsp;
                </td>
            </tr>
        </table>
    <%--</div>--%>
        <table id="tabRedirect"  border="0" cellpadding="0" cellspacing="0" class="one_table">

             <tr>
                <td ><font color="red">*</font>
                    资讯摘要：</td>
                <td>
                    <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine"  Width="292px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
            <font color="red">*</font> 资讯内容</td>
            <td>
		<textarea name="txtContent" id="txtContent" style="DISPLAY: none; width: 292px;"></textarea>
                </td>
            </tr>
        
            <tr>
                <td colspan="2" align="left">
                    <FCKeditorV2:FCKeditor ID="FCKeditor" Height="300" BasePath="~/Vfckeditor/"  runat="server">
                    </FCKeditorV2:FCKeditor><span id="content"></span>
                    &nbsp;</td>
            </tr>
        <tr style="display:none">
                <td>
                    图片上传：</td>
                <td >
                    <asp:FileUpload ID="uploadPic" runat="server" Width="235px" />&nbsp;<asp:Button ID="btnUpload"
                        runat="server" CssClass="btn"  OnClick="btnUpload_Click" Text="上 传" />
                    <asp:Label ID="LblMessage" runat="server" ForeColor="#C00000"></asp:Label><br />
                    <span class="hui">图片须为jpg或gif格式，大小不超过100K </span>
                </td>
            </tr>
            <tr style="display:none">
                <td >
                    <span style="font-family: 宋体">图片说明：</span></td>
                <td >
                <input name="txtPicAbout" type="text" size="30" id="txtPicAbout" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="height: 81px" >
                    <div>
                        内容分页：</div>
                </td>
                <td style="height: 81px">
                <div>
				<table id="rblPageStatus" border="0" cellpadding="0" cellspacing="0" class="one_table">
			    <tr>
				<td >
				<asp:radiobuttonlist id="rblPageStatus" runat="server" RepeatDirection="Horizontal">
																		<asp:ListItem Value="0" Selected="True">不分页</asp:ListItem>
																		<asp:ListItem Value="1">手动分页</asp:ListItem>
																		<asp:ListItem Value="2">自动分页</asp:ListItem>
																	</asp:radiobuttonlist>
																	<%--<input id="rblPageStatus_0" type="radio" name="rblPageStatus" value="0" checked="checked" />
				<label for="rblPageStatus_0">不分页</label>
				</td><td style="height: 22px"><input id="rblPageStatus_1" type="radio" name="rblPageStatus" value="1" />
				<label for="rblPageStatus_1">手动分页</label>
				</td>
				<td style="height: 22px">
				<input id="rblPageStatus_2" type="radio" name="rblPageStatus" value="2" />
				<label for="rblPageStatus_2">自动分页</label>--%>
				</td>
				</tr>
		      </table>
		注：手动分页符标记为“ [NextPage] ”<br/>
			自动分页时的每页大约字符数：&nbsp;
			<input name="txtPageCharCount" type="text" value="20000" id="txtPageCharCount" runat="server" /></div>
											
                </td>
            </tr>
</table>
           <table  border="0" cellpadding="0" cellspacing="0" class="one_table"> 
            <tr>
                <td style="width: 71px"><font color="red">*</font> 开始日期：</td>
            <td >
                    <cc1:DateTimeBox ID="txtValidateStartTime" runat="server"></cc1:DateTimeBox>
            </td>
            </tr>
             <tr>
                <td style="width: 71px" ><font color="red">*</font> 有效期：</td>
            <td >
                  	<asp:DropDownList id="ddlValiditeTerm" runat="server">
					<asp:ListItem Value="1">1</asp:ListItem>
					<asp:ListItem Value="2">2</asp:ListItem>
					<asp:ListItem Value="3">3</asp:ListItem>
					<asp:ListItem Value="4">4</asp:ListItem>
			        <asp:ListItem Value="5">5</asp:ListItem>
			        <asp:ListItem Value="6">6</asp:ListItem>
			        <asp:ListItem Value="7">7</asp:ListItem>
			        <asp:ListItem Value="8">8</asp:ListItem>
			        <asp:ListItem Value="9">9</asp:ListItem>
			        <asp:ListItem Value="10">10</asp:ListItem>
			        <asp:ListItem Value="11">11</asp:ListItem>
			        <asp:ListItem Value="12">12</asp:ListItem>
			        <asp:ListItem Value="0" Selected="True">无限</asp:ListItem>
		           </asp:DropDownList>个月</td></tr>
             <tr>
                <td style="width: 71px"><font color="red">*</font> 模版号：</td>
           
            <td >
                    <asp:TextBox ID="txtTemplate" runat="server" Enabled="False">001</asp:TextBox></td></tr>
               <tr>
                   <td style="width: 71px" >
                       <span style="color: #ff0000">*</span>发布时间：</td>
                 <td >
                    <cc1:DateTimeBox ID="txtPublishT" runat="server"></cc1:DateTimeBox></td>
               </tr>
     <%--       <tr >
                   <td>
                       &nbsp;&nbsp; 审 &nbsp; &nbsp;&nbsp; 核:</td>
                   <td>
                   <input id="cbAuditing" type="checkbox" name="cbAuditing" runat="server" /><label for="cbAuditing">直接审核通过</label>
                   </td>
               </tr>--%>
           <tr >
                   <td style="display:none; width: 71px;">
                       &nbsp;&nbsp;
                   </td>
                   <td style="display:none">
                   <asp:RadioButton id="rbyjcg" runat="server" Text="加入研究成果" GroupName="yjh"></asp:RadioButton>
			        <asp:RadioButton id="rbhyjj" runat="server" Text="加入行业聚焦" GroupName="yjh"></asp:RadioButton>
			        <asp:RadioButton id="rbfyrw" runat="server" Text="加入风云人物" GroupName="yjh"></asp:RadioButton>
                   </td>
                   <td colspan="2" align="center">
                       <asp:Button ID="btnPublish" runat="server" CssClass="btn"  Text="提交" OnClick="btnPublish_Click"  OnClientClick="return check();"/>
                   </td>
               </tr>
            
           </table>
           </div>

    </form>
    <script type="text/jscript">
             function check() {
       if (document.getElementById("txtTitle").value == "")
        {
            alert('请输入标题！');
            document.getElementById("txtTitle").focus();
            return false;

        }
     
        if (document.getElementById("txtKeyword").value == "")
        {
            alert('关键字不能为空！');
            document.getElementById("txtKeyword").focus();
            return false;
        }
         if (document.getElementById("txtSummary").value == "")
        {
            alert('请输入摘要！');
            document.getElementById("txtSummary").focus();
            return false;
        }
 
          if (document.getElementById("txtPublishT").value == "")
        {
            alert('发布时间不能为空！');

            return false;
        }
          if (document.getElementById("txtValidateStartTime").value == "")
        {
            alert('开始时间不能为空！');
            return false;
        }
   
          document.getElementById("imgLoding").style.display="block";

    }
		function FormIniInsertInfoToContent()
		{
			var ChkIsRedirect = document.Form1.chkIsRedirect;
			if (ChkIsRedirect == null)
				return;
			editor.HtmlEdit.document.body.innerHTML = document.Form1.txtContent.value; 			//初始化数据到控件
			//初始化行业或者地域列表的隐藏状态
			var Area = document.Form1.rdArea.checked;			
			var Industry = document.Form1.rdIndustry.checked;			
			if (Area){
				document.Form1.ddlArea.style.display="block";
				document.Form1.ddlIndustry.style.display="none";
				}
			if (Industry){
				document.Form1.ddlArea.style.display="none";			
				document.Form1.ddlIndustry.style.display="block";
				}		
			//初始化是否转移
			var IsRedirect = document.Form1.chkIsRedirect.checked;
			if (IsRedirect)
				tabRedirect.style.display="none";
			else
				tabRedirect.style.display="block";		
		}
		</script>
		         <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1074px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif"alt="Loading" />
                </div>
   </div>

</body>
</html>
