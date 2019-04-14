// JScript 文件

document.domain = "topfo.com";

    function crossSubDomainRequest(adv,LoginForm) 
    { 
       if(LoginForm=="" || LoginForm==null)
       {
          LoginForm="游客";
       }
        var proxy = document.getElementById("iframeProxy").contentWindow;
        var lg=encodeURI(LoginForm);
        var now=new Date();
        var stat=now.toLocaleString();
        var yy=stat.split('年');
        var MM=yy[1].split('月');
        var dd=MM[1].split('日');
        var time=yy[0]+"-"+MM[0]+"-"+dd[0]+dd[1];
        proxy.sendRequest("http://crm.topfo.com/advertise/Handler.ashx?adv="+adv+"&name="+lg+"&time="+time+""); 
    } 




 function Domain(adv,LoginForm)
 {
   crossSubDomainRequest(adv,LoginForm);
 }

