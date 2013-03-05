$(function() {

    $('.knockout-container-collapser').mousedown(function (e) {
        e.preventDefault();
    });

    $('.knockout-container-collapser').click(function (e) {
        e.preventDefault();
        var $cont = $(this).parent().find('.knockout-container');
        $cont.removeClass("collapse-transitions");
        $cont.css('height', $cont.height());
        window.setTimeout(function () {
            $cont.addClass("collapse-transitions");
            var isCollapsed = $cont.data('isCollapsed');
            if (!isCollapsed) {
                $cont.data('isCollapsed', true);
                $cont.data('initHeight', $cont.height());
                $cont.css('height', 0);
            } else {
                $cont.data('isCollapsed', false);
                $cont.css('height', $cont.data('initHeight'));
            }
        }, 10);
    });


    function appViewModel() {
        this.name = "Bert";
        this.adress = "Bertington";
    }

    // Activates knockout.js
    ko.applyBindings(new appViewModel());

});