$(function () {
    //$(".search-box-btn").click(function () {
    //    var wdth = window.innerWidth > 600 ? 600 : window.innerWidth - 30;
    //    $(".search-box").text("");
    //    $(".search-box").show();
    //    $(".search-box").animate({ width: wdth }, 800);
    //    $(".search-box").focus();
    //    $(".search-box-btn").hide();
    //});
    //$(".search-box").blur(function () {
    //    $(".search-box").animate({ width: '50' }, 500, null, function () {
    //        $(".search-box-btn").show();
    //        $(".search-box").hide();
    //        $(".search-box").attr("width", 0);
    //    });
    //});

    window.onscroll = function () {
    
        if (window.scrollY > 50) {
            $(".navbar-default").addClass("top-attached");
            $(".navbar-default ul.navbar-nav li").css("padding", "10px");
        }
        else {
            $(".navbar-default").removeClass("top-attached");
            $(".navbar-default ul.navbar-nav li").css("padding", "30px");
        }
    };

    //var mut = new MutationObserver(function (mutations, mut) {
    //  mutations.forEach(function(mutation) {
    //        if (mutation.attributeName === 'class' && !$(mutation.target).hasClass("active")) {
    //            $(mutation.target).removeClass("overlay");
    //        }
    //        if (mutation.attributeName === 'class' && $(mutation.target).hasClass("active") && !$(mutation.target).hasClass("overlay")) {
    //            $(mutation.target).addClass("overlay");
    //        }
            
    //    });
        
    //    // if attribute changed === 'class' && 'open' has been added, add css to 'otherDiv'
    //    //    $("div.carousel-inner .active").addClass("overlay");
    //});

    //mut.observe(document.querySelector(".main-carousel-slide-container"), {
    //    'attributes': true
    //});
});

var reloadPage = function (data) {
    window.location = data.responseJSON;
//    window.location.reload();
};