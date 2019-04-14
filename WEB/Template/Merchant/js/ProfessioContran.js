// JScript 文件

//取得名称为name的cookie值 
var InfoID;
function GetCookie(name) 
{ 
var arg = name + "="; 
var alen = arg.length; 
var clen = document.cookie.length; 
var i = 0; 
while (i < clen) 
{ 
var j = i + alen; 
if (document.cookie.substring(i, j) == arg) 
return getCookieVal (j); 
i = document.cookie.indexOf(" ", i) + 1; 
if (i == 0) break; 
} 
return null; 
} 

function getCookieVal (offset)
{

 
var endstr = document.cookie.indexOf (";", offset);
if (endstr == -1)
endstr = document.cookie.length;
return document.cookie.substring(offset,endstr);
}


function url1()
{
 window.location.href= "http://member.topfo.com/login.aspx?ReturnUrl=" + window.location.href;
}
var xmlhttp;
        function createXMLHTTP()
        {
          
            if(window.XMLHttpRequest)
            {
                xmlhttp=new XMLHttpRequest();//mozilla浏览器
            }
            else if(window.ActiveXObject)
            {
                try
                {
                    xmlhttp=new ActiveXObject("Msxml2.XMLHTTP");//IE老版本
                }
                catch(e)
                {}
                try
                {
                    xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");//IE新版本
                }
                catch(e)
                {}
                if(!xmlhttp)
                {
                    window.alert("不能创建XMLHttpRequest对象实例！");
                    return false;
                }
            }
        }
function fillGridAll(InfoID)
{
  
   var vLoginName = GetCookie("topfo.com_CKData");
    if(vLoginName == null)
    {
        document.getElementById("denglu").innerHTML="您暂时还不能查看该资源联系方式，因为你还不是我们的会员或没登陆！&gt;&gt;<a href='http://member.topfo.com/Register/Register.aspx'target='_blank' class='f_line'>[注册会员]</a><a href='#' onclick='url1();'>登录</a>";
    }
    else
     {
        if(document.getElementById("LXFSDetailContentInDown")!=null)
           {
             document.getElementById("LXFSDetailContentInDown").style.display="block";
           }
            createXMLHTTP();                                                            
            var url ="http://www.topfo.com/webservice/ProfessionaService.asmx/GetProfessiona?infoid="+InfoID;
            xmlhttp.open("get",url, true); 
            xmlhttp.onreadystatechange = Methodcheck; 
            xmlhttp.send(null);
     }
}
          function Methodcheck()
          {
             if(xmlhttp.readyState==4)//判断对象状态
            {
                if(xmlhttp.status==200)//信息成功返回，开始处理信息
                { 
                    var ReNode=xmlhttp.responseXML.documentElement.childNodes;  
                    var nodeStr = ReNode.item(0).nodeValue;
                    node = ReNode.item(0).nodeValue;
                    var vRetTemp =node;
                    if(node.length<20)
                    {
                    
                    }
                    else
                    {
                     document.getElementById("LXFSDetailContentInDown").style.display="block";
                     document.getElementById("LXFSDetailContentInDown").innerHTML=nodeStr;     
                    }    
                }
            }
       }
    