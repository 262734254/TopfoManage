<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyMadeMofiy.aspx.cs" Inherits="Company_CompanyMadeMofiy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>广告定制</title>
   <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
   <script language="javascript" type="text/javascript" src="../js/twoCalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="title" align="center">
             <h2><p><span><b><a href="CompanyMadeMofiy.aspx">广告定制管理</a></b></span></p></h2>
             <h2><p><span><b>审核广告定制信息</b></span></p></h2>
             </div>
       <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td align="right" class="f_td" style="width: 195px">
                        <span class="f_red">*</span>广告名称：</td>
                    <td>
                        <span runat="server" id="Company"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="width: 195px">
                        <span class="f_red">*</span>总价格：</td>
                    <td>
                        <input runat="server" id="txtSumPrice" type="text" /> 元
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="width: 195px">
                        <span class="f_red">*</span>开始时间：</td>
                    <td>
                        <input type="text"  id="begTime" name="begTime" runat="server"
									   onfocus="if(this.value==''){this.value='';this.style.color='#000';}MyCalendar.SetDate(this) "  
									   onblur="if(this.value=='') {this.value='';this.style.color='#888';}" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="width: 195px">
                        <span class="f_red"></span>结束时间：</td>
                    <td>
                        <input type="text"  id="endTime" name="begTime" runat="server"
									   onfocus="if(this.value==''){this.value='';this.style.color='#000';}MyCalendar.SetDate(this) "  
									   onblur="if(this.value=='') {this.value='';this.style.color='#888';}" />
                    </td>
                </tr>
                
                
                <tr>
                    <td align="right" class="f_td" style="width: 195px">
                        <span class="f_red">*</span>联系人：</td>
                    <td>
                        <input runat="server" id="txtLinkName" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="width: 195px">
                        <span class="f_red">*</span>联系电话：</td>
                    <td>
                        <input runat="server" id="txtTelPhone" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="width: 195px">
                        <span class="f_red">*</span>电子邮箱：</td>
                    <td>
                        <input runat="server" id="txtEmail" type="text" />
                    </td>
                </tr>
               <tr>
                    <td align="right" class="f_td" style="width: 195px">
                        <span class="f_red">*</span>备注：</td>
                    <td>
                        <textarea runat="server" id="txtRemark" style="width: 268px; height: 99px"></textarea>
                    </td>
                </tr>
                <tr>
                <td align="right" class="f_td" style="width: 195px">
                    审核：
                </td>
                <td>
                <asp:RadioButtonList id="rblAuditing" runat="server"  OnClick="status(1)"  RepeatDirection="Horizontal" RepeatLayout="Flow">
	            <asp:ListItem Value="0" >未审核</asp:ListItem>
	            <asp:ListItem Value="1">审核通过</asp:ListItem>
	            <asp:ListItem Value="2">审核未通过</asp:ListItem>
               </asp:RadioButtonList> 
                </td>
                </tr>
                
                
                <tr>
                    <td align="right" class="f_td" style="width: 195px">
                        评论人：
                    </td>
                    <td>
                        <span id="CommentName" runat="server" style="color:Red"></span>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button runat="server" ID="btnStatus" Text="审 核" CssClass="btn" OnClick="btnStatus_Click"   />
                        &nbsp &nbsp
                        <input type="button" class="btn" value="返 回" onclick="window.location.href='CompanyMadeView.aspx'" />
                    </td>
                </tr>
            </table>

    </form>
</body>
</html>
