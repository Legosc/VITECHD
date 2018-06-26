$(document).ready(function () {
    $("#contactCard").hover(function () {
        var attr = $('#robot').attr('hidden');

        if (typeof attr !== typeof undefined && attr !== false) {
            $('#robot').removeAttr('hidden');
            $('#robot').toggleClass('animation-target');
        }

    });
});

if ('serviceWorker' in navigator) {
    window.addEventListener('load', function () {
        navigator.serviceWorker.register('/service-worker.js');
    });
}
