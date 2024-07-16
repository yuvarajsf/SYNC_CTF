var Demonixis = Demonixis || {};
(function () {

    let RootURL = "https://localhost:7138";

    window.onload = async function () {
        var userId = getCookieFromName('userid');
        if (userId) {
            // make request to server to get user data using userId as path parameter
            var response = await fetch(RootURL + '/user/get-user-info/' + userId);
            try {

                var responseData = await response.json();

                if (!response.ok) {
                    alert('Error: ' + responseData.message);
                    return;
                } else {
                    document.getElementById('userinfo').remove();
                    document.getElementById('canvasContainer').style.display = 'block';
                    document.cookie = "level=" + responseData.challenge.currentLevel;
                    new Demonixis.initialize(responseData.challenge.currentLevel);
                }
            } catch (error) {
                console.log("new user trying to connect");
            }
        }
    }

    async function formHandler(event) {
        event.preventDefault();
        var userInfoContainer = document.getElementById('userinfo');
        var gameContainer = document.getElementById('canvasContainer');
        var userName = document.getElementById('username').value;
        var team = document.getElementById('team').value;

        if (userName === '' || team === '') {
            alert('Please fill in all fields');
            return;
        }

        var data = {
            username: userName,
            team: team
        };

        // use fetch to send data to the server
        var response = await fetch(RootURL + '/user/register-user', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        // get the response from the server
        var responseData = await response.json();
        debugger;
        if (!response.ok) {
            alert('Error: ' + responseData.message);
            return;
        } else {
            document.cookie = "userid=" + responseData.userId;
            document.cookie = "level=" + responseData.challenge.currentLevel;
            userInfoContainer.remove();
            gameContainer.style.display = 'block';
            new Demonixis.initialize(1);
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


    Demonixis.showHideMessage = function () {
        var messageContainer = document.createElement("div")
        messageContainer.setAttribute("id", "messageContainer");
        messageContainer.style.position = "absolute";
        messageContainer.style.backgroundColor = "#fafafa";
        messageContainer.style.border = "1px solid #333";

        var message = document.createElement("h1");
        message.innerHTML = "You need to solve the upcomming challenge to get Minimap to exit the maze!";
        messageContainer.style.textAlign = "center";
        messageContainer.style.color = "#000";
        messageContainer.style.padding = "15px";
        messageContainer.appendChild(message);
        document.body.appendChild(messageContainer);

        messageContainer.style.left = (window.innerWidth / 2 - messageContainer.offsetWidth / 2) + "px";
        messageContainer.style.top = (window.innerHeight / 2 - messageContainer.offsetHeight / 2) + "px";

        var timer = setTimeout(function () {
            clearTimeout(timer);
            messageContainer.remove();
            showCTFChallenge();
        }, 8000);
    }

    function showCTFChallenge() {
        var messageContainer = document.createElement("div")
        messageContainer.setAttribute("id", "messageContainer");
        messageContainer.style.position = "absolute";
        messageContainer.style.width = "50%";
        messageContainer.style.height = "50%";
        messageContainer.style.backgroundColor = "#fafafa";
        messageContainer.style.border = "1px solid #333";

        var currentLevel = Number.parseInt(getCookieFromName('level'));
        var challengeArray = [
            "/challenges/level1",
            "/challenges/level2",
            "/challenges/level3",
            "/challenges/level4",
            "/challenges/level5"
        ];
        var message = document.createElement("h1");
        message.innerHTML = `
            <div style="width: 300px; margin: 0 auto; border: 1px solid #ccc; padding: 20px; text-align: center;">
             <button id="close-btn" style="position: absolute; top: 10px; right: 10px; background-color: transparent; border: none; font-size: 18px; cursor: pointer;">X</button>    
            <div style="font-size: 24px; font-weight: bold; margin-bottom: 20px;">CTF Challenge</div>
                <div style="font-size: 18px; margin-bottom: 20px;">By Yuvaraj</div>
                <div style="margin-bottom: 20px;">
                    <a href="${challengeArray[currentLevel - 1]}" style="color: blue; text-decoration: none; font-size: 20px" target="_blank">Click here</a>
                </div>
                <div style="margin-bottom: 20px;">
                    <input type="text" id="flag" name="flag" placeholder="Enter flag" style="width: 100%; padding: 10px; box-sizing: border-box; border: 1px solid #ccc; border-radius: 4px;">
                </div>
                <div style="display: flex; justify-content: space-between;">
                    <button id="submit-flag" type="submit" style="width: 48%; padding: 10px; background-color: #4CAF50; color: white; border: none; border-radius: 4px; cursor: pointer;">Submit</button>
                    <button type="button" style="width: 48%; padding: 10px; background-color: red; color: white; border: none; border-radius: 4px; cursor: pointer;" onclick="document.querySelector('[name=flag]').value=''">Clear</button>
                </div>
            </div>`;
        messageContainer.style.textAlign = "center";
        messageContainer.style.color = "#000";
        messageContainer.style.padding = "15px";
        messageContainer.appendChild(message);
        document.body.appendChild(messageContainer);

        messageContainer.style.left = (window.innerWidth / 2 - messageContainer.offsetWidth / 2) + "px";
        messageContainer.style.top = (window.innerHeight / 2 - messageContainer.offsetHeight / 2) + "px";
        messageContainer.style.zIndex = "2";


        // add background blur effect
        var blurEffect = document.createElement("div");
        blurEffect.style.position = "fixed";
        blurEffect.style.top = "0";
        blurEffect.style.left = "0";
        blurEffect.style.width = "100%";
        blurEffect.style.height = "100%";
        blurEffect.style.backgroundColor = "rgba(0,0,0,0.5)";
        blurEffect.style.zIndex = "1";
        document.body.appendChild(blurEffect);

        // add event lister for close button
        document.getElementById('close-btn').addEventListener('click', function () {
            messageContainer.style.display = "none";
            blurEffect.style.display = "none";
            addMessageContainerEnableBtn();

            document.getElementById('enable-btn').addEventListener('click', function () {
                messageContainer.style.display = "block";
                blurEffect.style.display = "block";
                document.getElementById('enable-btn').remove();
            });
        });

        function addMessageContainerEnableBtn() {
            var btnContainer = document.createElement("div");
            btnContainer.style.position = "absolute";
            btnContainer.id = "enable-btn";
            btnContainer.style.top = "50%";
            btnContainer.style.left = "0px";
            btnContainer.style.width = "50px";
            btnContainer.style.height = "50px";
            btnContainer.style.backgroundColor = "blue";
            btnContainer.style.borderRadius = "50%";
            btnContainer.style.color = "#fff";
            btnContainer.style.textAlign = "center";
            btnContainer.innerHTML = "🏁";
            btnContainer.style.cursor = "pointer";
            btnContainer.style.zIndex = "2";
            btnContainer.style.fontSize = "30px";
            document.body.appendChild(btnContainer);
        }

        // add event lister for submit flag button
        document.getElementById('submit-flag').addEventListener('click', async function (event) {
            event.preventDefault();
            var flag = document.getElementById('flag').value;
            var userId = getCookieFromName('userid');
            if (flag === '') {
                alert('Please enter a flag');
                return;
            }

            var response = await fetch(RootURL + '/flag/validate-flag/' + userId + "/" + flag)
            var responseData = await response.json();

            if (!response.ok) {
                alert('Error: ' + responseData.message);
                return;
            } else {
                if (responseData) {
                    alert('Valid Flag! You can now exit the maze');
                    messageContainer.remove();
                    blurEffect.remove();
                    new Demonixis.ShowMiniMap(true);
                } else {
                    alert('Invalid flag');
                }
            }
        });
    }

    document.getElementById('start').addEventListener('click', async function (event) {
        await formHandler(event);
    });
})();