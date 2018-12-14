'use strict';

//Set up connection
var connection = new signalR.HubConnectionBuilder().withUrl('/chatHub').build();
var list = document.getElementById('messagesList');
list.scrollTop = list.scrollHeight;

// Parses message and appends to ul
connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, '&lt;').replace(/>/g, '&gt;');
    var msgBlock = document.createElement('div');
    msgBlock.classList.add('clearFix');
    msgBlock.classList.add('messageBlock');
    var encodedMsg = `<span class="bold">${user}</span> : ${msg}`;
    var li = document.createElement('p');
    li.innerHTML = encodedMsg;
    var currUser = document.getElementById('currentUser');
    msgBlock.appendChild(li);

    //Checks if message is sent from currentUser
    if (currUser.value === user) {
        li.classList.add('myMessage');
        li.textContent = msg;
    } else {
        li.classList.add('otherMessage');
    }
    document.getElementById('messagesList').appendChild(msgBlock);
    list.scrollTop = list.scrollHeight;
});

// Error handling for connection
connection.start().catch(function (err) {
    return console.error(err.toString());
});

// Logic message sending button FOR GENERAL CHAT
document.getElementById('sendButton').addEventListener('submit', function (event) {
    console.log(event);
    var user = document.getElementById('userInput').value;
    var message = document.getElementById('messageInput').value;
    connection.invoke('SendMessage', user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

//Pressing enter also allows message sending
document.getElementById('messageInput').addEventListener('keyup', function (e) {
    e.preventDefault();
    if (e.keyCode === 13) {
        document.getElementById('sendButton').click();
        this.value = '';
    }
});