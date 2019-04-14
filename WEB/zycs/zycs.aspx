<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zycs.aspx.cs" Inherits="zycs_zycs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnRz" runat="server" Text="融资资源" OnClick="BtnIndex_Click" />
        &nbsp;
        <asp:Button ID="BtnTz" runat="server" Text="投资资源" OnClick="BtnIndex1_Click" />
        &nbsp;
        <asp:Button ID="ButZs" runat="server" Text="招商资源" OnClick="ButIndex2_Click" />
    </div>
    </form>
</body>
</html>
