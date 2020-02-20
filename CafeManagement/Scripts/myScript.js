$(document).ready(function () {
    $("#save").attr("disabled", true);
    var $inputs = $("#form :input");
    $inputs.each(function () {       
        var id = "#" + $(this).attr("id"); //Lấy id của all input trong form
        if ($(id).hasClass("text-required"))
        {
            //Nếu input có class 'text-input' thì tự động tạo focusout theo Id
            $(id).focusout(function(){
                requiredValid(id); //Gọi hàm kiểm tra required
            });
        }
    });
});

function requiredValid(id) {
    //Lấy tên class theo Id
    var oldClass = $(id).attr("class");
    //Cắt giá trị đầu tên class (trước dấu -) => Vd: textbox-custom => Substring = textbox-
    //Sau đó ghép substring với 'valid' để sử dụng class valid => Vd: class mới = textbox-valid   
    if ($(id).val().length == 0) {
        var newClass = oldClass.substring(0, oldClass.indexOf("-") + 1).concat("valid text-required");
        $(id).popover({ content: "Bắt buộc nhập" });
        $(id).popover("enable");
        $(id).popover("show");        
    }
    else {
        var newClass = oldClass.substring(0, oldClass.indexOf("-") + 1).concat("correct text-required");
        $(id).popover("hide");
        $(id).popover("disable");      
    }
    $(id).removeClass(oldClass).addClass(newClass);
    // Nếu allow all validate sẽ mở nút save
    if ($(".textbox-correct").length == $(".text-required").length) {
        $("#save").attr("disabled", false);
    }
    else {
        $("#save").attr("disabled", true);
    }
}


function formatNumber(n) {
    return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
}





