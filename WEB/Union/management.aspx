<%@ Page Language="C#" AutoEventWireup="true" CodeFile="management.aspx.cs" Inherits="System_management" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script language="javascript" type="text/javascript"> 
    function GetIndexNum()
    {
          var objindex=document.getElementById("ctl00_ContentPlaceHolder1_hidindex");
          var  obj =document.getElementsByName("txtSequence");
          objindex.value="";
          for(var i=0;i<obj.length;i++)
          {
               objindex.value += obj[i].value + ",";
          } 
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input id="hidparent" runat="server" type="hidden" />
    <input id="hidindex" runat="server" type="hidden" />
    <input id="hidsid" runat="server" type="hidden" />
    <input id="hidname" runat="server" type="hidden" />
    <div class="r_agencies">
        <div class="recomme">
            专业服务类别管理</div>
        <div class="redtxt">
            分类管理</div>
    </div>
    <div class="r_audit" id="dvContent" runat="server" style="">
        <ul style="width: 709px">
            <li><a href="management_add.aspx?sid=00">添加大类</a></li><asp:Label ID="lblMess" runat="server"></asp:Label>
            <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSave" Text="保 存"
                runat="server" OnClientClick="GetIndexNum()" OnClick="btnSave_Click" /></li></ul>
    </div>
    <div>
    </div>
    </form>
</body>
</html>
