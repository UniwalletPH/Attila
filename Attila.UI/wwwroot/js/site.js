(function ($) {
    $('document').ready(function () {
        changeContentMinHeight();

        $(window).resize(function () {
            changeContentMinHeight();
        });

        $('#footer').show();

        function changeContentMinHeight() {
            var _vh = Math.max(
                document.documentElement.clientHeight,
                window.innerHeight || 0);

            var _topNav = $('#topnavigation').outerHeight();
            var _footer = $('#footer').outerHeight();

            var _remHeigt = _vh - _topNav - _footer - 10;

            if ($('#content')) {
                $('#content').css('min-height', _remHeigt);
            }


        }
    });
})(jQuery);