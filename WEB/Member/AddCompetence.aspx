<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCompetence.aspx.cs" Inherits="ManageSystem_AddCompetence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript"  src="../css/jquery.js"></script>
    <script type="text/javascript" language="javascript">
     var managetype='<%=Request.QueryString["ManageTypeID"] %>';
    var membertype='<%=Request.QueryString["MemberGradeID"] %>';
    function getlist(managetype0,membertype0)
    {
    var str=ManageSystem_AddCompetence.getName(managetype0,membertype0);
    if(str.value!=null)
    {
     var wo=str.value.split(',');
     var all = document.getElementsByTagName("input"); 
      for(var i=0;i<all.length;i++)
            { 
            var a=all[i].name.split('*');
                for(var j=0;j<wo.length;j++)
                {
                    if(a[0]==wo[j])
                    {
                     all[i].checked = true;
                    }
                }
               
            }

        }
    }
    function Sub(managetype1,membertype1)
    {       var quan="";
            var all = document.getElementsByTagName("input");
            for(var i=0;i<all.length;i++)
            {
                if(all[i].checked)
                {  var a=all[i].name.split('*');
                    if(quan=='')
                    {
                    quan=a[0];
                    }
                     else{  quan+=','+a[0];}
                }
                
            }   
             var str=ManageSystem_AddCompetence.Competence_Update(managetype1,membertype1,quan);
             if(str.value>0)
             {
             window.location.href="AddMenu.aspx";
             }else{alert("更新失败"+str.value);}
        
    }
    function chc(m,v)
    {
        if(m.checked)
        {
         
        v.checked=true;
         
        }
    }
     </script>
</head>
<body onload="getlist(managetype,membertype)">
    <form id="form1" runat="server">
    <div  style=" margin:10px 200px 10px 200px">
    添加权限:
   
    <span id="span1"  runat="server"></span>
      
      

    </div>
    </form>
</body>
</html>
