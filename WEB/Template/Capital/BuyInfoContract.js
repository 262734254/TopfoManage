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

var xmlhttp;
function url1()
{
 window.location.href= "http://member.topfo.com/login.aspx?ReturnUrl=" + window.location.href;
}
function fillGridAll(InfoID)
{

   var vLoginName = GetCookie("topfo.com_CKData");

    if(vLoginName == null)
    {
     document.getElementById("denglu").innerHTML="您暂时还不能查看该资源联系方式，因为你还不是我们的会员或没登陆！&gt;&gt;<a href='http://member.topfo.com/Register/Register.aspx'target='_blank' class='f_line'>[注册会员]</a><a href='#' onclick='url1();'>登录</a>";

//       alert("您需要登陆后才能查看联系信息，请先登陆!");
//        window.location.href= "http://member.topfo.com/login.aspx?ReturnUrl=" + window.location.href;
        
    }
     else
    {
    
    if(document.getElementById("LXFSDetailContentInDown")!=null)
    {
        document.getElementById("LXFSDetailContentInDown").style.display="block";
    }
 var url ="http://www.topfo.com/webservice/PriceService.asmx/GetContactDetail_New?infoid="+InfoID+"&LoginName="+vLoginName;

      
    if(window.XMLHttpRequest)
    {                          
        xmlhttp=new XMLHttpRequest();        
    } 
        if(window.ActiveXObject)
        {
            try
            {
                xmlhttp= new ActiveXObject("Msxml2.XMLHTTP");
            }
            catch(e)
            {                
                try
                {
                    xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
                }
                catch(e)
                {
//                    alert(e.name + ":" + e.message);
                }
            }
        }                                  
    if(xmlhttp)
    {
        try
        {                                                                         
            if(!xmlhttp && typeof XMLHttpRequest!='undefined') 
            {
              xmlhttp = new XMLHttpRequest();
            }                                                        
            xmlhttp.open("get",url, true); 
           
            xmlhttp.onreadystatechange = function() 
            {
                if(xmlhttp.readyState==4 && xmlhttp.status == 200) 
                {                                                
                    fillGridOtherResource_Change(xmlhttp,InfoID);
                }
                
            }
            xmlhttp.send(null);                                            
        }
        catch(e)
        {
//            alert(e.name + ":" + e.message);
        }
      }
    }
    
}
function fillGridOtherResource_Change(xmlhttp,InfoID)
{
    try
    {                                 
        if(xmlhttp.readyState==4 && xmlhttp.status == 200)
        {  
                                                  
            var ReNode=xmlhttp.responseXML.documentElement.childNodes;  
            var nodeStr = ReNode.item(0).nodeValue;
            node = ReNode.item(0).nodeValue;
            var vRetTemp =node;
//            alert(nodeStr);
            if(node.length<20)
            {
            
            }
            else
            {
             document.getElementById("LXFSDetailContentInDown").style.display="block";
             document.getElementById("LXFSDetailContentInDown").innerHTML=nodeStr;     
            }    
        }
        else
        {          
            alert("xmlhttp.readyState:"+xmlhttp.readyState);                                  
        }
    }  
     catch(e)
    {
        alert(e.name + ":" + e.message);
    }                              
}     