var OxOcb9a=["FocusDocument","GetDocument","GetWindow","PostBack","SetActiveTab","UpdateToolbar","length","Command","className","CuteEditorButtonActive","CuteEditorButton","IsCommandActive","CuteEditorButtonDisabled","IsCommandDisabled","LogSavePoint","Edit","html","SearchSelectionElement","body","parentNode","tagName","ShowTagDialog","ResourceDir","/Dialogs/Tag.Aspx?settinghash=[[_setting_]]","\x26Tag=","TagType","tagType","\x26Tab=","","\x26","\x26[[GetDNNArg]]","InsertElement","AfterEnd","container","SurroundElement","Control","div","innerHTML","rangeCount","childNodes","nodeName","\x3C","attributes","nodeValue"," ","=\x22","\x22","\x3E","\x3C![CDATA[","]]\x3E",";","\x3C!--","--\x3E","nodeType"]; editor[OxOcb9a[0x0]]=function (){ editwin.focus() ;}  ; editor[OxOcb9a[0x1]]=function (){return editdoc;}  ; editor[OxOcb9a[0x2]]=function (){return editwin;}  ; editor[OxOcb9a[0x3]]=function (Ox193){return editor.ExecCommand(OxOcb9a[0x3],false,Ox193);}  ; editor[OxOcb9a[0x4]]=function (Ox318){ _set_ActiveTab(Ox318) ;}  ; editor[OxOcb9a[0x5]]=function (){var Ox194=cmd_active_imgs[OxOcb9a[0x6]];for(var i=0x0;i<Ox194;i++){var Oxb9=cmd_active_imgs[i];var Ox195=editor.QueryCommandActive(Oxb9.getAttribute(OxOcb9a[0x7]));if(Ox195){ Oxb9[OxOcb9a[0x8]]=OxOcb9a[0x9] ;} else { Oxb9[OxOcb9a[0x8]]=OxOcb9a[0xa] ;} ; Oxb9.setAttribute(OxOcb9a[0xb],Ox195) ;} ;var Ox194=cmd_enable_imgs[OxOcb9a[0x6]];for(var i=0x0;i<Ox194;i++){var Oxb9=cmd_enable_imgs[i];var Ox196=editor.QueryCommandEnable(Oxb9.getAttribute(OxOcb9a[0x7]));if(!Oxb9.getAttribute(OxOcb9a[0xb])){if(!Ox196){ Oxb9[OxOcb9a[0x8]]=OxOcb9a[0xc] ;} else { Oxb9[OxOcb9a[0x8]]=OxOcb9a[0xa] ;} ;} ; Oxb9.setAttribute(OxOcb9a[0xd],!Ox196) ;} ;}  ; editor[OxOcb9a[0xe]]=function (){if(_get_ActiveTab()!=OxOcb9a[0xf]){return ;} ;var Ox190=Log_GetSavePoint();var Ox191=Ox190?Ox190[OxOcb9a[0x10]]:null;var Ox192=GetSavePoint();if(Ox191!=Ox192[OxOcb9a[0x10]]){ Log_AddSavePoint(Ox192) ; editor.UpdateToolbar() ;} else { Log_SetSavePoint(Ox192) ;} ;}  ; editor[OxOcb9a[0x11]]=function (Ox130){var sel=editwin.getSelection();var r=sel.getRangeAt(0x0);var Ox2f=Range_GetParentElement(r);for(var e=Ox2f;e!=null&&e!=editdoc[OxOcb9a[0x12]];e=e[OxOcb9a[0x13]]){if(e[OxOcb9a[0x14]]==Ox130){return e;} ;} ;return null;}  ; editor[OxOcb9a[0x15]]=function (element,Ox18e,Ox197,Ox198){return showModalDialog(editor.getAttribute(OxOcb9a[0x16])+OxOcb9a[0x17]+OxOcb9a[0x18]+(element[OxOcb9a[0x1a]]||element[OxOcb9a[0x19]]||element[OxOcb9a[0x14]])+OxOcb9a[0x1b]+(Ox18e||OxOcb9a[0x1c])+OxOcb9a[0x1d]+(Ox198||OxOcb9a[0x1c])+OxOcb9a[0x1e],{element:element,editor:editor,window:editwin,document:editdoc,changed:Ox197},_tagDialogFeature);}  ; editor[OxOcb9a[0x1f]]=function (element,Ox199){if(Ox199==element){ Ox199=null ;} ;if(Ox199!=null){ Ox199.insertAdjacentElement(OxOcb9a[0x20],element) ;return ;} ;var Ox19a=OxOcb9a[0x21]+( new Date().getTime());var sel=editwin.getSelection();var r=sel.getRangeAt(0x0); r.deleteContents() ; sel.removeAllRanges() ; r.insertNode(element) ; r.collapse(true) ; sel.addRange(r) ; NotifySelectionChange() ;return true;}  ; editor[OxOcb9a[0x22]]=function (element){var sel=editwin.getSelection();var r=sel.getRangeAt(0x0);var Oxf0=Range_GetSelectionType(r);var Oxaf=OxOcb9a[0x1c];if(Oxf0!=OxOcb9a[0x23]){var Ox2cf=r.cloneContents();var div=editdoc.createElement(OxOcb9a[0x24]); div.appendChild(Ox2cf) ; Oxaf=div[OxOcb9a[0x25]] ; editor.InsertElement(element) ;try{ element[OxOcb9a[0x25]]=Oxaf ;} catch(x){} ;} else {for(var i=0x0;i<sel[OxOcb9a[0x26]];i++){var Ox175=sel.getRangeAt(i); element.appendChild(Ox175.cloneContents()) ;} ; editor.InsertElement(element) ;} ; editor.SelectElement(element) ;}  ; function getInnerHTML(Ox27e){var Ox1f=OxOcb9a[0x1c];for(var i=0x0;i<Ox27e[OxOcb9a[0x27]][OxOcb9a[0x6]];i++){ Ox1f+=getOuterHTML(Ox27e[OxOcb9a[0x27]].item(i)) ;} ;return Ox1f;}  ; function getOuterHTML(Ox27e){var Ox1f=OxOcb9a[0x1c];switch(Ox27e[OxOcb9a[0x35]]){case 0x1: Ox1f+=OxOcb9a[0x29]+Ox27e[OxOcb9a[0x28]] ;for(var i=0x0;i<Ox27e[OxOcb9a[0x2a]][OxOcb9a[0x6]];i++){if(Ox27e[OxOcb9a[0x2a]].item(i)[OxOcb9a[0x2b]]!=null){ Ox1f+=OxOcb9a[0x2c] ; Ox1f+=Ox27e[OxOcb9a[0x2a]].item(i)[OxOcb9a[0x28]] ; Ox1f+=OxOcb9a[0x2d] ; Ox1f+=Ox27e[OxOcb9a[0x2a]].item(i)[OxOcb9a[0x2b]] ; Ox1f+=OxOcb9a[0x2e] ;} ;} ;if(Ox27e[OxOcb9a[0x27]][OxOcb9a[0x6]]==0x0&&leafElems[Ox27e[OxOcb9a[0x28]]]){ Ox1f+=OxOcb9a[0x2f] ;} else { Ox1f+=OxOcb9a[0x2f] ; Ox1f+=getInnerHTML(Ox27e) ; Ox1f+=OxOcb9a[0x29]+Ox27e[OxOcb9a[0x28]]+OxOcb9a[0x2f] ;} ;break ;case 0x3: Ox1f+=Ox27e[OxOcb9a[0x2b]] ;break ;case 0x4: Ox1f+=OxOcb9a[0x30]+Ox27e[OxOcb9a[0x2b]]+OxOcb9a[0x31] ;break ;case 0x5: Ox1f+=OxOcb9a[0x1d]+Ox27e[OxOcb9a[0x28]]+OxOcb9a[0x32] ;break ;case 0x8: Ox1f+=OxOcb9a[0x33]+Ox27e[OxOcb9a[0x2b]]+OxOcb9a[0x34] ;break ;;;;;;} ;return Ox1f;}  ;