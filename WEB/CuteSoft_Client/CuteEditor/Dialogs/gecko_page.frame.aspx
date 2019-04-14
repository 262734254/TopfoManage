<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<html>
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)">
	<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)">
	<link rel=stylesheet href='gecko_style.css' >
	<script src=Gecko_dialog.js></script><script src=../_shared.js></script>
	<body style="border:0px;padding-top:4px;padding-left:4px;padding-right:4px;;margin:0px;overflow:auto;">
		<table border="0" cellspacing="0" cellpadding="2" style="width:100%;">
			<tr>
				<td valign="top">
					<fieldset>
						<legend>[[DocumentPropertyPage]]</legend>
						<div style="height:12px"></div>
						<table border="0" cellpadding="3" cellspacing="0" style="border-collapse:collapse;" class="normal">
							<tr>
								<td>[[Title]]:</td>
								<td colspan="4">
									<input type="text" id="inp_title" style="width:320px">
								</td>
							</tr>
							<tr>
								<td>DOCTYPE:</td>
								<td colspan="4">
									<input type="text" id="inp_doctype" style="width:320px">
								</td>
							</tr>
							<tr>
								<td>[[Description]]:</td>
								<td colspan="4">
									<textarea id="inp_description" rows="3" style="width:320px"></textarea>
								</td>
							</tr>
							<tr>
								<td>[[Keywords]]:</td>
								<td colspan="4">
									<textarea id="inp_keywords" rows="3" style="width:320px"></textarea>
								</td>
							</tr>
							<tr>
								<td>[[HtmlBase]]:</td>
								<td colspan="4"><input type="text" id="inp_htmlbase" style="width:320px"></td>
							</tr>
							<tr>
								<td nowrap>[[PageLanguage]]:</td>
								<td colspan="4">
									<input type="text" id="PageLanguage" name="PageLanguage" size="15" style="WIDTH:320px">
								</td>
							</tr>
							<tr>
								<td nowrap>[[HTMLEncoding]]:</td>
								<td colspan="4">
									<input type="text" id="HTMLEncoding" name="HTMLEncoding" size="15" style="WIDTH:320px">
								</td>
							</tr>
							<tr>
								<td nowrap>[[Backgroundcolor]]:</td>
								<td>
									<input type="text" id="bgcolor" name="bgcolor" size="7" style="WIDTH:57px">	
									<img id="bgcolor_Preview" src="../images/colorpicker.gif" onclick="SelectColor(1);" align="absMiddle">
												
								</td>
								<td width="5"></td>
								<td nowrap>[[ForeColor]]:</td>
								<td>
									<input type="text" id="fontcolor" name="fontcolor" size="7" style="WIDTH:57px">
									<img id="fontcolor_Preview" src="../images/colorpicker.gif" onclick="SelectColor(2);" align="absMiddle">
								</td>
							</tr>							
							<tr>
								<td nowrap>[[TopMargin]]:</td>
								<td>
									<input type="text" id="TopMargin" name="TopMargin" size="7" style="WIDTH:57px"> Pixels
								</td>
								<td width="5"></td>
								<td nowrap>[[BottomMargin]]:</td>
								<td>
									<input type="text" id="BottomMargin" name="BottomMargin" size="7" style="WIDTH:57px"> Pixels
								</td>
							</tr>
							<tr>
								<td nowrap>[[LeftMargin]]:</td>
								<td>
									<input type="text" id="LeftMargin" name="LeftMargin" size="7" style="WIDTH:57px"> Pixels
								</td>
								<td width="5"></td>
								<td nowrap>[[RightMargin]]:</td>
								<td>
									<input type="text" id="RightMargin" name="RightMargin" size="7" style="WIDTH:57px"> Pixels
								</td>
							</tr>
							<tr>
								<td nowrap>[[MarginWidth]]:</td>
								<td>
									<input type="text" id="MarginWidth" name="MarginWidth" size="7" style="WIDTH:57px"> Pixels
								</td>
								<td width="5"></td>
								<td nowrap>[[MarginHeight]]:</td>
								<td>
									<input type="text" id="MarginHeight" name="MarginHeight" size="7" style="WIDTH:57px"> Pixels
								</td>
							</tr>
						</table>
					</fieldset>
				</td>
			</tr>
		</table>
		
		<p align="center">
			<input class="inputbuttoninsert" type="button" value="[[Ok]]" onclick="btnok_click()"
						id="Button1" NAME="Button1">&nbsp;&nbsp;&nbsp; 
			<input class="inputbuttoncancel" type="button" value="[[Cancel]]" onclick="btncc_click()"
								id="Button2" NAME="Button2">
		</p>
	</body>
	<script>
	
	var OxO6295=["dialogArguments","editor","window","document","DOCTYPE","body","head","style","base","title","innerHTML","","meta","length","name","keywords","content","description","httpEquiv","content-type","content-language","value","inp_doctype","inp_title","inp_description","inp_keywords","fontcolor","backgroundColor","fontcolor_Preview","bgcolor","bgcolor_Preview","topMargin","TopMargin","bottomMargin","BottomMargin","leftMargin","LeftMargin","rightMargin","RightMargin","marginWidth","MarginWidth","marginHeight","MarginHeight","PageLanguage","HTMLEncoding","href","inp_htmlbase","[[ValidNumber]]","color","Please enter a valid color number.","lastChild","http-equiv","BASE","parentNode","Content-Type","Content-Language","DOCTYP","headHTML","bodyHTML","returnValue","../colorpicker.aspx","\x3Cbody","attributes","specified","nodeName","cssText","undefined","nodeValue"," ","=\x22","\x22","\x3E"]; window.resizeTo(0x1ea,0x203) ;var obj=top[OxO6295[0x0]];var editor=obj[OxO6295[0x1]];var editwin=obj[OxO6295[0x2]];var editdoc=obj[OxO6295[0x3]];var DOCTYPE=obj[OxO6295[0x4]];var body=editdoc.getElementsByTagName(OxO6295[0x5]).item(0x0);var head=obj[OxO6295[0x6]];var body_bgcolor=revertColor(editdoc[OxO6295[0x5]][OxO6295[0x7]].backgroundColor);var body_fontcolor=revertColor(editdoc[OxO6295[0x5]][OxO6295[0x7]].color);var htmlbase=editdoc.getElementsByTagName(OxO6295[0x8]).item(0x0);var str_title=editdoc.getElementsByTagName(OxO6295[0x9])[0x0]; str_title=str_title?str_title[OxO6295[0xa]]:OxO6295[0xb] ;var str_keywords=OxO6295[0xb];var str_description=OxO6295[0xb];var str_HTMLEncoding=OxO6295[0xb];var str_PageLanguage=OxO6295[0xb];var str_BaseHref=OxO6295[0xb];var str_DOCTYPE=OxO6295[0xb];var metas=editdoc.getElementsByTagName(OxO6295[0xc]);for(var m=0x0;m<metas[OxO6295[0xd]];m++){if(metas[m][OxO6295[0xe]].toLowerCase()==OxO6295[0xf]){ str_keywords=metas[m][OxO6295[0x10]] ;} ;if(metas[m][OxO6295[0xe]].toLowerCase()==OxO6295[0x11]){ str_description=metas[m][OxO6295[0x10]] ;} ;if(metas[m][OxO6295[0x12]].toLowerCase()==OxO6295[0x13]){ str_HTMLEncoding=metas[m][OxO6295[0x10]] ;} ;if(metas[m][OxO6295[0x12]].toLowerCase()==OxO6295[0x14]){ str_PageLanguage=metas[m][OxO6295[0x10]] ;} ;} ; document.getElementById(OxO6295[0x16])[OxO6295[0x15]]=obj[OxO6295[0x4]] ; document.getElementById(OxO6295[0x17])[OxO6295[0x15]]=str_title ; document.getElementById(OxO6295[0x18])[OxO6295[0x15]]=str_description ; document.getElementById(OxO6295[0x19])[OxO6295[0x15]]=str_keywords ; document.getElementById(OxO6295[0x1a])[OxO6295[0x15]]=body_fontcolor ; document.getElementById(OxO6295[0x1c])[OxO6295[0x7]][OxO6295[0x1b]]=body_fontcolor ; document.getElementById(OxO6295[0x1d])[OxO6295[0x15]]=body_bgcolor ; document.getElementById(OxO6295[0x1e])[OxO6295[0x7]][OxO6295[0x1b]]=body_bgcolor ;if(body[OxO6295[0x1f]]){ document.getElementById(OxO6295[0x20])[OxO6295[0x15]]=body[OxO6295[0x1f]] ;} ;if(body[OxO6295[0x21]]){ document.getElementById(OxO6295[0x22])[OxO6295[0x15]]=body[OxO6295[0x21]] ;} ;if(body[OxO6295[0x23]]){ document.getElementById(OxO6295[0x24])[OxO6295[0x15]]=body[OxO6295[0x23]] ;} ;if(body[OxO6295[0x25]]){ document.getElementById(OxO6295[0x26])[OxO6295[0x15]]=body[OxO6295[0x25]] ;} ;if(body[OxO6295[0x27]]){ document.getElementById(OxO6295[0x28])[OxO6295[0x15]]=body[OxO6295[0x27]] ;} ;if(body[OxO6295[0x29]]){ document.getElementById(OxO6295[0x2a])[OxO6295[0x15]]=body[OxO6295[0x29]] ;} ; document.getElementById(OxO6295[0x2b])[OxO6295[0x15]]=str_PageLanguage ; document.getElementById(OxO6295[0x2c])[OxO6295[0x15]]=str_HTMLEncoding ;if(htmlbase){ document.getElementById(OxO6295[0x2e])[OxO6295[0x15]]=htmlbase[OxO6295[0x2d]] ;} ; function btnok_click(){try{ body[OxO6295[0x1f]]=document.getElementById(OxO6295[0x20])[OxO6295[0x15]] ; body[OxO6295[0x21]]=document.getElementById(OxO6295[0x22])[OxO6295[0x15]] ; body[OxO6295[0x23]]=document.getElementById(OxO6295[0x24])[OxO6295[0x15]] ; body[OxO6295[0x25]]=document.getElementById(OxO6295[0x26])[OxO6295[0x15]] ;if(document.getElementById(OxO6295[0x28])[OxO6295[0x15]]){ body[OxO6295[0x27]]=document.getElementById(OxO6295[0x28])[OxO6295[0x15]] ;} ;if(document.getElementById(OxO6295[0x2a])[OxO6295[0x15]]){ body[OxO6295[0x29]]=document.getElementById(OxO6295[0x2a])[OxO6295[0x15]] ;} ;} catch(er){ alert(OxO6295[0x2f]) ;return ;} ; str_DOCTYPE=document.getElementById(OxO6295[0x16])[OxO6295[0x15]] ; body_fontcolor=document.getElementById(OxO6295[0x1a])[OxO6295[0x15]] ; body_bgcolor=document.getElementById(OxO6295[0x1d])[OxO6295[0x15]] ; str_title=document.getElementById(OxO6295[0x17])[OxO6295[0x15]] ; str_description=document.getElementById(OxO6295[0x18])[OxO6295[0x15]] ; str_keywords=document.getElementById(OxO6295[0x19])[OxO6295[0x15]] ; str_PageLanguage=document.getElementById(OxO6295[0x2b])[OxO6295[0x15]] ; str_HTMLEncoding=document.getElementById(OxO6295[0x2c])[OxO6295[0x15]] ; str_BaseHref=document.getElementById(OxO6295[0x2e])[OxO6295[0x15]] ;try{ editdoc[OxO6295[0x5]][OxO6295[0x7]][OxO6295[0x1b]]=body_bgcolor ; editdoc[OxO6295[0x5]][OxO6295[0x7]][OxO6295[0x30]]=body_fontcolor ;} catch(er){ alert(OxO6295[0x31]) ;return ;} ;var metas=head.getElementsByTagName(OxO6295[0xc]);var Ox5dc=null;var Ox5dd=null;var Ox5de=null;var Ox5df=null;var Oxb1=head.getElementsByTagName(OxO6295[0x9])[0x0];if(Oxb1){while(node=Oxb1[OxO6295[0x32]]){ Oxb1.removeChild(node) ;} ;} else { Oxb1=editdoc.createElement(OxO6295[0x9]) ; head.appendChild(Oxb1) ;} ; Oxb1.appendChild(editdoc.createTextNode(str_title)) ;if(str_title){ editdoc[OxO6295[0x9]]=str_title ;} else { editdoc[OxO6295[0x9]]=OxO6295[0xb] ;} ;for(var m=0x0;m<metas[OxO6295[0xd]];m++){if(metas[m][OxO6295[0xe]].toLowerCase()==OxO6295[0xf]){ Ox5dc=metas[m] ;} ;if(metas[m][OxO6295[0xe]].toLowerCase()==OxO6295[0x11]){ Ox5dd=metas[m] ;} ;if(metas[m][OxO6295[0x12]].toLowerCase()==OxO6295[0x13]){ Ox5de=metas[m] ;} ;if(metas[m][OxO6295[0x12]].toLowerCase()==OxO6295[0x14]){ Ox5df=metas[m] ;} ;} ; function Ox5e0(Oxb6,name,Ox4db){var Ox5e1=document.createElement(OxO6295[0xc]);switch((Oxb6+OxO6295[0xb]).toLowerCase()){case OxO6295[0xe]: Ox5e1[OxO6295[0xe]]=name ;break ;case OxO6295[0x33]: Ox5e1[OxO6295[0x12]]=name ;break ;;;} ; Ox5e1[OxO6295[0x10]]=Ox4db ; head.appendChild(Ox5e1) ;}  ;if(htmlbase){try{ head.removeChild(htmlbase) ;} catch(er){ alert(htmlbase.href) ;} ; htmlbase=null ;} ;if(!htmlbase&&str_BaseHref){var Ox359=editdoc.createElement(OxO6295[0x34]); Ox359[OxO6295[0x2d]]=str_BaseHref ; head.appendChild(Ox359) ;} ;if(Ox5dc){ Ox5dc[OxO6295[0x35]].removeChild(Ox5dc) ; Ox5dc=null ;} ;if(!Ox5dc&&str_keywords){ Ox5e0(OxO6295[0xe],OxO6295[0xf],str_keywords) ;} ;if(Ox5dd){ Ox5dd[OxO6295[0x35]].removeChild(Ox5dd) ; Ox5dd=null ;} ;if(!Ox5dd&&str_description){ Ox5e0(OxO6295[0xe],OxO6295[0x11],str_description) ;} ;if(Ox5de){ Ox5de[OxO6295[0x35]].removeChild(Ox5de) ; Ox5de=null ;} ;if(!Ox5de&&str_HTMLEncoding){ Ox5e0(OxO6295[0x33],OxO6295[0x36],str_HTMLEncoding) ;} ;if(Ox5df){ Ox5df[OxO6295[0x35]].removeChild(Ox5df) ; Ox5df=null ;} ;if(!Ox5df&&str_PageLanguage){ Ox5e0(OxO6295[0x33],OxO6295[0x37],str_PageLanguage) ;} ;var parameters= new Array(); parameters[OxO6295[0x38]]=str_DOCTYPE ; parameters[OxO6295[0x39]]=head[OxO6295[0xa]] ; parameters[OxO6295[0x3a]]=getBodyHTML() ; top[OxO6295[0x3b]]=parameters ; top.close() ;}  ; function btncc_click(){ top[OxO6295[0x3b]]=false ; top.close() ;}  ; function SelectColor(n){var Ox567=OxO6295[0x3c];if(n==0x1){ showModalDialog(Ox567,null,_colorpickerDialogFeature,function (Ox2dc,Ox18d){if(Ox18d[OxO6295[0x3b]]){ document.getElementById(OxO6295[0x1d])[OxO6295[0x15]]=Ox18d[OxO6295[0x3b]].toUpperCase() ; document.getElementById(OxO6295[0x1e])[OxO6295[0x7]][OxO6295[0x1b]]=Ox18d[OxO6295[0x3b]] ;} ;} ) ;} else { showModalDialog(Ox567,null,_colorpickerDialogFeature,function (Ox2dc,Ox18d){if(Ox18d[OxO6295[0x3b]]){ document.getElementById(OxO6295[0x1a])[OxO6295[0x15]]=Ox18d[OxO6295[0x3b]].toUpperCase() ; document.getElementById(OxO6295[0x1c])[OxO6295[0x7]][OxO6295[0x1b]]=Ox18d[OxO6295[0x3b]] ;} ;} ) ;} ;}  ; function getBodyHTML(){var Oxaf=OxO6295[0x3d];var Ox284=body[OxO6295[0x3e]];for( i=0x0 ;i<Ox284[OxO6295[0xd]];++i){var Ox146=Ox284.item(i);if(!Ox146[OxO6295[0x3f]]){continue ;} ;var name=Ox146[OxO6295[0x40]].toLowerCase();if(/_moz|contenteditable|_msh/.test(name)){continue ;} ;if(/_moz|unselectable|_msh/.test(name)){continue ;} ;var Ox223;if(name==OxO6295[0x7]){ Ox223=body[OxO6295[0x7]][OxO6295[0x41]] ;} else {if( typeof body[Ox146[OxO6295[0x40]]]!=OxO6295[0x42]){ Ox223=body[Ox146[OxO6295[0x40]]] ;} else { Ox223=Ox146[OxO6295[0x43]] ;} ;} ;if(/(_moz|^$)/.test(Ox223)){continue ;} ; Oxaf+=OxO6295[0x44]+name+OxO6295[0x45]+Ox223+OxO6295[0x46] ;} ; Oxaf+=OxO6295[0x47] ;return Oxaf;}  ;	
	
	</script>
</html>
