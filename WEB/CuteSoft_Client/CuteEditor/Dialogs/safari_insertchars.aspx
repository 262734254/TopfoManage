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
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
		<link rel="stylesheet" href='Safari_style.css'>
		<script language="javascript">		
			var OxOb5e7=["availWidth","availHeight","","\x3Ctr\x3E","\x3Ctd style=\x27align: left; height: 20; font-size: 12px; \x27 bgcolor=white width=\x2718\x27 align=center onClick=\x27getchar(this)\x27 onmouseover=\x27spcOver(this)\x27 onmouseout=\x27spcOut(this)\x27 title=\x27","\x27 \x3E","\x26#",";","\x3C/td\x3E","\x3C/tr\x3E","background","style","#0A246A","color","white","black","Verdana","innerHTML","Unicode","\x3CFONT CLASS=\x27UNICODE\x27\x3E","\x3Cspan style=\x27font-family:","\x27\x3E","\x3C/span\x3E","dialogArguments","opener","editor","editdoc","Delete"]; window.resizeTo(0x1cc,0x190) ; window.moveTo((screen[OxOb5e7[0x0]]-0x258)/0x2,(screen[OxOb5e7[0x1]]-0x190)/0x2) ; window.focus() ;var tds=0x16; function writeChars(){var Ox1f=OxOb5e7[0x2];for(var i=0x21;i<0x100;){ document.write(OxOb5e7[0x3]) ;for(var j=0x0;j<=tds;j++){ document.write(OxOb5e7[0x4]+i+OxOb5e7[0x5]) ; document.write(OxOb5e7[0x6]+i+OxOb5e7[0x7]) ; document.write(OxOb5e7[0x8]) ; i++ ;} ; document.write(OxOb5e7[0x9]) ;} ;}  ; function spcOver(Ox2fc){ Ox2fc[OxOb5e7[0xb]][OxOb5e7[0xa]]=OxOb5e7[0xc] ; Ox2fc[OxOb5e7[0xb]][OxOb5e7[0xd]]=OxOb5e7[0xe] ;}  ; function spcOut(Ox2fc){ Ox2fc[OxOb5e7[0xb]][OxOb5e7[0xa]]=OxOb5e7[0xe] ; Ox2fc[OxOb5e7[0xb]][OxOb5e7[0xd]]=OxOb5e7[0xf] ;}  ; function getchar(obj){var Ox541=getFontValue()||OxOb5e7[0x10];if(!obj[OxOb5e7[0x11]]){return ;} ;var h=obj[OxOb5e7[0x11]];if(Ox541==OxOb5e7[0x12]){ h=OxOb5e7[0x13]+obj[OxOb5e7[0x11]]+OxOb5e7[0x2] ;} else {if(Ox541!=OxOb5e7[0x10]){ h=OxOb5e7[0x14]+Ox541+OxOb5e7[0x15]+obj[OxOb5e7[0x11]]+OxOb5e7[0x16] ;} ;} ;var obj=window[OxOb5e7[0x18]][OxOb5e7[0x17]];var editor=obj[OxOb5e7[0x19]];var editdoc=obj[OxOb5e7[0x1a]]; editdoc.execCommand(OxOb5e7[0x1b],false,OxOb5e7[0x2]) ; editor.PasteHTML(h) ;}  ; function cancel(){ top.close() ;}  ;
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
						var OxO24cd=["selfont","length","checked","value","Verdana","display","style","charstable1","Unicode","block","none","charstable2","fontFamily"]; function getFontValue(){var coll=document.getElementsByName(OxO24cd[0x0]);for(var i=0x0;i<coll[OxO24cd[0x1]];i++){if(coll[i][OxO24cd[0x2]]){return coll[i][OxO24cd[0x3]];} ;} ;}  ; function sel_font_change(){var Ox546=getFontValue()||OxO24cd[0x4]; document.getElementById(OxO24cd[0x7])[OxO24cd[0x6]][OxO24cd[0x5]]=(Ox546!=OxO24cd[0x8]?OxO24cd[0x9]:OxO24cd[0xa]) ; document.getElementById(OxO24cd[0xb])[OxO24cd[0x6]][OxO24cd[0x5]]=(Ox546==OxO24cd[0x8]?OxO24cd[0x9]:OxO24cd[0xa]) ; document.getElementById(OxO24cd[0x7])[OxO24cd[0x6]][OxO24cd[0xc]]=Ox546 ;if(Ox546==OxO24cd[0x8]){} ;}  ;
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
								var OxOb03a=[]; writeChars() ;
								</SCRIPT>
							</TABLE>
							<TABLE id="charstable2" width="95%" height="222" cellspacing="1" cellpadding="1" border="0"
								bordercolor="dimgray" align="center" bgcolor="dimgray" style="FONT-FAMILY: Verdana;display:none;">
								<SCRIPT>
								var OxO1c8f=["\x26#402;","\x26#913;","\x26#914;","\x26#915;","\x26#916;","\x26#917;","\x26#918;","\x26#919;","\x26#920;","\x26#921;","\x26#922;","\x26#923;","\x26#924;","\x26#925;","\x26#926;","\x26#927;","\x26#928;","\x26#929;","\x26#931;","\x26#932;","\x26#933;","\x26#934;","\x26#935;","\x26#936;","\x26#937;","\x26#945;","\x26#946;","\x26#947;","\x26#948;","\x26#949;","\x26#950;","\x26#951;","\x26#952;","\x26#953;","\x26#954;","\x26#955;","\x26#956;","\x26#957;","\x26#958;","\x26#959;","\x26#960;","\x26#961;","\x26#962;","\x26#963;","\x26#964;","\x26#965;","\x26#966;","\x26#967;","\x26#968;","\x26#969;","\x26#977;","\x26#978;","\x26#982;","\x26#8226;","\x26#8230;","\x26#8242;","\x26#8243;","\x26#8254;","\x26#8260;","\x26#8472;","\x26#8465;","\x26#8476;","\x26#8482;","\x26#8501;","\x26#8592;","\x26#8593;","\x26#8594;","\x26#8595;","\x26#8596;","\x26#8629;","\x26#8656;","\x26#8657;","\x26#8658;","\x26#8659;","\x26#8660;","\x26#8704;","\x26#8706;","\x26#8707;","\x26#8709;","\x26#8711;","\x26#8712;","\x26#8713;","\x26#8715;","\x26#8719;","\x26#8722;","\x26#8727;","\x26#8730;","\x26#8733;","\x26#8734;","\x26#8736;","\x26#8869;","\x26#8870;","\x26#8745;","\x26#8746;","\x26#8747;","\x26#8756;","\x26#8764;","\x26#8773;","\x26#8800;","\x26#8801;","\x26#8804;","\x26#8805;","\x26#8834;","\x26#8835;","\x26#8836;","\x26#8838;","\x26#8839;","\x26#8853;","\x26#8855;","\x26#8901;","\x26#8968;","\x26#8969;","\x26#8970;","\x26#8971;","\x26#9001;","\x26#9002;","\x26#9674;","\x26#9824;","\x26#9827;","\x26#9829;","\x26#9830;","length","\x3Ctr\x3E","\x26","\x26amp;","\x3Ctd style=\x27align: left; height: 20; font-size: 12px; \x27 bgcolor=white width=\x2718\x27 align=center onClick=\x27getchar(this)\x27 onmouseover=\x27spcOver(this)\x27 onmouseout=\x27spcOut(this)\x27 title=\x27"," - ","\x27 \x3E","\x3C/td\x3E","\x3C/tr\x3E"];var arr=[OxO1c8f[0x0],OxO1c8f[0x1],OxO1c8f[0x2],OxO1c8f[0x3],OxO1c8f[0x4],OxO1c8f[0x5],OxO1c8f[0x6],OxO1c8f[0x7],OxO1c8f[0x8],OxO1c8f[0x9],OxO1c8f[0xa],OxO1c8f[0xb],OxO1c8f[0xc],OxO1c8f[0xd],OxO1c8f[0xe],OxO1c8f[0xf],OxO1c8f[0x10],OxO1c8f[0x11],OxO1c8f[0x12],OxO1c8f[0x13],OxO1c8f[0x14],OxO1c8f[0x15],OxO1c8f[0x16],OxO1c8f[0x17],OxO1c8f[0x18],OxO1c8f[0x19],OxO1c8f[0x1a],OxO1c8f[0x1b],OxO1c8f[0x1c],OxO1c8f[0x1d],OxO1c8f[0x1e],OxO1c8f[0x1f],OxO1c8f[0x20],OxO1c8f[0x21],OxO1c8f[0x22],OxO1c8f[0x23],OxO1c8f[0x24],OxO1c8f[0x25],OxO1c8f[0x26],OxO1c8f[0x27],OxO1c8f[0x28],OxO1c8f[0x29],OxO1c8f[0x2a],OxO1c8f[0x2b],OxO1c8f[0x2c],OxO1c8f[0x2d],OxO1c8f[0x2e],OxO1c8f[0x2f],OxO1c8f[0x30],OxO1c8f[0x31],OxO1c8f[0x32],OxO1c8f[0x33],OxO1c8f[0x34],OxO1c8f[0x35],OxO1c8f[0x36],OxO1c8f[0x37],OxO1c8f[0x38],OxO1c8f[0x39],OxO1c8f[0x3a],OxO1c8f[0x3b],OxO1c8f[0x3c],OxO1c8f[0x3d],OxO1c8f[0x3e],OxO1c8f[0x3f],OxO1c8f[0x40],OxO1c8f[0x41],OxO1c8f[0x42],OxO1c8f[0x43],OxO1c8f[0x44],OxO1c8f[0x45],OxO1c8f[0x46],OxO1c8f[0x47],OxO1c8f[0x48],OxO1c8f[0x49],OxO1c8f[0x4a],OxO1c8f[0x4b],OxO1c8f[0x4c],OxO1c8f[0x4d],OxO1c8f[0x4e],OxO1c8f[0x4f],OxO1c8f[0x50],OxO1c8f[0x51],OxO1c8f[0x52],OxO1c8f[0x53],OxO1c8f[0x54],OxO1c8f[0x54],OxO1c8f[0x55],OxO1c8f[0x56],OxO1c8f[0x57],OxO1c8f[0x58],OxO1c8f[0x59],OxO1c8f[0x5a],OxO1c8f[0x5b],OxO1c8f[0x5c],OxO1c8f[0x5d],OxO1c8f[0x5e],OxO1c8f[0x5f],OxO1c8f[0x60],OxO1c8f[0x61],OxO1c8f[0x61],OxO1c8f[0x62],OxO1c8f[0x63],OxO1c8f[0x64],OxO1c8f[0x65],OxO1c8f[0x66],OxO1c8f[0x67],OxO1c8f[0x68],OxO1c8f[0x69],OxO1c8f[0x6a],OxO1c8f[0x6b],OxO1c8f[0x6c],OxO1c8f[0x5a],OxO1c8f[0x6d],OxO1c8f[0x6e],OxO1c8f[0x6f],OxO1c8f[0x70],OxO1c8f[0x71],OxO1c8f[0x72],OxO1c8f[0x73],OxO1c8f[0x74],OxO1c8f[0x75],OxO1c8f[0x76],OxO1c8f[0x77],OxO1c8f[0x78]];for(var i=0x0;i<arr[OxO1c8f[0x79]];i+=tds){ document.write(OxO1c8f[0x7a]) ;for(var j=i;j<i+tds&&j<arr[OxO1c8f[0x79]];j++){var n=arr[j]; document.write(OxO1c8f[0x7d]+n+OxO1c8f[0x7e]+n.replace(OxO1c8f[0x7b],OxO1c8f[0x7c])+OxO1c8f[0x7f]) ; document.write(n) ; document.write(OxO1c8f[0x80]) ;} ; document.write(OxO1c8f[0x81]) ;} ;
								</SCRIPT>
							</TABLE>
							<br>	
						</fieldset>
					</td>
				</tr>
				<tr>
					<td align="right">
						<BUTTON style="FONT-SIZE: x-small; VERTICAL-ALIGN: middle; CURSOR: hand; FONT-FAMILY: MS Sans Serif"
							type="reset" onclick="cancel()" style="width:80px">[[Cancel]] </BUTTON>
					</td>
				</tr>
			</table>
	</body>
</HTML>
