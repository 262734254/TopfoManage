<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<fieldset><legend>[[Attributes]]</legend>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[CssClass]]:</td>
			<td><input type="text" id="inp_class" style="width:80px"></td>			
			<td>&nbsp;</td>
			<td>[[Width]] :</td>
			<td><input type="text" id="inp_width" style="width:60px" onkeypress="event.returnValue=IsDigit();"></td>
			<td>&nbsp;</td>
			<td>Height :</td>
			<td><input type="text" id="inp_height" style="width:60px" onkeypress="event.returnValue=IsDigit();"></td>
		</tr>
			<td style='width:60px'>[[Alignment]]:</td>
			<td><select id="sel_align" style="width:80px">
					<option value="">[[NotSet]]</option>
					<option value="left">[[Left]]</option>
					<option value="center">[[Center]]</option>
					<option value="right">[[Right]]</option>
				</select>
			</td>
			<td>&nbsp;</td>
			<td>[[Text-Align]]:</td>
			<td><select id="sel_textalign">
					<option value="">[[NotSet]]</option>
					<option value="left">[[Left]]</option>
					<option value="center">[[Center]]</option>
					<option value="right">[[Right]]</option>
					<option value="justify">[[Justify]]</option>
				</select>
			</td>
			<td>&nbsp;</td>
			<td>
				[[Float]]:
			</td>
			<td><select id="sel_float">
					<option value="">[[NotSet]]</option>
					<option value="left">[[Left]]</option>
					<option value="right">[[Right]]</option>
				</select>
			</td>
		</tr>
			<td style='width:60px'>
				[[ForeColor]]</td>
			<td>
				<input type="text" id="inp_forecolor" name="inp_forecolor" size="7" style="WIDTH:57px">
				<img id="img_forecolor" src="../images/colorpicker.gif" align="absMiddle" style='BEHAVIOR:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
					oncolorchange="inp_forecolor.value=this.selectedColor; this.style.backgroundColor=inp_forecolor.style.backgroundColor=this.selectedColor; FireUIChanged()"></td>
			<td>&nbsp;</td>
			<td>[[BackColor]]</td>
			<td colspan=4>
				<input type="text" id="inp_backcolor" name="inp_backcolor" size="7" style="WIDTH:57px">
				<img id="img_backcolor" src="../images/colorpicker.gif" align="absMiddle" style='BEHAVIOR:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'
					oncolorchange="inp_backcolor.value=this.selectedColor; this.style.backgroundColor=inp_backcolor.style.backgroundColor=this.selectedColor; FireUIChanged()"></td>
		</tr>
	</table>
	<table class="normal">
		<tr>
			<td style='width:60px'>[[title]]:</td>
			<td>
				<textarea id="inp_tooltip" rows="3" style="width:320px"></textarea>
			</td>
		</tr>
	</table>
</fieldset>

<script>

var OxObba5=["className","value","width","style","height","align","styleFloat","textAlign","title","color","backgroundColor",""]; function UpdateState(){}  ; function SyncToView(){ inp_class[OxObba5[0x1]]=element[OxObba5[0x0]] ; inp_width[OxObba5[0x1]]=element[OxObba5[0x3]][OxObba5[0x2]] ; inp_height[OxObba5[0x1]]=element[OxObba5[0x3]][OxObba5[0x4]] ; sel_align[OxObba5[0x1]]=element[OxObba5[0x5]] ; sel_float[OxObba5[0x1]]=element[OxObba5[0x3]][OxObba5[0x6]] ; sel_textalign[OxObba5[0x1]]=element[OxObba5[0x3]][OxObba5[0x7]] ; inp_tooltip[OxObba5[0x1]]=element[OxObba5[0x8]] ; inp_forecolor[OxObba5[0x1]]=element[OxObba5[0x3]][OxObba5[0x9]] ; inp_forecolor[OxObba5[0x3]][OxObba5[0xa]]=inp_forecolor[OxObba5[0x1]] ; img_forecolor[OxObba5[0x3]][OxObba5[0xa]]=inp_forecolor[OxObba5[0x1]] ; inp_backcolor[OxObba5[0x1]]=element[OxObba5[0x3]][OxObba5[0xa]] ; inp_backcolor[OxObba5[0x3]][OxObba5[0xa]]=inp_backcolor[OxObba5[0x1]] ; img_backcolor[OxObba5[0x3]][OxObba5[0xa]]=inp_backcolor[OxObba5[0x1]] ;}  ; function SyncTo(element){ element[OxObba5[0x0]]=inp_class[OxObba5[0x1]] ; element[OxObba5[0x3]][OxObba5[0x2]]=inp_width[OxObba5[0x1]] ; element[OxObba5[0x3]][OxObba5[0x4]]=inp_height[OxObba5[0x1]] ; element[OxObba5[0x5]]=sel_align[OxObba5[0x1]] ; element[OxObba5[0x3]][OxObba5[0x6]]=sel_float[OxObba5[0x1]] ; element[OxObba5[0x3]][OxObba5[0x7]]=sel_textalign[OxObba5[0x1]] ; element[OxObba5[0x8]]=inp_tooltip[OxObba5[0x1]] ; element[OxObba5[0x3]][OxObba5[0x9]]=inp_forecolor[OxObba5[0x1]] ; element[OxObba5[0x3]][OxObba5[0xa]]=inp_backcolor[OxObba5[0x1]] ;if(element[OxObba5[0x0]]==OxObba5[0xb]){ element.removeAttribute(OxObba5[0x0]) ;} ;if(element[OxObba5[0x8]]==OxObba5[0xb]){ element.removeAttribute(OxObba5[0x8]) ;} ;if(element[OxObba5[0x5]]==OxObba5[0xb]){ element.removeAttribute(OxObba5[0x5]) ;} ;}  ;

</script>
