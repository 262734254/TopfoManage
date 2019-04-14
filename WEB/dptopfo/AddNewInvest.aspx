<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewInvest.aspx.cs" Inherits="admin_AddNewInvest" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <%--<link rel="stylesheet" type="text/css" href="http://dp.topfo.com/css/common.css" />
    <link rel="stylesheet" type="text/css" href="http://dp.topfo.com/css/css.css" />--%>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../jwysiwyg/jquery.wysiwyg.css" type="text/css" />

    <script type="text/javascript" src="../jwysiwyg/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../jwysiwyg/jquery.wysiwyg.js"></script>
      <script type="text/javascript">
  $(function()
  {
      $('#txtChina').wysiwyg();
      $('#txtEnglish').wysiwyg();
      
  });
  </script>

    <style type="text/css">
#uploadPic{
	width:200px;
	border:1px solid maroon;
}
#uploadPic1{
	width:0px;
	border:0px solid green;
	
}
</style>

    <script language="javascript" type="text/javascript">
//    function GetMessageLength(str)
//    {
//        var oEditor = FCKeditorAPI.GetInstance(str) ;
//        var oDOM = oEditor.EditorDocument ;
//        var iLength ;
//        if (document.all)        // If Internet Explorer.
//        {
//            iLength = oDOM.body.innerText.length ;
//        }
//        else                    // If Gecko.
//        {
//            var r = oDOM.createRange() ;
//            r.selectNodeContents( oDOM.body ) ;
//            iLength = r.toString().length ;
//        }
//    //oEditor.InsertHtml('')
//    return iLength
//    }  
function a(){
    if(document.getElementById("<%=txtChina.ClientID %>")=='0')
    {
        alert('中文介绍不能为空');return false;
    }
//    if(GetMessageLength("<%=txtEnglish.ClientID %>")=='0')
//    {
//        alert('英文介绍不能为空');return false;
//    }
}
//取fck内容
function GetMessageContent(str)
{
     var oEditor = FCKeditorAPI.GetInstance(str) ;
     return oEditor.GetXHTML();
} 
function  aa(){ 
    try{
        document.form2.file.click();
         //document.form2.submit();
       }catch(e)
        { }
       } 
function cheakall(ithis)
    {
    var items = document.getElementsByTagName("input");     
     for(i=0; i<items.length;i++)
     {       
       if(items[i].type=="checkbox")
       {
            items[i].checked =ithis.checked;
       }
     }
    }
    function showCheck()
    {
            if(document.getElementById("imgLoding").style.display=="none")
            {
            document.getElementById("imgLoding").style.display="block";
            }else
            {
            document.getElementById("imgLoding").style.display="none";
            }
    }
    </script>

</head>
<body>
    <form id="form2" runat="server">
        <input type="hidden" id="flag" runat="server" />
      <div class="title">
            <h2>
                <p>
                    <span><b>修改投资成本</b></span></p>
            </h2>
        </div>
            <table border="0" cellpadding="0" cellspacing="0" class="one_table" style="width: 100%;">
                <tr>
                    <td style="width: 13%" align="center">
                        中文介绍：</td>
                    <td align="left" valign="middle">
                        <%--<FCKeditorV2:FCKeditor ID="txtChina" runat="server" Height="260" BasePath="~/Vfckeditor/">
                        </FCKeditorV2:FCKeditor>--%>
                        <asp:TextBox ID="txtChina" runat="server" TextMode="MultiLine" Height="143px" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 13%" align="center">
                        英文介绍：</td>
                    <td align="left" valign="middle">
                    <asp:TextBox ID="txtEnglish" runat="server" TextMode="MultiLine" Height="143px" Width="98%"></asp:TextBox>
                        <%--<FCKeditorV2:FCKeditor ID="txtEnglish" Height="260" runat="server" BasePath="~/Vfckeditor/">
                        </FCKeditorV2:FCKeditor>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center">
                            <asp:Button ID="Button1" Height="24px" runat="server" CssClass="btn" OnClick="Button1_Click"
                                OnClientClick="return a()" Text="添加" Width="68px" />
                            <asp:Button ID="btnUpdate" Height="23px" runat="server" CssClass="btn" OnClick="btnUpdate_Click"
                                OnClientClick="return a()" Text="修改" Visible="False" Width="72px" />
                            <input type="button" id="Button3" style="height: 24px; width: 66px;" onclick="history.back();"
                                value="返回" class="btn" />
                        </div>
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
