<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnvironmentTabInsert.aspx.cs"
    Inherits="admin_EnvironmentTabInsert" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>投资环境录入页</title>
    <style type="text/css">
#uploadPic{
	width:200px;
	height:20px;
	border:1px solid maroon;
}
</style>
    <%--<link href="http://dp.topfo.com/css/css.css" rel="stylesheet" type="text/css" />
    <link href="http://dp.topfo.com/css/common.css" rel="stylesheet" type="text/css" />--%>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../jwysiwyg/jquery.wysiwyg.css" type="text/css" />

    <script type="text/javascript" src="../jwysiwyg/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../jwysiwyg/jquery.wysiwyg.js"></script>

    <script type="text/javascript">
  $(function()
  {
      $('#txtengilsh').wysiwyg();
      $('#txtzhongwen').wysiwyg();
      
  });
  </script>
    <script type="text/javascript" language="javascript">
//               function GetMessageLength(str)//    {//        var oEditor = FCKeditorAPI.GetInstance(str) ;//        var oDOM = oEditor.EditorDocument ;//        var iLength ;//        if (document.all)        // If Internet Explorer.//        {//            iLength = oDOM.body.innerText.length ;//        }//        else                    // If Gecko.//        {//            var r = oDOM.createRange() ;//            r.selectNodeContents( oDOM.body ) ;//            iLength = r.toString().length ;//        }    //oEditor.InsertHtml('')    return iLength    }  
    function checks()
    {
         if(document.getElementById("<%=txtzhongwen.ClientID %>")=='0')
      {
       alert('请输入中文概况！');
       return false;
      }
      else{return true;}
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
    <form id="form1" runat="server">
        <div class="list1">
            <div>
                <h2 style="margin-bottom: 8px;">
                    <p>
                        <span><b>投资环境录入页</b></span></p>
                </h2>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    <td style="width: 12%">
                        区域中文概况：</td>
                    <td>
                        <%--<FCKeditorV2:FCKeditor ID="txtzhongwen" runat="server" Width="556" Height="252" BasePath="~/Vfckeditor/">
                        </FCKeditorV2:FCKeditor>--%>
                        <asp:TextBox ID="txtzhongwen" runat="server" TextMode="MultiLine" Height="183px" Width="98%"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        区域英文概况：</td>
                    <td >
                        <%--<FCKeditorV2:FCKeditor ID="txtengilsh" runat="server" Width="556" Height="252" BasePath="~/Vfckeditor/">
                        </FCKeditorV2:FCKeditor>--%>
                        <asp:TextBox ID="txtengilsh" runat="server" TextMode="MultiLine" Height="183px" Width="98%"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        上传图片：</td>
                    <td style="text-align: left">
                        <asp:FileUpload ID="uploadPic" runat="server" />&nbsp<asp:Button ID="btnUpdatefile"
                            runat="server" Text="上 传" Height="20px" onfocus="this.blur()" OnClientClick="return showCheck()" OnClick="btnUpdatefile_Click"
                            CssClass="btn" />
                             <div id="imgLoding" style="display: none;">
                                <img src="http://www.topfo.com/Web13/images/down.gif" alt="Loading" />图片上传中
                            </div>
                            </td>
                </tr>
                <tr>
                    <td>
                        图片描述：</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtmiao" runat="server"></asp:TextBox></td>
                </tr>
                <tr runat="server">
                    <%--           <tr><td colspan="3"><input type="checkbox" onclick="cheakall(this)"/>全选/反选</td></tr>--%>
                    <td>
                        图片：</td>
                    <td>
                        <div>
                            <asp:DataList ID="DataList1" runat="server" CaptionAlign="Bottom" 
                                RepeatColumns="3" RepeatDirection="Vertical">
                                <HeaderTemplate>
                                    <input type="checkbox" onclick="cheakall(this)" />全选/反选&nbsp
                                    <asp:Button ID="Button1" onfocus="this.blur()" runat="server" CssClass="button1"
                                        Text="删除图片 " OnClick="btnsave_Click" /></HeaderTemplate>
                                <ItemTemplate>
                                    <table style="height: auto; overflow: hidden">
                                        <tr>
                                            <td>
                                                <img alt='<%# Eval("Descript") %>' src='<%#GetType(Convert.ToString( Eval("Descript")))%>'
                                                    height="75px" width="100px" /><br />
                                                <asp:CheckBox ID="chckimage" runat="server" CausesValidation="true" />
                                                <asp:HiddenField ID="HiddenField1" Value='<%# Eval("Descript") %>' runat="server" />
                                                <asp:HiddenField ID="HiddenField2" Value='<%# Eval("Shuoming") %>' runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center">
                            &nbsp &nbsp<asp:Button ID="btnSave" onfocus="this.blur()" CssClass="btn" runat="server"
                                OnClientClick="return checks()" Text="保 存" OnClick="btnSave_Click" />&nbsp
                                <input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
