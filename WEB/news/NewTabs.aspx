<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="NewTabs.aspx.cs" Inherits="news_NewTabs" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>录入页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
     <script  src="../js/JScriptloans.js" type ="text/javascript" language="javascript"></script>
         <script type ="text/javascript" language ="javascript">
           function GetMessageLength(str)    {        var oEditor = FCKeditorAPI.GetInstance(str) ;        var oDOM = oEditor.EditorDocument ;        var iLength ;        if (document.all)        // If Internet Explorer.        {            iLength = oDOM.body.innerText.length ;        }        else                    // If Gecko.        {            var r = oDOM.createRange() ;            r.selectNodeContents( oDOM.body ) ;            iLength = r.toString().length ;        }    //oEditor.InsertHtml('')    return iLength    }  
           function postnewtabs()
   {
  if(document.getElementById ("txtnewsTitle").value.length==0)
   {
     document.getElementById ("showtxtnewsTitle").innerHTML="*";
     document.getElementById ("showtxtnewsTitle").style .display ="inline";
     document.getElementById ("txtnewsTitle").focus();
     return false;
   }
     if(document.getElementById ("txtzhaiyao").value.length==0)
   {
     document.getElementById ("showzhaiyao").innerHTML="*";
     document.getElementById ("showzhaiyao").style .display ="inline";
     document.getElementById ("txtzhaiyao").focus();
     return false;
   }     if(document.getElementById ("txttitle").value.length==0)
   {
     document.getElementById ("showtitle").innerHTML="*";
     document.getElementById ("showtitle").style .display ="inline";
     document.getElementById ("txttitle").focus();
     return false;
   }
     if(document.getElementById ("txtkeywords").value.length==0)
   {
     document.getElementById ("showkeywords").innerHTML="*";
     document.getElementById ("showkeywords").style .display ="inline";
     document.getElementById ("txtkeywords").focus();
     return false;
   }
     if(document.getElementById ("txtdescript").value.length==0)
   {
     document.getElementById ("showdescript").innerHTML="*";
     document.getElementById ("showdescript").style .display ="inline";
     document.getElementById ("txtdescript").focus();
     return false;
   }
      if(GetMessageLength("<%=FreeTextBox1.ClientID %>")=='0')
   {
     document.getElementById ("showcontext").innerHTML="请输入内容";
     document.getElementById ("showcontext").style.display ="inline";
     return false;
   }
   if(document.getElementById ("txtform").value.length==0)
   {
     document.getElementById ("showlaiyuan").innerHTML="*";
     document.getElementById ("showlaiyuan").style .display ="inline";
     document.getElementById ("txtform").focus();
     return false;
   }
   else
   {
    document.getElementById ("imgLoding").style .display ="";
  return true;
}
  }
  
      function UpdatePerImage()
    {
    
     var strd;
     strd=document.getElementById("showidUpdatePerson").value;
     var d=window.open ('UpdateNewsImage.aspx?strdo='+strd, 'newwindow', 'height=400, width=550, top=200, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')
    //var sd=window.showModalDialog("test.aspx","","dialogWidth=350px;dialogHeight=150px;tool=0;scroll=0;location=0;status=1;resizable=0");
//    alert(sd);
    }
         </script>
</head>
<body>
    <form id="form1" runat="server" action="">
    <div>
    <table border="0" cellpadding="0" cellspacing="0"    class="one_table">
    			<tr >
				<th colSpan="2">
					<div  align="center">资讯录入</div>
				</th>
			</tr>
    <tr><td><span style ="color:Red">*</span>标题：</td><td >
        <asp:TextBox ID="txtnewsTitle"  onblur="outpostcode(this,'showtxtnewsTitle')"  runat="server" Width="278px"></asp:TextBox>&nbsp;<div id="showtxtnewsTitle" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td style="height: 87px"><span style ="color:Red">*</span>摘要：</td><td style="height: 87px" >
        <asp:TextBox ID="txtzhaiyao" onblur="outpostcode(this,'showzhaiyao')" TextMode="MultiLine" runat="server" Height="64px" Width="351px"></asp:TextBox>&nbsp;<div id="showzhaiyao" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>Title：</td><td >
        <asp:TextBox ID="txttitle" onblur="outpostcode(this,'showtitle')"  runat="server" Width="278px"></asp:TextBox>&nbsp;<div id="showtitle" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>Keywords：</td><td >
        <asp:TextBox ID="txtkeywords" onblur="outpostcode(this,'showkeywords')"  runat="server" Width="278px"></asp:TextBox>&nbsp;<div id="showkeywords" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>Descript：</td><td >
        <asp:TextBox ID="txtdescript" onblur="outpostcode(this,'showdescript')"  runat="server" Width="278px"></asp:TextBox>&nbsp;<div id="showdescript" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>类型：</td><td >
        <asp:DropDownList ID="ddrtype" runat="server">
        </asp:DropDownList></td></tr>
    <tr><td><span style ="color:Red">*</span>图片上传：</td><td >
        <asp:FileUpload ID="uploadPic" runat="server" />&nbsp<asp:Button ID="btnUpfile" runat="server"
            Text="上 传" OnClick="btnUpfile_Click" />&nbsp<input type="button" value="修改图片" onclick ="UpdatePerImage()"/><asp:Label ID="LblMessage2" runat="server" Text=""></asp:Label></td></tr>
    <tr><td><span style ="color:Red">*</span>内容：</td><td >
                       <FCKeditorV2:FCKeditor ID="FreeTextBox1" runat="server" Height="300" BasePath="~/Vfckeditor/">
        </FCKeditorV2:FCKeditor>
                        &nbsp;<div id="showcontext" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red"></span>作者：</td><td >
        <asp:TextBox ID="txtauthor" Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showauthor" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>来源：</td><td >
        <asp:TextBox ID="txtform" onblur="outpostcode(this,'showlaiyuan')"  Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showlaiyuan" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td>操作：</td><td >
        <asp:RadioButtonList ID="radiocaozuo" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">未审核</asp:ListItem>
            <asp:ListItem Value="1">直接审核</asp:ListItem>
        </asp:RadioButtonList></td></tr>
            <tr><td>是否推荐：</td><td >
        <asp:RadioButtonList ID="radiotuijian" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
        </asp:RadioButtonList></td></tr>
    <tr><td colspan="2" align="center">
        <asp:Button ID="btnSave" runat="server" OnClientClick="return postnewtabs()" CssClass="btn"  Text="发 布" OnClick="btnSave_Click" /> &nbsp;&nbsp;<input type="button" id="Button3" onclick="history.back();" value="返 回" class="btn" /></td></tr>
    </table>
    </div>
    </form>
     <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1135px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif"alt="Loading" />
                </div>
   </div>
          <input type="hidden"  id="showidUpdatePerson" runat="server" />
</body>
</html>
