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
        this.userData = new UserHelper().GetUserById(userId, false);
        this.currentPath = Directory.GetCurrentDirectory();
    }

    public bool ValidateUserFlag(string flag)
    {
        CtfModel userCTFStatusData = this.userData.challenge;
        UserLevel currentUserLevel = userCTFStatusData.currentLevel;
        List<UserModel> allUserData = new UserHelper().GetAllUser();
        CTFStatus currentPlayerStatus = userCTFStatusData.challengeStatus.Find(data => data.level == currentUserLevel);
        if (!currentPlayerStatus.isCompleted)
        {
            bool flagStatus = currentPlayerStatus.flag == flag;
            if (flagStatus)
            {
                UserModel currentUserData = allUserData.Find(data => data.userId == this.userId);
                foreach (var userChallenge in currentUserData.challenge.challengeStatus)
                {
                    if (userChallenge.level == currentUserLevel)
                    {
                        userChallenge.isFlagFound = true;
                        userChallenge.flagFoundAt = DateTime.Now;
                        break;
                    }
                }
                this.UpdateUserGameStatus(allUserData);
                return true;
            }

        } 
        return false;
    }

    public bool UpdateUserEscapeStatus()
    {
        bool isFlagFound = false;
        CtfModel ctfData = this.userData.challenge;
        UserLevel currentUserLevel = ctfData.currentLevel;
        List<UserModel> userDatas = new UserHelper().GetAllUser();
        
        var currentUserData = userDatas.Find(data => data.userId == this.userId);
                
        // update completed state
        foreach (var data in currentUserData.challenge.challengeStatus)
        {
            if (data.level == currentUserLevel)
            {
                if (data.isFlagFound)
                {
                    data.isCompleted = true;
                    data.isEscaped = true;
                    isFlagFound = data.isFlagFound;
                    break;
                }
            }
        }
        
        // update current level into next level
        if (isFlagFound)
        {

            int userLevel = Int16.Parse(JsonConvert.SerializeObject(ctfData.currentLevel)) + 1;
            if (userLevel > 5)
            {
                userLevel = 5;
            }
            currentUserData.challenge.currentLevel = JsonConvert.DeserializeObject<UserLevel>((userLevel).ToString());

            // update into original data
            this.UpdateUserGameStatus(userDatas);
            return true;
        }

        return false;
    }
    
    public void UpdateUserGameStatus(List<UserModel> userDatas)
    {
        string serializedData = JsonConvert.SerializeObject(userDatas);
        File.WriteAllTextAsync(currentPath + "/Database/database.json", serializedData);
    }
}