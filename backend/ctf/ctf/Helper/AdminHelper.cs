using ctf.Model;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ctf.Helper;

public class AdminHelper
{
    private UserHelper _userHelper;
    private List<UserModel> usersData;
    private List<CommentModel> userComments;

    public AdminHelper()
    {
        this._userHelper = new UserHelper();
        this.usersData = _userHelper.GetAllUser();
        this.userComments = _userHelper.GetAllCommentsFromDB();
    }

    public bool CheckPermission(string userName)
    {
        bool havePermission = false;
        if (!string.IsNullOrEmpty(userName))
        {
            string adminName = this.GetAdminName();
            if (!string.IsNullOrEmpty(adminName))
            {
                if (adminName == userName)
                {
                    havePermission = true;
                }
            }
        }
        return havePermission;
    }

    private string GetAdminName()
    {
        string admin = this.usersData.Find(data => data.team == "admin")?.userName;
        if (!string.IsNullOrEmpty(admin))
        {
            return admin;
        }

        return string.Empty;
    }
    
    public List<CurrentLevelInfo> GetAllUserLevelInfo()
    {
        List<CurrentLevelInfo> usersLevelInfo = new List<CurrentLevelInfo>();
        for (var i=0; i < this.usersData.Count; i++)
        {
            if (this.usersData[i].team != "admin")
            {
                CurrentLevelInfo userInfo = new CurrentLevelInfo()
                {
                    userName = this.usersData[i].userName.ToUpper(),
                    team = this.usersData[i].team.ToUpper(),
                    currentLevel = this.usersData[i].challenge.currentLevel,
                    isFlagFound = this.usersData[i].challenge.challengeStatus.Find(data => data.level == this.usersData[i].challenge.currentLevel).isFlagFound,
                    isEscaped = this.usersData[i].challenge.challengeStatus.Find(data => data.level == this.usersData[i].challenge.currentLevel).isEscaped
                };

                usersLevelInfo.Add(userInfo);
            }
        }

        return usersLevelInfo;
    }

    public List<UsedHints> GetAllUsersHintLevelWise()
    {
        List<UserLogs> userLogs = new UserLogHelper().GetAllUserLogs();
        List<UsedHints> allUsedHints = new List<UsedHints>();
        foreach (var data in userLogs)
        {
            UsedHints usedHints = new UsedHints();
            usedHints.data = new List<UserLogData>();
            usedHints.userName = data.userName.ToUpper();
            for (var i = 1; i <= 5; i++)
            {
                UserLevel currentCheckingLevel = JsonConvert.DeserializeObject<UserLevel>(i.ToString());
                List<UserHintsAndLvl> levelDatas = data.userLogData.FindAll(data => data.level == currentCheckingLevel);

                if (levelDatas.Count > 1)
                {
                    List<string> hints = new List<string>();
                    
                    for (var j = 0; j < levelDatas.Count; j++)
                    {
                        hints.Add(levelDatas[j].codeWord);
                    }
                    
                    UserLogData userLog = new UserLogData()
                    {
                        level = currentCheckingLevel,
                        hint = hints
                    };
                    
                    usedHints.data.Add(userLog);
                }
                else if (levelDatas.Count == 1)
                {
                    UserLogData userLog = new UserLogData()
                    {
                        level = JsonConvert.DeserializeObject<UserLevel>(i.ToString()),
                        hint = new List<string>()
                        {
                            levelDatas[0].codeWord
                        },
                    };
                    
                    usedHints.data.Add(userLog);
                }
                
            }
            allUsedHints.Add(usedHints);
        }

        return allUsedHints;
    }

    public List<UserCommentsModel> GetAllComments()
    {
        List<UserCommentsModel> userComments = new List<UserCommentsModel>();
        foreach (var data in this.usersData)
        {
            if (data.team.ToLower() != "admin".ToLower())
            {
                string currentUser = data.userName.ToUpper();
                var currentUserComments =
                    this.userComments.FindAll(info => info.userName.ToLower() == currentUser.ToLower());
                List<string> singleUserCmt = new List<string>();
                foreach (var cmtData in currentUserComments)
                {
                    singleUserCmt.Add(cmtData.comment);
                }

                UserCommentsModel userCmt = new UserCommentsModel()
                {
                    userName = currentUser,
                    comments = singleUserCmt
                };

                userComments.Add(userCmt);
            }
        }

        return userComments;
    }

    public List<LeaderBoard> GetLeaderBoardInfo()
    {
        return new List<LeaderBoard>();
    }
}