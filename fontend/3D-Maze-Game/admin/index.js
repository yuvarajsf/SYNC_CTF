(function(){
    let RootURL = "https://localhost:7138";

    window.onload = async function() {

        var userName = getCookieFromName('username');
        var response = await fetch(RootURL + '/admin/check-permission/' + userName);
        try {
            var responseData = await response.json();
            if (responseData) {
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
})();