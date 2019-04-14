<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceDetail.aspx.cs" Inherits="Resource_ResourceDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />
    <title>无标题页</title>
    <style type="text/css"> 
        .f_red{color:red}
        .f_td{width:15%;background-color:#f7f7f7;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title" align="center">
            <h2>
                <p>
                    <span><b><a href="ResourceManage.aspx">中介资源管理</a></b></span></p>
            </h2>
            <h2>
                <p>
                    <span><b>资源审核</b></span></p>
            </h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td align="right" class="f_td">
                            <span class="f_red">*</span>标题：</td>
                        <td>
                            <%# Eval("Title") %>
                            <%--<input id="txtTitle" readonly="readonly" runat="server" type="text" style="width: 238px;
                                height: 20px" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f_td">
                            <span class="f_red">*</span>身份类型：</td>
                        <td>
                            <%# (Eval("Identity").ToString() == "0") ? "招商方" : (Eval("Identity").ToString() == "1") ? "投资方" : "融资方" %>
                            <%-- <asp:DropDownList ID="DropIdentity" Width="150" runat="server">
                                <asp:ListItem Value="-1">请选择</asp:ListItem>
                                <asp:ListItem Value="0">招商方</asp:ListItem>
                                <asp:ListItem Value="1">投资方</asp:ListItem>
                                <asp:ListItem Value="2">融资方</asp:ListItem>
                            </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f_td">
                            <span class="f_red">*</span>业行类型：</td>
                        <td>
                            <%# Eval("IndustryBName")%>
                            <%--<asp:DropDownList ID="DropIndustry" Width="150" runat="server">
                            </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f_td">
                            <span class="f_red">*</span>省份：</td>
                        <td>
                            <%# Eval("ProvinceName")%>
                            <%--<asp:DropDownList ID="DropProvince" Width="150" runat="server">
                            </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f_td">
                            <span class="f_red">*</span>城市：</td>
                        <td>
                            <%# Eval("CityName")%>
                            <%--<asp:DropDownList ID="DropCity" Width="150" runat="server">
                            </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f_td">
                            <span class="f_red">*</span>联系人：</td>
                        <td>
                            <%# Eval("Contact") %>
                            <%-- <input id="txtContact" runat="server" type="text" style="width: 238px; height: 20px" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f_td">
                            <span class="f_red">*</span>电话：</td>
                        <td>
                            <%# Eval("Phone") %>
                            <%--<input id="txtPhone" runat="server" type="text" style="width: 238px; height: 20px" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f_td">
                            <span class="f_red">*</span>Email：</td>
                        <td>
                            <%# Eval("Email") %>
                            <%--<input id="Text1" runat="server" type="text" style="width: 238px; height: 20px" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f_td">
                            <span class="f_red">*</span>状态：</td>
                        <td>
                            <%# (Eval("Status").ToString() == "0") ? "未审核" : "审核通过" %>
                            <%-- <asp:DropDownList ID="Status" runat="server">
                                <asp:ListItem Value="-1">请选择</asp:ListItem>
                                <asp:ListItem Value="0">未审核</asp:ListItem>
                                <asp:ListItem Value="1">审核通过</asp:ListItem>
                                <asp:ListItem Value="2">审核未通过</asp:ListItem>
                                <asp:ListItem Value="3">已过期</asp:ListItem>
                            </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f_td">
                            经费规划：</td>
                        <td>
                            <%# (Eval("Funds").ToString() == "") ? "&nbsp;" : Eval("Funds") %>
                            <%--<textarea runat="server" id="txtFunds" style="width: 420px; height: 180px">
                       </textarea>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f_td">
                            说明：</td>
                        <td>
                            <%# (Eval("Explain").ToString() == "") ? "&nbsp;" : Eval("Explain") %>
                            <%--<textarea runat="server" id="txtExplain" style="width: 420px; height: 180px">
                       </textarea>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 24px">
                            <asp:Button runat="server" ID="BtnSvae" OnClick="BtnModfiy_Click" OnClientClick="return CheckNull();"
                                CssClass="btn" Text="审核" />
                            &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='ResourceManage.aspx';"
                                value="返回" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: 0px; left: 0px; width: 104%; height: 1652px; filter: alpha(opacity=60);">
            <div class="content">
                <p>数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
            </div>
        </div>
    </form>
</body>
</html>
