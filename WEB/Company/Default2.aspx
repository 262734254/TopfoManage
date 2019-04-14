<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Company_Default2" %>

<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>无标题页</title>
    <script language="javascript" type="text/javascript" src="http://www.topfo.com/js/jquery.js"></script>
<script language="javascript" type="text/javascript">
function sendHit(cn)
{
   //var url="http://dp.topfo.com/Comm/Handler.ashx?userName='"+cn+"'&jsoncallback=?";
   //alert(cn);
   var url="Handler.ashx?userName='"+cn+"'&jsoncallback=?";
    $.getJSON(url,function(msg){
    alert(msg.name);
　　    
    });
    
    
}
function shows(cn)
{
alert(cn);
  sendHit(cn);
} 

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a href="javascript:shows('cn001')">aaa</a>
        <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
    </div>
    </form>
</body>
</html>
