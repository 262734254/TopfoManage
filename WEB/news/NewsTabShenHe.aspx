<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest ="false" CodeFile="NewsTabShenHe.aspx.cs" Inherits="news_NewsTabShenHe" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>资讯审核页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
     <script  src="../js/JScriptloans.js" type ="text/javascript" language="javascript"></script>
       <script type ="text/javascript" language ="javascript">
                  function GetMessageLength(str)    {        var oEditor = FCKeditorAPI.GetInstance(str) ;        var oDOM = oEditor.EditorDocument ;        var iLength ;        if (document.all)        // If Internet Explorer.        {            iLength = oDOM.body.innerText.length ;        }        else                    // If Gecko.        {            var r = oDOM.createRange() ;            r.selectNodeContents( oDOM.body ) ;            iLength = r.toString().length ;        }    //oEditor.InsertHtml('')    return iLength    }  
          function changgereson(divid)
    {
      if(divid==0)
      {
       document.getElementById("shenhe").style.display="none";
       document.getElementById("tuijian").style.display="none";
      }
      if(divid==1)
      {
       document.getElementById("tuijian").style.display="block";
        document.getElementById("shenhe").style.display="none";
      }
      if(divid==3)
      {
         document.getElementById("tuijian").style.display="none";
       document.getElementById("shenhe").style.display="block";
      }
      if(divid==5)
      {
         document.getElementById("tuijian").style.display="none";
       document.getElementById("shenhe").style.display="none";
      }
    }
   function postnewtabs()
   {
  if(document.getElementById ("txtnewsTitle").value.length==0)
   {
     document.getElementById ("showtxtnewsTitle").innerHTML="*";
     document.getElementById ("showtxtnewsTitle").style.display ="inline";
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
    var strd=document.getElementById ("sdfsid").value;
    var d=window.open ('UpdateNewsImaged.aspx?strdod='+strd, 'newwindow', 'height=400, width=550, top=200, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')
    }
         </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0"    class="one_table">
    			<tr >
				<th colSpan="2">
					<div  align="center">资讯审核</div>
				</th>
			</tr>
    <tr><td><span style ="color:Red">*</span>标题：</td><td >
        <asp:TextBox ID="txtnewsTitle" onblur="outpostcode(this,'showtxtnewsTitle')"  runat="server" Width="278px"></asp:TextBox>&nbsp;<div id="showtxtnewsTitle" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>摘要：</td><td >
        <asp:TextBox ID="txtzhaiyao" onblur="outpostcode(this,'showzhaiyao')" TextMode="MultiLine" runat="server" Height="64px" Width="351px"></asp:TextBox>&nbsp;<div id="showzhaiyao" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>Title：</td><td >
        <asp:TextBox ID="txttitle" onblur="outpostcode(this,'showtitle')"  Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showtitle" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>Keywords：</td><td >
        <asp:TextBox ID="txtkeywords" onblur="outpostcode(this,'showkeywords')"  Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showkeywords" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>Descript：</td><td >
        <asp:TextBox ID="txtdescript" onblur="outpostcode(this,'showdescript')" Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showdescript" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
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
        <asp:TextBox ID="txtauthor"   Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showauthor" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>来源：</td><td >
        <asp:TextBox ID="txtform" onblur="outpostcode(this,'showlaiyuan')" Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showlaiyuan" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td>操作：</td><td >
                         <input  type="radio" id="shen" name="shenz" runat ="server" onclick="changgereson('0')" value ="0"/>未审核 <input  type="radio" id="shens" name="shenz" runat ="server" onclick="changgereson('1')" value ="1"/>审核 <input id="shensss" name="shenz" runat ="server"  type="radio" onclick="changgereson('3')" value ="3"/>审核未通过<input id="shenssss" name="shenz" runat ="server"  type="radio" onclick="changgereson('5')" value ="5"/>已删除</td></tr>
           <tr id="tuijian"  style ="display:none";  runat ="server">
                <td >
                    是否推荐：</td>
                <td >
                    <asp:RadioButtonList ID="radiotuijian" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" >不推荐</asp:ListItem>
                        <asp:ListItem Value="1">推荐</asp:ListItem>
                        <asp:ListItem Value="2">推广</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
               <tr id="shenhe"  style ="display:none";  runat ="server">
                <td>
                    未通过审核原因：</td>
                <td>
                       <table border="0" cellpadding="0" cellspacing="0" width="100%" class="one_table">
                            <tr>
                                <td bgcolor="#f7f7f7">
                                    <asp:TextBox ID="txtson" runat="server" Width="334px" Height="92px" TextMode="MultiLine"></asp:TextBox><br />
                                    <span class="hui">原因描述尽量简单、明确，不超过20个汉字 <a href="javascript:;" onclick="document.getElementById('txtson').value='';">
                                        [清除]</a></span>
                                </td>
                                <td>
                                    1、<a onclick="getStr('该需求在库中已存在!')" href="javascript:void(0)">该需求在库中已存在!</a><br />
                                    2、<a onclick="getStr('该需求应发布到“商机/创业”版块!')" href="javascript:void(0)">该需求应发布到"商机/创业"版块!</a><br />
                                    3、<a onclick="getStr('该需求应发布到“融资”版块!')" href="javascript:void(0)">该需求应发布到"融资"版块!</a><br />
                                    4、<a onclick="getStr('需求介绍不符合规范，请按要求完善后发布!')" href="javascript:void(0)">需求介绍不符合规范，请按要求完善后发布!</a><br />
                                    5、<a onclick="getStr('该信息不符合投资资源标准!')" href="javascript:void(0)">该信息不符合投资资源标准!</a><br />
                                </td>
                            </tr>
                        </table>

                        <script>function getStr(str)
        {
           document.getElementById("txtson").value=str;
        }
                        </script>
                </td>
            </tr>
    <tr><td colspan="2" align="center">
        <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClientClick="return postnewtabs()"  Text="审 核" OnClick="btnSave_Click" />&nbsp;&nbsp;
           <input type="button" id="Button3" onclick="history.back();" value="返 回" class="btn" /></td></tr>
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
   <input  type="hidden" id="sdfsid" runat ="server"/>
</body>
</html>
