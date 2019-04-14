<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NarrowSearch.aspx.cs" Inherits="Company_NarrowSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
    <title>查看窄告信息</title>
</head>
<body>
        <form id="form1" runat="server">
   <div class="title" align="center">
             <h2><p><span><b><a href="NarrowModeView.aspx">窄告定制信息管理</a></b></span></p></h2>
             <h2><p><span><b>查看窄告信息</b></span></p></h2>
             </div>
       <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td align="right" class="f_td" style="width:15%">
                        <span class="f_red"></span>标题：</td>
                    <td>
                        <span runat="server" id="txtTitle"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="width:15%">
                        <span class="f_red"></span>描述：</td>
                    <td>
                        <%--<span runat="server" id="txtDescript"></span>--%>
                        <textarea runat="server" id="txtDescript" style="width: 312px; height: 102px"></textarea>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="width:15%">
                        <span class="f_red"></span>链接地址：</td>
                    <td>
                        <span runat="server" id="txtUrl"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="width:15%">
                        <span class="f_red"></span>发布时间：</td>
                    <td>
                        <span runat="server" id="txtTime"></span>
                    </td>
                </tr>
                <tr>
                <td colspan="2"><span style="color:Red; font-size:larger">搜索条件</span></td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="width:15%">
                        <span class="f_red"></span>类型：</td>
                    <td>
                        <span runat="server" id="txtInfoType"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td" style="width:15%">
                        <span class="f_red"></span>省份：</td>
                    <td>
                        <span runat="server" id="txtProvince"></span>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="2" align="center">
                        
                        <input type="button" class="btn" value="返 回" onclick="window.location.href='NarrowModeView.aspx'" />
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
