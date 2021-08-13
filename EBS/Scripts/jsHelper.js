
/// <reference path="jquery-2.0.0.min.js" />

function log(text) {
    console.log(text);
}

function showMessage(title, message) {
    $('.modal-header > h3').html(title);
    $('.modal-body').html(message);

    $('.modal').modal('show');
}