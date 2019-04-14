<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelLoginName.aspx.cs" Inherits="advertise_SelLoginName" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
     function btn()
     {
        var url="";
        url="AdvisitInfoList.aspx";
        window.location.href=url;
     }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title">
                <h2>
                    <p>
                        <span><b>用户详细信息</b></span></p>
                </h2>
           
            </div>
        <table border="1" cellpadding="0" cellspacing="0" class="one_table" >
            <tr>
                <th class="f_14 f_red strong" style="padding: 5px 10px;">
                    用户信息</th>
            </tr>
        </table>
        <table border="1" width="100%" cellpadding="0" cellspacing="0" class="one_table">
        <asp:Panel runat="server" ID="PaNum" Visible="true">
            <%--<tr>
                <td width="130" align="right" >
                    <span class="f_red">*</span> <strong>项目单位名称：</strong></td>
                <td>
                    <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="f_red">*</span> <strong>联系人：</strong></td>
                <td>
                    <asp:Label runat="server" ID="lblLinkMan"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red"></span><strong>固定电话：</strong></td>
                <td width="80%">
                    
                    <asp:Label runat="server" ID="lblPhone"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red"></span><strong>手机号码：</strong></td>
                <td width="80%">
                       <asp:Label runat="server" ID="lblMobile"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <span class="f_red">*</span> <strong>电子邮箱：</strong></td>
                <td width="80%">
                    <asp:Label runat="server" ID="lblEmial"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <strong>详细地址：</strong></td>
                <td width="80%">
                    <asp:Label runat="server" ID="lblAddress"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <input type="button" id="btnOk" class="btn" onclick="btn();"  value="返回"/></td>
                
            </tr>
            </asp:Panel>
            <asp:Panel runat="server" ID="PanTishi" Visible="false">
            <tr >
            <td colspan="2" style="text-align:center"><span style="color:Red;">该用户是浏览者，不存在详细信息！</span><a href="AdvisitInfoList.aspx">返回>>></a></td>
            </tr>
            </asp:Panel>
        </table>

    </form>
</body>
</html>
