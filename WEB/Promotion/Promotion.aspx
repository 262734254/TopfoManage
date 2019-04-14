<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Promotion.aspx.cs" Inherits="Promotion_Promotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/Controls/ZoneSelectControl.ascx"  TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
    <%@ Register Src="~/Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>债权融资</title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>

</head>
<body>
    <form id="form1" runat="server">
 <div class="title" align="center">
             <h2><p><span><b><a href="#">添加推广位置</a></b></span></p></h2>
             <h2><p><span><b><a href="SelPromotion.aspx">查看推广位置</a></b></span></p></h2>
             </div>
        <table width="100%" border="0" class="one_table" cellspacing="0" cellpadding="0">
            <tr>
                <th style="padding: 5px 10px;" class="f_14">
                    <span class="f_red strong">添加推广位置</span></th>
            </tr>
        </table>
        <table width="100%" class="one_table" cellspacing="0" >
            <tr>
                <td align="right" width="20%">
                    <span class="f_red"></span> <strong>编号：</strong></td>
                <td align="left" width="80%">
                    <input id="txtId"  runat="server" onkeyup="value=value.replace(/[^0-9]/g,'')" onblur="value=value.replace(/[^0-9]/g,'')" /></td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red"></span> <strong>推广位置：</strong></td>
                <td align="left" width="80%">
                    <input id="txtName"  runat="server"  /></td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red"></span> <strong>备注：</strong></td>
                <td align="left" width="80%">
                <textarea runat="server" id="txtRemark"></textarea>
                    </td>
            </tr>
            <tr>
            <td colspan="2" align="center"> 
                <asp:Button runat="server" ID="btnAdd" Text="添加" CssClass="btn" OnClick="btnAdd_Click" />
            </td>
            </tr>


        </table>

    </form>
</body>
</html>