<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MerchanStatic.aspx.cs" Inherits="State_MerchanStatic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
 <script type="text/javascript">
 
 
 function goto()
 {
 var diqu = document.getElementById("Are").value;

 if(diqu=="")
 {
 alert("请选择省");
 return false;
 }
 }
 
 function gotoInduy()
 {
 var diqu = document.getElementById("Are").value;

 if(diqu=="")
 {
 alert("请选择省");
 return false;
 }
 
  var XY = document.getElementById("Induy").value;

 if(XY=="")
 {
 alert("请选择行业");
 return false;
 }
 
 }
    function getValue(obj,str,num,type){
    var input=window.document.getElementById(obj);

input.value=str;
       

        if(type=="Induy")
        {
    	var Induy=window.document.getElementById(type);
    	Induy.value=num;
    	}

       if(type=="Are")
    	{
        var Are=window.document.getElementById(type);
    	Are.value=num;
    	}		
  }
  
   function showAndHide(obj,types,style,num){

  var Layer=window.document.getElementById(obj);
    switch(types){
  case "show":
    Layer.style.display="block";
  break;
  case "hide":
    Layer.style.display="none";
  break;
}
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>静态页面生成</title>
     <link type="text/css" href="../css/CRM.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
       
       <input id="Induy" type="hidden" name="Induy" runat="server" />
  <input id="Are" type="hidden" runat="server" name="Are"  />
     
  <div class="topfor-search-1"  style="height:1000px" >
    <div class="sch1"><input name="txt" type="text" id="txt" onfocus="showAndHide('List1','show','0','Induy');" onblur="showAndHide('List1','hide','0','Induy');" value="行业" />  </div>
    
    
  <div class="aMenu" id="List1" style="left:0px; top:33px;_left:7px;">
  <div class="aMenu1">
    <ul>
  
 <li onmousedown="getValue('txt','批发零售','#         ','Induy');showAndHide('List1','hide','#         ','Induy');"><a href="#"> 批发零售</a></li>
   <li onmousedown="getValue('txt','房地产业','$         ','Induy');showAndHide('List1','hide','$         ','Induy');"><a href="#">房地产业</a></li>
   <li onmousedown="getValue('txt','农林牧渔','A         ','Induy');showAndHide('List1','hide','A         ','Induy');"><a href="#">农林牧渔</a></li>
   <li onmousedown="getValue('txt','食品饮料','B         ','Induy');showAndHide('List1','hide','B         ','Induy');"><a href="#">食品饮料</a></li>
   <li onmousedown="getValue('txt','冶金矿产','C         ','Induy');showAndHide('List1','hide','C         ','Induy');"><a href="#">冶金矿产</a></li>
   <li onmousedown="getValue('txt','机械制造','D         ','Induy');showAndHide('List1','hide','D         ','Induy');"><a href="#">机械制造</a></li>
   <li onmousedown="getValue('txt','汽车汽配','E         ','Induy');showAndHide('List1','hide','E         ','Induy');"><a href="#">汽车汽配</a></li>   
   <li onmousedown="getValue('txt','能源动力','F         ','Induy');showAndHide('List1','hide','F         ','Induy');"><a href="#">能源动力</a></li>
   <li onmousedown="getValue('txt','石油化工','G         ','Induy');showAndHide('List1','hide','G         ','Induy');"><a href="#">石油化工</a></li>
   <li onmousedown="getValue('txt','纺织服装','H         ','Induy');showAndHide('List1','hide','H         ','Induy');"><a href="#">纺织服装</a></li>
   <li onmousedown="getValue('txt','环境保护','I         ','Induy');showAndHide('List1','hide','I         ','Induy');"><a href="#">环境保护</a></li>
   <li onmousedown="getValue('txt','医疗保健','J         ','Induy');showAndHide('List1','hide','J         ','Induy');"><a href="#">医疗保健</a></li>
   <li onmousedown="getValue('txt','生物科技','K         ','Induy');showAndHide('List1','hide','K         ','Induy');"><a href="#">生物科技</a></li>
   <li onmousedown="getValue('txt','教育培训','L         ','Induy');showAndHide('List1','hide','L         ','Induy');"><a href="#">教育培训</a></li>
   <li onmousedown="getValue('txt','印刷出版','M         ','Induy');showAndHide('List1','hide','M         ','Induy');"><a href="#">印刷出版</a></li>
   <li onmousedown="getValue('txt','广告传媒','N         ','Induy');showAndHide('List1','hide','N         ','Induy');"><a href="#">广告传媒</a></li>
   <li onmousedown="getValue('txt','影视娱乐','O         ','Induy');showAndHide('List1','hide','O         ','Induy');"><a href="#">影视娱乐</a></li>
   <li onmousedown="getValue('txt','电子通讯','P         ','Induy');showAndHide('List1','hide','P         ','Induy');"><a href="#">电子通讯</a></li>
   <li onmousedown="getValue('txt','建筑建材','Q         ','Induy');showAndHide('List1','hide','Q         ','Induy');"><a href="#">建筑建材</a></li>
   <li onmousedown="getValue('txt','信息产业','R         ','Induy');showAndHide('List1','hide','R         ','Induy');"><a href="#">信息产业</a></li>  
   <li onmousedown="getValue('txt','高新技术','S         ','Induy');showAndHide('List1','hide','S         ','Induy');"><a href="#">高新技术</a></li>
   <li onmousedown="getValue('txt','基础设施','T         ','Induy');showAndHide('List1','hide','T         ','Induy');"><a href="#">基础设施</a></li>  
   <li onmousedown="getValue('txt','交通运输','U         ','Induy');showAndHide('List1','hide','U         ','Induy');"><a href="#">交通运输</a></li>
   <li onmousedown="getValue('txt','物流仓储','V         ','Induy');showAndHide('List1','hide','V         ','Induy');"><a href="#">物流仓储</a></li>
   <li onmousedown="getValue('txt','金融投资','W         ','Induy');showAndHide('List1','hide','W         ','Induy');"><a href="#">金融投资</a></li>
   <li onmousedown="getValue('txt','旅游休闲','X         ','Induy');showAndHide('List1','hide','X         ','Induy');"><a href="#">旅游休闲</a></li>
   <li onmousedown="getValue('txt','社会服务','Y         ','Induy');showAndHide('List1','hide','Y         ','Induy');"><a href="#">社会服务</a></li>
   <li onmousedown="getValue('txt','酒店餐饮','Z         ','Induy');showAndHide('List1','hide','Z         ','Induy');"><a href="#">酒店餐饮</a></li>
   <li onmousedown="getValue('txt','其他行业','*         ','Induy');showAndHide('List1','hide','*         ','Induy');">  <a href="#">其他行业</a></li>

   <li onmousedown="getValue('txt','所有行业','MM','Induy');showAndHide('List1','hide','MM','Induy');"><a href="#">所有行业</a></li>

</ul>
  </div>
   </div>
    

    <div class="sch3"><input name="txt" type="text" id="txt2" onfocus="showAndHide('List3','show','','Are');" onblur="showAndHide('List3','hide','','Are');" value="区省"/>  </div>
        <div class="aMenu" id="List3" style="left:103px;_left:114px; top:33px; height:241px">
     <div class="aMenu1">
    <ul>     
   <li onmousedown="getValue('txt2','全国','','Are');showAndHide('List3','hide','','Are');"><a href="#">全国</a></li>   
  <li onmousedown="getValue('txt2','安徽','1002','Are');showAndHide('List3','hide','1002','Are');"><a href="#">安徽</a></li>
  <li onmousedown="getValue('txt2','北京','1098','Are');showAndHide('List3','hide','1098','Are');"><a href="#">北京</a></li>
  <li onmousedown="getValue('txt2','福建','1103','Are');showAndHide('List3','hide','1103','Are');"><a href="#">福建</a></li>
  <li onmousedown="getValue('txt2','甘肃','1181','Are');showAndHide('List3','hide','1181','Are');"><a href="#">甘肃</a></li>
  <li onmousedown="getValue('txt2','广西','1277','Are');showAndHide('List3','hide','1277','Are');"><a href="#">广西</a></li>
  <li onmousedown="getValue('txt2','贵州','1382','Are');showAndHide('List3','hide','1382','Are');"><a href="#">贵州</a></li>
  <li onmousedown="getValue('txt2','海南','1474','Are');showAndHide('List3','hide','1474','Are');"><a href="#">海南</a></li>
  <li onmousedown="getValue('txt2','河北','1511','Are');showAndHide('List3','hide','1511','Are');"><a href="#">河北</a></li>
  <li onmousedown="getValue('txt2','河南','1670','Are');showAndHide('List3','hide','1670','Are');"><a href="#">河南</a></li>
  <li onmousedown="getValue('txt2','黑龙江','1816','Are');showAndHide('List3','hide','1816','Are');"><a href="#">黑龙江</a></li> 
  <li onmousedown="getValue('txt2','山西','2728','Are');showAndHide('List3','hide','2728','Are');"><a href="#">山西</a></li>
  <li onmousedown="getValue('txt2','湖北','1908','Are');showAndHide('List3','hide','1908','Are');"><a href="#">湖北</a></li> 
  <li onmousedown="getValue('txt2','湖南','2002','Are');showAndHide('List3','hide','2002','Are');"><a href="#">湖南</a></li> 
  <li onmousedown="getValue('txt2','吉林','2218','Are');showAndHide('List3','hide','2218','Are');"><a href="#">吉林</a></li>
  <li onmousedown="getValue('txt2','江苏','2177','Are');showAndHide('List3','hide','2177','Are');"><a href="#">江苏</a></li>
  <li onmousedown="getValue('txt2','内蒙古','2434','Are');showAndHide('List3','hide','2434','Are');"><a href="#">内蒙古</a></li>
  <li onmousedown="getValue('txt2','宁夏','2536','Are');showAndHide('List3','hide','2536','Are');"><a href="#">宁夏</a></li>
  <li onmousedown="getValue('txt2','青海','2561','Are');showAndHide('List3','hide','2561','Are');"><a href="#">青海</a></li>
  <li onmousedown="getValue('txt2','上海','2610','Are');showAndHide('List3','hide','2610','Are');"><a href="#">上海</a></li>
  <li onmousedown="getValue('txt2','广东','2614','Are');showAndHide('List3','hide','2614','Are');"><a href="#">广东</a></li>
  <li onmousedown="getValue('txt2','山西','2728','Are');showAndHide('List3','hide','2728','Are');"><a href="#">山西</a></li>
  <li onmousedown="getValue('txt2','山东','2847','Are');showAndHide('List3','hide','2847','Are');"><a href="#">山东</a></li>
  <li onmousedown="getValue('txt2','陕西','2973','Are');showAndHide('List3','hide','2973','Are');"><a href="#">陕西</a></li>
  <li onmousedown="getValue('txt2','四川','3078','Are');showAndHide('List3','hide','3078','Are');"><a href="#">四川</a></li>
  <li onmousedown="getValue('txt2','天津','3256','Are');showAndHide('List3','hide','3256','Are');"><a href="#">天津</a></li>
  <li onmousedown="getValue('txt2','重庆','3262','Are');showAndHide('List3','hide','3262','Are');"><a href="#">重庆</a></li>
  <li onmousedown="getValue('txt2','西藏','3290','Are');showAndHide('List3','hide','3290','Are');"><a href="#">西藏</a></li>
  <li onmousedown="getValue('txt2','新疆','3371','Are');showAndHide('List3','hide','3371','Are');"><a href="#">新疆</a></li>
  <li onmousedown="getValue('txt2','浙江','3478','Are');showAndHide('List3','hide','3478','Are');"><a href="#">浙江</a></li>
  <li onmousedown="getValue('txt2','云南','3559','Are');showAndHide('List3','hide','3559','Are');"><a href="#">云南</a></li>
  <li onmousedown="getValue('txt2','江西','2258','Are');showAndHide('List3','hide','2258','Are');"><a href="#">江西</a></li>
  <li onmousedown="getValue('txt2','辽宁','2361','Are');showAndHide('List3','hide','2361','Are');"><a href="#">辽宁</a></li>
 </ul>
  </div>
   </div>
    <div >
     <asp:Button ID="btnZs" runat="server" Width="144px" Text="区域生成" OnClientClick="return goto();"  OnClick="btnZs_Click" />
     <asp:Button ID="btnZsInduy" runat="server" Width="144px" Text="区域加行业生成" OnClientClick="return gotoInduy();"  OnClick="btnZsInduy_Click" />
       <asp:Button ID="Button1" runat="server" Width="144px" Text="行业生成"  OnClick="Button1_Click"  />
    </div>
  </div>
</form>



    
</body>
</html>
