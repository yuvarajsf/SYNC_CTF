using ctf.Model;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;

namespace ctf.Helper;

public class UserHelper
{
    private string currentPath;
    public UserHelper()
    {
        this.currentPath = Directory.GetCurrentDirectory();
    }

    private UserModel RemoveFlagFromObject(UserModel userData)
    {
        var data = userData?.challenge.challengeStatus.FindAll(data => !string.IsNullOrEmpty(data.flag) == true);
        foreach (CTFStatus info in data)
        {
            info.flag = string.Empty;
        }

        return userData;
    }
    
    public UserModel GetUserById(Guid guid, bool isRemoveFlag = true)
    {
        var userDetails = this.GetAllUser();
        var currentUserInfo = userDetails?.Find(data => data.userId == guid);
        if (isRemoveFlag && currentUserInfo != null)
        {
            return this.RemoveFlagFromObject(currentUserInfo);
        }

        return currentUserInfo;
    }
    
    public List<UserModel> GetAllUser()
    {
        string fileData = File.ReadAllTextAsync(currentPath + "/Database/database.json").Result;
        return JsonConvert.DeserializeObject<List<UserModel>>(fileData);
    }
    
    public UserModel UpdateUser(UserModel userData)
    {
        try
        {
            List<UserModel> userList = new List<UserModel>();
            if (!string.IsNullOrEmpty(userData.userName))
            {
                userData.userId = Guid.NewGuid();
                userData.challenge = new CtfModel();
                userData.challenge.currentLevel = UserLevel.Level1;
                userData.challenge.challengeStatus = this.GetInitialStatusList(userData.team);

                userList = this.GetAllUser();
                userList?.Add(userData);
                string serializedData = JsonConvert.SerializeObject(userList);
                File.WriteAllTextAsync(currentPath + "/Database/database.json", serializedData);
                
            }
        }
        catch (Exception ex)
        {
            File.AppendAllTextAsync(currentPath + "/Logs/logs.txt", ex.ToString());
        }

        return this.RemoveFlagFromObject(userData);
    }

    public List<CTFStatus> GetInitialStatusList(string team)
    {
        List<CTFStatus> initialStatusList = new List<CTFStatus>();

        for (int i = 1; i <= 5; i++)
        {
            UserLevel level = JsonConvert.DeserializeObject<UserLevel>(i.ToString());
            initialStatusList.Add(new CTFStatus()
            {
                level =  level,
                isCompleted = false,
                flag = this.GenerateAndGetFlagBasedOnLevel(level, team)
            });
        }

        return initialStatusList;
    }

    public string GenerateAndGetFlagBasedOnLevel(UserLevel level, string team)
    {
        string currentTeamFlag = string.Empty;
        FlagOrder levelFlag = new FlagOrder();
        FlagModel userFlags = new FlagModel();
        switch (team) 
        {
            case "website":
                levelFlag = userFlags.siteFlag.Find(data => data.levelFlag == level);
                currentTeamFlag = levelFlag.flag;
                break;
            case "report":
                levelFlag = userFlags.reportFlag.Find(data => data.levelFlag == level);
                currentTeamFlag = levelFlag.flag;
                break;
            case "desk":
                levelFlag = userFlags.deskFlag.Find(data => data.levelFlag == level);
                currentTeamFlag = levelFlag.flag;
                break;
            case "sign":
                levelFlag = userFlags.signFlag.Find(data => data.levelFlag == level);
                currentTeamFlag = levelFlag.flag;
                break;
            default:
                break;
        }

        return currentTeamFlag;
    }
}