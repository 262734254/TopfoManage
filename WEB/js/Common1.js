js = {
    $: function(Id) {
        return document.getElementById(Id);
    },
    $$: function(TagName) {
        return document.getElementsByTagName(TagName);
    },
    AnyRequest: function(Method, Url, Data, CollBack) {
        var xmlhttp;
        var IsSuccess = false;
        if (window.XMLHttpRequest) {
            xmlhttp = new window.XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            xmlhttp = new window.ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.open(Method, Url);
        xmlhttp.setRequestHeader("content-type", "application/x-www-form-urlencoded");
        xmlhttp.onreadystatechange = function() {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                if (CollBack != "") {
                    CollBack(xmlhttp.responseText);
                }
                IsSuccess = true;
            }
        }
        xmlhttp.send(Data);
        return IsSuccess;
    },
    IsEnter: function(ev) {
        ev = ev || window.event;
        var keyCode;
        if (window.event)
            keyCode = ev.keyCode;
        else
            keyCode = ev.which;
        if (keyCode == 13 || keyCode == 10)
            return true;
        return false;
    },
    Trim: function(Content) {
        var Trim = /\s*$|^\s*/g;
        return Content.replace(this.Trim, "");
    },
    CheckEmail: function(Email) {
        var RegEmail = /^([0-9]|[a-zA-Z])\w+@\w+\.\w+$/;
        return RegEmail.test((Email.replace(this.Trim, "")))
    },
    CheckFile: function(File, AllowFileExtens, FielSize) {
        var IsSusscee = true;
        if (File.value == "" || File.value == null) {
            alert("请选择文件!");
            IsSusscee = false;
        }
        else if (FileExtens == null || FileExtens == "") {
            var FileExtens = File.value.substring(File.value.indexOf(".") + 1, File.value.length);
            if (!(AllowFileExtens.indexOf(FileExtens) > -1)) {
                IsSusscee = false;
                alert("上传的文件类型不正确!(只允许上传" + AllowFileExtens + ")");
            }
        }
        return IsSusscee;
    },
    DelChecked: function(Id, Msg1, Msg2) {
        var Items = document.getElementsByTagName("input");
        var count = 0;
        if (Items.length > 0) {
            for (var i = 0; i < Items.length; i++) {
                var item = Items[i];
                if (item.type == "checkbox" && item.id.indexOf(Id) > -1) {
                    if (item.checked) {
                        count++;
                    }
                }
            }
        }
        if (count <= 0) {
            alert(Msg1);
            return false;
        }
        else if(Msg2!="")
        {
            if (!confirm(Msg2)) {
                return false;
            }
        }
        return true;
    },
    IsSelect: function(Id) {
        var Items = document.getElementsByTagName("input");
        var count = 0;
        if (Items.length > 0) {
            for (var i = 0; i < Items.length; i++) {
                var item = Items[i];
                if (item.type == "checkbox" && item.id.indexOf(Id) > -1) {
                    if (item.checked) {
                        count++;
                    }
                }
            }
        }
        if (count <= 0) {
            alert("请选需要删除的项!");
            return false;
        }
        else if (!confirm("确定要删除选中项!")) {
            return false;
        }
        return true;
    },
    IsSelect: function(IsTure,Id) {
        var Items = document.getElementsByTagName("input");
        if (Items.length > 0) {
            for (var i = 0; i < Items.length; i++) {
                var Item = Items[i];
                if (Item.type == "checkbox" && Item.id.indexOf(Id) > -1) {
                    Item.checked = IsTure;
                }
            }
        }
    }
};