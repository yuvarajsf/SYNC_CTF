using ctf.Model;
using Newtonsoft.Json;

namespace ctf.Helper;

public class CtfHelper
{
    public UserModel userData;
    public string currentPath;
    public Guid userId;
    
    public CtfHelper(Guid userId)
    {
        this.userId = userId;
        this.userData = new UserHelper().GetUserStatusById(userId, false);
        this.currentPath = Directory.GetCurrentDirectory();
    }

    public bool ValidateUserFlag(string flag)
    {
        CtfModel ctfData = this.userData.challenge;
        UserLevel currentUserLevel = ctfData.currentLevel;
        CTFStatus userStatusData =  ctfData.challengeStatus.Find(data => data.level == currentUserLevel);
        if (!userStatusData.isCompleted)
        {
            bool status = userStatusData.flag == flag;
            if (status)
            {
                List<UserModel> userDatas = new UserHelper().GetAllUser();
                var currentUserData = userDatas.Find(data => data.userId == this.userId);
                
                // update completed state
                foreach (var data in currentUserData.challenge.challengeStatus)
                {
                    if (data.level == currentUserLevel)
                    {
                        data.isCompleted = true;
                        break;
                    }
                }
                
                // update current level into next level
                currentUserData.challenge.currentLevel = JsonConvert.DeserializeObject<UserLevel>((Int16.Parse(JsonConvert.SerializeObject(ctfData.currentLevel)) + 1).ToString());
                
                // update into original data
                this.UpdateUserGameStatus(userDatas);
                return true;
            }
        }

        return false;
    }

    public void UpdateUserGameStatus(List<UserModel> userDatas)
    {
        string serializedData = JsonConvert.SerializeObject(userDatas);
        File.WriteAllTextAsync(currentPath + "/Database/database.json", serializedData);
    }
}