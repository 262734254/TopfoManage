<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<%
	string QUERY_STRING=Request.ServerVariables["QUERY_STRING"];
%>
<HTML>
	<HEAD>
		<title>[[ImageMap]] 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
		<link rel="stylesheet" href='style.css'>
		<script src=dialog.js></script><script src=../_shared.js></script>		
		<style>
		.row { HEIGHT: 22px }
		.cb { VERTICAL-ALIGN: middle }
		.itemimg { VERTICAL-ALIGN: middle }
		.editimg { VERTICAL-ALIGN: middle }
		.cell1 { VERTICAL-ALIGN: middle }
		.cell2 { VERTICAL-ALIGN: middle }
		.cell3 { PADDING-RIGHT: 4px; VERTICAL-ALIGN: middle; TEXT-ALIGN: right }
		.cb { }
		</style>
	</HEAD>
	<body unselectable="on">
		<table border="0" cellspacing="0" cellpadding="5" width="100%" align="center"  unselectable="on">
			<tr>
				<td style="padding:4px 0 1px 4px">						
						&nbsp;&nbsp;&nbsp;
						<IMG src="../images/ImageMap.gif" onclick="newMap();" Alt="[[AddHotSpot]]" class="dialogButton"
						onmouseover="CuteEditor_ColorPicker_ButtonOver(this);">
						<IMG src="../images/link.gif" onclick="Addlink(this);" Alt="[[insertlink]]" class="dialogButton"
						onmouseover="CuteEditor_ColorPicker_ButtonOver(this);">				
						&nbsp;&nbsp;&nbsp;
						<IMG src="../images/zoom_in.gif" onclick="Zoom_In();" Alt="[[ZoomIn]]" class="dialogButton"
						onmouseover="CuteEditor_ColorPicker_ButtonOver(this);"> <IMG src="../images/zoom_out.gif" onclick="Zoom_Out();" Alt="[[ZoomOut]]" class="dialogButton"
						onmouseover="CuteEditor_ColorPicker_ButtonOver(this);"> <IMG src="../images/bestfit.gif" onclick="BestFit();" Alt="[[BestFit]]" class="dialogButton"
						onmouseover="CuteEditor_ColorPicker_ButtonOver(this);"> <IMG src="../images/Actualsize.gif" onclick="Actualsize();" Alt="[[ActualSize]]" class="dialogButton"
						onmouseover="CuteEditor_ColorPicker_ButtonOver(this);">						
				</td>
			</tr>
			<tr>
				<td valign="top" height="280">
					<iframe ID="iframe" MARGINHEIGHT="1" MARGINWIDTH="1" src="../template.aspx" width="100%" scrolling="yes" height="100%"></iframe>
				</td>
			</tr>
			<tr>
				<td class="dialogFooter" vAlign="top" align="right" style="PADDING-RIGHT: 13px; PADDING-LEFT: 13px; PADDING-BOTTOM: 7px; PADDING-TOP: 7px">
					<table cellSpacing="0" cellPadding="1">
						<tbody>
							<tr>
								<td>
									<input type="button" value="[[Update]]" onclick="do_update()">&nbsp;&nbsp;
									<input type="button" value="[[Cancel]]" onclick="do_cancel()">&nbsp;
								</tr>
						</tbody>
					</table>
				</td>
			</tr>
		</table>			
		
<script>

var OxOaf9d=["dialogArguments","editor","window","document","img","contentWindow","iframe","onload","src","","src_cetemp","unselectable","on","text/html","replace","contentEditable","body","clearAttributes","marginTop","style","4","marginLeft","10","color","black","background","white","2D-Position","LiveResize","outerHTML","innerHTML","useMap","MAP","length","name","#","areas","href","target","alt","coords",",","\x3Cimg id=\x27myIMAGE","\x27 border=1 src=\x27../images/space.gif\x27 alt=\x27[[AddLinktoImageMap]]\x27 style=\x27position:absolute;left:","px;top:","px;width:","px;height:","px;z-index:","\x27\x3E","type","selection","Control","parentNode","tagName","IMG","id","dialogWidth:350px;dialogHeight:212px;help:no;scroll:no;status:no;resizable:0;","frameloaded","returnValue","keyCode","zoom","height","width","\x27  border=1 src=\x27../images/space.gif\x27 alt=\x27[[AddLinktoImageMap]]\x27 style=\x27position:absolute;z-index:",";width:20;height:20;left:0;top:0\x27\x3E","wheelDelta","0%","myIMAGE","\x3Carea shape=\x27rect\x27 coords=\x27","\x27","href=\x27","\x27 ","target=\x27","alt=\x27","\x3E","PasteHTML","\x3Cmap name=\x27","\x3C/map\x3E","off","AutoMap"];var obj=top[OxOaf9d[0x0]];var editor=obj[OxOaf9d[0x1]];var editwin=obj[OxOaf9d[0x2]];var editdoc=obj[OxOaf9d[0x3]];var oImg=obj[OxOaf9d[0x4]];var iframe=document.getElementById(OxOaf9d[0x6])[OxOaf9d[0x5]];var iframe_doc=iframe[OxOaf9d[0x3]];var oMap=null;var aMapName= new Array();var aLeft= new Array();var aTop= new Array();var aWidth= new Array();var aHeight= new Array();var aHref= new Array();var aTarget= new Array();var aTitle= new Array();var aCoords= new Array(); window[OxOaf9d[0x7]]=function (){var src; src=oImg.getAttribute(OxOaf9d[0x8])+OxOaf9d[0x9] ;if(oImg.getAttribute(OxOaf9d[0xa])){ src=oImg.getAttribute(OxOaf9d[0xa])+OxOaf9d[0x9] ;} ; oImg[OxOaf9d[0x8]]=src ; oImg[OxOaf9d[0xb]]=OxOaf9d[0xc] ; iframe_doc.open(OxOaf9d[0xd],OxOaf9d[0xe]) ; iframe_doc.write(OxOaf9d[0x9]) ; iframe_doc.close() ; iframe[OxOaf9d[0x3]][OxOaf9d[0x10]][OxOaf9d[0xf]]=true ; iframe[OxOaf9d[0x3]][OxOaf9d[0x10]][OxOaf9d[0x11]] ; iframe[OxOaf9d[0x3]][OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x12]]=OxOaf9d[0x14] ; iframe[OxOaf9d[0x3]][OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x15]]=OxOaf9d[0x16] ; iframe[OxOaf9d[0x3]][OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x17]]=OxOaf9d[0x18] ; iframe[OxOaf9d[0x3]][OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x19]]=OxOaf9d[0x1a] ; iframe[OxOaf9d[0x3]].execCommand(OxOaf9d[0x1b],true,true) ; iframe[OxOaf9d[0x3]].execCommand(OxOaf9d[0x1c],true,true) ; iframe.focus() ; iframe[OxOaf9d[0x3]][OxOaf9d[0x10]][OxOaf9d[0x1e]]=oImg[OxOaf9d[0x1d]] ;var Ox523=oImg[OxOaf9d[0x1f]];if(Ox523!=OxOaf9d[0x9]){ Ox523=Ox523.toUpperCase() ;var Ox524=editdoc[OxOaf9d[0x10]].getElementsByTagName(OxOaf9d[0x20]);for(var i=0x0;i<Ox524[OxOaf9d[0x21]];i++){ aMapName[i]=Ox524[i][OxOaf9d[0x22]].toUpperCase() ;if((OxOaf9d[0x23]+aMapName[i])==Ox523){ oMap=Ox524[i] ;} ;} ;} ;if(oMap){for(var i=0x0;i<oMap[OxOaf9d[0x24]][OxOaf9d[0x21]];i++){ aHref[i]=oMap.areas(i)[OxOaf9d[0x25]] ; aTarget[i]=oMap.areas(i)[OxOaf9d[0x26]] ; aTitle[i]=oMap.areas(i)[OxOaf9d[0x27]] ; aCoords[i]=oMap.areas(i)[OxOaf9d[0x28]] ;var Ox146=aCoords[i].split(OxOaf9d[0x29]); aLeft[i]=parseInt(Ox146[0x0]) ; aTop[i]=parseInt(Ox146[0x1]) ; aWidth[i]=parseInt(Ox146[0x2])-aLeft[i] ; aHeight[i]=parseInt(Ox146[0x3])-aTop[i] ; iframe[OxOaf9d[0x3]][OxOaf9d[0x10]][OxOaf9d[0x1e]]+=OxOaf9d[0x2a]+i+OxOaf9d[0x2b]+aLeft[i]+OxOaf9d[0x2c]+aTop[i]+OxOaf9d[0x2d]+aWidth[i]+OxOaf9d[0x2e]+aHeight[i]+OxOaf9d[0x2f]+(i+0x1)+OxOaf9d[0x30] ;} ;} ;}  ; function SearchSelectionElement(Ox130){if(iframe_doc[OxOaf9d[0x32]][OxOaf9d[0x31]]==OxOaf9d[0x33]){var Ox2f=iframe_doc[OxOaf9d[0x32]].createRange().item(0x0);} else {var Ox2f=iframe_doc[OxOaf9d[0x32]].createRange().parentElement();} ;for(var e=Ox2f;iframe_doc[OxOaf9d[0x10]].contains(e);e=e[OxOaf9d[0x34]]){if(e[OxOaf9d[0x35]]==Ox130){return e;} ;} ;return null;}  ; function Addlink(){var Oxb9=SearchSelectionElement(OxOaf9d[0x36]);if(Oxb9){var Ox527=Oxb9[OxOaf9d[0x37]];var Ox528=parseInt(Ox527.substr(0x7));var obj={href:aHref[Ox528],target:aTarget[Ox528],title:aTitle[Ox528]};var arr=showModalDialog('mapLink.aspx?<%= QUERY_STRING %>',obj,OxOaf9d[0x38]);if(arr){ aHref[Ox528]=arr[0x0] ; aTarget[Ox528]=arr[0x1] ; aTitle[Ox528]=arr[0x2] ;} ;} ;return false;}  ;if(!top[OxOaf9d[0x39]]){ top[OxOaf9d[0x39]]=true ;} ; function do_cancel(){ top[OxOaf9d[0x3a]]=null ; top.close() ;}  ; function IsDigit(){return ((event[OxOaf9d[0x3b]]>=0x30)&&(event[OxOaf9d[0x3b]]<=0x39));}  ; function Zoom_In(){if(iframe_doc[OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x3c]]!=0x0){ iframe_doc[OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x3c]]*=1.2 ;} else { iframe_doc[OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x3c]]=1.2 ;} ;}  ; function Zoom_Out(){if(iframe_doc[OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x3c]]!=0x0){ iframe_doc[OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x3c]]*=0.8 ;} else { iframe_doc[OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x3c]]=0.8 ;} ;}  ; function BestFit(){if(!oImg){return ;} ;var Ox2e2=0x118;var Ox81=0x122; iframe_doc[OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x3c]]=0x1/Math.max(oImg[OxOaf9d[0x3e]]/Ox81,oImg[OxOaf9d[0x3d]]/Ox2e2) ;}  ; function Actualsize(){ iframe_doc[OxOaf9d[0x10]][OxOaf9d[0x13]][OxOaf9d[0x3c]]=0x1 ;}  ; function newMap(){var n=aHref[OxOaf9d[0x21]]; aHref[n]=OxOaf9d[0x9] ; aTarget[n]=OxOaf9d[0x9] ; aTitle[n]=OxOaf9d[0x9] ; iframe[OxOaf9d[0x3]][OxOaf9d[0x10]][OxOaf9d[0x1e]]+=OxOaf9d[0x2a]+n+OxOaf9d[0x3f]+(n+0x1)+OxOaf9d[0x40] ; iframe.scrollBy(0x0,0x0) ; iframe.focus() ;}  ;var count=0xa; function Picture(Ox611){if(event[OxOaf9d[0x41]]>=0x78){ count++ ;} else {if(event[OxOaf9d[0x41]]<=-0x78){ count-- ;} ;} ; Ox611[OxOaf9d[0x13]][OxOaf9d[0x3c]]=count+OxOaf9d[0x42] ;return false;}  ; function do_update(){var b=false;for(var i=0x0;i<aHref[OxOaf9d[0x21]];i++){var obj=iframe[OxOaf9d[0x3]].getElementById(OxOaf9d[0x43]+i);if(obj){ b=true ;} ;} ;if(b){var Oxaf=OxOaf9d[0x9];for(var i=0x0;i<aHref[OxOaf9d[0x21]];i++){var obj=iframe[OxOaf9d[0x3]].getElementById(OxOaf9d[0x43]+i);if(obj){var Ox52a=parseInt(obj[OxOaf9d[0x13]].left);var Ox52b=parseInt(obj[OxOaf9d[0x13]].top);var Ox52c=parseInt(obj[OxOaf9d[0x13]].width);var Ox52d=parseInt(obj[OxOaf9d[0x13]].height);var Ox52e=Ox52a+Ox52c;var Ox52f=Ox52b+Ox52d; Oxaf+=OxOaf9d[0x44]+Ox52a+OxOaf9d[0x29]+Ox52b+OxOaf9d[0x29]+Ox52e+OxOaf9d[0x29]+Ox52f+OxOaf9d[0x45] ;if(aHref[i]!=OxOaf9d[0x9]){ Oxaf+=OxOaf9d[0x46]+aHref[i]+OxOaf9d[0x47] ;} ;if((aTarget[i]!=OxOaf9d[0x9])&&aTarget[i]){ Oxaf+=OxOaf9d[0x48]+aTarget[i]+OxOaf9d[0x47] ;} ;if(aTitle[i]!=OxOaf9d[0x9]){ Oxaf+=OxOaf9d[0x49]+aTitle[i]+OxOaf9d[0x47] ;} ; Oxaf+=OxOaf9d[0x4a] ;} ;} ;if(oMap){ oMap[OxOaf9d[0x1e]]=Oxaf ;} else { sUseMap=getAutoMapName() ; oImg[OxOaf9d[0x1f]]=OxOaf9d[0x23]+sUseMap ; editor.ExecCommand(OxOaf9d[0x4b],false,OxOaf9d[0x4c]+sUseMap+OxOaf9d[0x30]+Oxaf+OxOaf9d[0x4d]) ;} ;} else {if(oMap){ oMap[OxOaf9d[0x1d]]=OxOaf9d[0x9] ;} ; oImg[OxOaf9d[0x1f]]=OxOaf9d[0x9] ;} ; oImg[OxOaf9d[0xb]]=OxOaf9d[0x4e] ; oImg.removeAttribute(OxOaf9d[0xb]) ; editor.InsertElement(oImg) ; window.close() ; top.close() ;}  ; function getAutoMapName(){var b=true;var n=0x0;var Ox25=OxOaf9d[0x9];while(b){ n++ ; Ox25=OxOaf9d[0x4f]+n ;if(isValidMapName(Ox25)){ b=false ;} ;} ;return Ox25;}  ; function isValidMapName(Ox1f){ Ox1f=Ox1f.toUpperCase() ;for(var i=0x0;i<aMapName[OxOaf9d[0x21]];i++){if(aMapName[i]==Ox1f){return false;} ;} ;return true;}  ; function do_cancel(){ oImg.removeAttribute(OxOaf9d[0xb]) ; top.close() ;}  ;	


</script>
	</body>
</HTML>
