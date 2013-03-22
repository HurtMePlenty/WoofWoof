function initializeCollapsers() {

    $('.knockout-container-collapser').mousedown(function(e) {
        e.preventDefault();
    });

    $('.knockout-container-collapser').click(function(e) {
        e.preventDefault();
        var $cont = $(this).parent().find('.knockout-container');
        $cont.removeClass("collapse-transitions");

        var contHeight;
        if ($cont.css('box-sizing') == 'border-box') {
            contHeight = $cont.outerHeight();
        } else {
            contHeight = $cont.height();
        }

        var $self = $(this);
        $cont.css('height', contHeight);
        window.setTimeout(function() {
            $cont.addClass("collapse-transitions");
            var isCollapsed = $cont.data('isCollapsed');
            if (!isCollapsed) {
                $self.data('init-width', $self.width());
                $cont.data('isCollapsed', true);
                $cont.data('initHeight', contHeight);
                $cont.data('padding-top', $cont.css('padding-top')).css('padding-top', 0);
                $cont.data('padding-bottom', $cont.css('padding-bottom')).css('padding-bottom', 0);
                ;
                $cont.css('height', 0);
                $self.width($cont.width());

            } else {
                $self.width($self.data('init-width'));
                $cont.data('isCollapsed', false);
                $cont.height($cont.data('initHeight'));
                $cont.css('padding-top', $cont.data('padding-top'));
                $cont.css('padding-bottom', $cont.data('padding-bottom'));
            }
        }, 10);
    });
}