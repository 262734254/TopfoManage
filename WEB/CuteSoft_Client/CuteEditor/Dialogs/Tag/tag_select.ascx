<%@ Control Inherits="CuteEditor.EditorUtilityCtrl" Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<style type=text/css>
	.codebutton
	{
		width:110px; 
	}
</style>

<fieldset><legend>[[Input]]</legend>
	<table class="normal">
		<tr>
			<td width="60">[[Name]]:</td>
			<td><input type="text" id="inp_name" style="width:100px"></td>
			<td>&nbsp;&nbsp;&nbsp;</td>
			<td nowrap>[[AccessKey]]:</td>
			<td>
				<input type="text" id="inp_access" size="1" maxlength=1>
			</td>
		</tr>
		<tr>
			<td>[[ID]]:</td>
			<td><input type="text" id="inp_id" style="width:100px"></td>
			<td>&nbsp;&nbsp;</td>			
			<td nowrap>
				[[TabIndex]]:
			</td>
			<td>
				<input type="text" id="inp_index" size="5" value="" maxlength=5 onkeypress="event.returnValue=IsDigit();">&nbsp;		
			</td>			
		</tr>
		<tr>
			<td>[[Size]]:</td>
			<td colspan=4><input type="text" id="inp_size" style="width:100px"></td>
		</td>
		<tr>
			<td>
			</td>
			<td colspan="4"><input type="checkbox" id="inp_Multiple"><label for="inp_Multiple">[[AllowMultipleSelections]]</label>
			</td>
		</tr>
		<tr>
			<td>
			</td>
			<td colspan="4"><input type="checkbox" id="inp_Disabled"><label for="inp_Disabled">[[Disabled]]</label>
			</td>
		</tr>
	</table>
	
	[[Items]]: <br>
	
	<table class="normal">
		<tr>
			<td>[[Text]]:
				<br>
				<input type="text" id="inp_item_text" style="width:130px">
			</td>
			<td>[[Value]]:
				<br>
				<input type="text" id="inp_item_value" style="width:130px">
			</td>
			<td rowspan="3" valign=top>
				<table>
					<tr>
						<td colspan=2><button class="codebutton" onclick="Insert();" id="btnInsertItem">[[Insert]]</button>
						</td>
					</tr>
					<tr>
						<td colspan=2><button class="codebutton" onclick="Update();" id="btnUpdateItem">[[Update]]</button>
						</td>
					</tr>
					<tr>
						<td colspan=2><button class="codebutton" onclick="Delete();" id="btnDeleteItem">[[Delete]]</button>
						</td>
					</tr>
					<tr>
						<td colspan=2><button class="codebutton" onclick="Move(1);" id="btnMoveUpItem">[[MoveUp]]</button>
						</td>
					</tr>
					<tr>
						<td colspan=2><button class="codebutton" onclick="Move(-1);" id="btnMoveDownItem">[[MoveDown]]</button>
						</td>
					</tr>				
				</table>						
			</td>
		</tr>
		<tr>
			<td><select size="6" id="list_options" style="width:130px" onchange="document.getElementById('list_options2').selectedIndex = this.selectedIndex;Select(this);FireUIChanged();"></select></td>
			<td><select size="6" id="list_options2" style="width:130px" onchange="document.getElementById('list_options').selectedIndex = this.selectedIndex;Select(this);FireUIChanged();"></select></td>
		</tr>
		<tr>
			<td>[[Color]]:&nbsp;<input size="7" type="text" id="inp_item_forecolor" oncolorpopup="this.selectedColor=value" style='behavior:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'	oncolorchange='inp_item_forecolor.value=this.selectedColor; inp_item_forecolor.style.backgroundColor=this.selectedColor'></td>
			<td>[[BackColor]]:&nbsp;<input size="7" type="text" id="inp_item_backcolor" oncolorpopup="this.selectedColor=value" style='behavior:url(../ColorPicker.htc.aspx?culture=[[_culture_]]&[[DNN_Arg]])'	oncolorchange='inp_item_backcolor.value=this.selectedColor; inp_item_backcolor.style.backgroundColor=this.selectedColor'></td>
		</tr>
	</table>
</fieldset>
<script>


var OxOe06a=["inp_name","inp_id","inp_size","inp_Multiple","inp_Disabled","list_options","list_options2","inp_item_text","inp_item_value","inp_item_forecolor","inp_item_backcolor","inp_access","inp_index","value","text","color","style","backgroundColor","selectedIndex","options","Please select an item first","length","OPTION","document","id","cssText","Name","name","size","disabled","checked","multiple","tabIndex","","accessKey"];var inp_name=document.getElementById(OxOe06a[0x0]);var inp_id=document.getElementById(OxOe06a[0x1]);var inp_size=document.getElementById(OxOe06a[0x2]);var inp_Multiple=document.getElementById(OxOe06a[0x3]);var inp_Disabled=document.getElementById(OxOe06a[0x4]);var list_options=document.getElementById(OxOe06a[0x5]);var list_options2=document.getElementById(OxOe06a[0x6]);var inp_item_text=document.getElementById(OxOe06a[0x7]);var inp_item_value=document.getElementById(OxOe06a[0x8]);var inp_item_forecolor=document.getElementById(OxOe06a[0x9]);var inp_item_backcolor=document.getElementById(OxOe06a[0xa]);var inp_access=document.getElementById(OxOe06a[0xb]);var inp_index=document.getElementById(OxOe06a[0xc]); function SetOption(Ox73){ Ox73[OxOe06a[0xe]]=inp_item_text[OxOe06a[0xd]] ; Ox73[OxOe06a[0xd]]=inp_item_value[OxOe06a[0xd]] ; Ox73[OxOe06a[0x10]][OxOe06a[0xf]]=inp_item_forecolor[OxOe06a[0xd]] ; Ox73[OxOe06a[0x10]][OxOe06a[0x11]]=inp_item_backcolor[OxOe06a[0xd]] ;}  ; function SetOption2(Ox73){ Ox73[OxOe06a[0xe]]=inp_item_value[OxOe06a[0xd]] ; Ox73[OxOe06a[0xd]]=inp_item_text[OxOe06a[0xd]] ; Ox73[OxOe06a[0x10]][OxOe06a[0xf]]=inp_item_forecolor[OxOe06a[0xd]] ; Ox73[OxOe06a[0x10]][OxOe06a[0x11]]=inp_item_backcolor[OxOe06a[0xd]] ;}  ; function Select(Ox73){var Ox379=Ox73[OxOe06a[0x12]]; list_options[OxOe06a[0x12]]=Ox379 ; list_options2[OxOe06a[0x12]]=Ox379 ; inp_item_text[OxOe06a[0xd]]=list_options2[OxOe06a[0xd]] ; inp_item_value[OxOe06a[0xd]]=list_options[OxOe06a[0xd]] ;}  ; function Insert(){var Ox73= new Option(); SetOption(Ox73) ; list_options[OxOe06a[0x13]].add(Ox73) ;var Ox733= new Option(); SetOption2(Ox733) ; list_options2[OxOe06a[0x13]].add(Ox733) ; FireUIChanged() ;}  ; function Update(){if(list_options[OxOe06a[0x12]]==-0x1){ alert(OxOe06a[0x14]) ;return ;} ;var Ox73=list_options.options(list_options.selectedIndex); SetOption(Ox73) ;var Ox733=list_options2.options(list_options2.selectedIndex); SetOption2(Ox733) ; FireUIChanged() ;}  ; function Move(Ox5b){var Ox379=list_options[OxOe06a[0x12]];if(Ox379<0x0){return ;} ;var Ox735=Ox379-Ox5b;if(Ox735<0x0){ Ox735=0x0 ;} ;if(Ox735>(list_options[OxOe06a[0x13]][OxOe06a[0x15]]-0x1)){ Ox735=list_options[OxOe06a[0x13]][OxOe06a[0x15]]-0x1 ;} ;if(Ox379==Ox735){return ;} ;var Ox73=list_options.options(list_options.selectedIndex);var Ox20=list_options2[OxOe06a[0xd]];var Ox9=list_options[OxOe06a[0xd]]; Delete() ; inp_item_text[OxOe06a[0xd]]=Ox20 ; inp_item_value[OxOe06a[0xd]]=Ox9 ;var Ox73= new Option(); SetOption(Ox73) ; list_options[OxOe06a[0x13]].add(Ox73,Ox735) ;var Ox733= new Option(); SetOption2(Ox733) ; list_options2[OxOe06a[0x13]].add(Ox733,Ox735) ; list_options[OxOe06a[0x12]]=Ox735 ; list_options2[OxOe06a[0x12]]=Ox735 ; FireUIChanged() ;}  ; function Delete(){if(list_options[OxOe06a[0x12]]==-0x1||list_options[OxOe06a[0x12]]==-0x1){ alert(OxOe06a[0x14]) ;return ;} ;var Ox737=list_options[OxOe06a[0x12]];var Ox73=list_options.options(list_options.selectedIndex); Ox73.removeNode(true) ; Ox73=list_options2.options(list_options2.selectedIndex) ; Ox73.removeNode(true) ;if(list_options[OxOe06a[0x13]][OxOe06a[0x15]]>Ox737){ list_options[OxOe06a[0x12]]=Ox737 ;} else {if(list_options[OxOe06a[0x13]][OxOe06a[0x15]]){ list_options[OxOe06a[0x12]]=list_options[OxOe06a[0x13]][OxOe06a[0x15]]-0x1 ;} ;} ; list_options.ondblclick() ;if(list_options2[OxOe06a[0x13]][OxOe06a[0x15]]>Ox737){ list_options2[OxOe06a[0x12]]=Ox737 ;} else {if(list_options2[OxOe06a[0x13]][OxOe06a[0x15]]){ list_options2[OxOe06a[0x12]]=list_options2[OxOe06a[0x13]][OxOe06a[0x15]]-0x1 ;} ;} ; FireUIChanged() ;}  ; function list_options.ondblclick(){if(list_options[OxOe06a[0x12]]==-0x1){return ;} ;var Ox73=list_options.options(list_options.selectedIndex); inp_item_text[OxOe06a[0xd]]=Ox73[OxOe06a[0xe]] ; inp_item_value[OxOe06a[0xd]]=Ox73[OxOe06a[0xd]] ; inp_item_forecolor[OxOe06a[0xd]]=inp_item_forecolor[OxOe06a[0x10]][OxOe06a[0x11]]=Ox73[OxOe06a[0x10]][OxOe06a[0xf]] ; inp_item_backcolor[OxOe06a[0xd]]=inp_item_backcolor[OxOe06a[0x10]][OxOe06a[0x11]]=Ox73[OxOe06a[0x10]][OxOe06a[0x11]] ;}  ; function CopySelect(Ox73a,Ox73b){ Ox73b[OxOe06a[0x13]][OxOe06a[0x15]]=0x0 ;for(var i=0x0;i<Ox73a[OxOe06a[0x13]][OxOe06a[0x15]];i++){var Ox73c=Ox73a.options(i);var Ox733=Ox73b[OxOe06a[0x17]].createElement(OxOe06a[0x16]);if(Ox73b[OxOe06a[0x18]]!=OxOe06a[0x6]){ Ox733[OxOe06a[0xd]]=Ox73c[OxOe06a[0xd]] ; Ox733[OxOe06a[0xe]]=Ox73c[OxOe06a[0xe]] ;} else { Ox733[OxOe06a[0xd]]=Ox73c[OxOe06a[0xe]] ; Ox733[OxOe06a[0xe]]=Ox73c[OxOe06a[0xd]] ;} ; Ox733[OxOe06a[0x10]][OxOe06a[0x19]]=Ox73c[OxOe06a[0x10]][OxOe06a[0x19]] ; Ox73b[OxOe06a[0x13]].add(Ox733) ;} ; Ox73b[OxOe06a[0x12]]=Ox73a[OxOe06a[0x12]] ;}  ; function UpdateState(){}  ; function SyncToView(){if(element[OxOe06a[0x1a]]){ inp_name[OxOe06a[0xd]]=element[OxOe06a[0x1a]] ;} ;if(element[OxOe06a[0x1b]]){ inp_name[OxOe06a[0xd]]=element[OxOe06a[0x1b]] ;} ; inp_id[OxOe06a[0xd]]=element[OxOe06a[0x18]] ; inp_size[OxOe06a[0xd]]=element[OxOe06a[0x1c]] ; CopySelect(element,list_options) ; CopySelect(element,list_options2) ; inp_Disabled[OxOe06a[0x1e]]=element[OxOe06a[0x1d]] ; inp_Multiple[OxOe06a[0x1e]]=element[OxOe06a[0x1f]] ;if(element[OxOe06a[0x20]]==0x0){ inp_index[OxOe06a[0xd]]=OxOe06a[0x21] ;} else { inp_index[OxOe06a[0xd]]=element[OxOe06a[0x20]] ;} ;if(element[OxOe06a[0x22]]){ inp_access[OxOe06a[0xd]]=element[OxOe06a[0x22]] ;} ;}  ; function SyncTo(element){ element[OxOe06a[0x1b]]=inp_name[OxOe06a[0xd]] ;if(element[OxOe06a[0x1a]]){ element[OxOe06a[0x1a]]=inp_name[OxOe06a[0xd]] ;} else {if(element[OxOe06a[0x1b]]){ element.removeAttribute(OxOe06a[0x1b],0x0) ; element[OxOe06a[0x1a]]=inp_name[OxOe06a[0xd]] ;} else { element[OxOe06a[0x1a]]=inp_name[OxOe06a[0xd]] ;} ;} ; element[OxOe06a[0x18]]=inp_id[OxOe06a[0xd]] ; element[OxOe06a[0x1c]]=inp_size[OxOe06a[0xd]] ; element[OxOe06a[0x1d]]=inp_Disabled[OxOe06a[0x1e]] ; element[OxOe06a[0x1f]]=inp_Multiple[OxOe06a[0x1e]] ; element[OxOe06a[0x22]]=inp_access[OxOe06a[0xd]] ; element[OxOe06a[0x20]]=inp_index[OxOe06a[0xd]] ;if(element[OxOe06a[0x20]]==OxOe06a[0x21]){ element.removeAttribute(OxOe06a[0x20]) ;} ;if(element[OxOe06a[0x22]]==OxOe06a[0x21]){ element.removeAttribute(OxOe06a[0x22]) ;} ; CopySelect(list_options,element) ;}  ;

</script>
