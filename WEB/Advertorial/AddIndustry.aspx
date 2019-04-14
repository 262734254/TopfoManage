<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddIndustry.aspx.cs" Inherits="Advertorial_AddIndustry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加行业类型</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
          var xmlHttp;
        function createXMLHTTP()
        {
           //alert("ok1");
            if(window.XMLHttpRequest)
            {
                xmlHttp=new XMLHttpRequest();//mozilla浏览器
            }
            else if(window.ActiveXObject)
            {
                try
                {
                    xmlHttp=new ActiveXObject("Msxml2.XMLHTTP");//IE老版本
                }
                catch(e)
                {}
                try
                {
                    xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");//IE新版本
                }
                catch(e)
                {}
                if(!xmlHttp)
                {
                    window.alert("不能创建XMLHttpRequest对象实例！");
                    return false;
                }
            }
        }
            function CheckName(classId,MuneName)
            {
                createXMLHTTP();//创建XMLHttpRequest对象
                var url="Hander.aspx?MuneName="+escape(MuneName)+"&classID="+classId;
                //alert(url);
                //以POST形式局部请求服务器
                xmlHttp.open("POST",url,true);
                //关联一个事件
                xmlHttp.onreadystatechange=MethodcheckUserName;//定义发送请求后事件关联回传方法(类似于按钮的单击事件)
                xmlHttp.send(null);
            }
         function MethodcheckUserName()
          {
             if(xmlHttp.readyState==4)//判断对象状态
            {
                if(xmlHttp.status==200)//信息成功返回，开始处理信息
                { 
                    if(xmlHttp.responseText=="true"){
                        document.getElementById("message").innerHTML="<font color='red' size='-1'>行业类型存在</font>";
                    }else if(xmlHttp.responseText=="false"){
                        //菜单名不存在
                        document.getElementById("message").innerHTML="<font color='green' size='-1'>行业类型可用</font>";
                    }else{
                        //访问出错
                          document.getElementById("message").innerHTML="获取信息出错";
                    }
                }
            }
    }
     function a()
    {
     var MuneName=document.getElementById("<%=txtMuneName.ClientID %>").value;
    var classId=document.getElementById("<%=classId.ClientID %>").value;
      
      if(MuneName=="")
       {
            document.getElementById("message").innerHTML="<font color='red' size='-1'>类型不能为空</font>";
            return;
       }
     CheckName(classId,MuneName);
    }
    function b()
     {
         var MuneName=document.getElementById("<%=txtMuneName.ClientID %>").value;//
         var UrlAdd=document.getElementById("<%=txtUrlAdd.ClientID %>").value;
          if(MuneName=="")
           {
                document.getElementById("message").innerHTML="<font color='red' size='-1'>类型不能为空</font>";
                return false; //URL不能为空
           }
           if(UrlAdd=="")
           {
            document.getElementById("message1").innerHTML="<font color='red' size='-1'>备注不能为空</font>";
                return false; 
           }
       }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        
        <div align="center">
        <input id="classId" type="hidden"  runat="server"/>
         <div class="title"><h2><p><span><b>
             <asp:Literal ID="lbmenu" runat="server"></asp:Literal></b></span></p></h2></div>
          <table border="0" cellpadding="0" cellspacing="0" class="one_table" style="width: 612px; height: 124px">
                <tr>
                    <td style="width: 23%" align="center">
                        类型名称：</td>
                    <td align="left" style="width: 333px;display:inline;" valign="middle">
                    <asp:TextBox ID="txtMuneName" runat="server" onkeyup="a();" onblur="a();" Height="21px" Width="163px" AutoCompleteType="Email"></asp:TextBox>&nbsp;
                       <div style="display:inline; text-align: left; font-size:13px;">&nbsp;<span id="message"></span>&nbsp;</div> 
                        </td>
                </tr>
                <tr>
                    <td style="width: 23%" align="center">
                        备注：</td>
                    <td align="left"  valign="middle">
                        <asp:TextBox ID="txtUrlAdd" runat="server" Width="379px" Height="107px"></asp:TextBox>
                        <div style="display:inline; text-align: left; font-size:13px;">&nbsp;<span id="message1"></span>&nbsp;</div> 
                        
                        </td>
                </tr>
                <tr>
                    <td style="width: 23%" align="center">
                        是否启动：</td>
                    <td align="left">
                        <asp:RadioButton ID="rdoQidong" GroupName="rdo" Checked="true" runat="server" Text="启动" />
                        <asp:RadioButton ID="rdoClose" runat="server"  GroupName="rdo" Text="关闭" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button2" runat="server" OnClientClick="return  b();" Text="添加" OnClick="Button1_Click" CssClass="btn" />
                        &nbsp;&nbsp;
                        <input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" /></td>
                    
                    
                </tr>
                
            </table>
        </div>
    </form>
</body>
</html>
