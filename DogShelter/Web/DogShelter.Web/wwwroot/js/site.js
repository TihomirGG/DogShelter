// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("input#files").change(function () {
    var files = $(this)[0].files;
    if (files.length < 1) {
        $.notify('You have to upload at least 1 image.');
    }
    else if (files.length > 6) {
        $.notify('You can upload max to 6 images.');
    }
});