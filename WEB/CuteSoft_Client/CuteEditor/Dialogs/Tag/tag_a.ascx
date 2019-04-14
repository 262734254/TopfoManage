<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[Hyperlink_Information]]</legend>
	<table class="normal">
		<tr>
			<td style="width:60px">[[Url]]:</td>
			<td colspan="3"><input type="text" id="inp_src" style="width:260px">
			</td>
			<td><button id="btnbrowse">[[Browse]]</button></td>
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
				<input type="text" id="inp_index" size="5" maxlength=5 onkeypress="event.returnValue=IsDigit();">
				&nbsp;
				[[Color]]:&nbsp;
				<input type="text" id="inp_color" size="7" style='behavior:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
					oncolorpopup="this.selectedColor=value" oncolorchange="this.value=this.selectedColor;inp_color.style.backgroundColor=this.selectedColor;FireUIChanged()">
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

var OxO34e1=["inp_src","sel_protocol","inp_target","inp_id","inp_class","inp_access","inp_index","inp_color","inp_title","allanchors","","visibility","style","hidden","SelectFile.Aspx?settinghash=[[_setting_]]\x26type=gif,jpg,jpeg,png,bmp\x26file=","\x26[[DNN_Arg]]","[[SelectFileDialogOption]]","value","visible","options","length","anchors","OPTION","name","text","#","selection","type","Unselect","parentElement","body","StartToStart","EndToEnd","://",":","others","selectedIndex","href_cetemp","href","\x26#","id","color","backgroundColor","className","title","target","tabIndex","accessKey","innerHTML","mailto:","[[ValidID]]","\x3Cp\x3E\x26nbsp;\x3C/p\x3E","\x3Cp\x3E\x26#160;\x3C/p\x3E","\x3Cp\x3E\x3C/p\x3E","\x3Cdiv\x3E\x26#160;\x3C/div\x3E","\x3Cdiv\x3E\x26nbsp;\x3C/div\x3E","\x3Cdiv\x3E\x3C/div\x3E","$1",";"];var inp_src=document.getElementById(OxO34e1[0x0]);var sel_protocol=document.getElementById(OxO34e1[0x1]);var inp_target=document.getElementById(OxO34e1[0x2]);var inp_id=document.getElementById(OxO34e1[0x3]);var inp_class=document.getElementById(OxO34e1[0x4]);var inp_access=document.getElementById(OxO34e1[0x5]);var inp_index=document.getElementById(OxO34e1[0x6]);var inp_color=document.getElementById(OxO34e1[0x7]);var inp_title=document.getElementById(OxO34e1[0x8]);var allanchors=document.getElementById(OxO34e1[0x9]);var originalInnerHTML=OxO34e1[0xa]; allanchors[OxO34e1[0xc]][OxO34e1[0xb]]=OxO34e1[0xd] ; updateList() ; function btnbrowse.onclick(){var Ox74=showModalDialog(OxO34e1[0xe]+escape(inp_src.value)+OxO34e1[0xf],null,OxO34e1[0x10]);if(Ox74){ inp_src[OxO34e1[0x11]]=Ox74 ;} ;}  ; function ToggleAnchors(){if(allanchors[OxO34e1[0xc]][OxO34e1[0xb]]==OxO34e1[0xd]){ allanchors[OxO34e1[0xc]][OxO34e1[0xb]]=OxO34e1[0x12] ;} else { allanchors[OxO34e1[0xc]][OxO34e1[0xb]]=OxO34e1[0xd] ;} ;}  ; function updateList(){while(allanchors[OxO34e1[0x13]][OxO34e1[0x14]]!=0x0){ allanchors[OxO34e1[0x13]].remove(allanchors.options(0x0)) ;} ;for(var i=0x0;i<editdoc[OxO34e1[0x15]][OxO34e1[0x14]];i++){var Ox539=document.createElement(OxO34e1[0x16]); Ox539[OxO34e1[0x18]]=OxO34e1[0x19]+editdoc[OxO34e1[0x15]][i][OxO34e1[0x17]] ; Ox539[OxO34e1[0x11]]=editdoc[OxO34e1[0x15]][i][OxO34e1[0x17]] ; allanchors[OxO34e1[0x13]].add(Ox539) ;} ;}  ; function selectAnchor(Ox53b){ editor.FocusDocument() ;var Ox305=editdoc[OxO34e1[0x1a]].createRange();var Ox4e4=editdoc[OxO34e1[0x1a]][OxO34e1[0x1b]]; Ox305.execCommand(OxO34e1[0x1c]) ;for(var i=0x0;i<editdoc[OxO34e1[0x15]][OxO34e1[0x14]];i++){if(editdoc[OxO34e1[0x15]][i][OxO34e1[0x17]]==Ox53b){ inp_src[OxO34e1[0x11]]=OxO34e1[0x19]+Ox53b ;if(Ox305[OxO34e1[0x1d]]){var Ox613=editdoc[OxO34e1[0x1e]].createTextRange(); Ox613.moveToElementText(editdoc[OxO34e1[0x15]][i]) ; Ox305.setEndPoint(OxO34e1[0x1f],Ox613) ; Ox305.setEndPoint(OxO34e1[0x20],Ox613) ; Ox305.select() ;} ;} ;} ;}  ; function sel_protocol_change(){var src=inp_src[OxO34e1[0x11]].replace(/$\s*/,OxO34e1[0xa]);for(var i=0x0;i<sel_protocol[OxO34e1[0x13]][OxO34e1[0x14]];i++){var Ox5b=sel_protocol.options(i)[OxO34e1[0x11]];if(src.substr(0x0,Ox5b.length).toLowerCase()==Ox5b){ src=src.substr(Ox5b[OxO34e1[0x14]],src[OxO34e1[0x14]]-Ox5b.length) ;break ;} ;} ;var Ox674=src.indexOf(OxO34e1[0x21]);if(Ox674!=-0x1){ src=src.substr(Ox674+0x3,src[OxO34e1[0x14]]-0x3-Ox674) ;} ;var Ox674=src.indexOf(OxO34e1[0x22]);if(Ox674!=-0x1){ src=src.substr(Ox674+0x1,src[OxO34e1[0x14]]-0x1-Ox674) ;} ;var Ox675=sel_protocol[OxO34e1[0x11]];if(Ox675==OxO34e1[0x23]){ Ox675=OxO34e1[0xa] ;} ; inp_src[OxO34e1[0x11]]=Ox675+src ;}  ; function Update_sel_protocol(src){var Ox458=false;for(var i=0x0;i<sel_protocol[OxO34e1[0x13]][OxO34e1[0x14]];i++){var Ox5b=sel_protocol.options(i)[OxO34e1[0x11]];if(src.substr(0x0,Ox5b.length).toLowerCase()==Ox5b){if(sel_protocol[OxO34e1[0x24]]!=i){ sel_protocol[OxO34e1[0x24]]=i ;} ; Ox458=true ;break ;} ;} ;if(!Ox458){ sel_protocol[OxO34e1[0x24]]=sel_protocol[OxO34e1[0x13]][OxO34e1[0x14]]-0x1 ;} ;}  ; function UpdateState(){}  ; function SyncToView(){var src=element.getAttribute(OxO34e1[0x25]);if(!src||src[OxO34e1[0x14]]==0x0){ src=element.getAttribute(OxO34e1[0x26],0x2)+OxO34e1[0xa] ;} ;if(EnableAntiSpamEmailEncoder&&(element[OxO34e1[0x26]]).indexOf(OxO34e1[0x27])!=-0x1){ src=decode(src) ;} else {if(src.toLowerCase().substr(0x0,BaseHref[OxO34e1[0x14]]+0x1)==BaseHref+OxO34e1[0x19]){ src=src.substring(BaseHref.length) ;} ;} ; Update_sel_protocol(src) ; inp_id[OxO34e1[0x11]]=element[OxO34e1[0x28]] ; inp_src[OxO34e1[0x11]]=src ;if(element[OxO34e1[0xc]][OxO34e1[0x29]]){ inp_color[OxO34e1[0x11]]=element[OxO34e1[0xc]][OxO34e1[0x29]] ; inp_color[OxO34e1[0xc]][OxO34e1[0x2a]]=inp_color[OxO34e1[0x11]] ;} ;if(element[OxO34e1[0x2b]]){ inp_class[OxO34e1[0x11]]=element[OxO34e1[0x2b]] ;} ;if(element[OxO34e1[0x2c]]){ inp_title[OxO34e1[0x11]]=element[OxO34e1[0x2c]] ;} ;if(element[OxO34e1[0x2d]]){ inp_target[OxO34e1[0x11]]=element[OxO34e1[0x2d]] ;} ;if(element[OxO34e1[0x2e]]){ inp_index[OxO34e1[0x11]]=element[OxO34e1[0x2e]] ;} ;if(element[OxO34e1[0x2f]]){ inp_access[OxO34e1[0x11]]=element[OxO34e1[0x2f]] ;} ; originalInnerHTML=element[OxO34e1[0x30]] ;}  ; function SyncTo(element){if(sel_protocol[OxO34e1[0x11]]==OxO34e1[0x31]&&EnableAntiSpamEmailEncoder){ element[OxO34e1[0x26]]=obfuscate(inp_src.value) ; element.setAttribute(OxO34e1[0x25],inp_src.value) ; Update_sel_protocol(decode(element[OxO34e1[0x26]].replace(/$\s*/,OxO34e1[0xa]))) ;} else { element[OxO34e1[0x26]]=inp_src[OxO34e1[0x11]] ; element.setAttribute(OxO34e1[0x25],inp_src.value) ; Update_sel_protocol(element[OxO34e1[0x26]].replace(/$\s*/,OxO34e1[0xa])) ;} ;try{ element[OxO34e1[0xc]][OxO34e1[0x29]]=inp_color[OxO34e1[0x11]]||OxO34e1[0xa] ;} catch(x){ element[OxO34e1[0xc]][OxO34e1[0x29]]=OxO34e1[0xa] ;} ; element[OxO34e1[0x2b]]=inp_class[OxO34e1[0x11]] ; element[OxO34e1[0x2d]]=inp_target[OxO34e1[0x11]] ; element[OxO34e1[0x2c]]=inp_title[OxO34e1[0x11]] ; element[OxO34e1[0x2e]]=inp_index[OxO34e1[0x11]] ; element[OxO34e1[0x2f]]=inp_access[OxO34e1[0x11]] ;if(element[OxO34e1[0x2c]]==OxO34e1[0xa]){ element.removeAttribute(OxO34e1[0x2c]) ;} ;if(element[OxO34e1[0x2d]]==OxO34e1[0xa]){ element.removeAttribute(OxO34e1[0x2d]) ;} ;if(element[OxO34e1[0x2b]]==OxO34e1[0xa]){ element.removeAttribute(OxO34e1[0x2b]) ;} ;if(element[OxO34e1[0x2e]]==OxO34e1[0xa]){ element.removeAttribute(OxO34e1[0x2e]) ;} ;if(element[OxO34e1[0x2f]]==OxO34e1[0xa]){ element.removeAttribute(OxO34e1[0x2f]) ;} ;var Ox535=/[^a-z\d]/i;if(Ox535.test(inp_id.value)){ alert(OxO34e1[0x32]) ;return ;} ; element[OxO34e1[0x28]]=inp_id[OxO34e1[0x11]] ;var Oxaf=element[OxO34e1[0x30]];switch(Oxaf.toLowerCase()){case OxO34e1[0x38]:case OxO34e1[0x37]:case OxO34e1[0x36]:case OxO34e1[0x35]:case OxO34e1[0x34]:case OxO34e1[0x33]: element[OxO34e1[0x30]]=OxO34e1[0xa] ;break ;default:break ;;;;;;;;} ;if(originalInnerHTML==OxO34e1[0xa]){ element[OxO34e1[0x30]]=element[OxO34e1[0x2c]]||element[OxO34e1[0x26]]||element[OxO34e1[0x17]] ;} ;}  ; function RemoveServerNamesFromUrl(Ox4f4,BaseHref){var Ox629=BaseHref; Ox629=Ox629.replace(/^(https?:\/\/[^\/]+)(.*)$/,OxO34e1[0x39]) ; serverre= new RegExp(Ox629) ;return Ox4f4.replace(serverre,OxO34e1[0xa]);}  ; function obfuscate(Ox3ce){var Ox3cf=OxO34e1[0xa];if(Ox3ce[OxO34e1[0x14]]>0x0){for(var i=0x0;i<Ox3ce[OxO34e1[0x14]];i++){ Ox3cf+=OxO34e1[0x27]+Ox3ce.charCodeAt(i)+OxO34e1[0x3a] ;} ;} ;return (Ox3cf);}  ; function decode(Ox6e4){var Ox6e5=OxO34e1[0xa];var arr=Ox6e4.split(OxO34e1[0x3a]);for(var i=0x0;i<arr[OxO34e1[0x14]];i++){var Ox20=arr[i].substr(0x2,arr[i][OxO34e1[0x14]]-0x2); Ox20=String.fromCharCode(Ox20) ; Ox6e5+=Ox20 ;} ;return (Ox6e5);}  ;

</script>
