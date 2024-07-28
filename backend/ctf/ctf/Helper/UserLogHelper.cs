using ctf.Model;
using Newtonsoft.Json;

namespace ctf.Helper;

public class UserLogHelper
{
    public List<UserModel> userData;
    public List<UserLogs> userLogs;
    public string currentDirectoryPath;

    public UserLogHelper()
    {
        this.currentDirectoryPath = Directory.GetCurrentDirectory();
        this.userData = new UserHelper().GetAllUser();
        this.userLogs = this.ReadUserLogs();
    }

    public void LogUserData(string codeWord, string userId, UserLevel level)
    {
        if (!string.IsNullOrEmpty(userId))
        {
            UserLogs userLog = this.userLogs.Find(data => data.userId == userId);
            if (userLog != null)
            {
                UserHintsAndLvl currentUserLog = new UserHintsAndLvl()
                {
                    level = level,
                    codeWord = codeWord
                };
                userLog.userLogData.Add(currentUserLog);
            }
            else
            {
                string currentUserName = this.userData.Find(data => data.userId == Guid.Parse(userId)).userName;
                UserHintsAndLvl currentUserLog = new UserHintsAndLvl()
                {
                    level = level,
                    codeWord = codeWord
                };
                
                UserLogs newUserLog = new UserLogs()
                {
                    userId = userId,
                    userName = currentUserName,
                    userLogData = new List<UserHintsAndLvl>()
                    {
                        currentUserLog
                    }
                };
                this.userLogs.Add(newUserLog);
            }
            this.WriteUserLog();
        }
    }

    public List<UserLogs> GetAllUserLogs()
    {
        return this.userLogs;
    }
    
    private List<UserLogs> ReadUserLogs()
    {
        string serializedUserLogs = File.ReadAllTextAsync(this.currentDirectoryPath + "/Database/UserLogs.json").Result;
        List<UserLogs> userLogs = JsonConvert.DeserializeObject<List<UserLogs>>(serializedUserLogs);
        return userLogs;
    }

    private void WriteUserLog()
    {
        string serializedLog = JsonConvert.SerializeObject(this.userLogs);
        File.WriteAllTextAsync(this.currentDirectoryPath + "/Database/UserLogs.json", serializedLog);
    }
}