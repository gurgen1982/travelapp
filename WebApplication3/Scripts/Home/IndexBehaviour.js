var index = {
    started: false,
    onBegin: function () {
        index.started = true;
        $("#btnSumbit").attr("disabled", "disabled");
        index._toggle();
    },
    onComplete: function (data, x, r) {
        var $element = $("#ajaxMessage");
        if (data.responseJSON == 200) {
            $element.text(successMessage);
            $element.removeClass("text-danger");
            $element.addClass("text-success");
            $element.fadeIn(1000);
            $("#frmSendContactMail")[0].reset();
        }
        else {
            $element.text(failedMessage);
            $element.removeClass("text-success");
            $element.addClass("text-danger");
            $element.fadeIn(500);
        }
        index.started = false;
        $(".sending").hide();
        $("#btnSumbit").removeAttr("disabled");
    },
    onSubScribed: function (data) {
        var $element = $("#ajaxSubScriptionMessage");
        if (data.responseJSON == 200) {
            $element.text(subscriptionMessage);
            $element.removeClass("text-danger");
            $element.addClass("text-success");
            $element.fadeIn(1000);
            $("#frmSubscription")[0].reset();
        }
        else {
            $element.text(failedSubscriptionMessage);
            $element.removeClass("text-success");
            $element.addClass("text-danger");
            $element.fadeIn(500);
        }
    },
    _toggle: function () {
        if (index.started == true) {
            $(".sending").toggle(400, index._toggle);
        }
    }

}