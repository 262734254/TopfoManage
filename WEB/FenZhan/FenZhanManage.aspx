<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FenZhanManage.aspx.cs" Inherits="FenZhan_FenZhanManage" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />
   <script language="javascript" type="text/jscript" src="../js/Common1.js"></script>
    <script language="javascript" type="text/javascript">
          function Modfiy(Id)
          {
             var url="ModfiyFenZhan.aspx?ModfiyId="+Id;
             window.location.href=url;
          }
         
          function CreateIndex(Address)
          {
             var url="FenZhanManage.aspx?Address="+encodeURI(Address);
             window.location.href=url;
          }
          
          function Look(Address)
          {
               window.open(Address);
          }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainconbox">
            <div class="title" align="center">
                <h2>
                    <p><span><b>分站管理</b></span></p>
                </h2>
            </div>
               <div class=" cshibiank">
                <table border="0" width="100%" cellpadding="0" cellspacing="0" align="center" class="one_table">
                      <tr>
                        <th width="7%" align="center" class="tabtitle" style="height: 29px"><a href="Javascript:js.IsSelect(true,'Cbox');">全</a>|<a href="Javascript:js.IsSelect(false,'Cbox');">反</a></th>
                        <th align="center" width="7%" class="tabtitle">序号</th>
                        <th align="center" width="14%" class="tabtitle">站点名称</th>
                        <th align="center" width="20%" class="tabtitle"> 站点地址</th>
                        <th align="center" width="10%" class="tabtitle"> 建立时间</th>
                        <th align="center" width="18%" class="tabtitle">管理</th>
                    </tr>    
                    <asp:Repeater ID="FenZhanList" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                                <td align="center">
                                    <label>
                                        <asp:CheckBox runat="server" ID="Cbox" ToolTip='<%# Eval("id") %>' />
                                    </label>
                                </td>
                                <td align="center">
                                  <%# Container.ItemIndex + 1 %>
                                </td>
                                <td align="center">
                                    <%# Eval("FenZhanName") %>
                                </td>
                                <td align="center">
                                   <%# Eval("Address") %>
                                </td>
                                <td align="center">
                                   <%# Convert.ToDateTime(Eval("CreateTime")).ToString("yyyy-mm-dd") %>
                                </td>
                                <td align="center">
                                    <a href='javascript:Modfiy(<%# Eval("Id") %>)'>修改</a>
                                    <a href='javascript:CreateIndex("<%# Eval("Address") %>")'>生成首页</a>
                                    <a href='javascript:Look("<%# Eval("Address").ToString().Replace(".aspx",".html") %>")'>查看</a>
                                    <asp:Label runat="server" ID="Address" Visible="false" Text='<%# Eval("Address") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <div style=" margin-left:5px; margin-top:5px;">
           <input type="button" value="添加分站" class="btn" onclick="window.location.href='AddFEnZhan.aspx';" />
            <asp:Button ID="BtnDelChecked" CssClass="btn" runat="server"
                Text="生成静态" OnClientClick="return js.DelChecked('Cbox','请选择需要生成的项!','');" OnClick="BtnDelChecked_Click" />
        </div>
    </form>
</body>
</html>