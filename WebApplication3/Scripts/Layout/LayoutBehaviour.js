$(function () {
    $(".search-box-btn").click(function () {
        var wdth = window.innerWidth > 600 ? 600 : window.innerWidth - 30;
        $(".search-box").text("");
        $(".search-box").show();
        $(".search-box").animate({ width: wdth }, 800);
        $(".search-box").focus();
        $(".search-box-btn").hide();
    });
    $(".search-box").blur(function () {
        $(".search-box").animate({ width: '50' }, 500, null, function () {
            $(".search-box-btn").show();
            $(".search-box").hide();
            $(".search-box").attr("width", 0);
        });
    });
});

var reloadPage = function (data) {
    window.location = data.responseJSON;
//    window.location.reload();
};