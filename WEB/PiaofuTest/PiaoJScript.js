// JScript 文件

document.writeln("<div id=\"xixi\" onmouseover=\"toBig()\" onmouseout=\"toSmall()\">");
document.writeln("<table style=\"float: left\" border=\"0\" cellspacing=\"0\"cellpadding=\"0\" width=\"157\">");
document.writeln("<tbody>");
document.writeln("<tr>");
document.writeln ("<td class=\"main_head\" height=\"39\" valign=\"top\">&nbsp;<\/td><\/tr>");
document.writeln("<tr>");
document.writeln("<td class=\"info\" valign=\"top\">");
document.writeln("<table class=\"qqtable\" border=\"0\" cellspacing=\"0\"  width=\"120\" align=\"center\">");
document.writeln("<tbody>");
document.writeln("<tr>");
document.writeln("<td align=\"middle\"><a href=\"http:\/\/www.topfo.com\/\" target=\"_blank\"><img border=\"0\" src=\"images/kefu_head.gif\"><\/a> <\/td> <\/tr>");
document.writeln("<tr>");
document.writeln("<td height=\"5\"><\/td><\/tr>");
document.writeln("<tr>");
document.writeln("<td height=\"30\" align=\"middle\"><span><a href=\"http:\/\/wpa.qq.com/msgrd?V=1&Uin=262734254&Site=http:\/\/www.topfo.com\/\&Menu=yes\" target=\"_blank\" title=\"在线客服\"><img src=\"images/qq_12606688_on.gif\" border=\"0\" align=\"absmiddle\"><\/a><\/span><\/td><\/tr>");
document.writeln("<tr>");
document.writeln("<td height=\"30\" align=\"middle\"><span>QQ:12345678901<\/span><\/td><\/tr>");
document.writeln("<tr>");
document.writeln("<td height=\"5\"><\/td><\/tr>");
document.writeln("<tr>");
document.writeln("<td height=\"35\" valign=\"top\" align=\"middle\"><a href=\"http:\/\/www.topfo.com\/\" target=\"_blank\"><img border=\"0\" src=\"images/img3-5-btn1.gif\" width=\"90\" height=\"25\"><\/a><\/td><\/tr>");
document.writeln("<tr>");
document.writeln("<td height=\"38\" valign=\"top\" align=\"middle\"><a href=\"http:\/\/www.topfo.com\/\" target=\"_blank\"><img border=\"0\" src=\"images/img3-5-btn2.gif\" width=\"90\" height=\"25\"><\/a><\/td><\/tr>");
document.writeln("<tr>");
document.writeln("<td align=\"middle\">");
document.writeln("<div class=\"qun\"><font color=\"#9b9b9b\">中国招商投资网\</font><br/><span>11111<\/span><\/div><\/td><\/tr>");
document.writeln("<tr>");
document.writeln("<td align=\"middle\">");
document.writeln("<div class=\"qun\"><font color=\"#9b9b9b\">中国招商投资网<\/font><br/><span>1111<\/span><\/div><\/td></tr>");
document.writeln("<tr>");
document.writeln("<td align=\"middl\">&nbsp;<\/td><\/tr><\/tbody><\/table><\/td><\/tr>");
document.writeln("<tr>");
document.writeln("<td class=\"down_kefu valign=top\"><\/td><\/tr><\/tbody><\/table>");
document.writeln("<div class=\"Obtn\">");
document.writeln("<\/div>");
document.writeln("<\/div>")



xx=function (id,_top,_left){
		var me=id.charAt?document.getElementById(id):id, d1=document.body, d2=document.documentElement;
		d1.style.height=d2.style.height='100%';me.style.top=_top?_top+'px':0;me.style.left=_left+"px";//[(_left>0?'left':'left')]=_left?Math.abs(_left)+'px':0;
		me.style.position='absolute';
		setInterval(function (){me.style.top=parseInt(me.style.top)+(Math.max(d1.scrollTop,d2.scrollTop)+_top-parseInt(me.style.top))*0.1+'px';},10+parseInt(Math.random()*20));
		return arguments.callee;
		};
		window.onload=function (){
		xx
		('xixi',100,-152)
		}
		
		
		
		
		
		
		
		
		
			lastScrollY=0; 
			
			var InterTime = 1;
			var maxWidth=-1;
			var minWidth=-152;
			var numInter = 8;
			
			var BigInter ;
			var SmallInter ;
			
			var o =  document.getElementById("xixi");
				var i = parseInt(o.style.left);
				function Big()
				{
					if(parseInt(o.style.left)<maxWidth)
					{
						i = parseInt(o.style.left);
						i += numInter;	
						o.style.left=i+"px";	
						if(i==maxWidth)
							clearInterval(BigInter);
					}
				}
				function toBig()
				{
					clearInterval(SmallInter);
					clearInterval(BigInter);
						BigInter = setInterval(Big,InterTime);
				}
				function Small()
				{
					if(parseInt(o.style.left)>minWidth)
					{
						i = parseInt(o.style.left);
						i -= numInter;
						o.style.left=i+"px";
						
						if(i==minWidth)
							clearInterval(SmallInter);
					}
				}
				function toSmall()
				{
					clearInterval(SmallInter);
					clearInterval(BigInter);
					SmallInter = setInterval(Small,InterTime);
					
				}
