<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModfiyVideo.aspx.cs" Inherits="Video_ModfiyVideo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />
    <title></title>
    <style type="text/css"> 
.f_red{color:red}
.f_td{width:15%;background-color:#f7f7f7;
}
</style>

    <script language="javascript" type="text/javascript" src="../js/Common1.js"></script>

    <script language="javascript" type="text/javascript">
     function CheckNull()
     {
           var Title=js.$("txtTitle");
           if(js.Trim(Title.value)=="")
           {
               alert("请输入标题!");
               Title.focus();
               return false;
           }
        
           var ImgReg=/^.*(.jpg|.bmp|.gif|.png)/g;
           var ImgUrl=js.$("<%=txtImgUrl.ClientID %>");
           if(js.Trim(ImgUrl.value)=="")
           {
              alert("请输入图片地址!");
              ImgUrl.focus();
              return false;
           }
           
           if(!ImgReg.test(ImgUrl.value.toLowerCase()))
           {
               alert("图片格式不正确!");
               ImgUrl.focus();
               return false;
           }
           
           var VideoUrl=js.$("<%=txtVideoUrl.ClientID %>");
           if(js.Trim(VideoUrl.value)=="")
           {
              alert("请输入Url地址!");
              VideoUrl.focus();
              return false;
           }
           
           var VideoType=js.$("<%=DropVideoType.ClientID %>");
           if(VideoType.options[VideoType.selectedIndex].value=="-1")
           {
               alert("请选所属资源!");
               VideoType.focus();
               return false;
           }
           
           var Dropzhuanti=js.$("<%=Dropzhuanti.ClientID %>");
           if(Dropzhuanti.options[Dropzhuanti.selectedIndex].value=="-1")
           {
               alert("请选类别!");
               Dropzhuanti.focus();
               return false;
           }
           return true;
       }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="title" align="center">
            <h2>
                <p>
                    <span><b><a href="VideoList.aspx">视频/专题管理</a></b></span></p>
            </h2>
            <h2>
                <p>
                    <span><b>修改/专题视频</b></span></p>
            </h2>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>标题：</td>
                <td>
                    <input id="txtTitle" runat="server" type="text" style="width: 238px; height: 20px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>图片地址：</td>
                <td>
                    <input id="txtImgUrl" runat="server" type="text" style="width: 238px; height: 20px" />
                    <span class="f_red">图片格式(jpg|gif|bmp|png)</span>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>链接地址：</td>
                <td>
                    <input id="txtVideoUrl" runat="server" type="text" style="width: 238px; height: 20px" />
                    <%--<span class="f_red">(示例:http://www.topfo.com/) </span>--%>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>资源类型：</td>
                <td>
                    <asp:DropDownList ID="DropVideoType" Width="200" runat="server" Style="width: 238px;
                        height: 20px">
                        <asp:ListItem Value="-1">请选择</asp:ListItem>
                        <asp:ListItem Value="0">招商方</asp:ListItem>
                        <asp:ListItem Value="1">投资方</asp:ListItem>
                        <asp:ListItem Value="2">融资方</asp:ListItem>
                        <asp:ListItem Value="3">展会</asp:ListItem>
                        <asp:ListItem Value="4">资金贷款</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                   <td align="right" class="f_td">
                        <span class="f_red">*</span>类别：</td>
                    <td>
                        <asp:DropDownList ID="Dropzhuanti" Width="200" runat="server" Style="width: 238px;
                            height: 20px">
                            <asp:ListItem Value="-1">请选择</asp:ListItem>
                            <asp:ListItem Value="0">视频</asp:ListItem>
                            <asp:ListItem Value="1">专题</asp:ListItem>
                        </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>展示位置：</td>
                <td>
                    <asp:DropDownList ID="DropShowPosition" runat="server" Style="width: 238px; height: 20px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    序列号：</td>
                <td>
                    <input id="txtSort" onkeyup="value=value.replace(/[^0-9]/g,'')" onblur="value=value.replace(/[^0-9]/g,'')" runat="server" type="text" style="width: 238px; height: 20px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    是否推荐：</td>
                <td>
                    <asp:RadioButtonList ID="RadioRecommend" RepeatLayout="Flow" RepeatDirection="Horizontal"
                        runat="server">
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        <asp:ListItem Value="1">是</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    描述：</td>
                <td>
                    <textarea id="txtRemarks" runat="server" style="width: 538px; height: 200px">
                      </textarea>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" OnClick="BtnModfiy_Click" OnClientClick="return CheckNull();"
                        CssClass="btn" Text="修改" />
                    &nbsp;&nbsp;<input type="button" class="btn" onclick="location.href='VideoList.aspx';"
                        value="返回" />
                </td>
            </tr>
        </table>
        <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: 0px; left: 0px; width: 104%; height: 1652px; filter: alpha(opacity=60);">
            <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
            </div>
        </div>
    </form>
</body>
</html>

