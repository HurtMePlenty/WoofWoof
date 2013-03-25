function initializeCollapsers() {
    $('.knockout-container-collapser').collapser();
}

(function($) {

    $.widget('woofwoof.collapser', {
        _header: null,
        _body: null,
        options: {

        },
        
        _headerMouseDownFn: function(e) {
            e.preventDefault();
        },
        
        _headerClickFn: function (e, self) {
            var body = self._body;
            var header = self._header;
            e.preventDefault();
            body.removeClass("collapse-transitions");
            var contHeight;
            if (body.css('box-sizing') == 'border-box') {
                contHeight = body.outerHeight();
            } else {
                contHeight = body.height();
            }
            body.css('height', contHeight);
            window.setTimeout(function () {
                body.addClass("collapse-transitions");
                var isCollapsed = body.data('isCollapsed');
                if (!isCollapsed) {
                    header.data('init-width', header.width());
                    body.data('isCollapsed', true);
                    body.data('initHeight', contHeight);
                    body.data('padding-top', body.css('padding-top')).css('padding-top', 0);
                    body.data('padding-bottom', body.css('padding-bottom')).css('padding-bottom', 0);
                    body.css('height', 0);
                    header.width(body.width());

                } else {
                    header.width(header.data('init-width'));
                    body.data('isCollapsed', false);
                    body.height(body.data('initHeight'));
                    body.css('padding-top', body.data('padding-top'));
                    body.css('padding-bottom', body.data('padding-bottom'));
                }
            }, 10);
        },
        
        _create: function() {
            var self = this;
            this._header = $(this.element);
            this._body = this._header.next();
            this._on(this._header, { 'mousedown': this._headerMouseDownFn });
            this._on(this._header, {
                'click': function(e) {
                    this._headerClickFn(e, self);
                }
            });

            //this._header.mousedown(this._headerMouseDownFn);
            //this._header.click(
            //    function(e) {
            //         self._headerClickFn(e, self);
            //    });
        },

        _setOption: function(key, value) {
            this._super("_setOption", key, value);
        },

        _destroy: function () {
            this._off(this._header);

            _header.unbind('mousedown', _headerMouseDownFn);
            _header.unbind('click', _headerClickFn);
        }
    });
})(jQuery)