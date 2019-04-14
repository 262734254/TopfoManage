<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
	<table width=100% align=center cellpadding=0 cellspacing=0>
		<tr>
			<td valign=top style="padding:5;padding-bottom:0;height:100%">
				<table>
					<tr>
						<td valign=top style="padding:3">
							<div style="overflow:auto;border:gray 1 solid;width:115;height:127;">
								<table id=tblBorderStyle cellpadding=5 cellspacing=0 width=100% style="table-layout:fixed;background:white">
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doBorderStyle('')" style="cursor:default;height:25;padding:4;border:white 1 solid;">
											<div style="border:none;height:10;width:100%">[[NotSet]]</div>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doBorderStyle('solid')" style="cursor:default;height:25;padding:4;border:white 1 solid;">
											<div style="border-bottom:black 1 solid;height:10;width:100%" title="solid"></div>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doBorderStyle('dotted')" style="cursor:default;height:25;padding:4;border:white 1 solid;">
											<div style="border-bottom:black dotted;height:10;width:100%" title="dotted"></div>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doBorderStyle('dashed')" style="cursor:default;height:25;padding:4;border:white 1 solid;">
											<div style="border-bottom:black dashed;height:10;width:100%" title="dashed"></div>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doBorderStyle('double')" style="cursor:default;height:25;padding:4;border:white 1 solid;">
											<div style="border-bottom:black dotted;height:10;width:100%" title="double"></div>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doBorderStyle('groove')" style="cursor:default;height:25;padding:4;border:white 1 solid;">
											<div style="border-style:groove;height:10;width:100%" title="groove"></div>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doBorderStyle('ridge')" style="cursor:default;height:25;padding:4;border:white 1 solid;">
											<div style="border-style:ridge;height:10;width:100%" title="ridge"></div>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doBorderStyle('inset')" style="cursor:default;height:25;padding:4;border:white 1 solid;">
											<div style="border-style:inset;height:10;width:100%" title="inset"></div>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doBorderStyle('outset')" style="cursor:default;height:25;padding:4;border:white 1 solid;">
											<div style="border-style:outset;height:10;width:100%" title="outset"></div>
										</td>
									</tr>
								</table>
							</div>
							<input type=hidden name="sel_style" id="sel_style">
						</td>
						<td valign=top style="padding:3">
							<div style='overflow:auto;border:gray 1 solid;width:115;height:127'>
								<table id=tblBorderApplyTo cellpadding=5 cellspacing=0 width=100% style='table-layout:fixed;background:white'>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doWidth('1px')" style="height:25;padding:1;border:white 1 solid;" >
											<table width=100%><tr><td style="height:25" >1px</td><td valign=top width=100%> <table style='border-bottom:black 1px solid;height:16;' width=100%><tr><td></td></tr></table> </td></tr></table>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doWidth('2px')" style="height:25;padding:1;border:white 1 solid;" >
											<table width=100%><tr><td style="height:25" >2px</td><td valign=top width=100%> <table style='border-bottom:black 2px solid;height:16;' width=100%><tr><td></td></tr></table> </td></tr></table>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doWidth('3px')" style="height:25;padding:1;border:white 1 solid;" >
											<table width=100%><tr><td style="height:25" >3px</td><td valign=top width=100%> <table style='border-bottom:black 2px solid;height:16;' width=100%><tr><td></td></tr></table> </td></tr></table>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doWidth('4px')" style="height:25;padding:1;border:white 1 solid;" >
											<table width=100%><tr><td style="height:25" >4px</td><td valign=top width=100%> <table style='border-bottom:black 4px solid;height:16;' width=100%><tr><td></td></tr></table> </td></tr></table>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doWidth('5px')" style="height:25;padding:1;border:white 1 solid;" >
											<table width=100%><tr><td style="height:25" >5px</td><td valign=top width=100%> <table style='border-bottom:black 5px solid;height:16;' width=100%><tr><td></td></tr></table> </td></tr></table>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doWidth('6px')" style="height:25;padding:1;border:white 1 solid;" >
											<table width=100%><tr><td style="height:25" >6px</td><td valign=top width=100%> <table style='border-bottom:black 6px solid;height:16;' width=100%><tr><td></td></tr></table> </td></tr></table>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doWidth('7px')" style="height:25;padding:1;border:white 1 solid;" >
											<table width=100%><tr><td style="height:25" >7px</td><td valign=top width=100%> <table style='border-bottom:black 7px solid;height:16;' width=100%><tr><td></td></tr></table> </td></tr></table>
										</td>
									</tr>
								</table>
								<input type=hidden name=sel_border id="sel_border">
							</div>		
						</td>
						<td valign=top style="padding:3" nowrap>													
							<div style='overflow:auto;border:gray 1 solid;width:55;height:127'>
								<table id=tblBorderApplyTo cellpadding=5 cellspacing=0 width=100% style='table-layout:fixed;background:white'>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doPart('none')" style="height:30;padding:4;border:white 1 solid;" >
											<img src='../images/border_none.gif' alt='No Border'>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doPart('')" style="height:30;padding:4;border:white 1 solid;" >
											<img src='../images/border_outside.gif' alt='All'>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doPart('left')" style="height:30;padding:4;border:white 1 solid;" >
											<img src='../images/border_left.gif' alt='[[Left]]'>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doPart('top')" style="height:30;padding:4;border:white 1 solid;" >
											<img src='../images/border_top.gif' alt='[[Top]]'>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doPart('right')" style="height:30;padding:4;border:white 1 solid;" >
											<img src='../images/border_right.gif' alt='[[Right]]'>
										</td>
									</tr>
									<tr>
										<td valign=top onmouseover="CuteEditor_ColorPicker_ButtonOver(this);" onclick="doPart('bottom')" style="height:30;padding:4;border:white 1 solid;" >
											<img src='../images/border_bottom.gif' alt='[[Bottom]]'>
										</td>
									</tr>
								</table>
								<input type=hidden name=sel_part id="sel_part">
							</div>
						</td>
						<td valign=top style="padding:0 5px 3px 8px" nowrap>
							<table cellpadding=0 cellspacing=0 style="padding-bottom:10">								
								<tr>						
									<td nowrap>[[Bordercolor]]:<br>
										<input type="text" id="bordercolor" name="bordercolor" size="7" style="WIDTH:57px">
										<img id="bordercolor_Preview" src="../images/colorpicker.gif"  align="absMiddle" style='BEHAVIOR:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
												oncolorchange="bordercolor.value=this.selectedColor; bordercolor.style.backgroundColor=this.selectedColor">
									</td>
								</tr>
								<tr>
									<td nowrap>[[ForeColor]]:<br>
										<input type="text" id="inp_color" name="inp_color" size="7" style="WIDTH:57px">
										<img id="inp_color_Preview" src="../images/colorpicker.gif"  align="absMiddle" style='BEHAVIOR:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
												oncolorchange="inp_color.value=this.selectedColor; inp_color.style.backgroundColor=this.selectedColor">
									</td>
								</tr>
								<tr>						
									<td nowrap>[[Shade]]:<br>
										<input type="text" id="inp_shade" name="inp_shade" size="7" style="WIDTH:57px">
										<img id="inp_shade_Preview" src="../images/colorpicker.gif"  align="absMiddle" style='BEHAVIOR:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
												oncolorchange="inp_shade.value=this.selectedColor; inp_shade.style.backgroundColor=this.selectedColor">
									</td>
								</tr>				
							</table>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td nowrap style="padding-left:8; padding-top:10">
				
				<table cellpadding=0 cellspacing=0>
					<tr>
						<td>
							<table cellpadding=2 cellspacing=0>
								<tr><td colspan=7>[[Margin]]:</td></tr>
								<tr>
								<td><span>[[Left]]</span>:</td>
								<td><input type="text" id="inp_MarginLeft" size=1 onkeypress="event.returnValue=IsDigit();"></td>
								<td> px</td>
								<td>&nbsp;&nbsp;</td>
								<td align=right><span>[[Right]]</span>:</td>
								<td><input type="text" id="inp_MarginRight" size=1 onkeypress="event.returnValue=IsDigit();"></td>
								<td> px</td>
								</tr>
								<tr>
								<td><span>[[Top]]</span>:</td>
								<td><input type="text" id="inp_MarginTop" size=1 onkeypress="event.returnValue=IsDigit();"></td>
								<td> px</td>
								<td>&nbsp;&nbsp;</td>
								<td align=right><span>[[Bottom]]</span>:</td>
								<td><input type="text" id="inp_MarginBottom" size=1 onkeypress="event.returnValue=IsDigit();"></td>
								<td> px</td>
								</tr>
							</table>
						</td>
						<td>
							<div style="margin:5;height:55;border-left:lightgrey 1 solid"></div>
						</td>
						<td style="padding-bottom:5">				
							<table cellpadding=2 cellspacing=0>
								<tr><td colspan=7>[[Padding]]:</td></tr>
								<tr>
								<td><span>[[Left]]</span>:</td>
								<td><input type="text" id="inp_PaddingLeft" size=1 onkeypress="event.returnValue=IsDigit();"></td>
								<td> px</td>
								<td>&nbsp;&nbsp;</td>
								<td align=right><span>[[Right]]</span>:</td>
								<td><input type="text" id="inp_PaddingRight" size=1 onkeypress="event.returnValue=IsDigit();"></td>
								<td> px</td>
								</tr>
								<tr>
								<td><span>[[Top]]</span>:</td>
								<td><input type="text" id="inp_PaddingTop" size=1 onkeypress="event.returnValue=IsDigit();"></td>
								<td> px</td>
								<td>&nbsp;&nbsp;</td>
								<td align=right><span>[[Bottom]]</span>:</td>
								<td><input type="text" id="inp_PaddingBottom" size=1 onkeypress="event.returnValue=IsDigit();"></td>
								<td> px</td>
								</tr>
							</table>					
						</td>
					</tr>
					<tr>
						<td colspan=3 style="padding-top:3;padding-bottom:5;border-top:lightgrey 1 solid">						
							<fieldset><legend>[[Common]]</legend>
								<table class="normal">
									<tr>
										<td width="80" nowrap>[[Width]]:</td>
										<td><nobr>
											<input type="text" id="inp_width" size="8" onkeypress="event.returnValue=IsDigit();">
											<select id="sel_width_unit">
												<option value="px">px</option>
												<option value="%">%</option>
											</select></nobr>
										</td>
										<td></td>
										<td>[[Height]]:</td>
										<td><nobr>
											<input type="text" id="inp_height" size="8" onkeypress="event.returnValue=IsDigit();">
											<select id="sel_height_unit">
												<option value="px">px</option>
												<option value="%">%</option>
											</select></nobr>
										</td>
									</tr>
									<tr>
										<td valign="middle" nowrap>[[ID]]:</td>
										<td><input type="text" id="inp_id" size="16"></td>	
										<td></td>									
										<td style='width:60px'>[[CssClass]]:</td>
										<td><input type="text" id="inp_class" size="16"></td>
									</tr>
									<tr>
										<td>[[Alignment]]:</td>
										<td colspan=4>
											<select id="sel_align">
												<option value="">[[NotSet]]</option>
												<option value="left">[[Left]]</option>
												<option value="center">[[Center]]</option>
												<option value="right">[[Right]]</option>
											</select>
											&nbsp;
											[[Text-Align]] :
											<select id="sel_textalign">
												<option value="">[[NotSet]]</option>
												<option value="left">[[Left]]</option>
												<option value="center">[[Center]]</option>
												<option value="right">[[Right]]</option>
												<option value="justify">[[Justify]]</option>
											</select>
											&nbsp;
											[[Float]]:
											<select id="sel_float">
												<option value="">[[NotSet]]</option>
												<option value="left">[[Left]]</option>
												<option value="right">[[Right]]</option>
											</select>
										</td>
									</tr>
									<tr>
										<td style='width:60px'>[[Title]] :</td>
										<td colspan="4">
											<textarea id="inp_tooltip" rows="2" style="width:320px"></textarea>
										</td>
									</tr>
								</table>
							</fieldset>
						</td>
					</tr>		
				</table>
			</td>
		</tr>
	</table>

<script>

var OxOf688=["sel_style","sel_part","sel_border","inp_color","inp_shade","inp_id","inp_MarginLeft","inp_MarginRight","inp_MarginTop","inp_MarginBottom","inp_PaddingLeft","inp_PaddingRight","inp_PaddingTop","inp_PaddingBottom","inp_class","inp_width","inp_height","sel_align","sel_textalign","sel_float","inp_tooltip","value","borderColor","style","backgroundColor","color","id","className","width","height","length","inp_","sel_","_unit","selectedIndex","options","align","styleFloat","textAlign","title","border","borderBottomWidth","borderLeftWidth","borderRightWidth","borderTopWidth","borderBottomStyle","borderLeftStyle","borderRightStyle","borderTopStyle","none","-","red",""," ","paddingLeft","paddingRight","paddingTop","paddingBottom","marginLeft","marginRight","marginTop","marginBottom","[[ValidID]]","keyCode"];var sel_style=document.getElementById(OxOf688[0x0]);var sel_part=document.getElementById(OxOf688[0x1]);var sel_border=document.getElementById(OxOf688[0x2]);var inp_color=document.getElementById(OxOf688[0x3]);var inp_shade=document.getElementById(OxOf688[0x4]);var inp_id=document.getElementById(OxOf688[0x5]);var inp_MarginLeft=document.getElementById(OxOf688[0x6]);var inp_MarginRight=document.getElementById(OxOf688[0x7]);var inp_MarginTop=document.getElementById(OxOf688[0x8]);var inp_MarginBottom=document.getElementById(OxOf688[0x9]);var inp_PaddingLeft=document.getElementById(OxOf688[0xa]);var inp_PaddingRight=document.getElementById(OxOf688[0xb]);var inp_PaddingTop=document.getElementById(OxOf688[0xc]);var inp_PaddingBottom=document.getElementById(OxOf688[0xd]);var inp_class=document.getElementById(OxOf688[0xe]);var inp_width=document.getElementById(OxOf688[0xf]);var inp_height=document.getElementById(OxOf688[0x10]);var sel_align=document.getElementById(OxOf688[0x11]);var sel_textalign=document.getElementById(OxOf688[0x12]);var sel_float=document.getElementById(OxOf688[0x13]);var inp_tooltip=document.getElementById(OxOf688[0x14]); function UpdateState(){}  ; function doBorderStyle(Ox25){ sel_style[OxOf688[0x15]]=Ox25 ;}  ; function doPart(Ox25){ sel_part[OxOf688[0x15]]=Ox25 ;}  ; function doWidth(Ox25){ sel_border[OxOf688[0x15]]=Ox25 ;}  ; function SyncToView(){ bordercolor[OxOf688[0x15]]=element[OxOf688[0x17]][OxOf688[0x16]] ; bordercolor[OxOf688[0x17]][OxOf688[0x18]]=element[OxOf688[0x17]][OxOf688[0x16]] ; bordercolor_Preview[OxOf688[0x17]][OxOf688[0x18]]=element[OxOf688[0x17]][OxOf688[0x16]] ; inp_color[OxOf688[0x15]]=element[OxOf688[0x17]][OxOf688[0x19]] ; inp_color[OxOf688[0x17]][OxOf688[0x18]]=element[OxOf688[0x17]][OxOf688[0x19]] ; inp_color_Preview[OxOf688[0x17]][OxOf688[0x18]]=element[OxOf688[0x17]][OxOf688[0x19]] ; inp_shade[OxOf688[0x15]]=element[OxOf688[0x17]][OxOf688[0x18]] ; inp_id[OxOf688[0x15]]=element[OxOf688[0x1a]] ; inp_shade[OxOf688[0x17]][OxOf688[0x18]]=element[OxOf688[0x17]][OxOf688[0x18]] ; inp_shade_Preview[OxOf688[0x17]][OxOf688[0x18]]=element[OxOf688[0x17]][OxOf688[0x18]] ; inp_MarginLeft[OxOf688[0x15]]=ParseToString(element[OxOf688[0x17]].marginLeft) ; inp_MarginRight[OxOf688[0x15]]=ParseToString(element[OxOf688[0x17]].marginRight) ; inp_MarginTop[OxOf688[0x15]]=ParseToString(element[OxOf688[0x17]].marginTop) ; inp_MarginBottom[OxOf688[0x15]]=ParseToString(element[OxOf688[0x17]].marginBottom) ; inp_PaddingLeft[OxOf688[0x15]]=ParseToString(element[OxOf688[0x17]].paddingLeft) ; inp_PaddingRight[OxOf688[0x15]]=ParseToString(element[OxOf688[0x17]].paddingRight) ; inp_PaddingTop[OxOf688[0x15]]=ParseToString(element[OxOf688[0x17]].paddingTop) ; inp_PaddingBottom[OxOf688[0x15]]=ParseToString(element[OxOf688[0x17]].paddingBottom) ; inp_class[OxOf688[0x15]]=element[OxOf688[0x1b]] ;var arr=[OxOf688[0x1c],OxOf688[0x1d]];for(var Oxd7=0x0;Oxd7<arr[OxOf688[0x1e]];Oxd7++){var n=arr[Oxd7];var e=document.getElementById(OxOf688[0x1f]+n);var Ox25=document.getElementById(OxOf688[0x20]+n+OxOf688[0x21]); Ox25[OxOf688[0x22]]=0x0 ;if(ParseToString(element[OxOf688[0x17]][n])){ e[OxOf688[0x15]]=ParseToString(element[OxOf688[0x17]][n]) ;for(var i=0x0;i<Ox25[OxOf688[0x23]][OxOf688[0x1e]];i++){var Ox5b=Ox25.options(i)[OxOf688[0x15]];if(Ox5b&&element[OxOf688[0x17]][n].indexOf(Ox5b)!=-0x1){ Ox25[OxOf688[0x22]]=i ;break ;} ;} ;} ;} ; sel_align[OxOf688[0x15]]=element[OxOf688[0x24]] ; sel_float[OxOf688[0x15]]=element[OxOf688[0x17]][OxOf688[0x25]] ; sel_textalign[OxOf688[0x15]]=element[OxOf688[0x17]][OxOf688[0x26]] ; inp_tooltip[OxOf688[0x15]]=element[OxOf688[0x27]] ; sel_border[OxOf688[0x15]]=element[OxOf688[0x17]][OxOf688[0x28]] ;if(element[OxOf688[0x17]][OxOf688[0x2a]]==element[OxOf688[0x17]][OxOf688[0x2c]]&&element[OxOf688[0x17]][OxOf688[0x2a]]==element[OxOf688[0x17]][OxOf688[0x2b]]&&element[OxOf688[0x17]][OxOf688[0x2a]]==element[OxOf688[0x17]][OxOf688[0x29]]){ sel_border[OxOf688[0x15]]=element[OxOf688[0x17]][OxOf688[0x2a]] ;} ;if(element[OxOf688[0x17]][OxOf688[0x2e]]==element[OxOf688[0x17]][OxOf688[0x30]]&&element[OxOf688[0x17]][OxOf688[0x2e]]==element[OxOf688[0x17]][OxOf688[0x2f]]&&element[OxOf688[0x17]][OxOf688[0x2e]]==element[OxOf688[0x17]][OxOf688[0x2d]]){ sel_style[OxOf688[0x15]]=element[OxOf688[0x17]][OxOf688[0x2e]] ;} ;}  ; function SyncTo(element){var Ox6fe=sel_part[OxOf688[0x15]];if(Ox6fe==OxOf688[0x31]){ element[OxOf688[0x17]][OxOf688[0x28]]=OxOf688[0x31] ;} else {var Ox6ff=Ox6fe?OxOf688[0x32]+Ox6fe:Ox6fe;var Ox6b=OxOf688[0x33];var Ox83=sel_style[OxOf688[0x15]]||OxOf688[0x34];var Ox700=sel_border[OxOf688[0x15]]; element[OxOf688[0x17]][OxOf688[0x28]]=OxOf688[0x31] ;if(Ox700||Ox83){ SetStyle(element[OxOf688[0x17]],OxOf688[0x28]+Ox6ff,Ox700+OxOf688[0x35]+Ox83+OxOf688[0x35]+Ox6b) ;} else { SetStyle(element[OxOf688[0x17]],OxOf688[0x28]+Ox6ff,OxOf688[0x34]) ;} ; SetStyle(element[OxOf688[0x17]],OxOf688[0x28]+Ox6ff,Ox700+OxOf688[0x35]+Ox83+OxOf688[0x35]+Ox6b) ;} ;try{ element[OxOf688[0x17]][OxOf688[0x19]]=inp_color[OxOf688[0x15]]||OxOf688[0x34] ;} catch(x){ element[OxOf688[0x17]][OxOf688[0x19]]=OxOf688[0x34] ;} ;try{ element[OxOf688[0x17]][OxOf688[0x18]]=inp_shade[OxOf688[0x15]]||OxOf688[0x34] ;} catch(x){ element[OxOf688[0x17]][OxOf688[0x18]]=OxOf688[0x34] ;} ;try{ element[OxOf688[0x17]][OxOf688[0x16]]=bordercolor[OxOf688[0x15]]||OxOf688[0x34] ;} catch(x){ element[OxOf688[0x17]][OxOf688[0x16]]=OxOf688[0x34] ;} ; element[OxOf688[0x17]][OxOf688[0x36]]=inp_PaddingLeft[OxOf688[0x15]] ; element[OxOf688[0x17]][OxOf688[0x37]]=inp_PaddingRight[OxOf688[0x15]] ; element[OxOf688[0x17]][OxOf688[0x38]]=inp_PaddingTop[OxOf688[0x15]] ; element[OxOf688[0x17]][OxOf688[0x39]]=inp_PaddingBottom[OxOf688[0x15]] ; element[OxOf688[0x17]][OxOf688[0x3a]]=inp_MarginLeft[OxOf688[0x15]] ; element[OxOf688[0x17]][OxOf688[0x3b]]=inp_MarginRight[OxOf688[0x15]] ; element[OxOf688[0x17]][OxOf688[0x3c]]=inp_MarginTop[OxOf688[0x15]] ; element[OxOf688[0x17]][OxOf688[0x3d]]=inp_MarginBottom[OxOf688[0x15]] ; element[OxOf688[0x1b]]=inp_class[OxOf688[0x15]] ;var arr=[OxOf688[0x1c],OxOf688[0x1d]];for(var Oxd7=0x0;Oxd7<arr[OxOf688[0x1e]];Oxd7++){var n=arr[Oxd7];var e=document.getElementById(OxOf688[0x1f]+n);var Ox701=document.getElementById(OxOf688[0x20]+n+OxOf688[0x21]);if(ParseToString(e.value)){ element[OxOf688[0x17]][n]=ParseToString(e.value)+Ox701[OxOf688[0x15]] ;} else { element[OxOf688[0x17]][n]=OxOf688[0x34] ;} ;} ;var Ox535=/[^a-z\d]/i;if(Ox535.test(inp_id.value)){ alert(OxOf688[0x3e]) ;return ;} ; element[OxOf688[0x24]]=sel_align[OxOf688[0x15]] ; element[OxOf688[0x1a]]=inp_id[OxOf688[0x15]] ; element[OxOf688[0x17]][OxOf688[0x25]]=sel_float[OxOf688[0x15]] ; element[OxOf688[0x17]][OxOf688[0x26]]=sel_textalign[OxOf688[0x15]] ; element[OxOf688[0x27]]=inp_tooltip[OxOf688[0x15]] ;if(element[OxOf688[0x27]]==OxOf688[0x34]){ element.removeAttribute(OxOf688[0x27]) ;} ;if(element[OxOf688[0x1b]]==OxOf688[0x34]){ element.removeAttribute(OxOf688[0x1b]) ;} ;}  ; function IsDigit(){return ((event[OxOf688[0x3f]]>=0x30)&&(event[OxOf688[0x3f]]<=0x39));}  ;
</script>
