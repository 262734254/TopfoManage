<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<HTML>
	<head>
		<title>[[InsertChars]] 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="content-type" content="text/html ;charset=Unicode">
		<link rel="stylesheet" href='gecko_style.css'>
		<script src=gecko_dialog.js></script><script src=../_shared.js></script>
		<script language="javascript">
		var OxOd77b=["dialogArguments","availWidth","availHeight","","\x3Ctr\x3E","\x3Ctd style=\x27height: 20; font-size: 12px; \x27 bgcolor=white width=\x2718\x27 onClick=\x27getchar(this)\x27 onmouseover=\x27spcOver(this)\x27 onmouseout=\x27spcOut(this)\x27 title=\x27","\x27 \x3E","\x26#",";","\x3C/td\x3E","\x3C/tr\x3E","background","style","#0A246A","color","white","black","Verdana","innerHTML","Unicode","\x3CFONT CLASS=\x27UNICODE\x27\x3E","\x3Cspan style=\x27font-family:","\x27\x3E","\x3C/span\x3E"];var editor=top[OxOd77b[0x0]]; window.resizeTo(0x1cc,0x190) ; window.moveTo((screen[OxOd77b[0x1]]-0x1cc)/0x2,(screen[OxOd77b[0x2]]-0x190)/0x2) ;var tds=0x16; function writeChars(){var Ox1f=OxOd77b[0x3];for(var i=0x21;i<0x100;){ document.write(OxOd77b[0x4]) ;for(var j=0x0;j<=tds;j++){ document.write(OxOd77b[0x5]+i+OxOd77b[0x6]) ; document.write(OxOd77b[0x7]+i+OxOd77b[0x8]) ; document.write(OxOd77b[0x9]) ; i++ ;} ; document.write(OxOd77b[0xa]) ;} ;}  ; function spcOver(Ox2fc){ Ox2fc[OxOd77b[0xc]][OxOd77b[0xb]]=OxOd77b[0xd] ; Ox2fc[OxOd77b[0xc]][OxOd77b[0xe]]=OxOd77b[0xf] ;}  ; function spcOut(Ox2fc){ Ox2fc[OxOd77b[0xc]][OxOd77b[0xb]]=OxOd77b[0xf] ; Ox2fc[OxOd77b[0xc]][OxOd77b[0xe]]=OxOd77b[0x10] ;}  ; function getchar(obj){var h;var Ox541=getFontValue()||OxOd77b[0x11];if(!obj[OxOd77b[0x12]]){return ;} ; h=obj[OxOd77b[0x12]] ;if(Ox541==OxOd77b[0x13]){ h=OxOd77b[0x14]+obj[OxOd77b[0x12]]+OxOd77b[0x3] ;} else {if(Ox541!=OxOd77b[0x11]){ h=OxOd77b[0x15]+Ox541+OxOd77b[0x16]+obj[OxOd77b[0x12]]+OxOd77b[0x17] ;} ;} ; editor.PasteHTML(h) ;}  ; function cancel(){ top.close() ;}  ;
		</script>
	</HEAD>
	<body bgcolor="#d7d3cc">
			<table border="0" cellspacing="2" cellpadding="2" width="99%" align="center">
				<tr style="display:none">
					<td class="normal">
						[[FontName]]: <input type="radio" onpropertychange="sel_font_change()" id="selfont1" name="selfont" value=""
							checked><label for="selfont1">[[Default]]</label> <input type="radio" onpropertychange="sel_font_change()" id="selfont2" name="selfont" value="webdings"><label for="selfont2">Webdings</label>
						<input type="radio" onpropertychange="sel_font_change()" id="selfont3" name="selfont" value="wingdings"><label for="selfont3">Wingdings</label>
						<input type="radio" onpropertychange="sel_font_change()" id="selfont4" name="selfont" value="symbol"><label for="selfont4">Symbol</label>
						<input type="radio" onpropertychange="sel_font_change()" id="selfont5" name="selfont" value="Unicode"><label for="selfont5">Unicode</label>
						<script>
						var OxO7d3b=["selfont","length","checked","value","Verdana","display","style","charstable1","Unicode","block","none","charstable2","fontFamily"]; function getFontValue(){var coll=document.getElementsByName(OxO7d3b[0x0]);for(var i=0x0;i<coll[OxO7d3b[0x1]];i++){if(coll[i][OxO7d3b[0x2]]){return coll[i][OxO7d3b[0x3]];} ;} ;}  ; function sel_font_change(){var Ox546=getFontValue()||OxO7d3b[0x4]; document.getElementById(OxO7d3b[0x7])[OxO7d3b[0x6]][OxO7d3b[0x5]]=(Ox546!=OxO7d3b[0x8]?OxO7d3b[0x9]:OxO7d3b[0xa]) ; document.getElementById(OxO7d3b[0xb])[OxO7d3b[0x6]][OxO7d3b[0x5]]=(Ox546==OxO7d3b[0x8]?OxO7d3b[0x9]:OxO7d3b[0xa]) ; document.getElementById(OxO7d3b[0x7])[OxO7d3b[0x6]][OxO7d3b[0xc]]=Ox546 ;if(Ox546==OxO7d3b[0x8]){} ;}  ;
						</script>
					</td>
				</tr>
				<tr>
					<td align="center">
						<fieldset>
							<legend>
								[[InsertChars]]
							</legend>
							<br>
							<TABLE id="charstable1" width="95%" height="222" cellspacing="1" cellpadding="1" border="0"
								bordercolor="dimgray" align="center" bgcolor="dimgray" style="FONT-FAMILY: Verdana;">
								<SCRIPT>
								var OxOb76f=[]; writeChars() ;
								</SCRIPT>
							</TABLE>
							<TABLE id="charstable2" width="95%" height="222" cellspacing="1" cellpadding="1" border="0"
								bordercolor="dimgray" align="center" bgcolor="dimgray" style="FONT-FAMILY: Verdana;display:none;">
								<SCRIPT>
								var OxO2ebc=["\x26#402;","\x26#913;","\x26#914;","\x26#915;","\x26#916;","\x26#917;","\x26#918;","\x26#919;","\x26#920;","\x26#921;","\x26#922;","\x26#923;","\x26#924;","\x26#925;","\x26#926;","\x26#927;","\x26#928;","\x26#929;","\x26#931;","\x26#932;","\x26#933;","\x26#934;","\x26#935;","\x26#936;","\x26#937;","\x26#945;","\x26#946;","\x26#947;","\x26#948;","\x26#949;","\x26#950;","\x26#951;","\x26#952;","\x26#953;","\x26#954;","\x26#955;","\x26#956;","\x26#957;","\x26#958;","\x26#959;","\x26#960;","\x26#961;","\x26#962;","\x26#963;","\x26#964;","\x26#965;","\x26#966;","\x26#967;","\x26#968;","\x26#969;","\x26#977;","\x26#978;","\x26#982;","\x26#8226;","\x26#8230;","\x26#8242;","\x26#8243;","\x26#8254;","\x26#8260;","\x26#8472;","\x26#8465;","\x26#8476;","\x26#8482;","\x26#8501;","\x26#8592;","\x26#8593;","\x26#8594;","\x26#8595;","\x26#8596;","\x26#8629;","\x26#8656;","\x26#8657;","\x26#8658;","\x26#8659;","\x26#8660;","\x26#8704;","\x26#8706;","\x26#8707;","\x26#8709;","\x26#8711;","\x26#8712;","\x26#8713;","\x26#8715;","\x26#8719;","\x26#8722;","\x26#8727;","\x26#8730;","\x26#8733;","\x26#8734;","\x26#8736;","\x26#8869;","\x26#8870;","\x26#8745;","\x26#8746;","\x26#8747;","\x26#8756;","\x26#8764;","\x26#8773;","\x26#8800;","\x26#8801;","\x26#8804;","\x26#8805;","\x26#8834;","\x26#8835;","\x26#8836;","\x26#8838;","\x26#8839;","\x26#8853;","\x26#8855;","\x26#8901;","\x26#8968;","\x26#8969;","\x26#8970;","\x26#8971;","\x26#9001;","\x26#9002;","\x26#9674;","\x26#9824;","\x26#9827;","\x26#9829;","\x26#9830;","length","\x3Ctr\x3E","\x26","\x26amp;","\x3Ctd style=\x27height: 20; font-size: 12px; \x27 bgcolor=white width=\x2718\x27 onClick=\x27getchar(this)\x27 onmouseover=\x27spcOver(this)\x27 onmouseout=\x27spcOut(this)\x27 title=\x27"," - ","\x27 \x3E","\x3C/td\x3E","\x3C/tr\x3E"];var arr=[OxO2ebc[0x0],OxO2ebc[0x1],OxO2ebc[0x2],OxO2ebc[0x3],OxO2ebc[0x4],OxO2ebc[0x5],OxO2ebc[0x6],OxO2ebc[0x7],OxO2ebc[0x8],OxO2ebc[0x9],OxO2ebc[0xa],OxO2ebc[0xb],OxO2ebc[0xc],OxO2ebc[0xd],OxO2ebc[0xe],OxO2ebc[0xf],OxO2ebc[0x10],OxO2ebc[0x11],OxO2ebc[0x12],OxO2ebc[0x13],OxO2ebc[0x14],OxO2ebc[0x15],OxO2ebc[0x16],OxO2ebc[0x17],OxO2ebc[0x18],OxO2ebc[0x19],OxO2ebc[0x1a],OxO2ebc[0x1b],OxO2ebc[0x1c],OxO2ebc[0x1d],OxO2ebc[0x1e],OxO2ebc[0x1f],OxO2ebc[0x20],OxO2ebc[0x21],OxO2ebc[0x22],OxO2ebc[0x23],OxO2ebc[0x24],OxO2ebc[0x25],OxO2ebc[0x26],OxO2ebc[0x27],OxO2ebc[0x28],OxO2ebc[0x29],OxO2ebc[0x2a],OxO2ebc[0x2b],OxO2ebc[0x2c],OxO2ebc[0x2d],OxO2ebc[0x2e],OxO2ebc[0x2f],OxO2ebc[0x30],OxO2ebc[0x31],OxO2ebc[0x32],OxO2ebc[0x33],OxO2ebc[0x34],OxO2ebc[0x35],OxO2ebc[0x36],OxO2ebc[0x37],OxO2ebc[0x38],OxO2ebc[0x39],OxO2ebc[0x3a],OxO2ebc[0x3b],OxO2ebc[0x3c],OxO2ebc[0x3d],OxO2ebc[0x3e],OxO2ebc[0x3f],OxO2ebc[0x40],OxO2ebc[0x41],OxO2ebc[0x42],OxO2ebc[0x43],OxO2ebc[0x44],OxO2ebc[0x45],OxO2ebc[0x46],OxO2ebc[0x47],OxO2ebc[0x48],OxO2ebc[0x49],OxO2ebc[0x4a],OxO2ebc[0x4b],OxO2ebc[0x4c],OxO2ebc[0x4d],OxO2ebc[0x4e],OxO2ebc[0x4f],OxO2ebc[0x50],OxO2ebc[0x51],OxO2ebc[0x52],OxO2ebc[0x53],OxO2ebc[0x54],OxO2ebc[0x54],OxO2ebc[0x55],OxO2ebc[0x56],OxO2ebc[0x57],OxO2ebc[0x58],OxO2ebc[0x59],OxO2ebc[0x5a],OxO2ebc[0x5b],OxO2ebc[0x5c],OxO2ebc[0x5d],OxO2ebc[0x5e],OxO2ebc[0x5f],OxO2ebc[0x60],OxO2ebc[0x61],OxO2ebc[0x61],OxO2ebc[0x62],OxO2ebc[0x63],OxO2ebc[0x64],OxO2ebc[0x65],OxO2ebc[0x66],OxO2ebc[0x67],OxO2ebc[0x68],OxO2ebc[0x69],OxO2ebc[0x6a],OxO2ebc[0x6b],OxO2ebc[0x6c],OxO2ebc[0x5a],OxO2ebc[0x6d],OxO2ebc[0x6e],OxO2ebc[0x6f],OxO2ebc[0x70],OxO2ebc[0x71],OxO2ebc[0x72],OxO2ebc[0x73],OxO2ebc[0x74],OxO2ebc[0x75],OxO2ebc[0x76],OxO2ebc[0x77],OxO2ebc[0x78]];for(var i=0x0;i<arr[OxO2ebc[0x79]];i+=tds){ document.write(OxO2ebc[0x7a]) ;for(var j=i;j<i+tds&&j<arr[OxO2ebc[0x79]];j++){var n=arr[j]; document.write(OxO2ebc[0x7d]+n+OxO2ebc[0x7e]+n.replace(OxO2ebc[0x7b],OxO2ebc[0x7c])+OxO2ebc[0x7f]) ; document.write(n) ; document.write(OxO2ebc[0x80]) ;} ; document.write(OxO2ebc[0x81]) ;} ;
								</SCRIPT>
							</TABLE>
							<br>	
						</fieldset>
					</td>
				</tr>
				<tr>
					<td align="right">
						<BUTTON style="FONT-SIZE: x-small; VERTICAL-ALIGN: middle; CURSOR: pointer; FONT-FAMILY: MS Sans Serif"
							type="reset" onclick="cancel()" style="width:80px">[[Cancel]] </BUTTON>
					</td>
				</tr>
			</table>
	</body>
</HTML>
