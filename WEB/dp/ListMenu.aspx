<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListMenu.aspx.cs" Inherits="dp_ListMenu" %>

<link href="../css/CRM.css" rel="stylesheet" type="text/css" />
<link href="../css/style1.css" type="text/css" rel="stylesheet" />
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑角色权限</title>
    <style>
        body
        {
            font-family: verdana, helvetica, arial, sans-serif;
        }
        #mainMenu
        {
            background-color: #EEE;
            border: 1px solid #CCC;
            color: #000;
            width: 92%;
        }
        #menuList
        {
            margin: 0px;
            padding: 10px 0px 10px 15px;
        }
        li.menubar
        {
            background: url() no-repeat 0em 0.3em;
            font-size: 12px;
            line-height: 1.5em;
            list-style: none outside;
        }
        .menu, .submenu
        {
            margin-left: 15px;
            padding: 0px;
        }
        .menu li, .submenu li
        {
            background: url() no-repeat 0em 0.3em;
            list-style: none outside;
            float: left;
        }
        a.actuator
        {
            background-color: transparent;
            color: #000;
            font-size: 12px;
            padding-left: 15px;
            text-decoration: none;
        }
        a.actuator:hover
        {
            text-decoration: underline;
        }
        .menu li a, .submenu li a
        {
            background-color: transparent;
            color: #000;
            font-size: 12px;
            padding-left: 15px;
            text-decoration: none;
        }
        .menu li a:hover, submenu li a:hover
        {
            text-decoration: underline;
        }
        span.key
        {
            text-decoration: underline;
        }
    </style>

    <script type="text/javascript" language="javascript">

var MENU_ID_ARRAY = new Array();
<%=array %>
//第一级菜单2010-08-09 design by longbin

function check_all(menu_all,MENU_ID)
{  
 for (i=0;i<document.all(MENU_ID).length;i++)
 {  
   
   if(menu_all.checked)
      document.all(MENU_ID).item(i).checked=true;      
   else
      document.all(MENU_ID).item(i).checked=false;
   var IDStr = document.all(MENU_ID).item(i).id;
   var ID = IDStr.split('CB')[1];
   for (j=0;j<document.getElementsByName(ID).length;j++)
   {
        if(document.all(ID).item(j)!=null)
        {
            document.all(ID).item(j).checked = document.all(MENU_ID).item(i).checked;
        }
   }
 }

 if(i==0)
 {
   if(menu_all.checked)
      document.all(MENU_ID).checked=true;
   else
      document.all(MENU_ID).checked=false;
 }
}
//第二级子菜单 2010-08-09 design by longbin
function check0(id,id1)
{
   var nameStr = document.getElementById(id).id;
   var ID = nameStr.split('CB')[1];   
   for (j=0;j<document.getElementsByName(ID).length;j++)
   {
        if(document.all(ID).item(j)!=null)
        {
            document.all(ID).item(j).checked = document.getElementById(id).checked;
        }
   }
    var b=document.getElementById(id);
    var a=document.getElementById(id1);
    if(b.checked)
    {
        a.checked=true;
    }
}
function mysubmit()
{
var str="";
var all=document.getElementsByTagName("input")
for(var i=0;i<all.length;i++)
{  
   if(all[i].checked)
    {
        if(str=="")
        {
             str=all[i].value;
        }else
        {
            str+=","+all[i].value;
        }
    }
  }
  
  //document.getElementById("lblFuncIdStr").value=str;
  Form1.lblFuncIdStr.value = str;
  Form1.submit();
}
//第三级子菜单 2010-08-09 design by longbin
function check1(obj,ID)
{
   var cb = document.getElementById(ID);   
   cb.checked = obj.checked;
   var ckbox = document.getElementsByTagName("input");
   for(var i=0;i<ckbox.length;i++)
   {
       if(ckbox[i].type =="checkbox" && ckbox[i].name =="MENU_"+cb.name)
       {
            if(obj.checked)
            {
                ckbox[i].checked = obj.checked;
            }        
       }

   }
}
    </script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <div>
        <span id="span2"></span>&nbsp;<table class="small" cellspacing="0" cellpadding="3"
            width="100%" border="0">
            <tr>
                <td class="Big">
                    <span class="big3">&nbsp;&nbsp;编辑角色权限 - （<asp:Label ID="lblUserPriv" runat="server"></asp:Label>）</span>&nbsp;&nbsp;
                    <input id="lblFuncIdStr" type="hidden" runat="server" />
                    <input class="btn" onclick="mysubmit();" type="button" value="确定" />&nbsp;&nbsp;
                    <input class="btn" onclick="javascript:history.back()" type="button" value="返回" />
                </td>
            </tr>
        </table>
        <div id="mainMenu">
            <ul id="menuList">
                <asp:Repeater ID="rptMain" runat="server" OnItemDataBound="rptMain_ItemDataBound">
                    <ItemTemplate>
                        <li title='<%#Eval("SName")%>' style="float: left;">
                            <div style="float: left; width: 100%;">
                                <input type="checkbox" id='CB<%#Eval("SId")%>' name='MENU_<%#Eval("SId")%>' value='<%#Eval("Scode")%>'
                                   <%#GetIFCheck(Eval("scode")) %>  onclick="check_all(this,'<%#DataBinder.Eval(Container.DataItem,"Sid")%>');">
                                <span class="TableHeader">
                                    <%#Eval("SName")%></span>
                            </div>
                            <ul id="productsMenu" class="menu">
                                <asp:Repeater ID="rptChild" runat="server" OnItemDataBound="rptSecond_ItemDataBound">
                                    <ItemTemplate>
                                        <li>
                                            <input id="CB<%#Eval("Sid") %>" type="checkbox" onclick="check0('CB<%#Eval("Sid")%>','CB<%#Eval("SParentCode")%>');"
                                                name='<%#GetMenuId(Eval("Sparentsid"))%>' value='<%#Eval("Scode")%>' <%#GetIFCheck(Eval("scode")) %> />
                                            <span style="color:#FF6600";><%#Eval("SName")%></span>
                                            <ul id="newPhonesMenu" class="submenu">
                                                <asp:Repeater ID="rptThird" runat="server">
                                                    <ItemTemplate>
                                                        <li>
                                                            <input type="checkbox" name='<%#GetMenuId(Eval("Sparentsid"))%>' value='<%#Eval("Scode")%>'
                                                                onclick="check1(this,'CB<%#Eval("Sparentsid")%>');" <%#GetIFCheck(Eval("scode")) %> />
                                                            <span style="color:Black";><%#Eval("SName")%></span>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
