<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[Hyperlink_Information]]</legend>
			<table class="normal">
		<tr>
			<td style="width:60px">[[Url]]:</td>
			<td colspan="3"><input type="text" id="inp_src" style="width:260px"></td>
			<td></td>
		</tr>
		<tr>
			<td style="width:60px">[[Type]]:</td>
			<td>
				<select id=sel_protocol onchange="sel_protocol_change()">
					<option value="http://">http://</option>
					<option value="https://">https://</option>
					<option value="ftp://">ftp://</option>
					<option value="news://">news://</option>
					<option value="mailto:">mailto:</option>
					<!-- last one : if move this to front , change the script too -->
					<option value="others">[[Other]]</option>
				</select>
			</td>
			<td>
				[[Target]]: 
			</td>
			<td>
				<SELECT id="inp_target" NAME="inp_target">
					<OPTION value="">[[NotSet]]</OPTION>
					<OPTION value="_blank">[[Newwindow]]</OPTION>
					<OPTION value="_self">[[Samewindow]]</OPTION>
					<OPTION value="_top">[[Topmostwindow]]</OPTION>
					<OPTION value="_parent">[[Parentwindow]]</OPTION>
				</SELECT>
			</td>
			<td>
			</td>
		</tr>		
		<tr>
			<td valign="middle" nowrap>[[ID]]:</td>
			<td>
				<input type="text" id="inp_id" size="14">
			</td>
			<td>[[CssClass]]:</td>
			<td>
				<input type="text" id="inp_class" size="14">
			</td>
			<td></td>
		</tr>
		<tr>
			<td valign="middle" nowrap>[[AccessKey]]:</td>
			<td colspan=4>
				<input type="text" id="inp_access" size="2" maxlength=1>
				&nbsp;
				[[TabIndex]]:&nbsp;
				<input type="text" id="inp_index" size="5" maxlength=5 onkeypress="return IsDigit(event);">
				&nbsp;
				[[Color]]:&nbsp;
				<input type="text" id="inp_color" name="inp_color" size="7" style="WIDTH:57px">	
				<img id="inp_color_Preview" src="../images/colorpicker.gif" onclick="SelectColor('inp_color',this);" align="absMiddle">
			</td>
		</tr>
		<tr>
			<td>[[Title]]:</td>
			<td colspan="3">
				<textarea id="inp_title" rows="2" style="width:260px"></textarea>
			</td>
			<td></td>
		</tr>
		<tr>
			<td align=right></td>
			<td colspan=4>
				<input type="checkbox" id="inp_checked" unchecked onclick="ToggleAnchors();" />[[SelectAnchor]]
				<br>
				<select size="5" name="allanchors" style="width: 255" id="allanchors" onchange="selectAnchor(this.value);"></select>
			</td>
		</tr>
	</table>
</fieldset>
<script>
	var OxOf88d=["innerHTML","inp_src","inp_target","sel_protocol","inp_class","inp_title","inp_color","inp_id","inp_color_Preview","inp_access","inp_index","allanchors","visibility","style","hidden","","href","href_cetemp","\x26#","value","id","target","className","tabIndex","accessKey","title","color","backgroundColor","mailto:","selectedIndex","[[ValidID]]","class","\x3Cp\x3E\x26nbsp;\x3C/p\x3E","\x3Cp\x3E\x26#160;\x3C/p\x3E","\x3Cp\x3E\x3C/p\x3E","\x3Cdiv\x3E\x26#160;\x3C/div\x3E","\x3Cdiv\x3E\x26nbsp;\x3C/div\x3E","\x3Cdiv\x3E\x3C/div\x3E","name","link","length",";","visible","options","anchors","OPTION","text","#"];var linkhtml; linkhtml=element[OxOf88d[0x0]] ;var inp_src=document.getElementById(OxOf88d[0x1]);var inp_target=document.getElementById(OxOf88d[0x2]);var sel_protocol=document.getElementById(OxOf88d[0x3]);var inp_class=document.getElementById(OxOf88d[0x4]);var inp_title=document.getElementById(OxOf88d[0x5]);var inp_color=document.getElementById(OxOf88d[0x6]);var inp_id=document.getElementById(OxOf88d[0x7]);var inp_color_Preview=document.getElementById(OxOf88d[0x8]);var inp_access=document.getElementById(OxOf88d[0x9]);var inp_index=document.getElementById(OxOf88d[0xa]);var allanchors=document.getElementById(OxOf88d[0xb]); allanchors[OxOf88d[0xd]][OxOf88d[0xc]]=OxOf88d[0xe] ; updateList() ; function SyncToView(){if(element){var src=OxOf88d[0xf];if(element.getAttribute(OxOf88d[0x10])){ src=element.getAttribute(OxOf88d[0x10]) ;} ;if(element.getAttribute(OxOf88d[0x11])){ src=element.getAttribute(OxOf88d[0x11]) ;} ;if(EnableAntiSpamEmailEncoder&&(src).indexOf(OxOf88d[0x12])!=-0x1){ src=decode(src) ;} ; inp_src[OxOf88d[0x13]]=src ; inp_id[OxOf88d[0x13]]=element[OxOf88d[0x14]] ;if(element[OxOf88d[0x15]]){ inp_target[OxOf88d[0x13]]=element[OxOf88d[0x15]] ;} ;if(element[OxOf88d[0x16]]){ inp_class[OxOf88d[0x13]]=element[OxOf88d[0x16]] ;} ;if(element[OxOf88d[0x17]]<=0x0){ inp_index[OxOf88d[0x13]]=OxOf88d[0xf] ;} else { inp_index[OxOf88d[0x13]]=element[OxOf88d[0x17]] ;} ;if(element[OxOf88d[0x18]]){ inp_access[OxOf88d[0x13]]=element[OxOf88d[0x18]] ;} ;if(element[OxOf88d[0x19]]){ inp_title[OxOf88d[0x13]]=element[OxOf88d[0x19]] ;} ;if(element[OxOf88d[0xd]][OxOf88d[0x1a]]){ inp_color[OxOf88d[0x13]]=revertColor(element[OxOf88d[0xd]].color) ; inp_color[OxOf88d[0xd]][OxOf88d[0x1b]]=inp_color[OxOf88d[0x13]] ; inp_color_Preview[OxOf88d[0xd]][OxOf88d[0x1b]]=inp_color[OxOf88d[0x13]] ;} ;} ;}  ; function SyncTo(){if(sel_protocol[OxOf88d[0x13]]==OxOf88d[0x1c]&&EnableAntiSpamEmailEncoder){ element[OxOf88d[0x10]]=obfuscate(inp_src.value) ; element.setAttribute(OxOf88d[0x11],inp_src.value) ;} else { element[OxOf88d[0x10]]=inp_src[OxOf88d[0x13]] ; element.setAttribute(OxOf88d[0x11],inp_src.value) ;} ;if(element[OxOf88d[0x0]]==OxOf88d[0xf]&&inp_title[OxOf88d[0x13]]){ element[OxOf88d[0x0]]=inp_title[OxOf88d[0x13]] ;} ; element[OxOf88d[0x19]]=inp_title[OxOf88d[0x13]] ; element[OxOf88d[0x16]]=inp_class[OxOf88d[0x13]] ; element[OxOf88d[0x17]]=inp_index[OxOf88d[0x13]] ; element[OxOf88d[0x18]]=inp_access[OxOf88d[0x13]] ; element[OxOf88d[0x14]]=inp_id[OxOf88d[0x13]] ;if(inp_target[OxOf88d[0x1d]]!=-0x1){ element[OxOf88d[0x15]]=inp_target[OxOf88d[0x13]] ;} ;try{ element[OxOf88d[0xd]][OxOf88d[0x1a]]=inp_color[OxOf88d[0x13]]||OxOf88d[0xf] ;} catch(x){ element[OxOf88d[0xd]][OxOf88d[0x1a]]=OxOf88d[0xf] ;} ;var Ox535=/[^a-z\d]/i;if(Ox535.test(inp_id.value)){ alert(OxOf88d[0x1e]) ;return ;} ;if(element[OxOf88d[0x19]]==OxOf88d[0xf]){ element.removeAttribute(OxOf88d[0x19]) ;} ;if(element[OxOf88d[0x15]]==OxOf88d[0xf]){ element.removeAttribute(OxOf88d[0x15]) ;} ;if(element[OxOf88d[0x16]]==OxOf88d[0xf]){ element.removeAttribute(OxOf88d[0x1f]) ;} ;if(element[OxOf88d[0x17]]==OxOf88d[0xf]){ element.removeAttribute(OxOf88d[0x17]) ;} ;if(element[OxOf88d[0x18]]==OxOf88d[0xf]){ element.removeAttribute(OxOf88d[0x18]) ;} ;if(element[OxOf88d[0x14]]==OxOf88d[0xf]){ element.removeAttribute(OxOf88d[0x14]) ;} ;try{ element[OxOf88d[0xd]][OxOf88d[0x1a]]=inp_color[OxOf88d[0x13]] ;} catch(er){ element[OxOf88d[0xd]][OxOf88d[0x1a]]=OxOf88d[0xf] ;} ;var Oxaf=element[OxOf88d[0x0]];switch(Oxaf.toLowerCase()){case OxOf88d[0x25]:case OxOf88d[0x24]:case OxOf88d[0x23]:case OxOf88d[0x22]:case OxOf88d[0x21]:case OxOf88d[0x20]: element[OxOf88d[0x0]]=OxOf88d[0xf] ;break ;default:break ;;;;;;;;} ;if(element[OxOf88d[0x0]]==OxOf88d[0xf]){ element[OxOf88d[0x0]]=element[OxOf88d[0x19]]||inp_src[OxOf88d[0x13]]||element[OxOf88d[0x26]]||OxOf88d[0x27] ;} ;}  ; function sel_protocol_change(){ inp_src[OxOf88d[0x13]]=sel_protocol[OxOf88d[0x13]] ;}  ; function obfuscate(Ox3ce){var Ox3cf=OxOf88d[0xf];if(Ox3ce[OxOf88d[0x28]]>0x0){for(var i=0x0;i<Ox3ce[OxOf88d[0x28]];i++){ Ox3cf+=OxOf88d[0x12]+Ox3ce.charCodeAt(i)+OxOf88d[0x29] ;} ;} ;return (Ox3cf);}  ; function decode(Ox6e4){var Ox6e5=OxOf88d[0xf];var arr=Ox6e4.split(OxOf88d[0x29]);for(var i=0x0;i<arr[OxOf88d[0x28]];i++){var Ox20=arr[i].substr(0x2,arr[i][OxOf88d[0x28]]-0x2); Ox20=String.fromCharCode(Ox20) ; Ox6e5+=Ox20 ;} ;return (Ox6e5);}  ; function ToggleAnchors(){if(allanchors[OxOf88d[0xd]][OxOf88d[0xc]]==OxOf88d[0xe]){ allanchors[OxOf88d[0xd]][OxOf88d[0xc]]=OxOf88d[0x2a] ;} else { allanchors[OxOf88d[0xd]][OxOf88d[0xc]]=OxOf88d[0xe] ;} ;}  ; function updateList(){while(allanchors[OxOf88d[0x2b]][OxOf88d[0x28]]!=0x0){ allanchors[OxOf88d[0x2b]].remove(allanchors.options(0x0)) ;} ;for(var i=0x0;i<editdoc[OxOf88d[0x2c]][OxOf88d[0x28]];i++){var Ox539=document.createElement(OxOf88d[0x2d]); Ox539[OxOf88d[0x2e]]=OxOf88d[0x2f]+editdoc[OxOf88d[0x2c]][i][OxOf88d[0x26]] ; Ox539[OxOf88d[0x13]]=editdoc[OxOf88d[0x2c]][i][OxOf88d[0x26]] ; allanchors[OxOf88d[0x2b]].add(Ox539) ;} ;}  ; function selectAnchor(Ox53b){ inp_src[OxOf88d[0x13]]=OxOf88d[0x2f]+Ox53b ;}  ;
</script>
