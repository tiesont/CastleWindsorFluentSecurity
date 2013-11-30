;(function ($) {

    // Extension to apply unobstrusive validation to dynamically-added elements
    // @see http://stackoverflow.com/questions/4406291/jquery-validate-unobtrusive-not-working-with-dynamic-injected-elements
    $.fn.updateValidation = function () {
        var form = this.closest("form")
            .removeData("validator")
            .removeData("unobtrusiveValidation");

        $.validator.unobtrusive.parse(form);

        return this;
    };


    /* 
    *   Page extensions
    *
    *   @meta:  Simple jQuery extension to turn any element into a "scroll to top" link.
    *   @url:   n/a
    *
    */
    $.fn.scrollbutton = function (elem) {
        this.on('click', function (e) {
            e.preventDefault();
            $(elem == "" || elem == null ? 'html, body' : elem).animate({ scrollTop: 0 }, 'slow');
        });
    }

})(jQuery);
