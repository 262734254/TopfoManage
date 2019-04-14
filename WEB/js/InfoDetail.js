var xmlhttp;
      
//获取资源的核心信息
function GetContactDetail(InfoID)
{
    var vLoginName = GetCookie("topfo.com_CKData"); 
    
    if(vLoginName == null)
    {
        alert("您需要登陆后才能查看联系信息，请先登陆!");
        window.location.href= "http://member.topfo.com/login.aspx?ReturnUrl=" + window.location.href;
    }
    var url = "/WebSerivce/TopfoInfo.asmx/GetContactDetail?infoid="+InfoID;
    
    if(window.XMLHttpRequest)
    {                          
        xmlhttp=new XMLHttpRequest();       
    }
    else //code for IE
    {
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
                    alert(e.name + ":" + e.message);
                }
            }
        }    
    }                              
//    if(xmlhttp)
//    {
//        try
//        {                                                                         
//            if(!xmlhttp && typeof XMLHttpRequest!='undefined') 
//            {
//              xmlhttp = new XMLHttpRequest();
//            }                                                        
//            xmlhttp.open("get",url, true); 
//            xmlhttp.onreadystatechange = function() 
//            {
//                if(xmlhttp.readyState==4 && xmlhttp.status == 200) 
//                {                                                
//                    fillContactByID_Change(xmlhttp);
//                }
//            }
//            xmlhttp.send(null);                                            
//        }
//        catch(e)
//        {
//            alert(e.name + ":" + e.message);
//        }         
//    } 
}

//function fillContactByID_Change()
//{
//    try
//    {                                 
//        if(xmlhttp.readyState==4 && xmlhttp.status == 200)
//        {
//            var ReNode=xmlhttp.responseXML.documentElement.childNodes;  
//            node = ReNode.item(0).nodeValue;
//            var vRetTemp =node;
//            var arr = vRetTemp.split('|'); 
//            var arrLen = arr.length;
//            
//            if(window.document.getElementById("div_Contact")!=null)
//            {
//                window.document.getElementById("div_Contact").innerHTML = arr[0]; 
//            }   
//            if(window.document.getElementById("div_Attachment")!=null)
//            {
//                window.document.getElementById("div_Attachment").innerHTML = arr[1]; 
//            }    
//            //merchant
//            if(arrLen==5)
//            {
//                if(window.document.getElementById("div_ProjectStatus")!=null)
//                {
//                    window.document.getElementById("div_ProjectStatus").innerHTML = arr[2]; 
//                }
//                if(window.document.getElementById("div_Market")!=null)
//                {
//                    window.document.getElementById("div_Market").innerHTML = arr[3]; 
//                }
//                if(window.document.getElementById("div_Benefit")!=null)
//                {
//                    window.document.getElementById("div_Benefit").innerHTML = arr[4]; 
//                } 
//            }
//            //project
//            //GQ
//            if(arrLen==11)
//            {
//                if(window.document.getElementById("div_Dwlyysy")!=null && arr[2] != "undefined")
//                {
//                    window.document.getElementById("div_Dwlyysy").innerHTML = arr[2] + " 万元(人民币)"; 
//                }  
//                if(window.document.getElementById("div_Dwljly")!=null && arr[3] != "undefined")
//                {
//                    window.document.getElementById("div_Dwljly").innerHTML = arr[3] + " 万元(人民币)"; 
//                }  
//                if(window.document.getElementById("div_Dwlyysy")!=null && arr[4] != "undefined")
//                {
//                    window.document.getElementById("div_Dwzzc").innerHTML = arr[4] + " 万元(人民币)"; 
//                }  
//                if(window.document.getElementById("div_Dwzzc")!=null && arr[5] != "undefined")
//                {
//                    window.document.getElementById("div_Dwzfz").innerHTML = arr[5] + " 万元(人民币)"; 
//                }  
//                //ZQ
//                if(window.document.getElementById("div_CompanyYearIncome")!=null && arr[2] != "undefined")
//                {
//                    window.document.getElementById("div_CompanyYearIncome").innerHTML = arr[2] + " 万元(人民币)"; 
//                } 
//                if(window.document.getElementById("div_CompanyNG")!=null && arr[3] != "undefined")
//                {
//                    window.document.getElementById("div_CompanyNG").innerHTML = arr[3] + " 万元(人民币)"; 
//                } 
//                if(window.document.getElementById("div_CompanyTotalCapital")!=null && arr[4] != "undefined")
//                {
//                    window.document.getElementById("div_CompanyTotalCapital").innerHTML = arr[4] + " 万元(人民币)"; 
//                } 
//                if(window.document.getElementById("div_CompanyTotalDebet")!=null && arr[5] != "undefined")
//                {
//                    window.document.getElementById("div_CompanyTotalDebet").innerHTML = arr[5] + " 万元(人民币)"; 
//                } 
//                //P
//                if(window.document.getElementById("div_ProjectAbout")!=null && arr[6] != "undefined")
//                {
//                    window.document.getElementById("div_ProjectAbout").innerHTML = arr[6]; 
//                }  
//                if(window.document.getElementById("div_marketAbout")!=null && arr[7] != "undefined")
//                {
//                    window.document.getElementById("div_marketAbout").innerHTML = arr[7]; 
//                }  
//                if(window.document.getElementById("div_competitioAbout")!=null && arr[8] != "undefined")
//                {
//                    window.document.getElementById("div_competitioAbout").innerHTML = arr[8]; 
//                }  
//                if(window.document.getElementById("div_BussinessModeAbout")!=null && arr[9] != "undefined")
//                {
//                    window.document.getElementById("div_BussinessModeAbout").innerHTML = arr[9]; 
//                }  
//                if(window.document.getElementById("div_ManageTeamAbout")!=null && arr[10] != "undefined")
//                {
//                    window.document.getElementById("div_ManageTeamAbout").innerHTML = arr[10]; 
//                }  
//            }
//            //capital
//            if(window.document.getElementById("div_InvestorIntro")!=null)
//            {
//                window.document.getElementById("div_InvestorIntro").innerHTML = arr[2]; 
//            }   
//        }
//        else
//        {          
//            alert("xmlhttp.readyState:"+xmlhttp.readyState);                                  
//        }
//    }  
//    catch(e)
//    {
//        alert(e.name + ":" + e.message);
//    }                              
//}




//取得名称为name的cookie值 
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

function getCookieVal(offset)
{
    var endstr = document.cookie.indexOf (";", offset);
    if (endstr == -1)
    endstr = document.cookie.length;
    return document.cookie.substring(offset,endstr);
}
