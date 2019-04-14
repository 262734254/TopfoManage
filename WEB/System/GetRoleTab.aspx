<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetRoleTab.aspx.cs" Inherits="System_GetRoleTab" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 
 <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
<link href="../css/style1.css" type="text/css" rel="stylesheet" />
  <STYLE type="text/css">
    .btn{width:65px;height:23px;background:url(../image/40.gif) no-repeat left top;border:none;cursor:pointer;}
    </STYLE>
    
    <title>后台管理</title>
    <script language="javascript" type="text/javascript">
        function CheckShow(a)
        {
            var checkb = document.getElementsByTagName("input");
            for (var i = 0; i < checkb.length; i++)
            {
                checkb[i].checked = a.checked;
            }
        }
      
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title"><h2><p><span><b>管理角色</b></span></p></h2></div>
    
        <asp:GridView ID="GridRoleTab" runat="server" AutoGenerateColumns="False" DataKeyNames="SRoleID" ShowFooter="True" CssClass="one_table two_table" >
            <Columns> 
                <asp:TemplateField HeaderText="多选">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SRoleID" HeaderText="ID" />
                <asp:BoundField DataField="SRName" HeaderText="名称" />
                <asp:BoundField DataField="SRDoc" HeaderText="角色描述" />
                <asp:BoundField DataField="SRDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" HeaderText="创建日期" />
                 
                 <asp:TemplateField HeaderText="状态"> 
                                               <ItemTemplate> 
                                                 
                                                          
           <asp:Label ID="lbname" runat="server" Text='<%#Eval("SRCheck").ToString()=="1"?"已通过":"未通过"%>'>
                                                  
                                                  </asp:Label>                 
                                                                
               </ItemTemplate> 
                                                 
                    <HeaderStyle HorizontalAlign="Center" /> 
                  </asp:TemplateField>
                
                <asp:TemplateField HeaderText="审核">
                 
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                        <asp:LinkButton ID="LinkCheck" runat="server" CommandArgument='<%# Eval("SRoleID") %>' OnClientClick="return confirm('确认审核！')" OnClick="LinkCheck_Click">审核</asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
                
                <asp:TemplateField HeaderText="权限">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                        <asp:LinkButton ID="LinkQuan" runat="server" CommandArgument='<%# Eval("SRoleID") %>' OnClick="LinkQuan_Click">权限</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                 <asp:TemplateField HeaderText="删除">
                 
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                        <asp:LinkButton ID="LinkDelete" runat="server" CommandArgument='<%# Eval("SRoleID") %>' OnClientClick="return confirm('是否删除！')" OnClick="LinkDelete_Click">删除</asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
                
                
                
                <asp:TemplateField HeaderText="修改">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                        <asp:LinkButton ID="LinkUpdate" runat="server" CommandArgument='<%# Eval("SRoleID") %>' OnClick="LinkUpdate_Click">查看/修改</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            <HeaderStyle Font-Size="Smaller" />
        </asp:GridView>
        <br />
        <asp:Button ID="InsertBut" runat="server" CssClass="btn" OnClick="InsertBut_Click" Text="增加角色" />
        <asp:Button ID="butZu" runat="server" CssClass="btn" OnClick="butZu_Click" Text="查看组表" />
       
    </form>
</body>
</html>
