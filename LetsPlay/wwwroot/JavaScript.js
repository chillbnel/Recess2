﻿/* Set the width of the side navigation to 250px */
function openNav() {
    document.getElementById("mySidenav").style.width = "250px";

}

/* Set the width of the side navigation to 0 */
function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}

$(".toggleNots").on("click", function () {
    $(".requests-box").slideToggle('fast');
});

$(".toggleFriends").on("click", function () {
    $(".friends-box").slideToggle('fast');
});
