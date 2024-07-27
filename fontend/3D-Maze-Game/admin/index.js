(function(){
    let RootURL = "https://localhost:7138";

    window.onload = async function() {

        var userName = getCookieFromName('username');
        var response = await fetch(RootURL + '/admin/check-permission/' + userName);
        try {
            var responseData = await response.json();
            if (responseData) {
                await getAllPlayerStatus();
            }else {
                window.document.body.innerHTML = "<h1>Access Denied</h1>";
            }
        } catch (error) {
            console.log("new user trying to connect");
        }
    }

    function getCookieFromName(name) {
        var cookies = document.cookie.split(';');
        for (var i = 0; i < cookies.length; i++) {
            var cookie = cookies[i].split('=');
            if (cookie[0].trim() === name) {
                return cookie[1];
            }
        }
        return null;
    }


    async function getAllPlayerStatus() {
        var response = await fetch(RootURL + '/admin/get-all-player-status');
        var responseData = await response.json();
        var tbody = document.getElementById('t-body');
        tbody.innerHTML = "";
        responseData.forEach(function(player) {
            var tr = document.createElement('tr');
            var td1 = document.createElement('td');
            td1.innerHTML = player.userName;
            var td2 = document.createElement('td');
            td2.innerHTML = player.currentLevel;
            var td3 = document.createElement('td');
            if (player.isFlagFound) {
                td3.innerHTML = "Escaping..";
            }
            if (player.isEscaped) {
                td3.innerHTML = "Escaped";
            }
            if (!player.isFlagFound && !player.isEscaped) {
                td3.innerHTML = "Searching Flag!";
            }

            var td4 = document.createElement('td');
            td4.innerHTML = player.team;

            tr.appendChild(td1);
            tr.appendChild(td2);
            tr.appendChild(td3);
            tr.appendChild(td4);
            tbody.appendChild(tr);
        });

        // add timer to update the table every 5 seconds and remove the previous data
        var timer = setTimeout(() => {
            getAllPlayerStatus();
        }, 5000);
    }


})();