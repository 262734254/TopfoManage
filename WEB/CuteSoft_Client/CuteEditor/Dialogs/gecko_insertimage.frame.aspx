<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.FileBrowserPage" %>
<%
	string QUERY_STRING=Request.ServerVariables["QUERY_STRING"];
%>
<HTML>
	<HEAD>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href='gecko_style.css'>
		<script src=Gecko_dialog.js></script><script src=../_shared.js></script>
		<script src="filebrowserpage.js"></script>
		<script src="sorttable.js"></script>
		<script language="JavaScript">
		var OxOd6fc=["disabled","target","[[Disabled]]","[[SpecifyNewFolderName]]","","value","hiddenActionData","[[CopyMoveto]]","/","[[AreyouSureDelete]]","parentNode","text","isdir",".","[[SpecifyNewFileName]]","hiddenAction","rename","path","True","False",":","cancelBubble","backgroundColor","style","#eeeeee","tagName","INPUT","changedir","hiddenFile","url","TargetUrl","../colorpicker.aspx","returnValue","s_bordercolor"]; function CreateDir_click(){if(event){if(event[OxOd6fc[0x1]][OxOd6fc[0x0]]){ alert(OxOd6fc[0x2]) ;return false;} ;} ;var Ox2fb=window.prompt(OxOd6fc[0x3],OxOd6fc[0x4]);if(Ox2fb){ document.getElementById(OxOd6fc[0x6])[OxOd6fc[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function Move_click(){if(event){if(event[OxOd6fc[0x1]][OxOd6fc[0x0]]){ alert(OxOd6fc[0x2]) ;return false;} ;} ;var Ox2fb=window.prompt(OxOd6fc[0x7],OxOd6fc[0x8]);if(Ox2fb){ document.getElementById(OxOd6fc[0x6])[OxOd6fc[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function Copy_click(){if(event){if(event[OxOd6fc[0x1]][OxOd6fc[0x0]]){ alert(OxOd6fc[0x2]) ;return false;} ;} ;var Ox2fb=window.prompt(OxOd6fc[0x7],OxOd6fc[0x8]);if(Ox2fb){ document.getElementById(OxOd6fc[0x6])[OxOd6fc[0x5]]=Ox2fb ;return true;} else {return false;} ;}  ; function Delete_click(){if(event[OxOd6fc[0x1]][OxOd6fc[0x0]]){ alert(OxOd6fc[0x2]) ;return false;} ;var Ox5a1=confirm(OxOd6fc[0x9]);if(Ox5a1){ ResetFields() ;return true;} else {return false;} ;}  ; function EditImg_click(Oxb9){if(Oxb9[OxOd6fc[0x0]]){ alert(OxOd6fc[0x2]) ;return false;} ; row=Oxb9[OxOd6fc[0xa]][OxOd6fc[0xa]] ;var Ox550=row[OxOd6fc[0xb]];var name;if(row[OxOd6fc[0xc]]){ name=prompt(OxOd6fc[0x3],Ox550) ;} else {var i=Ox550.lastIndexOf(OxOd6fc[0xd]);var Ox551=Ox550.substr(i);var Ox20=Ox550.substr(0x0,Ox550.lastIndexOf(OxOd6fc[0xd])); name=prompt(OxOd6fc[0xe],Ox20) ;if(name){ name=name+Ox551 ;} ;} ;if(name&&name!=row[OxOd6fc[0xb]]){ document.getElementById(OxOd6fc[0xf])[OxOd6fc[0x5]]=OxOd6fc[0x10] ; document.getElementById(OxOd6fc[0x6])[OxOd6fc[0x5]]=(row[OxOd6fc[0xc]]?OxOd6fc[0x12]:OxOd6fc[0x13])+OxOd6fc[0x14]+row[OxOd6fc[0x11]]+OxOd6fc[0x14]+name ; postback() ;} ;if(event){ event[OxOd6fc[0x15]]=true ;} ;}  ; function row_over(Oxc3){ Oxc3[OxOd6fc[0x17]][OxOd6fc[0x16]]=OxOd6fc[0x18] ;}  ; function row_out(Oxc3){ Oxc3[OxOd6fc[0x17]][OxOd6fc[0x16]]=OxOd6fc[0x4] ;}  ; function row_click(Oxc3){if(Oxc3[OxOd6fc[0xc]]){if(event){if(event[OxOd6fc[0x1]]&&event[OxOd6fc[0x1]][OxOd6fc[0x19]]==OxOd6fc[0x1a]){return ;} ;} ; document.getElementById(OxOd6fc[0xf])[OxOd6fc[0x5]]=OxOd6fc[0x1b] ; document.getElementById(OxOd6fc[0x6])[OxOd6fc[0x5]]=Oxc3.getAttribute(OxOd6fc[0x11]) ; postback() ;} else {var Ox4f4=Oxc3.getAttribute(OxOd6fc[0x11]); document.getElementById(OxOd6fc[0x1c])[OxOd6fc[0x5]]=Ox4f4 ;var Oxba=Oxc3.getAttribute(OxOd6fc[0x1d]); document.getElementById(OxOd6fc[0x1e])[OxOd6fc[0x5]]=Oxba ; Actualsize(Oxba) ;} ;}  ; function postback(){ <%=Page.ClientScript.GetPostBackEventReference(hiddenAction,"")%> ;}  ; function SelectColor(){var Ox567=OxOd6fc[0x1f]; showModalDialog(Ox567,null,_colorpickerDialogFeature,function (Ox2dc,Ox18d){if(Ox18d[OxOd6fc[0x20]]){ bordercolor[OxOd6fc[0x5]]=Ox18d[OxOd6fc[0x20]].toUpperCase() ; document.getElementById(OxOd6fc[0x21])[OxOd6fc[0x17]][OxOd6fc[0x16]]=Ox18d[OxOd6fc[0x20]] ;} ;} ) ;}  ;
		</script>
		<style>
		.row { HEIGHT: 22px }
		.cb { VERTICAL-ALIGN: middle }
		.itemimg { VERTICAL-ALIGN: middle }
		.editimg { VERTICAL-ALIGN: middle }
		.cell1 { VERTICAL-ALIGN: middle }
		.cell2 { VERTICAL-ALIGN: middle }
		.cell3 { PADDING-RIGHT: 4px; VERTICAL-ALIGN: middle; TEXT-ALIGN: right }
		.cb { }
		</style>
	</HEAD>
	<body>
		<form runat="server" enctype="multipart/form-data" id="Form1">
			<!-- start hidden -->
			<script>
        var OxO2cd6=["onload","value","hiddenAlert","","hiddenAction","hiddenActionData"]; window[OxO2cd6[0x0]]=reset_hiddens ; function reset_hiddens(){if(document.getElementById(OxO2cd6[0x2])[OxO2cd6[0x1]]){ alert(document.getElementById(OxO2cd6[0x2]).value) ;} ; document.getElementById(OxO2cd6[0x2])[OxO2cd6[0x1]]=OxO2cd6[0x3] ; document.getElementById(OxO2cd6[0x4])[OxO2cd6[0x1]]=OxO2cd6[0x3] ; document.getElementById(OxO2cd6[0x5])[OxO2cd6[0x1]]=OxO2cd6[0x3] ;}  ;
			</script>
			<input type="hidden" runat="server" id="hiddenDirectory"> <input type="hidden" runat="server" id="hiddenFile">
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert"> <input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" onserverchange="hiddenAction_ServerChange">
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenActionData">
			<!-- end hidden -->
				<table border="0" cellspacing="2" cellpadding="0" width="100%" align="center">
				<tr>
					<td width="20">
						<asp:Image ID="Image1" Runat="server" ImageUrl="../images/openfolder.gif"></asp:Image>
					</td>
					<td width="240" class="normal">
						<asp:Label Runat="server" ID="FolderDescription"></asp:Label>
					</td>
					<td>
						<asp:ImageButton ID="CreateDir" Runat="server" AlternateText="[[Createdirectory]]" ImageUrl="../images/newfolder.gif"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" Visible="true"
							OnClick="CreateDir_Click" />
						<asp:ImageButton ID="Copy" Runat="server" AlternateText="[[Copyfiles]]" ImageUrl="../images/Copy.gif"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" Visible="true"
							OnClick="Copy_Click" />
						<asp:ImageButton ID="Move" Runat="server" AlternateText="[[Movefiles]]" ImageUrl="../images/move.gif"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" Visible="true"
							OnClick="Move_Click" /><IMG src="../images/Actualsize.gif" onclick="Actualsize();" Alt="[[ActualSize]]" class="dialogButton"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)"><IMG src="../images/resize.gif" id="img_AutoThumbnail" onclick="AutoThumbnail();" Alt="[[AutoThumbnail]]" class="dialogButton"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)"> 
					</td>
				</tr>
			</table>
			<table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
				<tr>
					<td valign="top" nowrap width="270">
						<div style="BORDER: 1.5pt inset;  VERTICAL-ALIGN: middle; OVERFLOW: auto; WIDTH: 100%; HEIGHT: 270px; Padding: 0 0 0 0; BACKGROUND-COLOR: white">
							<asp:Table ID="FoldersAndFiles" Runat="server" CellSpacing="1" CellPadding="1" Width="100%" CssClass="sortable">
								<asp:TableRow BackColor="#f0f0f0">
									<asp:TableHeaderCell Width="16px" >
						<asp:ImageButton ID="Delete" Runat="server" AlternateText="[[Deletefiles]]"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" ImageUrl="../images/s_cut.gif"
							Visible="true" OnClick="Delete_Click" />
									</asp:TableHeaderCell>
									<asp:TableHeaderCell Width="16px" >
						<asp:ImageButton ID="DoRefresh" Runat="server" AlternateText="[[Refresh]]" ImageUrl="../images/s_refresh.gif"
							onMouseOver="Check(this,1)" onMouseOut="Check(this,0)" Visible="true"
							OnClick="DoRefresh_Click" />
									</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="name_Cell" Width="136px" CssClass="filelistHeadCol" Font-Bold="False">[[Name]]</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="size_Cell" Width="72px" CssClass="filelistHeadCol" Font-Bold="False">[[Count]]/[[Size]]</asp:TableHeaderCell>
									<asp:TableHeaderCell ID="op_Cell"  Width="16px">&nbsp;</asp:TableHeaderCell>
								</asp:TableRow>
							</asp:Table>
						</div>
					</td>
					<td width="10">&nbsp;
					</td>
					<td width="10" nowrap>&nbsp;
					</td>
					<td valign="top">
						<div style="Height:260px; WIDTH: 330px; BORDER: 1.0pt inset; PADDING: 5px;VERTICAL-ALIGN: top; OVERFLOW: auto;BACKGROUND-COLOR: white; TEXT-ALIGN: center">
							<div id="divpreview" style="BACKGROUND-COLOR: white" style="width:100%">
								<img id="img_demo" src="../images/1x1.gif">
							</div>
						</div>
					</td>
				</tr>
			</table>
			<table border="0" cellspacing="2" cellpadding="0" width="98%" align="center">
				<tr>
					<td valign="top">
						<fieldset>
							<legend>
								[[Layout]]</legend>
							<table border="0" cellpadding="5" cellspacing="0"  width="220">
								<tr>
									<td>
										<table border="0" cellpadding="2" cellspacing="0" class="normal">
											<tr>
												<td width="100">[[Alignment]]:</td>
												<td>
													<select name="ImgAlign" style="WIDTH : 80px" ID="Align" onchange="do_preview()" onpropertychange="do_preview()"
														runat="server">
														<OPTION id="optNotSet" value="">[[Notset]]</OPTION>
														<OPTION id="optLeft" value="left">[[Left]]</OPTION>
														<OPTION id="optRight" value="right">[[Right]]</OPTION>
														<OPTION id="optTexttop" value="textTop">[[Texttop]]</OPTION>
														<OPTION id="optAbsMiddle" value="absMiddle">[[Absmiddle]]</OPTION>
														<OPTION id="optBaseline" value="baseline" selected>[[Baseline]]</OPTION>
														<OPTION id="optAbsBottom" value="absBottom">[[Absbottom]]</OPTION>
														<OPTION id="optBottom" value="bottom">[[Bottom]]</OPTION>
														<OPTION id="optMiddle" value="middle">[[Middle]]</OPTION>
														<OPTION id="optTop" value="top">[[Top]]</OPTION>
													</select>
												</td>
											</tr>
											<tr>
												<td nowrap>[[Bordersize]]:</td>
												<td>
													<INPUT type="text" SIZE="2" name="Border" onchange="do_preview()" onkeypress="return IsDigit(event);" style="WIDTH : 80px" ID="Border">
												</td>
											</tr>
											<tr>
												<td nowrap>[[Bordercolor]]:</td>
												<td>
													<input type="text" id="bordercolor" name="bordercolor" size="7" style="WIDTH:57px">	
													<img id="s_bordercolor" src="../images/colorpicker.gif" onclick="SelectColor();" align="absMiddle">
												</td>
											</tr>
											<tr>
												<td colspan="2">
													<table border="0" cellpadding="0" cellspacing="0" class="normal">
														<tr>
															<td width="100" nowrap>[[Width]]:</td>
															<td>
																<INPUT type="text" SIZE="2" onkeyup="checkConstrains('width');" onkeypress="return IsDigit(event);" style="WIDTH : 80px" id="inp_width">
															</td>
															<td rowspan="2" align="right" valign="middle"><img src="../images/locked.gif" id="imgLock" width="25" height="32" alt="Constrained Proportions" /></td>
														</tr>
														<tr>
															<td nowrap>[[Height]]:</td>
															<td>
																<INPUT type="text" SIZE="2" onkeyup="checkConstrains('height');" onkeypress="return IsDigit(event);" style="WIDTH : 80px" id="inp_height">
															</td>
														</tr>
														<tr>
															<td colspan="2">
																<input type="checkbox" id="constrain_prop" checked onclick="javascript:toggleConstrains();" />
																Constrain Proportions</td>
														</tr>
													</table>
												</td>
										</table>
									</td>
								</tr>
							</table>
						</fieldset>
						<fieldset><legend>[[Spacing]]</legend>
							<table border="0" cellpadding="5" cellspacing="0">
								<tr>
									<td>
										<table border="0" cellpadding="2" cellspacing="0" class="normal">
											<tr>
												<td valign="middle" width="100">[[Horizontal]]:</td>
												<td><INPUT type="text" SIZE="2" name="HSpace" value="" onchange="do_preview()" onkeypress="return IsDigit(event);" style="WIDTH:80px" id="HSpace">
												</td>
											</tr>
											<tr>
												<td valign="middle">[[Vertical]]:</td>
												<td><INPUT type="text" SIZE="2" name="VSpace" value="" onchange="do_preview()" onkeypress="return IsDigit(event);" style="WIDTH:80px" id="VSpace"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</fieldset>
					</td>
					<td width="10">
					</td>
					<td valign="top">
						<fieldset>
							<legend>
								[[Insert]]</legend>
							<table border="0" cellpadding="4" cellspacing="0">
								<tr>
									<td>
										<table border="0" cellpadding="1" cellspacing="0" class="normal">
											<tr>
												<td valign="middle">
													URL:</td>
												<td colspan="3">
													<input type="text" id="TargetUrl" onpropertychange="do_preview()" size="42" name="TargetUrl"
														runat="server"></td>
												<td></td>
											</tr>
											<tr>
												<td valign="middle">[[Alternate]]:</td>
												<td valign="middle"><input type="text" id="AlternateText" size="20" NAME="AlternateText"></td>
												<td valign="middle" nowrap>[[ID]]:</td>
												<td><input type="text" id="inp_id" size="14"></td>
												<td></td>
											</tr>
											<tr>
												<td valign="middle" nowrap>[[longDesc]]:</td>
												<td valign="middle" colspan="3"><input type="text" id="longDesc" size="42" NAME="longDesc"></td>
												<td><img src="../images/Accessibility.gif" align="absMiddle" hspace="5"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</fieldset>
						<fieldset id="fieldsetUpload">
							<legend>
								[[Upload]] (Max file size allowed
								<%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxImageSize * 1024)%>
								)</legend>
							<table border="0" cellspacing="2" cellpadding="0" width="100%" class="normal" align="center">
								<tr>
									<td valign="top" style="FONT-SIZE: 8pt; VERTICAL-ALIGN: middle; FONT-FAMILY: MS Sans Serif">
										<asp:Label ID="Label_PictureUpload" Runat="server"></asp:Label>
										<input id="InputFile" size="45" type="file" runat="server" style="HEIGHT:20px" name="InputFile">&nbsp; <br>
										<asp:Button ID="uploadButton" Text="[[Upload]]" Runat="server" OnClick="uploadButton_Click" />&nbsp;
									</td>
								</tr>
								<tr>
									<td height="5">
									</td>
								</tr>
								<tr>
									<td width=100%>
										<% if(secset.RestrictUploadedImageDimension) {%>
										<li>
											Max image dimension is
											<%= secset.MaxImageWidth%>
											x
											<%= secset.MaxImageHeight%>
											pixels.
										</li>
										<li>
											Auto resize uploaded images function is
											<%= secset.AutoResizeUploadedImages? "on":"off" %>
											.</li>
										<%}%>
										<li>
											<table cellpadding="0" cellspacing="0" border="0" style="display:inline">
												<tr>
													<td>
														<nobr>
															Max Upload folder size is : <%= CuteEditor.Impl.FileStorage.FormatSize(secset.MaxImageFolderSize * 1024)%>.
															Used: <%= CuteEditor.Impl.FileStorage.FormatSize(fs.GetDirectorySize(fs.VirtualRoot)) %>
														</nobr>
													</td>
													<td>
														<div style="background-color:green;height:3px;width:40;font-size:3px">
															<div style="background-color:red;height:3px;width:<%= GetUsedSpaceBarWidth() %>px;font-size:3px"></div>
														</div>
													</td>
												</tr>
											</table>											
										</li>
									</td>
								</tr>
							</table>
						</fieldset>
						<p align="center">
							<input class="inputbuttoninsert" type="button" value="[[Insert]]" onclick="do_insert()"
								id="Button1">&nbsp;&nbsp;&nbsp; <input class="inputbuttoncancel" type="button" value="[[Cancel]]" onclick="do_cancel()"
								id="Button2">
						</p>
					</td>
				</tr>
			</table>
		</form>
		<script runat="server">
	protected override void InitOfType()
	{
		fs.VirtualRoot=CuteEditor.EditorUtility.ProcessWebPath(Context,null,secset.ImageGalleryPath).TrimEnd('/')+"/";
	}
    protected override void GetFiles(ArrayList files)
    {
        foreach (string ext in secset.ImageFilters)
        {
            if (ext == null || ext.Length == 0) continue;

            files.AddRange(fs.GetFileItems(CurrentDirectory, secset.FileNamePrefix + "*" + ext));
        }
    }
    protected override bool AllowFileName(string filename)
    {
        filename = filename.ToLower();
        foreach (string ext in secset.ImageFilters)
        {
            if (ext == null || ext.Length == 0) continue;
            if(filename.EndsWith(ext.ToLower()))
                return true;
        }
        return false;
    }
    
    protected int GetUsedSpaceBarWidth()
    {
      int w = Convert.ToInt32(40*fs.GetDirectorySize(fs.VirtualRoot)/(secset.MaxImageFolderSize * 1024));
      if(w<1)
		w=1;
		
	  if(w>40)
		w=40;
		
      return w;      
    }
    
    protected override string CheckUploadData(ref byte[] data)
    {     
       if (fs.GetDirectorySize(fs.VirtualRoot) >= secset.MaxImageFolderSize * 1024)
           return "Image folder size exceeds the limit: "+ CuteEditor.Impl.FileStorage.FormatSize(secset.MaxImageFolderSize * 1024);
       
        System.Drawing.Image img;
        try
        {
            img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(data));
        }
        catch
        {
            return "Image is in the wrong format.";
        }

        //let base class to implement
        /*
        
        if (data.Length >= secset.MaxImageSize * 1024)
           return "Image size exceeds "+CuteEditor.Impl.FileStorage.FormatSize(secset.MaxImageSize * 1024)+" limit: "+ CuteEditor.Impl.FileStorage.FormatSize(data.Length);


        if(secset.RestrictUploadedImageDimension)
        {
			if(secset.AutoResizeUploadedImages)
			{
				return null;//let base class implement the secset.AutoResizeUploadedImages
			}
			else
			{
				if ((img.Width > secset.MaxImageWidth) || ((img.Height > secset.MaxImageHeight)))
					return String.Format("Image dimension ({0} x {1} pixels) exceeding limits.", img.Width, img.Height);
			}	
		}
		*/
		
        return null;
    }
		</script>
		<script src="addvars.js"></script>
		<script>			
			var OxOfdc4=["dialogArguments","img","editor","inp_width","inp_height","inp_id","VSpace","HSpace","Border","bordercolor","s_bordercolor","Align","AlternateText","longDesc","TargetUrl","img_demo","divpreview","frameloaded","className","cetempFlash","","src","src_cetemp","value","width","height","id","vspace","hspace","border"," ","style","backgroundColor","align","alt","file","../images/1x1.gif","0","?","\x26","borderColor",".aspx","display","img_AutoThumbnail","none","[[ValidID]]","[[ValidColor]]","[[SelectImagetoInsert]]","longdesc","=\x22","\x22","imgLock","constrain_prop","checked","../images/locked.gif","length","specified","nodeName","[[SelectImagetoThumbnail]]","[[_CuteEditorResource_]]","\x26p=","width=315,height=200,resizable=0,toolbars=0,menubar=0,status=0","returnValue","hiddenAction","refresh"];var obj=top[OxOfdc4[0x0]];var element;var editor;if(obj){ element=obj[OxOfdc4[0x1]] ; editor=obj[OxOfdc4[0x2]] ;} ;var inp_width=document.getElementById(OxOfdc4[0x3]);var inp_height=document.getElementById(OxOfdc4[0x4]);var inp_id=document.getElementById(OxOfdc4[0x5]);var VSpace=document.getElementById(OxOfdc4[0x6]);var HSpace=document.getElementById(OxOfdc4[0x7]);var Border=document.getElementById(OxOfdc4[0x8]);var bordercolor=document.getElementById(OxOfdc4[0x9]);var s_bordercolor=document.getElementById(OxOfdc4[0xa]);var Align=document.getElementById(OxOfdc4[0xb]);var AlternateText=document.getElementById(OxOfdc4[0xc]);var longDesc=document.getElementById(OxOfdc4[0xd]);var TargetUrl=document.getElementById(OxOfdc4[0xe]);var img_demo=document.getElementById(OxOfdc4[0xf]);var divpreview=document.getElementById(OxOfdc4[0x10]);if(!top[OxOfdc4[0x11]]){ top[OxOfdc4[0x11]]=true ;try{if(element[OxOfdc4[0x12]]!=OxOfdc4[0x13]){var src=OxOfdc4[0x14];if(element.getAttribute(OxOfdc4[0x15])){ src=element.getAttribute(OxOfdc4[0x15]) ;} ;if(element.getAttribute(OxOfdc4[0x16])){ src=element.getAttribute(OxOfdc4[0x16]) ;} ; TargetUrl[OxOfdc4[0x17]]=src ; inp_width[OxOfdc4[0x17]]=element[OxOfdc4[0x18]]||OxOfdc4[0x14] ; inp_height[OxOfdc4[0x17]]=element[OxOfdc4[0x19]]||OxOfdc4[0x14] ; inp_id[OxOfdc4[0x17]]=element[OxOfdc4[0x1a]]||OxOfdc4[0x14] ;if(element[OxOfdc4[0x1b]]<=0x0){ VSpace[OxOfdc4[0x17]]=OxOfdc4[0x14] ;} else { VSpace[OxOfdc4[0x17]]=element[OxOfdc4[0x1b]] ;} ;if(element[OxOfdc4[0x1c]]<=0x0){ HSpace[OxOfdc4[0x17]]=OxOfdc4[0x14] ;} else { HSpace[OxOfdc4[0x17]]=element[OxOfdc4[0x1c]] ;} ; Border[OxOfdc4[0x17]]=element[OxOfdc4[0x1d]]||OxOfdc4[0x14] ;var arr=revertColor(element[OxOfdc4[0x1f]].borderColor).split(OxOfdc4[0x1e]); bordercolor[OxOfdc4[0x17]]=arr[0x0] ; bordercolor[OxOfdc4[0x1f]][OxOfdc4[0x20]]=bordercolor[OxOfdc4[0x17]]||OxOfdc4[0x14] ; s_bordercolor[OxOfdc4[0x1f]][OxOfdc4[0x20]]=bordercolor[OxOfdc4[0x17]]||OxOfdc4[0x14] ; Align[OxOfdc4[0x17]]=element[OxOfdc4[0x21]]||OxOfdc4[0x14] ; AlternateText[OxOfdc4[0x17]]=element[OxOfdc4[0x22]]||OxOfdc4[0x14] ; longDesc[OxOfdc4[0x17]]=element[OxOfdc4[0xd]]||OxOfdc4[0x14] ;} ;} catch(e){} ;} ; function Actualsize(Ox5ac){var Ox20d=TargetUrl[OxOfdc4[0x17]]; img_demo[OxOfdc4[0x18]]=OxOfdc4[0x14] ; img_demo[OxOfdc4[0x19]]=OxOfdc4[0x14] ; inp_width[OxOfdc4[0x17]]=img_demo[OxOfdc4[0x18]] ; inp_height[OxOfdc4[0x17]]=img_demo[OxOfdc4[0x19]] ; do_preview(Ox20d) ;}  ; function ResetFields(){ TargetUrl[OxOfdc4[0x17]]=OxOfdc4[0x14] ; inp_width[OxOfdc4[0x17]]=OxOfdc4[0x14] ; inp_height[OxOfdc4[0x17]]=OxOfdc4[0x14] ; inp_id[OxOfdc4[0x17]]=OxOfdc4[0x14] ; VSpace[OxOfdc4[0x17]]=OxOfdc4[0x14] ; HSpace[OxOfdc4[0x17]]=OxOfdc4[0x14] ; Border[OxOfdc4[0x17]]=OxOfdc4[0x14] ; bordercolor[OxOfdc4[0x17]]=OxOfdc4[0x14] ; bordercolor[OxOfdc4[0x1f]][OxOfdc4[0x20]]=OxOfdc4[0x14] ; Align[OxOfdc4[0x17]]=OxOfdc4[0x14] ; AlternateText[OxOfdc4[0x17]]=OxOfdc4[0x14] ; longDesc[OxOfdc4[0x17]]=OxOfdc4[0x14] ;}  ;var sCheckFlag=OxOfdc4[0x23]; do_preview() ; function do_preview(Ox5ac){var Ox20d;if(Ox5ac){ Ox20d=Ox5ac ;} else { Ox20d=document.getElementById(OxOfdc4[0xe])[OxOfdc4[0x17]] ;} ;var Ox5af=Ox20d;if(Ox20d==OxOfdc4[0x14]){return ;} ;var Oxb9= new Image(); Oxb9[OxOfdc4[0x15]]=Ox20d ;if(Oxb9[OxOfdc4[0x18]]){var Ox5b0= new Date();var Ox4f8=Ox5b0.getTime();if(Ox5af==OxOfdc4[0x14]){ Ox5af=OxOfdc4[0x24] ;} ;if(inp_width[OxOfdc4[0x17]]==OxOfdc4[0x25]||inp_width[OxOfdc4[0x17]]==OxOfdc4[0x14]){ inp_width[OxOfdc4[0x17]]=Oxb9[OxOfdc4[0x18]] ; inp_height[OxOfdc4[0x17]]=Oxb9[OxOfdc4[0x19]] ;} ;if(Ox5af.indexOf(OxOfdc4[0x26])!=-0x1){ Ox5af=Ox5af+OxOfdc4[0x27]+Ox4f8 ;} else { Ox5af=Ox5af+OxOfdc4[0x26]+Ox4f8 ;} ; img_demo[OxOfdc4[0x15]]=Ox5af ; img_demo[OxOfdc4[0x22]]=AlternateText[OxOfdc4[0x17]] ; img_demo[OxOfdc4[0x21]]=Align[OxOfdc4[0x17]] ; img_demo[OxOfdc4[0x18]]=inp_width[OxOfdc4[0x17]] ; img_demo[OxOfdc4[0x19]]=inp_height[OxOfdc4[0x17]] ; img_demo[OxOfdc4[0x1b]]=VSpace[OxOfdc4[0x17]] ; img_demo[OxOfdc4[0x1c]]=HSpace[OxOfdc4[0x17]] ;if(parseInt(Border.value)>0x0){ img_demo[OxOfdc4[0x1d]]=Border[OxOfdc4[0x17]] ;} ;if(bordercolor[OxOfdc4[0x17]]!=OxOfdc4[0x14]){ img_demo[OxOfdc4[0x1f]][OxOfdc4[0x28]]=bordercolor[OxOfdc4[0x17]] ;} ;} ; Ox20d=Ox20d.toLowerCase() ;if(Ox20d.indexOf(OxOfdc4[0x29])!=-0x1){ document.getElementById(OxOfdc4[0x2b])[OxOfdc4[0x1f]][OxOfdc4[0x2a]]=OxOfdc4[0x2c] ;} ;}  ; function do_insert(){if(element){var Oxb9=element;} else {var Oxb9= new Image();} ; Oxb9[OxOfdc4[0x15]]=TargetUrl[OxOfdc4[0x17]] ;try{ Oxb9.setAttribute(OxOfdc4[0x16],TargetUrl.value) ;} catch(e){} ; Oxb9[OxOfdc4[0x18]]=inp_width[OxOfdc4[0x17]] ; Oxb9[OxOfdc4[0x19]]=inp_height[OxOfdc4[0x17]] ;if(Oxb9[OxOfdc4[0x1f]][OxOfdc4[0x18]]||Oxb9[OxOfdc4[0x1f]][OxOfdc4[0x19]]){ Oxb9[OxOfdc4[0x1f]][OxOfdc4[0x18]]=inp_width[OxOfdc4[0x17]] ; Oxb9[OxOfdc4[0x1f]][OxOfdc4[0x19]]=inp_height[OxOfdc4[0x17]] ;} ; Oxb9[OxOfdc4[0x1b]]=VSpace[OxOfdc4[0x17]] ; Oxb9[OxOfdc4[0x1c]]=HSpace[OxOfdc4[0x17]] ; Oxb9[OxOfdc4[0x1d]]=Border[OxOfdc4[0x17]] ;var Ox535=/[^a-z\d]/i;if(Ox535.test(inp_id.value)){ alert(OxOfdc4[0x2d]) ;return ;} ; Oxb9[OxOfdc4[0x1a]]=inp_id[OxOfdc4[0x17]] ;try{ Oxb9[OxOfdc4[0x1f]][OxOfdc4[0x28]]=bordercolor[OxOfdc4[0x17]] ;} catch(er){ alert(OxOfdc4[0x2e]) ;return false;} ; Oxb9[OxOfdc4[0x21]]=Align[OxOfdc4[0x17]] ; Oxb9[OxOfdc4[0x22]]=AlternateText[OxOfdc4[0x17]] ; Oxb9[OxOfdc4[0xd]]=longDesc[OxOfdc4[0x17]] ;if(TargetUrl[OxOfdc4[0x17]]==OxOfdc4[0x14]){ alert(OxOfdc4[0x2f]) ;return false;} ;if(Oxb9[OxOfdc4[0x18]]==0x0){ Oxb9.removeAttribute(OxOfdc4[0x18]) ;} ;if(Oxb9[OxOfdc4[0x19]]==0x0){ Oxb9.removeAttribute(OxOfdc4[0x19]) ;} ;if(Oxb9[OxOfdc4[0xd]]==OxOfdc4[0x14]){ Oxb9.removeAttribute(OxOfdc4[0xd]) ;} ;if(Oxb9[OxOfdc4[0x30]]==OxOfdc4[0x14]||Oxb9[OxOfdc4[0x30]]==null){ Oxb9.removeAttribute(OxOfdc4[0x30]) ;} ;if(Oxb9[OxOfdc4[0x1c]]==OxOfdc4[0x14]){ Oxb9.removeAttribute(OxOfdc4[0x1c]) ;} ;if(Oxb9[OxOfdc4[0x1b]]==OxOfdc4[0x14]){ Oxb9.removeAttribute(OxOfdc4[0x1b]) ;} ;if(Oxb9[OxOfdc4[0x1a]]==OxOfdc4[0x14]){ Oxb9.removeAttribute(OxOfdc4[0x1a]) ;} ;if(Oxb9[OxOfdc4[0x1d]]==OxOfdc4[0x14]){ Oxb9.removeAttribute(OxOfdc4[0x1d]) ;} ;if(Oxb9[OxOfdc4[0x21]]==OxOfdc4[0x14]){ Oxb9.removeAttribute(OxOfdc4[0x21]) ;} ; editor.InsertElement(Oxb9,element) ; top.close() ;}  ; function attr(name,Ox223){if(!Ox223||Ox223==OxOfdc4[0x14]){return OxOfdc4[0x14];} ;return OxOfdc4[0x1e]+name+OxOfdc4[0x31]+Ox223+OxOfdc4[0x32];}  ; function do_cancel(){ top.close() ;}  ; function toggleConstrains(){var Ox5b2=document.getElementById(OxOfdc4[0x33]);var Ox5b3=document.getElementById(OxOfdc4[0x34]);if(Ox5b3[OxOfdc4[0x35]]){ Ox5b2[OxOfdc4[0x15]]=OxOfdc4[0x36] ; checkConstrains(OxOfdc4[0x18]) ;} else { Ox5b2[OxOfdc4[0x15]]=OxOfdc4[0x24] ;} ;}  ;var checkingConstrains=false; function checkConstrains(Ox197){if(checkingConstrains){return ;} ; checkingConstrains=true ;try{var Ox5b3=document.getElementById(OxOfdc4[0x34]);if(Ox5b3[OxOfdc4[0x35]]){var Ox5b6= new Image(); Ox5b6[OxOfdc4[0x15]]=TargetUrl[OxOfdc4[0x17]] ; original_width=Ox5b6[OxOfdc4[0x18]] ; original_height=Ox5b6[OxOfdc4[0x19]] ;if(original_width>0x0&&original_height>0x0){ width=inp_width[OxOfdc4[0x17]] ; height=inp_height[OxOfdc4[0x17]] ;if(Ox197==OxOfdc4[0x18]){if(width[OxOfdc4[0x37]]==0x0||isNaN(width)){ inp_width[OxOfdc4[0x17]]=OxOfdc4[0x14] ; inp_height[OxOfdc4[0x17]]=OxOfdc4[0x14] ;return ;} else { height=parseInt(width*original_height/original_width) ; inp_height[OxOfdc4[0x17]]=height ;} ;} ;if(Ox197==OxOfdc4[0x19]){if(height[OxOfdc4[0x37]]==0x0||isNaN(height)){ inp_width[OxOfdc4[0x17]]=OxOfdc4[0x14] ; inp_height[OxOfdc4[0x17]]=OxOfdc4[0x14] ;return ;} else { width=parseInt(height*original_width/original_height) ; inp_width[OxOfdc4[0x17]]=width ;} ;} ;} ;} ; do_preview() ;} finally{ checkingConstrains=false ;} ;}  ; function GetAttribute(Ox2fc,Ox512){if(Ox2fc){var attr=Ox2fc.getAttributeNode(Ox512);if(attr&&attr[OxOfdc4[0x38]]){return Ox2fc[attr[OxOfdc4[0x39]]];} ;return OxOfdc4[0x14];} else {return OxOfdc4[0x14];} ;}  ; function AutoThumbnail(){if(document.getElementById(OxOfdc4[0xe])[OxOfdc4[0x17]]==OxOfdc4[0x14]){ alert(OxOfdc4[0x3a]) ;return false;} ;var src=document.getElementById(OxOfdc4[0xe])[OxOfdc4[0x17]];var Ox2f=OxOfdc4[0x3b]; showModalDialog('Thumbnail.aspx?<%= QUERY_STRING %>&f='+src+OxOfdc4[0x3c]+Ox2f+OxOfdc4[0x14],src,OxOfdc4[0x3d],function (Ox2dc,Ox18d){if(Ox18d[OxOfdc4[0x3e]]){var arr=Ox18d[OxOfdc4[0x3e]];if(arr){ document.getElementById(OxOfdc4[0xe])[OxOfdc4[0x17]]=arr ; Actualsize() ; document.getElementById(OxOfdc4[0x3f])[OxOfdc4[0x17]]=OxOfdc4[0x40] ; postback() ;} ;} ;} ) ;}  ;	
				

	</script>
	</body>
</HTML>
