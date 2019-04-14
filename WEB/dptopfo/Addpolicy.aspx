<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Addpolicy.aspx.cs" Inherits="admin_Addpolicy" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改优惠政策</title>
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
<script language="javascript" type="text/javascript">
//    function GetMessageLength(str)
//    {
//        var oEditor = FCKeditorAPI.GetInstance(str) ;
//        var oDOM = oEditor.EditorDocument ;
//        var iLength ;
//        if ( document.all )        // If Internet Explorer.
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
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="policyId" runat="server" />
        
            <div class="title">
                <h2>
                    <p>
                        <span><b>
                            修改优惠政策
                        </b></span>
                    </p>
                </h2>
            </div>
            <div class="list">
            <table border="0" cellpadding="0" class="one_table"  cellspacing="0" style="width: 100%;
                height: 124px">
                <tr id="clickId" runat="server" style="display: none;">
                    <td style="width: 15%" align="center">
                        点击率：</td>
                    <td align="left" valign="middle">
                        <span style="color: Red;">
                            <asp:Label ID="txtClick" runat="server" Text="Label"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        中文介绍：</td>
                    <td align="left" valign="middle">
                     <asp:TextBox ID="txtChina" runat="server" TextMode="MultiLine" Height="183px" Width="98%"></asp:TextBox>
                        
                      <%-- <FCKeditorV2:FCKeditor ID="txtChina" runat="server" Width="99%" Height="300px" BasePath="~/Vfckeditor/">
                        </FCKeditorV2:FCKeditor>--%>
                    </td>
                </tr>
                <tr>
                    <td  align="center">
                        英文介绍：</td>
                    <td align="left" valign="middle">
                     <asp:TextBox ID="txtEnglish" runat="server" TextMode="MultiLine" Height="183px" Width="98%"></asp:TextBox>
                        
                    <%--<FCKeditorV2:FCKeditor ID="txtEnglish" Width="99%" Height="300px" runat="server" BasePath="~/Vfckeditor/">
                        </FCKeditorV2:FCKeditor>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    <div style="text-align:center;">
                        <asp:Button ID="Button1" OnClientClick="return a()" CssClass="btn" runat="server" Text="添加 " 
                            OnClick="Button1_Click" Height="24px" Width="70px" />
                        &nbsp;
                        <asp:Button ID="btnUpdate" runat="server" Text="修改 " CssClass="btn" OnClientClick="return a()" Visible="False"
                            OnClick="btnUpdate_Click" Height="25px" Width="66px" />&nbsp; &nbsp;
                        <input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" />
                        </div></td>
                </tr>
            </table>
        </div>
         <%-- <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: -1px; left: 0px; width: 100%; height: 1055px; filter: alpha(opacity=60);">
            <div style="position: absolute; left: 520px; top: 110px;">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif" alt="Loading" />
            </div>
        </div>--%>
    </form>
</body>
</html>
