<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[SystemFont]]</legend>
	<select id="sel_font" style="width:240">
		<option value="">[[NotSet]]</option>
		<option value="caption">[[Caption]]</option>
		<option value="icon">[[Icon]]</option>
		<option value="menu">[[Menu]]</option>
		<option value="messagebox">[[Messagebox]]</option>
		<option value="smallcaption">[[Smallcaption]]</option>
		<option value="statusbar">[[Statusbar]]</option>
	</select>
</fieldset>
<div id="div_font_detail">
	<fieldset><legend>[[FontFamily]]</legend>
		<input type="text" id="sel_fontfamily" style="width:240">
	</fieldset>
	<fieldset><legend>[[Decoration]]</legend>
		<input type="checkbox" id="cb_decoration_under"><label for="cb_decoration_under">[[Underline]]</label>
		<input type="checkbox" id="cb_decoration_over"><label for="cb_decoration_over">[[Overline]]</label>
		<input type="checkbox" id="cb_decoration_through"><label for="cb_decoration_through">[[Strikethrough]]</label>
	</fieldset>
	<fieldset><legend>[[Style]]</legend>
		<input type="checkbox" id="cb_style_bold"><label for="cb_style_bold">[[Bold]]</label>
		<input type="checkbox" id="cb_style_italic"><label for="cb_style_italic">[[Italic]]</label>
		&nbsp;&nbsp;[[Capitalization]]:
		<select id="sel_fontTransform">
			<option value="">[[NotSet]]</option>
			<option value="uppercase">[[uppercase]]</option>
			<option value="lowercase">[[lowercase]]</option>
			<option value="capitalize">[[InitialCap]]</option>
		</select>
	</fieldset>
	<fieldset><legend>[[Size]]</legend>
		<select id="sel_fontsize">
			<option value="">[[NotSet]]</option>
			<option value="xx-large">xx-large</option>
			<option value=" x-large">x-large</option>
			<option value="large">large</option>
			<option value="medium">medium</option>
			<option value="small">small</option>
			<option value="x-small">x-small</option>
			<option value="xx-small">xx-small</option>
			<option value="larger">larger</option>
			<option value="smaller">Smaller</option>
		</select>
		[[OR]] <input type="text" id="inp_fontsize" style="width:56">
		<select id="sel_fontsize_unit">
			<option value="px">px</option>
			<option value="pt">pt</option>
			<option value="pc">pc</option>
			<option value="em">em</option>
			<option value="cm">cm</option>
			<option value="mm">mm</option>
			<option value="in">in</option>
		</select>
	</fieldset>
	<fieldset><legend>[[Color]]</legend>
		<input type="text" id="inp_color" name="inp_color" size="7" style="WIDTH:57px">
		<img src="../images/colorpicker.gif"  align="absMiddle" style='BEHAVIOR:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
			oncolorchange="inp_color.value=this.selectedColor; inp_color.style.backgroundColor=this.selectedColor; FireUIChanged()">
												
	</fieldset>
</div>
<div id="outer"><div id="div_demo">[[DemoText]]</div></div>
<script>

var OxOdfda=["disabled","selectedIndex","cssText","style","font","value","fontFamily","color","backgroundColor","textDecoration","overline","checked","underline","line-through","fontWeight","bold","fontStyle","italic","fontSize","length","options","textTransform","font-family","","overline ","underline ","line-through "]; function UpdateState(){ inp_fontsize[OxOdfda[0x0]]=sel_fontsize_unit[OxOdfda[0x0]]=(sel_fontsize[OxOdfda[0x1]]>0x0) ; div_font_detail[OxOdfda[0x0]]=sel_font[OxOdfda[0x1]]>0x0 ; div_demo[OxOdfda[0x3]][OxOdfda[0x2]]=element[OxOdfda[0x3]][OxOdfda[0x2]] ;}  ; function SyncToView(){ sel_font[OxOdfda[0x5]]=element[OxOdfda[0x3]][OxOdfda[0x4]].toLowerCase()||null ; sel_fontfamily[OxOdfda[0x5]]=element[OxOdfda[0x3]][OxOdfda[0x6]] ; inp_color[OxOdfda[0x5]]=element[OxOdfda[0x3]][OxOdfda[0x7]] ; inp_color[OxOdfda[0x3]][OxOdfda[0x8]]=inp_color[OxOdfda[0x5]] ;var Ox111=element[OxOdfda[0x3]][OxOdfda[0x9]].toLowerCase(); cb_decoration_over[OxOdfda[0xb]]=Ox111.indexOf(OxOdfda[0xa])!=-0x1 ; cb_decoration_under[OxOdfda[0xb]]=Ox111.indexOf(OxOdfda[0xc])!=-0x1 ; cb_decoration_through[OxOdfda[0xb]]=Ox111.indexOf(OxOdfda[0xd])!=-0x1 ; cb_style_bold[OxOdfda[0xb]]=element[OxOdfda[0x3]][OxOdfda[0xe]]==OxOdfda[0xf] ; cb_style_italic[OxOdfda[0xb]]=element[OxOdfda[0x3]][OxOdfda[0x10]]==OxOdfda[0x11] ; sel_fontsize[OxOdfda[0x5]]=element[OxOdfda[0x3]][OxOdfda[0x12]] ; sel_fontsize_unit[OxOdfda[0x1]]=0x0 ;if(sel_fontsize[OxOdfda[0x1]]==-0x1){if(ParseToString(element[OxOdfda[0x3]].fontSize)){ sel_fontsize[OxOdfda[0x5]]=ParseToString(element[OxOdfda[0x3]].fontSize) ;for(var i=0x0;i<sel_fontsize_unit[OxOdfda[0x14]][OxOdfda[0x13]];i++){var Ox5b=sel_fontsize_unit.options(i)[OxOdfda[0x5]];if(Ox5b&&element[OxOdfda[0x3]][OxOdfda[0x12]].indexOf(Ox5b)!=-0x1){ sel_fontsize_unit[OxOdfda[0x1]]=i ;break ;} ;} ;} ;} ; sel_fontTransform[OxOdfda[0x5]]=element[OxOdfda[0x3]][OxOdfda[0x15]] ;}  ; function SyncTo(element){ SetStyle(element[OxOdfda[0x3]],OxOdfda[0x4],sel_font.value) ;if(sel_fontfamily[OxOdfda[0x5]]){ element[OxOdfda[0x3]][OxOdfda[0x6]]=sel_fontfamily[OxOdfda[0x5]] ;} else { SetStyle(element.style,OxOdfda[0x16],OxOdfda[0x17]) ;} ;try{ element[OxOdfda[0x3]][OxOdfda[0x7]]=inp_color[OxOdfda[0x5]]||OxOdfda[0x17] ;} catch(x){ element[OxOdfda[0x3]][OxOdfda[0x7]]=OxOdfda[0x17] ;} ;var Ox79d=cb_decoration_over[OxOdfda[0xb]];var Ox79e=cb_decoration_under[OxOdfda[0xb]];var Ox79f=cb_decoration_through[OxOdfda[0xb]];if(!Ox79d&&!Ox79e&&!Ox79f){ element[OxOdfda[0x3]][OxOdfda[0x9]]=OxOdfda[0x17] ;} else {var Ox116=OxOdfda[0x17];if(Ox79d){ Ox116+=OxOdfda[0x18] ;} ;if(Ox79e){ Ox116+=OxOdfda[0x19] ;} ;if(Ox79f){ Ox116+=OxOdfda[0x1a] ;} ; element[OxOdfda[0x3]][OxOdfda[0x9]]=Ox116.substr(0x0,Ox116[OxOdfda[0x13]]-0x1) ;} ; element[OxOdfda[0x3]][OxOdfda[0xe]]=cb_style_bold[OxOdfda[0xb]]?OxOdfda[0xf]:OxOdfda[0x17] ; element[OxOdfda[0x3]][OxOdfda[0x10]]=cb_style_italic[OxOdfda[0xb]]?OxOdfda[0x11]:OxOdfda[0x17] ; element[OxOdfda[0x3]][OxOdfda[0x15]]=sel_fontTransform[OxOdfda[0x5]]||OxOdfda[0x17] ;if(sel_fontsize[OxOdfda[0x1]]>0x0){ element[OxOdfda[0x3]][OxOdfda[0x12]]=sel_fontsize[OxOdfda[0x5]] ;} else {if(ParseToString(inp_fontsize.value)){ element[OxOdfda[0x3]][OxOdfda[0x12]]=ParseToString(inp_fontsize.value)+sel_fontsize_unit[OxOdfda[0x5]] ;} else { element[OxOdfda[0x3]][OxOdfda[0x12]]=OxOdfda[0x17] ;} ;} ;}  ;

</script>
