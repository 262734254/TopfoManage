<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpporStatus.aspx.cs" Inherits="SJ_OpporStatus" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
    <%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>商机发布和修改</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    function getvalue()
    {
    var vRbtid=document.getElementById("rblAuditing");
      //得到所有radio
      var vRbtidList= vRbtid.getElementsByTagName("input");
      for(var i = 0;i<vRbtidList.length;i++)
      {
        if(vRbtidList[i].checked)
        {
           var value=vRbtidList[i].value;
           if(value=="1")
           {
              document.getElementById("divAuditing").style.display="block";
           }
           else
           {
             document.getElementById("divAuditing").style.display="none";
           }
        }
      }

    }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">

            <table border="1" cellpadding="0" cellspacing="0" class="one_table" style="width: 751px">
            <tr>
                <th colSpan="2">
                  <div align="center">商机信息</div>     
                </th>
            </tr>
             <tr>
                <td align="right" >
                  <span > * </span> <strong>商机信息标题：</strong></td>
                <td align="left">
                    <asp:TextBox ID="txtTitle" runat="server" Width="270px" Height="21px"></asp:TextBox>
                    <span id="spMerchantTopic" style="color:buttonshadow">请填写商机信息标题</span>
                </td>
            </tr>
            <tr>
                <td align="right" >
                  <span > </span>  <strong>商机标签：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtKeyWord"  runat="server" Columns="50" Width="270px" Height="21px"></asp:TextBox>
                    <span id="Span1"></span>
                </td>
            </tr>
           
            <tr>
                <td align="right" >
                  <span >* </span>  <strong>所属区域：</strong></td>
                <td align="left">
                   <uc1:ZoneSelectControl ID="ZoneSelectControl2" runat="server" />
                    <span id="Span8"></span>
                    <input name="ZoneId" type="text" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                </td>
            </tr>
            <tr>
                <td align="right">
                  <span >* </span>  <strong>所属行业：</strong></td>
                <td align="left">
                    <asp:DropDownList runat="server" ID="ddlIndustry"></asp:DropDownList>
                    <span id="Span9"></span>
                    
                </td>
            </tr>
            <tr>
                <td align="right" >
                  <strong>商机类别：</strong></td>
                <td align="left">
                   <asp:DropDownList id="ddlOpportunityType" runat="server" Width="80px" DataValueField="OpportunityTypeID" DataTextField="OpportunityTypeName"></asp:DropDownList>
                    <span id="Span7"></span>
                </td>
            </tr>
           
             <tr>
                <td align="right" >
                  <strong>网页标题：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtDisplayTitle" runat="server" Columns="50" Height="21px"></asp:TextBox>
                    <span id="Span3"></span>
                </td>
            </tr>
            <tr>
                <td align="right" >
                   <strong>短标题：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtShortTitle" runat="server" Columns="50" Height="21px"></asp:TextBox>
                    <span id="Span4"></span>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    <strong>短内容：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtShortContent" runat="server" Columns="50" Height="21px"></asp:TextBox>
                    <span id="Span5"></span>
                </td>
            </tr>
            <tr>
                <td align="right" >
                  <span class="hong"></span>  <strong>商机广告语：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtAdTitle" runat="server" Height="21px"></asp:TextBox>
                    <span id="Span6"></span>
                </td>
            </tr>
           <tr>
                <td align="right" >
                <strong>网页描述：</strong></td>
                <td align="left"> 
                    <asp:TextBox id="txtDescript" runat="server" Columns="50" TextMode="MultiLine" Height="78px" Width="418px"></asp:TextBox>
                    <span id="Span2"></span>
                     <input id="Mid"   style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF"/>
                </td>
            </tr>
             <%--<tr>
            <td  align="right" valign="top" style="width: 149px"><strong>上传图片：</strong></td>
            <td valign="top" align="left">        <asp:FileUpload ID="uploadPic" runat="server" Width="235px" />&nbsp;<asp:Button ID="btnUpload2"
                    runat="server"  Text="上 传" />
                <asp:Label ID="LblMessage" runat="server" BackColor="White" BorderColor="White" ForeColor="#C00000"></asp:Label><br />
                <span class="hui">图片须为jpg或gif格式，大小不超过100K </span></td>
          </tr>--%>
            <tr>
                <td align="right" >
                  <span >*</span>  <strong>详细商机内容：</strong></td>
                <td align="left">
                   <FTB:FreeTextBox ID="txtContent"  runat="server">
                    </FTB:FreeTextBox><br>
                    <span id="Span12"></span>
                </td>
            </tr>
            <tr>
                <td align="right" >
                  <span class="hong"></span>  <strong>商机分析：</strong></td>
                <td align="left">
                   <asp:TextBox id="txtAnalysis" runat="server" Columns="60"  TextMode="MultiLine"
																					Rows="5" Height="93px"></asp:TextBox>
                    <span id="Span13"></span>
                </td>
            </tr>
            
            <tr>
                <td align="right" >
                  <span class="hong"> </span>  <strong>商机要求：</strong></td>
                <td align="left">
                  <asp:TextBox id="txtRequest" runat="server" Columns="60"  TextMode="MultiLine"
																					Rows="5" Height="92px"></asp:TextBox>
                    <span id="Span14"></span>
                </td>
            </tr>
            <tr>
                <td align="right" >
                  <span class="hong"></span>  <strong>商机流程：</strong></td>
                <td align="left">
                   <asp:TextBox id="txtFlow" runat="server" Columns="60"  TextMode="MultiLine" Rows="5" Height="97px"></asp:TextBox>
                    <span id="Span15"></span>
                </td>
            </tr>
             <tr>
                <td align="right" >
                  <span class="hong"> </span>  <strong>备    注：</strong></td>
                <td align="left">
                  <asp:TextBox id="txtRemark" runat="server" Columns="60"  TextMode="MultiLine"
																					Rows="5" Height="91px"></asp:TextBox>
                    <span id="Span16"></span>
                </td>
            </tr>
             <tr>
                <td align="right" >
                  <span class="hong">* </span>  <strong>有效期：</strong></td>
                <td align="left">
                      <asp:RadioButtonList ID="rdbtXM" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" Height="2px" >
                      </asp:RadioButtonList>
                    <span id="Span17" style="color:buttonshadow">请填写有效期</span>
                    <input id="rdlTerm" name="rdlTerm" type="text" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                </td>
            </tr>

         
        </table>
        <!--联系方式开始将之隐藏 -->
      <table border="1" cellpadding="0" class="one_table" cellspacing="0" style="width: 751px">
      <tr>
        <th colspan="2">
        <div align="center">联系方式确认</div>
        </th>
      </tr>
      
    <tr>
        <td width="124" align="right" >
            <span class="hong">*</span> <strong>公司名称：</strong></td>
        <td width="638" align="left">
            <asp:TextBox id="txtComName" runat="server" Columns="40" Height="21px"></asp:TextBox>
            <span id="Span18" style="color:buttonshadow">请填写商机信息标题</span>
            </td>
    </tr>
    <tr id="tr2" name="trswitchpublish">
        <td width="124" align="right" >
            <strong>联 系 人：</strong></td>
        <td width="622" align="left">
           <asp:TextBox id="txtLinkMan" runat="server"  Columns="40" Height="21px" ></asp:TextBox></td>
    </tr>

    <tr>
        <td align="right" >
            <span class="hong"></span> <strong>联系电话：</strong></td>
        <td width="638" valign="top" align="left">
            <asp:TextBox ID="txtTelCountry"  runat="server" size='4' Height="21px" >+86</asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode"  runat="server" size='7'  Height="21px"/>
            <asp:TextBox ID="txtTelNumber"  runat="server" size='18' Height="21px" />
            <span id="spTel" ></span>
        </td>
    </tr>
     <tr id="tr1" name="trswitchpublish">
        <td width="124" align="right" >
            <strong>手机：</strong></td>
        <td width="622" align="left">
           <asp:TextBox id="txtMobile" runat="server"  Columns="40" Height="21px" ></asp:TextBox>
           <span id="Span10" style="color:buttonshadow">为了方便联系，联系电话和手机至少填写一个</span>
           </td>
    </tr>
     <tr id="tr8" name="trswitchpublish">
        <td align="right" >
            <strong>联系地址：</strong></td>
        <td width="638" align="left">
            <asp:TextBox id="txtAddress" runat="server" Columns="40" Height="21px"></asp:TextBox></td>
    </tr>
     <tr id="tr5" name="trswitchpublish">
        <td width="124" align="right" >
            <strong>邮编：</strong></td>
        <td width="622" align="left">
           <asp:TextBox id="txtPostCode" runat="server" Columns="15" MaxLength="6" Height="21px"></asp:TextBox></td>
    </tr>
     <tr id="tr6" name="trswitchpublish">
        <td width="124" align="right" style="height: 35px" >
            <strong>网址：</strong></td>
        <td width="622" align="left" style="height: 35px">
           <asp:TextBox id="txtWebSite" runat="server" Columns="40" Height="21px"></asp:TextBox></td>
    </tr>

    <tr id="tr3" name="trswitchpublish">
        <td align="right" >
            <span class="hong">*</span><strong>电子邮箱：</strong></td>
        <td width="638" align="left">
            <asp:TextBox ID="txtEmail"  runat="server" Height="21px" size='18' Width="233px" />
            <span id="Span19" style="color:buttonshadow">请填写您最常用的电子邮箱,示例:yyy@xx.com</span> 
        </td>
    </tr> 
    <asp:Panel ID="divStatu1" runat="server" Visible="true" >
	<tr>
		<td></td>
		<td align="left">&nbsp;
			<asp:CheckBox id="cbAuditing" runat="server" Text="直接审核通过"></asp:CheckBox></td>
	</tr>
	</asp:Panel>
   <asp:Panel ID="divStatu2" runat="server" Visible="true">
	<tr>
		<td  align="right"><span class="hong">*</span>审核状态</td>
		<td align="left">
			<div align="left"><span class="style4">&nbsp;
					<asp:RadioButtonList id="rblAuditing" runat="server" OnClick="getvalue()"  RepeatDirection="Horizontal" RepeatLayout="Flow">
						<asp:ListItem Value="0">未审核</asp:ListItem>
						<asp:ListItem Value="1">审核通过</asp:ListItem>
						<asp:ListItem Value="2">审核未通过</asp:ListItem>
					</asp:RadioButtonList> </span>
			</div>
		</td>
	</tr>
	<span id="divAuditing" runat="server" style="display:none">
	<tr>
		<td align="right"><span >*</span>信息评定</td>
		<td>
			<div align="left">
				<asp:DropDownList id="ddlFixPrice" runat="server" ></asp:DropDownList>
				</div>
		</td>
	</tr>
	<tr>
		<td align="right"><span >*</span>信息评分</td>
		<td>
			<div align="left">
				<asp:DropDownList id="ddlGrade" runat="server" ></asp:DropDownList>
				</div>
		</td>
		
	</tr>
	</span>
	</asp:Panel>
    <tr>
    <td colspan="2">
    <div align="center"><asp:button id="btnPublish" runat="server" Text="发布"  CssClass="btn" OnClick="btnPublish_Click"></asp:button>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<input id="btnFan" class="btn" onclick="window.location.href='OpporView.aspx'" type="button" value="返回" /></div>
    </td>
    </tr>

</table>

    </form>
</body>
</html>
