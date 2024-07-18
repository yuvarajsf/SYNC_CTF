(function () {

    const RootURL = "https://localhost:7138";
    const cmtBtn = document.getElementById('cmt-btn');
    const cmtInput = document.getElementById('cmt');

    const commentsContainer = document.getElementById('comments');
    const hintArea = document.getElementById('hint-area');


    window.onload = async function () {
        var userId = getCookieFromName('userid');
        var response = await fetch(RootURL + '/user/get-comments/'+userId, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        });

        var data = await response.json();
        if (data) {
            manipulateComments(data);
        } else {
            console.error(data);
        }

        var roleCookie = getCookieFromName('role');
        if (!isStringEmpty(roleCookie)){
            var response = await fetch(RootURL + '/user/validate-role/'+roleCookie);
            var data = await response.text();
            if (!isStringEmpty(data)) {
                hintArea.innerHTML = data;
            }
        } else {
            document.cookie = 'role=Mqrt';
        }

    };

    function isStringEmpty(str) {
        return str === null || str === undefined || str === '';
    }

    function manipulateComments(data) {
        var comments = data;
            comments.forEach(comment => {
                commentsContainer.innerHTML = commentsContainer.innerHTML + `<div class="comment"><span class="comment-user"><b>${comment.userName} :</b> </span><span class="comment-text">${comment.comment}</span></div>`;
            });
    }

    cmtBtn.addEventListener('click', async function () {
        const comment = cmtInput.value;
        var userId = getCookieFromName('userid');
        var isAdmin = getCookieFromName('role');

        var data = {
            comment: comment,
            userId: userId,
            isAdmin: isAdmin
        }
        if (comment != '') {
            var response = await fetch(RootURL + '/user/add-comment', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
            });

            var data = await response.json();
            if (data) {
                manipulateComments(data);
                cmtInput.value = "";
            } else {
                console.error(data);
            }
        }
    });


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