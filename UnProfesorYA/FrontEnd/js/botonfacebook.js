var APP_ID = '1715877948686897';
var CHANNEL_URL = 'http://www.xelados.meximas.com';
var STATUS_CONNECTED = 'connected';
var STATUS_NOT_AUTHORIZED = 'not_authorized';
var STATUS_UNKNOWN = 'unknown';
var PERMISSIONS = { scope: 'email, user_about_me, user_birthday' };

var uid;
var accessToken;
var isLogginProcess = false;

function doLogin(ev) {
    isLogginProcess = true;
    FB.login(controlarStatus, PERMISSIONS);
}

function doAuthorize(ev) {
    isLogginProcess = true;
    FB.login(controlarStatus, PERMISSIONS);
}

function doLogout(ev) {
    FB.logout(controlarStatus);
}

function authResponseChange(respuesta) {
    controlarStatus(respuesta);
}

function statusChange(respuesta) {
    controlarStatus(respuesta);
}

function controlarStatus(respuesta) {
    if (respuesta.authResponse) {

        if (respuesta.status === STATUS_CONNECTED) {
            uid = respuesta.authResponse.userID;
            accessToken = respuesta.authResponse.accessToken;
            $('#logout').show();
            $('#authorize').hide();
            $('#login').hide();
            testAPI();

        }
        else if (respuesta.status === STATUS_NOT_AUTHORIZED) {
            $('#authorize').show();
            $('#logout').show();
            $('#login').hide();
        }
        else {

            $('#login').show();
            $('#authorize').hide();
            $('#logout').hide();
        }

    }
    else {

        if (isLogginProcess) {

            isLogginProcess = false;
            FB.getLoginStatus(controlarStatus, true);
        }

        if (respuesta.status === STATUS_NOT_AUTHORIZED) {
            $('#authorize').show();
            $('#login').hide();
            $('#logout').hide();
        }
        else {
            $('#login').show();
            $('#authorize').hide();
            $('#logout').hide();
        }
    }

}

function init() {

    FB.Event.subscribe('auth.authResponseChange', authResponseChange);
    FB.getLoginStatus(controlarStatus, true);
    $('#login').on('click', doLogin);
    $('#authorize').on('click', doAuthorize);
    $('#logout').on('click', doLogout);
}


function testAPI() {

    FB.api('/me', function (user) {
        var identificador = document.getElementById('identificador'); identificador.innerHTML = user.id
        var name = document.getElementById('name'); name.innerHTML = user.name
    });

}

$(document).ready(function () {
    $.ajaxSetup({ cache: true });
    $.getScript('//connect.facebook.net/es_ES/all.js', function () {
        FB.init({
            appId: APP_ID,
            channelUrl: CHANNEL_URL,
            status: false,
            xfbml: true
        });

        init();
    });
});