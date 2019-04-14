<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDlaunchInfo.aspx.cs" Inherits="advertise_AddDlaunchInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加广告主</title>
     <link href="../css/style.css" type="text/css" rel="stylesheet">
        <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
        <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
 <script language="javascript" type="text/javascript">
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
             function CheckName(MuneName)
            {
                createXMLHTTP();//创建XMLHttpRequest对象
                var url="ExistsLoginName.aspx?MuneName="+escape(MuneName);
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
                       document.getElementById("message").innerHTML="<font color='green' size='-1'></font>";
                       document.getElementById('btnAdd').disabled =false; 
                    }else if(xmlHttp.responseText=="false"){
                        //菜单名不存在
                        document.getElementById("message").innerHTML="<font color='red' size='-1'>不存在该用户名确认是否正确</font>";
                        document.getElementById('btnAdd').disabled =true; 

                        
                    }else{
                        //访问出错
                          document.getElementById("message").innerHTML="获取信息出错";
                    }
                }
            }
    }
     function a()
    {
     var MuneName=document.getElementById("<%=txtLoginName.ClientID %>").value;
      if(MuneName=="")
       {
            document.getElementById("message").innerHTML="<font color='red' size='-1'>广告主不能为空</font>";
            return;
       }
     CheckName(MuneName);
    }
	function chkBtn()
	{

     if(document.getElementById("txtStardate").value=="")
               {              
                       alert("开始日期不能为空");
                        return false;
               }   
                      if(document.getElementById("txtenddate").value=="")
               {              
                       alert("结束日期不能为空");
                        return false;
                 }  
                      if(document.getElementById("txtGivindate").value=="")
               {              
                       alert("赠送日期不能为空");
                        return false;
                 }  
                 
	   if(document.getElementById("txtLoginName").value=="")
	   {
	       alert("广告主名称");
	       document.getElementById("txtLoginName").focus();
	       return false;
	   }

	    
   }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title" align="center">
             <h2><p><span><b>广告主添加</b></span></p></h2>
             <h2><p><span><b><a href="ADlaunchInfoList.aspx">广告主管理</a></b></span></p></h2>
             </div>
    <div>
      <table style="border-color:#678897; border-style:solid;  border-collapse:collapse; height:180px; "
					borderColor="#004f71" cellSpacing="0" cellPadding="3" border="1" align="center" class="">
                <tr><td style="height: 43px; width: 120px;" >
                    广告主：</td><td style="height: 43px" >
                    <asp:TextBox ID="txtLoginName" runat="server" onkeyup="a();" ></asp:TextBox>
                    <div style="display:inline; text-align: left; font-size:13px;">&nbsp;<span id="message"></span>&nbsp;</div> </td></tr>
          <tr>
              <td style="height: 43px; width: 120px;" >
                  
                      开始日期：</td>
              <td style="height: 43px" >
              <input type="text" id="txtStardate" runat="server" onClick="WdatePicker({lang:'zh-cn'})" />
                  <%--<cc1:DateTimeBox ID="txtStardate" runat="server"></cc1:DateTimeBox>--%></td>
          </tr>
          <tr>
              <td style="height: 43px; width: 120px;" >
                  
                      结束日期：</td>
             <td style="height: 43px" >
                  <%--<cc1:DateTimeBox ID="txtenddate" runat="server"></cc1:DateTimeBox>--%>
                  <input type="text" id="txtenddate" runat="server" onClick="WdatePicker({lang:'zh-cn'})" />
                  </td>
          </tr>
          <tr>
             <td style="height: 43px; width: 120px;" >
 
                 
                      赠送日期：</td>
           <td style="height: 43px" >
                  <%--<cc1:DateTimeBox ID="txtGivindate" runat="server"></cc1:DateTimeBox>--%>
                  <input type="text" id="txtGivindate" runat="server" onClick="WdatePicker({lang:'zh-cn'})"/>
                  </td>
          </tr>
          <tr>
              <td style="height: 43px; width: 120px;" >
                
                      业务员 ：</td>
             <td style="height: 43px" >
                  <asp:TextBox ID="txtsalesman" runat="server"></asp:TextBox></td>
          </tr>
                <tr><td style="width: 120px" >备注：</td><td >
                    <textarea id="txtDoc" runat="server" ></textarea></td></tr>
                <tr><td style="width: 120px" >&nbsp;</td><td style="width: 357px">
                    <asp:Button ID="btnAdd" runat="server" Text="确认添加"    OnClientClick="return chkBtn();" OnClick="BtnAdd_Click" CssClass="btn" /></td></tr>
                </table>
    </div>
    </form>
</body>
</html>
