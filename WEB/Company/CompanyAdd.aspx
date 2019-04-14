<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyAdd.aspx.cs" Inherits="Company_CompanyAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
    <title>无标题页</title>
    <style type="text/css"> 
.f_red{color:red}
.f_td{width:15%;background-color:#f7f7f7;
}
</style>
<script language="javascript" type="text/javascript">
function status()
{
var vRbtid=document.getElementById("rblAuditing");
      var vRbtidList= vRbtid.getElementsByTagName("input");
      for(var i = 0;i<vRbtidList.length;i++)
      {
        if(vRbtidList[i].checked)
        {
           var value=vRbtidList[i].value;
          if(value=="1")
          {
             document.getElementById("spanmake").style.display="block";
          }else
          {
             document.getElementById("spanmake").style.display="none";
          }
        }
      }
}

function Opinion()
{
   
}
function chkBtn()
	{
	if(document.getElementById("txtKeywords").value=="")
	   {
	       alert("请填写网页关键字");
	       document.getElementById("txtKeywords").focus();
	       return false;
	   }
	   if(document.getElementById("txtTitle").value=="")
	   {
	       alert("请填写网页标题");
	       document.getElementById("txtTitle").focus();
	       return false;
	   }
	    if(document.getElementById("txtDescription").value=="")
	   {
	       alert("请填写网页短标题");
	       document.getElementById("txtDescription").focus();
	       return false;
	   }
	                   document.getElementById("imgLoding").style.display="";

	   
}
</script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="title" align="center">
             <h2><p><span><b><a href="SelCompany.aspx">企业名片管理</a></b></span></p></h2>
             <h2><p><span><b>审核企业名片信息</b></span></p></h2>
             </div>
       <table width="100%" cellpadding="0" cellspacing="0" class="one_table">
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>企业名称：</td>
                    <td>
                        <input id="txtCompanyName" runat="server" type="text" style="width: 238px; height: 20px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>网页标题：</td>
                    <td>
                        <input id="txtTitle" runat="server" type="text" style="width: 238px; height: 20px" />
                        <span class="f_red">为了便于搜索引擎搜索,请简明扼要</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>网页关键字：</td>
                    <td>
                        <input id="txtKeywords" runat="server" type="text" style="width: 238px; height: 20px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red"></span>网页短标题：</td>
                    <td>
                        <input id="txtDescription" runat="server" type="text" style="width: 238px; height: 20px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>所属区域：</td>
                    <td>
                        <asp:DropDownList ID="ddlRangeID" runat="server">
                            <asp:ListItem Value="-1">请选择地区</asp:ListItem>
                            <asp:ListItem Value="0">不限</asp:ListItem>
                            <asp:ListItem Value="1">华东地区</asp:ListItem>
                            <asp:ListItem Value="2">华南地区</asp:ListItem>
                            <asp:ListItem Value="3">华中地区</asp:ListItem>
                            <asp:ListItem Value="4">华北地区</asp:ListItem>
                            <asp:ListItem Value="5">西北地区</asp:ListItem>
                            <asp:ListItem Value="6">西南地区</asp:ListItem>
                            <asp:ListItem Value="7">东北地区</asp:ListItem>
                            <asp:ListItem Value="8">台港澳地区</asp:ListItem>
                            <asp:ListItem Value="9">其它</asp:ListItem>
                        </asp:DropDownList>
                        <input type="text" runat="server" id="txtRange" style="border: 1px solid #FFFFFF" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>所属行业：</td>
                    <td>
                        <asp:DropDownList ID="ddlIndustryID" runat="server">
                            <asp:ListItem Value="-1">请选择行业</asp:ListItem>
                            <asp:ListItem Value="1">商务贸易</asp:ListItem>
                            <asp:ListItem Value="2">房产建筑</asp:ListItem>
                            <asp:ListItem Value="3">工业制造</asp:ListItem>
                            <asp:ListItem Value="4">电脑通讯</asp:ListItem>
                            <asp:ListItem Value="5">生活服务</asp:ListItem>
                            <asp:ListItem Value="6">医疗卫生</asp:ListItem>
                            <asp:ListItem Value="7">农林牧渔</asp:ListItem> 
                            
                            <asp:ListItem Value="8">批发零售</asp:ListItem>
                            <asp:ListItem Value="9">冶金矿产</asp:ListItem>
                            <asp:ListItem Value="10">机械制造</asp:ListItem>
                            <asp:ListItem Value="11">汽车汽配</asp:ListItem>
                            
                            <asp:ListItem Value="12">石油化工</asp:ListItem>
                            <asp:ListItem Value="13">纺织服装</asp:ListItem>
                            <asp:ListItem Value="14">环境保护</asp:ListItem>
                            
                            <asp:ListItem Value="15">食品饮料</asp:ListItem>
                            <asp:ListItem Value="16">能源动力</asp:ListItem>
                            <asp:ListItem Value="17">生物科技</asp:ListItem>
                            <asp:ListItem Value="18">教育培训</asp:ListItem>
                            <asp:ListItem Value="19">印刷出版</asp:ListItem>
                            
                            <asp:ListItem Value="20">高新技术</asp:ListItem>
                            <asp:ListItem Value="21">基础设施</asp:ListItem>
                            <asp:ListItem Value="22">交通运输</asp:ListItem>
                            <asp:ListItem Value="23">广告传媒</asp:ListItem>
                            <asp:ListItem Value="24">信息产业</asp:ListItem>
                            <asp:ListItem Value="25">物流仓储</asp:ListItem>
                            <asp:ListItem Value="26">金融投资</asp:ListItem>
                            
                            <asp:ListItem Value="27">旅游休闲</asp:ListItem>
                            <asp:ListItem Value="28">社会服务</asp:ListItem>
                            <asp:ListItem Value="0">其它行业</asp:ListItem>
                        </asp:DropDownList>
                        <input type="text" runat="server" id="txtIndustry" style="border: 1px solid #FFFFFF" />
                    </td>
                </tr>
                <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>省份：</td>
                <td>
                   <asp:DropDownList ID="DropProvice" AutoPostBack="true" runat="server" OnSelectedIndexChanged="onChang_Provice">
                   </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>市区：</td>
                <td>
                     <asp:DropDownList ID="DropCity" runat="server">
                     </asp:DropDownList>
                </td>
            </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red"></span>员工人数：</td>
                    <td>
                        <input id="txtEmployees" runat="server" type="text" onkeyup="value=value.replace(/[^0-9]/g,'')"
                            onblur="value=value.replace(/[^0-9]/g,'')" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>企业性质：</td>
                    <td>
                        <asp:RadioButtonList ID="rblNatureID" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="1">国有</asp:ListItem>
                            <asp:ListItem Value="2">私营</asp:ListItem>
                            <asp:ListItem Value="3">集体</asp:ListItem>
                            <asp:ListItem Value="4">股份</asp:ListItem>
                        </asp:RadioButtonList>
                        <input type="text" runat="server" id="txtNature" style="border: 1px solid #FFFFFF" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red"></span>成立日期：</td>
                    <td>
                        <input type="text" runat="server" id="txtEstablishMent" onkeyup="value=value.replace(/[^0-9]/g,'')"
                            onblur="value=value.replace(/[^0-9]/g,'')" />年 <span class="hong">(例：2002)</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red"></span>注册资金：</td>
                    <td>
                        <input type="text" runat="server" id="txtCapital" onkeyup="value=value.replace(/[^0-9]/g,'')"
                            onblur="value=value.replace(/[^0-9]/g,'')" />万元
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red"></span>Logo：</td>
                    <td width="618">
                        <asp:FileUpload ID="uploadPic" runat="server" Width="235px" />
                        &nbsp;<asp:Button ID="btnUpload2" runat="server" CssClass="btn"  Text="上 传" OnClick="btnUpload2_Click" />
                        <asp:Label ID="LblMessage" runat="server" BackColor="White" BorderColor="White"
                            ForeColor="#C00000"></asp:Label>
                        <br />
                        <asp:Image ID="Image1"  runat="server" Height="106px" Width="98px" ></asp:Image>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span> 主营介绍：</td>
                    <td width="618">
                        <textarea runat="server" id="txtServiceProce" style="width: 390px; height: 141px"></textarea>
                        <span class="hong">请填写200个字以内</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>企业简介：</td>
                    <td>
                        <textarea runat="server" id="txtIntroduction" style="width: 387px; height: 145px"></textarea>
                        <span class="hong">请填写1000个字以内</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>联系人：</td>
                    <td>
                        <input type="text" id="txtLinkName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>联系电话：</td>
                    <td>
                        <input id="txtTelCountry" runat="server" type="text" size='4' value="+86" />
                        <input id="txtTelZoneCode" runat="server" type="text" size='7' />
                        <input id="txtTelNumber" runat="server" type="text" size='18' />
                        <span id="spTel"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        手机号码：</td>
                    <td>
                        <input id="txtMoblie" runat="server" type="text" style="width: 150px; height: 19px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red">*</span>电子邮箱：</td>
                    <td>
                        <input type="text" id="txtEmail" runat="server" style="width: 224px; height: 21px" />
                        <span class="hong">(示例:xxx@xx.com)</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        详细地址：</td>
                    <td>
                        <input type="text" id="txtAddress" runat="server" style="width: 225px; height: 19px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        <span class="f_red"></span>单位网址：
                    </td>
                    <td>
                        <input type="text" id="txtURL" runat="server" value="http://" style="width: 225px;
                            height: 19px" />
                        <span class="hong">(示例:http://www.topfo.com/)</span>
                    </td>
                </tr>
                <tr>
                <td align="right" class="f_td">
                    审核：
                </td>
                <td>
                <asp:RadioButtonList id="rblAuditing" runat="server"  OnClick="status(1)"  RepeatDirection="Horizontal" RepeatLayout="Flow">
	            <asp:ListItem Value="0" >未审核</asp:ListItem>
	            <asp:ListItem Value="1">审核通过</asp:ListItem>
	            <asp:ListItem Value="2">审核未通过</asp:ListItem>
               </asp:RadioButtonList> 
                </td>
                </tr>
                <span runat="server" id="spanmake" >
                <tr>
                    <td align="right" class="f_td">
                        是否推荐：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblIsmake"  RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem  Value="0">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:RadioButtonList>
                    </td>
                </tr>
                </span>
                <tr>
                    <td colspan="2" class="f_td">
                        评论管理
                    </td>
                    
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        评论内容：
                    </td>
                    <td>
                        <textarea runat="server" id="txtComment"></textarea>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        评论人：
                    </td>
                    <td>
                        <span id="CommentName" runat="server" style="color:Red">cn001</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        评论时间：
                    </td>
                    <td>
                        <span id="CommentTime" runat="server" style="color:Red">2011-04-18 10:00:00</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="f_td">
                        是否可信：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbtCred"  RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem  Value="0">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button runat="server" ID="btnStatus" Text="审 核" CssClass="btn"  OnClientClick="return chkBtn();"  OnClick="btnStatus_Click"  />
                        &nbsp &nbsp
                        <input type="button" class="btn" value="返 回" onclick="window.location.href='SelCompany.aspx'" />
                    </td>
                </tr>
            </table>
            
         <div id="imgLoding" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 104%;
   height:1652px; filter: 
   alpha(opacity=60);"></div>

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
    </form>
</body>
</html>
