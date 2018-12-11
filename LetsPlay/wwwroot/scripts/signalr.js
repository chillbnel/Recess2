// connect to signalr
$.connect.hub.start()
    .done(function () { console.log('error') })
    .fail(function () { alert('meh') });