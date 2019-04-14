<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyInsert.aspx.cs" Inherits="Company_CompanyInsert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" href="../css/CRM.css" rel="stylesheet" />
    <title>无标题页</title>
    <style type="text/css"> 
.f_red{color:red}
.f_td{width:15%;background-color:#f7f7f7;
}
</style>

    <script type="text/javascript" language="javascript">

   function GetObj(key)
   {
      return document.getElementById(key);
   }
   
   function Trim(str)
   {
      var ergtrim="/^\s*|\s*$/g";
      return str.replace(ergtrim,"");
   }
   
   function Check()
   {
         var txtCompanyName=GetObj("txtCompanyName");//企业名片
         if(Trim(txtCompanyName.value)=="")
         {
            alert("请填写企业名称!");
            txtCompanyName.focus();
            return false;
         }
         
         var Industry=GetObj("Industry");//所属区域
         if(Industry.options[Industry.selectedIndex].value=="-1")
         {
              alert("请选择所在区域!");
              Industry.focus();
              return false;
         }
         
         var Range=GetObj("Range");  //所属行业
         if(Range.options[Range.selectedIndex].value=="-1")
         {
            alert("请选择所在行业!");
            Range.focus();
            return false;
         }
         
         var Provice=document.getElementById("Provice"); //身份
         if(Provice.options[Provice.selectedIndex].value=="0")
         {
             alert("省份不能为空!");
             Provice.focus();
             return false;
         }
         
         var City=document.getElementById("City"); //市区
         if(Provice.options[City.selectedIndex].value=="0")
         {
             alert("市区不能为空!");
             City.focus();
             return false;
         }
         
         var txtEmployees=GetObj("txtEmployees");//员工人数
         if(Trim(txtEmployees.value)=="")
         {
            alert("员工人数不能为空!");
            txtEmployess.focus();
            return false;
         }
         
         var Nature=document.getElementsByName("Nature");//企业性质
         var isSelect=false;
         for(var i=0; i<Nature.length; i++)
         {
             if(Nature[i].checked)
             {
                 isSelect=true;
                 break;
             }
         }
         if(!isSelect)
         {
             alert("请选择企业性质!");
             return false;
         }
        
         var txtEstablishMent=GetObj("txtEstablishMent");//成立日期
         var reg_txtEstablishMent=/^\d{4}$/g;
         if(Trim(txtEstablishMent.value)=="")
         {
            alert("成立日期必能为空!");
            txtEstblishMent.focus();
            return false;
         }
         if(!reg_txtEstablishMent.test(txtEstablishMent.value))
         {
            alert("日期格式错误!");
            txtEstablishMent.focus();
            return false;
         }
         
         var txtCapital=GetObj("txtCapital");//注册资金
         if(Trim(txtCapital.value)=="")
         {
             alert("注册资金不能为空!");
             txtCapital.focus();
             return false;
         }
         
         var txtServiceProce=GetObj("txtServiceProce");//主营介绍
         if(Trim(txtServiceProce.value)=="")
         {
            alert("请填写经营范围!");
            txtServiceProce.focus();
            return false;
         }
         if(txtServiceProce.value.length>400)
         {
             alert("内容过长!");
             txtServiceProce.focus();
             return false;
         }
         
         var txtIntroduction=GetObj("txtIntroduction");//企业简介
         if(Trim(txtIntroduction.value)=="")
         {
            alert("请填写企业简介!");
            txtIntroduction.focus();
            return false;
         }
         if(txtIntroduction.value.length>2000)
         {
            alert("内容过长!");
            txtIntroduction.focus();
            return false;
         }
         
         var txtLinkName=GetObj("txtLinkName");//联系人
         if(Trim(txtLinkName.value)=="")
         {
            alert("联系人不能为空!");
            txtLinkName.focus();
            return false;
         }     
         
         //座机电话
         var Reg_TelZoneCode=/^0[0-9]{2,3}$/g;
         var Reg_txtTelNumber=/^\d{7,8}$/g;
         
         var txtTelCountry=document.getElementById("txtTelCountry");
         var txtTelZoneCode=document.getElementById("txtTelZoneCode");
         var txtTelNumber=document.getElementById("txtTelNumber");
         if(Trim(txtTelZoneCode.value)=="")
         {
              alert("区号不能为空!");
              txtTelZoneCode.focus();
              return false;
         } 
        if(!Reg_TelZoneCode.test(txtTelZoneCode.value))
         {
              alert("区号格式不正确，请重新输入");
              txtTelZoneCode.focus();
              return false;
         }
         
         if(Trim(txtTelNumber.value)=="")
         {
              alert("电话号码不能为空!");
              txtTelNumber.focus();
              return false;
         }
         if(!Reg_txtTelNumber.test(txtTelNumber.value))
         {
              alert("电话格式不正确，请重新输入");
              txtTelNumber.focus();
              return false;
         }
         
         //移动电话
         var txtMoblie=document.getElementById("txtMoblie");
         if(Trim(txtMoblie.value)!="")
         {
             var Reg_txtMoblie=/^(130|131|132|133|134|135|136|137|138|139)\d{8}$/g
             if(!Reg_txtMoblie.test(txtEmail.value))
             {
                alert("电话格式错误,请重新输入!");
                Reg_txtMoblie.focus();
                return false;
             }
         }
         
         var txtEmail=GetObj("txtEmail");//电子邮箱
         var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
         if(!filtEmial.test(Trim(txtEmail.value)))
         {
            alert("电子邮件格式不正确，请重新输入");
            txtEmail.focus();
            return false;
         }
   }
   
    var xmlhttp;
    function send(arg,type)
    {
       CreateXMLHttpRequest();
       xmlhttp.onreadystatechange = function(){
          if (xmlhttp.readyState == 4)
          {
            if(xmlhttp.status == 200)
            {
                var data = eval("(" + xmlhttp.responseText +")");
                if(type=="Province")
                {
                  CreateProvice(data);   
                }
                else if(type=="City")
                {
                   CreateCity(data);
                }
            }
          }
       }
       xmlhttp.open("POST","CompanyInsert.aspx",true);
       xmlhttp.setRequestHeader("Content-Length",arg.lenght);
       xmlhttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded;"); 
       xmlhttp.send(arg);
       
    }
    function CreateXMLHttpRequest()
    {
        if (window.ActiveXObject)
        {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        else if (window.XMLHttpRequest)
        {
            xmlhttp = new XMLHttpRequest();
        }
    }
    
    function CreateProvice(data)
    {
       var Items=data.province;
       if(Items.length>0)
       {
          var Provice=document.getElementById("Provice");
          for(var i=0; i<Items.length; i++)
          {
              var tOption = document.createElement("option");
              tOption.value=Items[i].ProvinceID;
              tOption.text=Items[i].ProvinceName;
              Provice.add(tOption);   
          }
       }
    }
    
    function ProviceonChang()
    {
         var Provice=document.getElementById("Provice");
         var index=Provice.options[Provice.selectedIndex].value;
         document.getElementById("<%=txtProvince.ClientID %>").value=index;
         send("Type=City&ProvinceID="+index,"City");
    }
    
    function CreateCity(data)
    {
       var Provice=document.getElementById("City");
       Provice.options.length=(Provice.options.length+1)-Provice.options.length;
       var Items=data.city;
       if(Items.length>0)
       {
          for(var i=0; i<Items.length; i++)
          {
              var tOption = document.createElement("option");
              tOption.value=Items[i].CityID;
              tOption.text=Items[i].CityName;
              Provice.add(tOption);   
          }
       }
    }
    
    function CityOnChang()
    {
         var City=document.getElementById("City");
         var index=City.options[City.selectedIndex].value;
         document.getElementById("<%=txtCity.ClientID %>").value=index;
    }
   </script>

</head>
<body>
    <form id="form1" runat="server">
        <input id="txtProvince" runat="server" type="hidden" />
        <input id="txtCity" runat="server" type="hidden" />
        <div class="title" align="center">
            <h2>
                <p>
                    <span><b><a href="SelCompany.aspx">企业名片管理</a></b></span></p>
            </h2>
            <h2>
                <p>
                    <span><b>录入企业名片信息</b></span></p>
            </h2>
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
                    <span class="f_red">*</span>所属区域：</td>
                <td>
                    <asp:DropDownList ID="Industry" runat="server">
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
                    <asp:DropDownList ID="Range" runat="server">
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
                    <select onchange="ProviceonChang()" id="Provice">
                       <option value="0">请选省份</option>
                    </select>
                    <script language="javascript" type="text/javascript">
                       send("Type=Province","Province");
                    </script>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>市区：</td>
                <td>
                    <select id="City" onchange="CityOnChang()">
                      <option value="0">请选择市区</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>员工人数：</td>
                <td>
                    <input id="txtEmployees" runat="server" type="text" onkeyup="value=value.replace(/[^0-9]/g,'')" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td" style="height: 22px">
                    <span class="f_red">*</span>企业性质：</td>
                <td style="height: 22px">
                    <asp:RadioButtonList ID="Nature" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">国有</asp:ListItem>
                        <asp:ListItem Value="2">私营</asp:ListItem>
                        <asp:ListItem Value="3">集体</asp:ListItem>
                        <asp:ListItem Value="4">股份</asp:ListItem>
                    </asp:RadioButtonList>
                    <input type="text" runat="server" id="txtNature" style="border: 1px solid #FFFFFF" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td" style="height: 24px">
                    <span class="f_red">*</span>成立日期：</td>
                <td style="height: 24px">
                    <input type="text" runat="server" id="txtEstablishMent" onkeyup="value=value.replace(/[^0-9]/g,'')" />年
                    <span class="f_red">(例：2002)</span>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>注册资金：</td>
                <td>
                    <input type="text" runat="server" id="txtCapital" onkeyup="value=value.replace(/[^0-9]/g,'')" />万元
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red"></span>Logo：</td>
                <td width="618">
                    <asp:FileUpload ID="uploadPic" runat="server" Width="235px" />
                    &nbsp;<asp:Button ID="btnUpload2" runat="server" CssClass="btn" Text="上 传" OnClick="btnUpload2_Click" />
                    <asp:Label ID="LblMessage" runat="server" BackColor="White" BorderColor="White" ForeColor="#C00000"></asp:Label>
                    <br />
                    <span class="f_red">图片须为jpg或gif格式，大小不超过500K </span>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span> 主营介绍：</td>
                <td width="618">
                    <textarea runat="server" id="txtServiceProce" style="width: 390px; height: 141px"></textarea>
                    <span class="f_red">请填写200个字以内</span>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>企业简介：</td>
                <td>
                    <textarea runat="server" id="txtIntroduction" style="width: 387px; height: 145px"></textarea>
                    <span class="f_red">请填写1000个字以内</span>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td" style="height: 24px">
                    <span class="f_red">*</span>联系人：</td>
                <td style="height: 24px">
                    <input type="text" id="txtLinkName" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>联系电话：</td>
                <td>
                    <input id="txtTelCountry" readonly="readonly" runat="server" type="text" size='4' value="+86" />
                    <input id="txtTelZoneCode" onkeyup="value=value.replace(/[^0-9]/g,'')" runat="server"
                        type="text" size='7' />
                    <input id="txtTelNumber" onkeyup="value=value.replace(/[^0-9]/g,'')" runat="server"
                        type="text" size='18' />
                    <span id="spTel"></span>
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    手机号码：</td>
                <td>
                    <input id="txtMoblie" onkeyup="value=value.replace(/[^0-9]/g,'')" runat="server"
                        type="text" style="width: 150px; height: 19px" />
                </td>
            </tr>
            <tr>
                <td align="right" class="f_td">
                    <span class="f_red">*</span>电子邮箱：</td>
                <td>
                    <input type="text" id="txtEmail" runat="server" style="width: 224px; height: 21px" />
                    <span class="f_red">(示例:xxx@xx.com)</span>
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
                    <span class="f_red">(示例:http://www.topfo.com/)</span>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 24px">
                    <asp:Button runat="server" ID="BtnSvae" CssClass="btn" OnClientClick="return Check();"
                        Text="保存" OnClick="BtnSvae_Click" />
                    &nbsp;&nbsp;<input type="reset" class="btn" value="重置" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
