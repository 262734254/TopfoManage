<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecommResource.aspx.cs" Inherits="MerchantManage_RecommResource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />

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
                var url="Hander.aspx?MuneName="+MuneName;
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
                     
                        return true;
                    }else if(xmlHttp.responseText=="false"){
                        //菜单名不存在
                        alert("您输入的用户名不存在");
                        return false;
                    }else{
                        //访问出错
                          alert("获取信息出错");
                        return false;
                    }
                }
            }
    }
     function exists()
    {
     var MuneName=document.getElementById("<%=txtIndex.ClientID %>").value;
      if(MuneName=="")
       {
       alert("用户名不能为空");
       return false;
       }
    if(MuneName=="输入您要推荐的用户")
       {
       alert("请输入您要推荐的用户");
       return false;
       }
    }
    </script>

    <script type="text/javascript" src="code1.js">
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="height:1000px">
            <table border="0" cellpadding="0" cellspacing="0"  align="center" class="one_table">
                <tr style="background: #bcd9e7; height: 27px;">
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        编号</th>
                    <th width="30%" align="center" class="tabtitle" style="height: 32px">
                        标题</th>
                    <%--<th width="10%" align="center" class="tabtitle" style="height: 32px">
                        管理</th>--%>
                </tr>
                <asp:Repeater ID="NewsList" OnItemDataBound="NewsList_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <tr onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''">
                            <td align="center" style="width: 100px">
                                <%#Eval("InfoID") %>
                                <td align="center">
                                    <asp:HyperLink ID="hlTitle" runat="server"></asp:HyperLink>
                                </td>
                               <%-- <td style="width: 100px" align="center">
                                    删除
                                    <asp:LinkButton ID="lbdel" CommandArgument='<%#Eval("InfoID")%>' CommandName="del"
                                        runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton>
                                </td>--%>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table">
                <tr>
                    <td align="left" style="height: 24px">
                        我要把以上资源推荐给<asp:TextBox ID="txtIndex" Text="输入您要推荐的用户" onfocus="if(this.value=='输入您要推荐的用户'){this.value='';this.style.color='#333333'}"
                            runat="server" Width="138px" Height="22px" ToolTip="输入您要推荐的用户" AutoCompleteType="Disabled"></asp:TextBox>&nbsp;
                        <asp:Button ID="btnIndexStatic" CssClass="btn" runat="server" Text="推荐" OnClientClick="return exists();" OnClick="btnIndexStatic_Click" />&nbsp;
                        <input type="button" id="Button3" onclick="history.back();" value="返回" class="btn" />
                    </td>
                </tr>
            </table>

            <script type="text/javascript" language="javascript">
                var oo=new mSift('oo',8);
                oo.Data=[<%=strs %>];
                oo.Create(document.getElementById('<%=txtIndex.ClientID %>'));
            </script>

        </div>
    </form>
</body>
</html>
