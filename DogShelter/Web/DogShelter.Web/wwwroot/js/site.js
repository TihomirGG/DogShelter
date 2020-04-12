// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$("input#files").change(function() {
//    const files = $(this)[0].files.length;

//    if (!files) {
//        console.log('if')
//        $.notify('You have to upload at least 1 image.');
//    }
//    else if (files > 6) {
//        console.log('else if')
//        $.notify('You can upload max to 6 images.');
//    }
//});


const createBtn = document.querySelector('.create');

console.log($)

createBtn.addEventListener('click', () => {
    const files = document.querySelector('#files').files;

    if (!files.length) {
        console.log('if')
        $.notify(
            'You have to upload at least 1 image.',
            { position: 'top center' }
        );
    }
    else if (files.length > 6) {
        console.log('else if')
        $.notify(
            'You can upload max to 6 images.',
            { position: 'top center' }
        );
    }
});
