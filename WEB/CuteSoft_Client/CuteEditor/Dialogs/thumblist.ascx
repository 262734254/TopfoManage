<%@ Control Language="c#" Inherits="CuteEditor.Dialogs.ThumbList" %>

<script language="JavaScript">

var OxO9e72=["dialogArguments","editor","img","editdoc","^[a-z]*:[/][/][^/]*","","src","IMG","border","product","Gecko","src_cetemp","Edit","opener","\x3CIMG border=\x270\x27 align=\x27absmiddle\x27 src=\x27","\x27\x3E"]; function insert(src){if(src){if(top[OxO9e72[0x0]]){var obj=top[OxO9e72[0x0]];var editor=obj[OxO9e72[0x1]];var Oxb9=obj[OxO9e72[0x2]];var editdoc=obj[OxO9e72[0x3]];var Oxba=src.replace( new RegExp(OxO9e72[0x4],OxO9e72[0x5]),OxO9e72[0x5]);if(Oxb9){ Oxb9[OxO9e72[0x6]]=Oxba ;} else { Oxb9=editdoc.createElement(OxO9e72[0x7]) ; Oxb9[OxO9e72[0x6]]=Oxba ;try{var Ox5b6= new Image(); Ox5b6[OxO9e72[0x6]]=Oxba ; Oxb9[OxO9e72[0x8]]=0x0 ;} catch(e){} ;} ;if(navigator[OxO9e72[0x9]]==OxO9e72[0xa]){try{ Oxb9.setAttribute(OxO9e72[0xb],Oxba) ;} catch(e){} ;} else {if(editor.GetActiveTab()==OxO9e72[0xc]){ Oxb9.setAttribute(OxO9e72[0xb],Oxba) ;} ;} ; editor.InsertElement(Oxb9) ;} else {var editor=window[OxO9e72[0xd]][OxO9e72[0x0]]; src=src.replace( new RegExp(OxO9e72[0x4],OxO9e72[0x5]),OxO9e72[0x5]) ;var h=OxO9e72[0xe]+src+OxO9e72[0xf];try{ editor.PasteHTML(h) ;} catch(e){ alert(e) ;} ; window[OxO9e72[0xd]].focus() ;} ; top.close() ;} ;}  ;
</script>

<ASP:DataList id="MyList" RepeatDirection="Horizontal" width="100%" height="300" RepeatColumns="4" CellSpacing="0" runat="server" EnableViewState="true" OnItemDataBound="Item_DataBound">
	
	<ItemStyle horizontalalign="Center"></ItemStyle>
    <FooterStyle font-size="8pt" horizontalalign="Center"></FooterStyle>
   
    <ItemTemplate>
		<img border="0" src="<%# ThumbUrl((String)(DataBinder.Eval(Container.DataItem,"Path"))) %>" onMouseover='Check(this,1); showTooltip("<nobr><%# String_Name%>: <%# DataBinder.Eval(Container.DataItem, "Name")%></nobr><br><nobr><%# String_Size%>: <%# ( Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Length")) /1024).ToString("n0")%> KB</nobr><br><nobr><%# String_Createddate%>: <%# DataBinder.Eval(Container.DataItem, "CreationTime") %></nobr><br><nobr><%# String_Modifieddate%>: <%# DataBinder.Eval(Container.DataItem, "LastWriteTime")%></nobr>", this, event)' onMouseout="Check(this,0); delayhidetip()" onclick="insert('<%# DataBinder.Eval(Container.DataItem,"Url") %>')" style="BORDER: white 1px solid" align="center">
	</ItemTemplate>
   
    <FooterTemplate>
		<%# NumImagesDisplayed()%> <asp:PlaceHolder id="plLinks" runat="server"></asp:PlaceHolder>
	</FooterTemplate>
</ASP:DataList>

<input id="hdnCurPage" type="hidden" runat="server" />
<input id="hdnPrevPath" type="hidden" runat="server" />