var index = {
    started: false,
    onBegin: function () {
        index.started = true;
        $("#btnSumbit").attr("disabled", "disabled");
        index._toggle();
    },
    onComplete: function (data, x, r) {
        //var $element = $("#ajaxMessage");
        if (data.responseJSON == 200) {
            //$element.text(successMessage);
            //$element.removeClass("text-danger");
            //$element.addClass("text-success");
            //$element.fadeIn(1000);
            index._showSnack(successMessage);
            $("#frmSendContactMail")[0].reset();
        }
        else {
            //$element.text(failedMessage);
            //$element.removeClass("text-success");
            //$element.addClass("text-danger");
            //$element.fadeIn(500);
            index._showSnack(failedMessage);
        }
        index.started = false;
        $(".sending").hide();
        $("#btnSumbit").removeAttr("disabled");
    },
    onSubScribed: function (data) {

        //var $element = $("#ajaxSubScriptionMessage");
        if (data.responseJSON == 200) {
            index._showSnack(subscriptionMessage);
            $("#frmSubscription")[0].reset();
            //$element.text(subscriptionMessage);
            //$element.removeClass("text-danger");
            //$element.addClass("text-success");
            //$element.fadeIn(1000);
            //setInterval(function () {
            //    $element.fadeOut(5000);
            //});

        }
        else {
            index._showSnack(failedSubscriptionMessage);
            //$element.text(failedSubscriptionMessage);
            //$element.removeClass("text-success");
            //$element.addClass("text-danger");
            //$element.fadeIn(500);
        }
    },
    _toggle: function () {
        if (index.started == true) {
            $(".sending").toggle(400, index._toggle);
        }
    },

    _showSnack: function (message) {
        var x = document.getElementById("snackbar")
        x.innerHTML = message;
        x.className = "show";
        setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
    }

}