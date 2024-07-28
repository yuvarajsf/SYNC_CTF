(function () {
    let RootURL = "https://localhost:7138";

    window.onload = async function () {

        var userName = getCookieFromName('username');
        var response = await fetch(RootURL + '/admin/check-permission/' + userName);
        try {
            var responseData = await response.json();
            if (responseData) {
                await getAllPlayerStatus();
            } else {
                window.document.body.innerHTML = "<h1>Access Denied</h1>";
            }
        } catch (error) {
            console.log("new user trying to connect");
        }
    }

    // add action to update button
    document.querySelector(".btn").addEventListener('click', async function (e) {
        e.preventDefault();
        switch (e.target.id) {
            case "status1":
                await getAllPlayerStatus();
                break;
            case "stage1":
                await loadDataForStageWiseUser();
                break;
            case "comt1":
                await loadAllComments();
                break;
            default:
                break;
        }
    });

    async function getAllPlayerStatus() {
        var response = await fetch(RootURL + '/admin/get-all-player-status');
        var responseData = await response.json();
        var tbody = document.getElementById('t-body');
        tbody.innerHTML = "";
        responseData.forEach(function (player) {
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
    }

    async function loadDataForStageWiseUser() {
        var response = await fetch(RootURL + '/admin/get-all-player-stage-wise-status');
        var responseData = await response.json();
        const Mastercontainer = document.getElementById('unique-table-container');

        if (document.getElementById('data-area')) {
            Mastercontainer.removeChild(document.getElementById('data-area'));
        }

        const container = document.createElement('div');
        container.id = 'data-area';
        Mastercontainer.appendChild(container);

        responseData.forEach(user => {
            const userTitle = document.createElement('div');
            userTitle.className = 'unique-collapsible-title';
            userTitle.textContent = user.userName;
            container.appendChild(userTitle);
            container.appendChild(document.createElement('br'));
            const tableContainer = document.createElement('div');
            tableContainer.className = 'unique-table-container';
            container.appendChild(tableContainer);

            user.data.forEach((levelData, index) => {
                const table = document.createElement('table');
                table.className = `unique-table unique-table-${index + 1}`;
                tableContainer.appendChild(table);

                const headerRow = document.createElement('tr');
                table.appendChild(headerRow);

                const headerLevel = document.createElement('th');
                headerLevel.className = 'unique-table-header';
                headerLevel.textContent = `Level ${levelData.level}`;
                headerRow.appendChild(headerLevel);

                levelData.hint.forEach(hint => {
                    const dataRow = document.createElement('tr');
                    table.appendChild(dataRow);

                    const dataCell = document.createElement('td');
                    dataCell.className = 'unique-table-data';
                    dataCell.textContent = hint;
                    dataRow.appendChild(dataCell);
                });
            });

            userTitle.addEventListener('click', function () {
                if (tableContainer.style.display === 'none' || tableContainer.style.display === '') {
                    tableContainer.style.display = 'block';
                } else {
                    tableContainer.style.display = 'none';
                }
            });
        });
    }

    async function loadAllComments() {
        var response = await fetch(RootURL + '/admin/get-all-comments');
        var commentsData = await response.json();
        const masterCommentsContainer = document.getElementById('comments-container-cmt');

        if (document.getElementById('root-comment-container-cmt')) {
            masterCommentsContainer.removeChild(document.getElementById('root-comment-container-cmt'));
        }
        
        const commentsContainer = document.createElement('div');
        commentsContainer.id = 'root-comment-container-cmt';
        masterCommentsContainer.appendChild(commentsContainer);

        commentsData.forEach(user => {
            const userTitle = document.createElement('div');
            userTitle.className = 'unique-collapsible-title-cmt';
            userTitle.textContent = user.userName;
            commentsContainer.appendChild(userTitle);
            commentsContainer.appendChild(document.createElement('br'));
            const commentContainer = document.createElement('div');
            commentContainer.className = 'unique-comment-container-cmt';
            commentsContainer.appendChild(commentContainer);
    
            const table = document.createElement('table');
            table.className = 'unique-table-cmt';
            commentContainer.appendChild(table);
    
            const headerRow = document.createElement('tr');
            table.appendChild(headerRow);
    
            const headerComment = document.createElement('th');
            headerComment.className = 'unique-table-header-cmt';
            headerComment.textContent = 'Comments';
            headerRow.appendChild(headerComment);
    
            user.comments.forEach(comment => {
                const dataRow = document.createElement('tr');
                table.appendChild(dataRow);
    
                const dataCell = document.createElement('td');
                dataCell.className = 'unique-table-data-cmt';
                dataCell.textContent = comment;
                dataRow.appendChild(dataCell);
            });
    
            userTitle.addEventListener('click', function() {
                if (commentContainer.style.display === 'none' || commentContainer.style.display === '') {
                    commentContainer.style.display = 'block';
                } else {
                    commentContainer.style.display = 'none';
                }
            });
        });

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