'use strict';

//Set up connection
var connection = new signalR.HubConnectionBuilder().withUrl('/chatHub').build();

// Parses message and appends to ul
connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, '&lt;').replace(/>/g, '&gt;');
    var encodedMsg = user + ' says ' + msg;
    var li = document.createElement('li');
    li.textContent = encodedMsg;
    document.getElementById('messagesList').appendChild(li);
});

// Error handling for connection
connection.start().catch(function (err) {
    return console.error(err.toString());
});

// Logic message sending button
document.getElementById('sendButton').addEventListener('click', function (event) {
    var user = document.getElementById('userInput').value;
    var message = document.getElementById('messageInput').value;
    connection.invoke('SendMessage', user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});