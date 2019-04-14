<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[TABLE]]</legend>
	<table class="normal">
		<tr>
			<td>[[CellSpacing]]:</td>
			<td><input type="text" id="inp_cellspacing"  size="14" onkeypress="event.returnValue=IsDigit();"></td>
			<td>[[CellPadding]]:</td>
			<td><input type="text" id="inp_cellpadding"  size="14" onkeypress="event.returnValue=IsDigit();"></td>
		</tr>
		<tr>
			<td>[[ID]]:</td>
			<td><input type="text" id="inp_id" size="14">&nbsp;&nbsp;</td>
			<td>[[Border]]:</td>
			<td><input type="text" id="inp_border"  size="14" onkeypress="event.returnValue=IsDigit();"></td>
		</tr>
		<tr>
			<td>[[Backgroundcolor]]:
			</td>
			<td><input type="text" id="inp_bgcolor"  size="14" style='behavior:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
					oncolorchange="this.value=this.selectedColor; this.style.backgroundColor=this.selectedColor">
			</td>
			<td>[[BorderColor]]:
			</td>
			<td><input type="text" id="inp_bordercolor" size="14" style='behavior:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
					oncolorchange="this.value=this.selectedColor; this.style.backgroundColor=this.selectedColor">
			</td>
		</tr>
		<tr>
			<td valign="middle" nowrap>[[Rules]]:</td>
			<td><select id="sel_rules">
					<option value="">[[NotSet]]</option>
					<option value="all">all</option>
					<option value="rows">rows</option>
					<option value="cols">cols</option>
					<option value="none">none</option>
				</select>
			<td colspan=2>
				<input type="checkbox" id="inp_collapse">
				<label for="inp_collapse">[[CollapseBorder]]</label>&nbsp;				
			</td>
		</tr>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Summary]] :</td>
			<td>
				<textarea id="inp_summary" rows="3" style="width:320px"></textarea>
			</td>
		</tr>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Caption]] :</td>
			<td><button id="btn_editcaption">[[Insert]]</button><button id="btn_delcaption">[[Delete]]</button></td>
			<td>&nbsp;</td>
			<td>[[THEAD]]:</td>
			<td><button id="btn_insthead">[[Insert]]</button></td>
			
			<td>&nbsp;</td>
			<td>[[TFOOT]]:</td>
			<td><button id="btn_instfoot">[[Insert]]</button></td>
			<td width="5"></td>
			<td><img src="../images/Accessibility.gif"  align="absMiddle" hspace="5"></td>
		</tr>
	</table>
</fieldset>
<fieldset><legend>[[Common]]</legend>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[CssClass]]:</td>
			<td><input type="text" id="inp_class" style="width:80px"></td>
			<td>[[Width]]:</td>
			<td><nobr>
				<input type="text" id="inp_width" style="width:42px">
				<select id="sel_width_unit">
					<option value="px">px</option>
					<option value="%">%</option>
				</select></nobr>
			</td>
			<td>[[Height]]:</td>
			<td><nobr>
				<input type="text" id="inp_height" style="width:42px">
				<select id="sel_height_unit">
					<option value="px">px</option>
					<option value="%">%</option>
				</select></nobr>
			</td>
		</tr>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Alignment]]:</td>
			<td><select id="sel_align">
					<option value="">[[NotSet]]</option>
					<option value="left">[[Left]]</option>
					<option value="center">[[Center]]</option>
					<option value="right">[[Right]]</option>
				</select></td>
			<td>
				[[Text-Align]] :</td>
			<td><select id="sel_textalign">
					<option value="">[[NotSet]]</option>
					<option value="left">[[Left]]</option>
					<option value="center">[[Center]]</option>
					<option value="right">[[Right]]</option>
					<option value="justify">[[Justify]]</option>
				</select></td>
			<td>[[Float]]:
			</td>
			<td><select id="sel_float">
					<option value="">[[NotSet]]</option>
					<option value="left">[[Left]]</option>
					<option value="right">[[Right]]</option>
				</select></td>
		</tr>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[Title]] :</td>
			<td>
				<textarea id="inp_tooltip" rows="3" style="width:320px"></textarea>
			</td>
		</tr>
	</table>
</fieldset>
<!-- #include file="../../_sharedie.htm" -->
<script>


var OxOacdf=["inp_cellspacing","inp_cellpadding","inp_id","inp_border","inp_bgcolor","inp_bordercolor","sel_rules","inp_collapse","inp_summary","inp_class","inp_width","inp_height","sel_width_unit","sel_height_unit","sel_align","sel_textalign","sel_float","inp_tooltip","tHead","tFoot","caption","innerHTML","innerText","[[Caption]]","Unable to delete the caption. Please remove it in HTML source.","[[Delete]]","[[Insert]]","[[Edit]]","display","style","none","disabled","","specified","nodeValue","cellSpacing","value","cellPadding","id","border","borderColor","backgroundColor","bgColor","borderCollapse","checked","collapse","rules","summary","className","width","length","options","selectedIndex","height","align","styleFloat","textAlign","title","[[ValidID]]","0","%"];var inp_cellspacing=document.getElementById(OxOacdf[0x0]);var inp_cellpadding=document.getElementById(OxOacdf[0x1]);var inp_id=document.getElementById(OxOacdf[0x2]);var inp_border=document.getElementById(OxOacdf[0x3]);var inp_bgcolor=document.getElementById(OxOacdf[0x4]);var inp_bordercolor=document.getElementById(OxOacdf[0x5]);var sel_rules=document.getElementById(OxOacdf[0x6]);var inp_collapse=document.getElementById(OxOacdf[0x7]);var inp_summary=document.getElementById(OxOacdf[0x8]);var inp_class=document.getElementById(OxOacdf[0x9]);var inp_width=document.getElementById(OxOacdf[0xa]);var inp_height=document.getElementById(OxOacdf[0xb]);var sel_width_unit=document.getElementById(OxOacdf[0xc]);var sel_height_unit=document.getElementById(OxOacdf[0xd]);var sel_align=document.getElementById(OxOacdf[0xe]);var sel_textalign=document.getElementById(OxOacdf[0xf]);var sel_float=document.getElementById(OxOacdf[0x10]);var inp_tooltip=document.getElementById(OxOacdf[0x11]); function insertOneRow(Ox7a9,count){var Oxc3=Ox7a9.insertRow();for(var i=0x0;i<count;i++){ Oxc3.insertCell() ;} ;}  ; function btn_insthead.onclick(){if(element[OxOacdf[0x12]]){ element.deleteTHead() ;} else {var Ox7aa=Table_GetColCount(element);var Ox7ab=element.createTHead(); insertOneRow(Ox7ab,Ox7aa) ;} ;}  ; function btn_instfoot.onclick(){if(element[OxOacdf[0x13]]){ element.deleteTFoot() ;} else {var Ox7aa=Table_GetColCount(element);var Ox7ac=element.createTFoot(); insertOneRow(Ox7ac,Ox7aa) ;} ;}  ; function btn_editcaption.onclick(){var Ox7ad=element[OxOacdf[0x14]];if(Ox7ad!=null){var Oxaf=editor.EditInWindow(Ox7ad.innerHTML,window);if(Oxaf!=null&&Oxaf!=false){ Ox7ad[OxOacdf[0x15]]=Oxaf ;} ;} else {var Ox7ad=element.createCaption(); Ox7ad[OxOacdf[0x16]]=OxOacdf[0x17] ;} ;}  ; function btn_delcaption.onclick(){if(element[OxOacdf[0x14]]!=null){ alert(OxOacdf[0x18]) ;} ;}  ; function UpdateState(){ btn_insthead[OxOacdf[0x16]]=element[OxOacdf[0x12]]?OxOacdf[0x19]:OxOacdf[0x1a] ; btn_instfoot[OxOacdf[0x16]]=element[OxOacdf[0x13]]?OxOacdf[0x19]:OxOacdf[0x1a] ;if(element[OxOacdf[0x14]]!=null){ btn_editcaption[OxOacdf[0x16]]=OxOacdf[0x1b] ; btn_editcaption[OxOacdf[0x1d]][OxOacdf[0x1c]]=OxOacdf[0x1e] ; btn_delcaption[OxOacdf[0x1f]]=false ;} else { btn_editcaption[OxOacdf[0x16]]=OxOacdf[0x1a] ; btn_delcaption[OxOacdf[0x1f]]=true ;} ;}  ;var t_inp_width=OxOacdf[0x20];var t_inp_height=OxOacdf[0x20]; function SyncToView(){ function GetAttribute(Ox512){var attr=element.getAttributeNode(Ox512);if(attr==null||!attr[OxOacdf[0x21]]){return OxOacdf[0x20];} ;return attr[OxOacdf[0x22]];}  ; inp_cellspacing[OxOacdf[0x24]]=GetAttribute(OxOacdf[0x23]) ; inp_cellpadding[OxOacdf[0x24]]=GetAttribute(OxOacdf[0x25]) ; inp_id[OxOacdf[0x24]]=GetAttribute(OxOacdf[0x26]) ; inp_border[OxOacdf[0x24]]=GetAttribute(OxOacdf[0x27]) ; inp_bordercolor[OxOacdf[0x24]]=GetAttribute(OxOacdf[0x28]) ; inp_bordercolor[OxOacdf[0x1d]][OxOacdf[0x29]]=inp_bordercolor[OxOacdf[0x24]] ; inp_bgcolor[OxOacdf[0x24]]=GetAttribute(OxOacdf[0x2a]) ; inp_bgcolor[OxOacdf[0x1d]][OxOacdf[0x29]]=inp_bgcolor[OxOacdf[0x24]] ; inp_collapse[OxOacdf[0x2c]]=element[OxOacdf[0x1d]][OxOacdf[0x2b]]==OxOacdf[0x2d] ; sel_rules[OxOacdf[0x24]]=GetAttribute(OxOacdf[0x2e]) ; inp_summary[OxOacdf[0x24]]=GetAttribute(OxOacdf[0x2f]) ; inp_class[OxOacdf[0x24]]=element[OxOacdf[0x30]] ;if(GetAttribute(OxOacdf[0x31])){ t_inp_width=GetAttribute(OxOacdf[0x31]) ;} else {if(element[OxOacdf[0x1d]][OxOacdf[0x31]]){ t_inp_width=element[OxOacdf[0x1d]][OxOacdf[0x31]] ;} ;} ;if(t_inp_width){ inp_width[OxOacdf[0x24]]=ParseToString(t_inp_width) ;for(var i=0x0;i<sel_width_unit[OxOacdf[0x33]][OxOacdf[0x32]];i++){var Ox5b=sel_width_unit.options(i)[OxOacdf[0x24]];if(Ox5b&&t_inp_width.indexOf(Ox5b)!=-0x1){ sel_width_unit[OxOacdf[0x34]]=i ;break ;} ;} ;} ;if(GetAttribute(OxOacdf[0x35])){ t_inp_height=GetAttribute(OxOacdf[0x35]) ;} else {if(element[OxOacdf[0x1d]][OxOacdf[0x35]]){ t_inp_height=element[OxOacdf[0x1d]][OxOacdf[0x35]] ;} ;} ;if(t_inp_height){ inp_height[OxOacdf[0x24]]=ParseToString(t_inp_height) ;for(var i=0x0;i<sel_height_unit[OxOacdf[0x33]][OxOacdf[0x32]];i++){var Ox5b=sel_height_unit.options(i)[OxOacdf[0x24]];if(Ox5b&&t_inp_height.indexOf(Ox5b)!=-0x1){ sel_height_unit[OxOacdf[0x34]]=i ;break ;} ;} ;} ; sel_align[OxOacdf[0x24]]=element[OxOacdf[0x36]] ; sel_float[OxOacdf[0x24]]=element[OxOacdf[0x1d]][OxOacdf[0x37]] ; sel_textalign[OxOacdf[0x24]]=element[OxOacdf[0x1d]][OxOacdf[0x38]] ; inp_tooltip[OxOacdf[0x24]]=element[OxOacdf[0x39]] ;}  ; function SyncTo(element){ element[OxOacdf[0x28]]=inp_bordercolor[OxOacdf[0x24]] ; element[OxOacdf[0x2a]]=inp_bgcolor[OxOacdf[0x24]] ; element[OxOacdf[0x1d]][OxOacdf[0x2b]]=inp_collapse[OxOacdf[0x2c]]?OxOacdf[0x2d]:OxOacdf[0x20] ; element[OxOacdf[0x2e]]=sel_rules[OxOacdf[0x24]]||OxOacdf[0x20] ; element[OxOacdf[0x2f]]=inp_summary[OxOacdf[0x24]] ; element[OxOacdf[0x30]]=inp_class[OxOacdf[0x24]] ; element[OxOacdf[0x23]]=inp_cellspacing[OxOacdf[0x24]] ; element[OxOacdf[0x25]]=inp_cellpadding[OxOacdf[0x24]] ;var Ox535=/[^a-z\d]/i;if(Ox535.test(inp_id.value)){ alert(OxOacdf[0x3a]) ;return ;} ; element[OxOacdf[0x26]]=inp_id[OxOacdf[0x24]] ;if(inp_border[OxOacdf[0x24]]==OxOacdf[0x20]){ element[OxOacdf[0x27]]=OxOacdf[0x3b] ;} else { element[OxOacdf[0x27]]=inp_border[OxOacdf[0x24]] ;} ;if(inp_width[OxOacdf[0x24]]==OxOacdf[0x20]){ element.removeAttribute(OxOacdf[0x31]) ; element[OxOacdf[0x1d]][OxOacdf[0x31]]=OxOacdf[0x20] ;} else { t_inp_width=inp_width[OxOacdf[0x24]] ;if(sel_width_unit[OxOacdf[0x24]]==OxOacdf[0x3c]){ t_inp_width=inp_width[OxOacdf[0x24]]+sel_width_unit[OxOacdf[0x24]] ;} ;if(element[OxOacdf[0x1d]][OxOacdf[0x31]]&&element[OxOacdf[0x31]]){ element[OxOacdf[0x1d]][OxOacdf[0x31]]=t_inp_width ; element[OxOacdf[0x31]]=t_inp_width ;} else {if(element[OxOacdf[0x1d]][OxOacdf[0x31]]){ element[OxOacdf[0x1d]][OxOacdf[0x31]]=t_inp_width ;} else { element[OxOacdf[0x31]]=t_inp_width ;} ;} ;} ;if(inp_height[OxOacdf[0x24]]==OxOacdf[0x20]){ element.removeAttribute(OxOacdf[0x35]) ; element[OxOacdf[0x1d]][OxOacdf[0x35]]=OxOacdf[0x20] ;} else { t_inp_height=inp_height[OxOacdf[0x24]] ;if(sel_height_unit[OxOacdf[0x24]]==OxOacdf[0x3c]){ t_inp_height=inp_height[OxOacdf[0x24]]+sel_height_unit[OxOacdf[0x24]] ;} ; t_inp_height=inp_height[OxOacdf[0x24]]+sel_height_unit[OxOacdf[0x24]] ;if(element[OxOacdf[0x1d]][OxOacdf[0x35]]&&element[OxOacdf[0x35]]){ element[OxOacdf[0x1d]][OxOacdf[0x35]]=t_inp_height ; element[OxOacdf[0x35]]=t_inp_height ;} else {if(element[OxOacdf[0x1d]][OxOacdf[0x35]]){ element[OxOacdf[0x1d]][OxOacdf[0x35]]=t_inp_height ;} else { element[OxOacdf[0x35]]=t_inp_height ;} ;} ;} ; element[OxOacdf[0x36]]=sel_align[OxOacdf[0x24]] ; element[OxOacdf[0x1d]][OxOacdf[0x37]]=sel_float[OxOacdf[0x24]] ; element[OxOacdf[0x1d]][OxOacdf[0x38]]=sel_textalign[OxOacdf[0x24]] ; element[OxOacdf[0x39]]=inp_tooltip[OxOacdf[0x24]] ;if(element[OxOacdf[0x39]]==OxOacdf[0x20]){ element.removeAttribute(OxOacdf[0x39]) ;} ;if(element[OxOacdf[0x2f]]==OxOacdf[0x20]){ element.removeAttribute(OxOacdf[0x2f]) ;} ;if(element[OxOacdf[0x30]]==OxOacdf[0x20]){ element.removeAttribute(OxOacdf[0x30]) ;} ;}  ;

</script>
