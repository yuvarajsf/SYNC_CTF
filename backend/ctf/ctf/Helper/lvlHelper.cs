using ctf.Model;

namespace ctf.Helper;

public class lvlHelper
{
    private UserModel userInfo;
    public lvlHelper(string userId)
    {
        this.userInfo = new UserHelper().GetUserById(Guid.Parse(userId));
    }

    public string Getl1UserFlag(string codeword)
    {
        if (codeword.ToLower() == "sivajivayileyjilebi")
        {
            return this.GetFlagString();
        }

        return "Code word mismatch or missing";
    }

    public string Getl2UserFlag(string codeword)
    {
        List<HintModel> userHints = new UserHelper().GetUserHintsFromFile();
        HintModel userHintData = userHints.Find(data => data.userId == this.userInfo.userId.ToString());
        if (userHintData != null)
        {
            if (userHintData.hint.Equals(codeword))
            {
                return this.GetUserFlagBasedOnLevel(this.userInfo.challenge.currentLevel);
            }
        }

        return "Code word mismatch or missing";
    }

    public string Getl3UserFlag(string codeword)
    {
        if (codeword.ToLower() == "summailladasimma")
        {
            return this.GetFlagString();
        }
        
        return "Code word mismatch or missing";
    }

    public string Getl4UserFlag(string codeword)
    {
        if (codeword.ToLower() == "metamamamarkzuck")
        {
            return this.GetFlagString();
        }

        return "Code word mismatch or missing";
    }


    public string Getl5UserFlag(string codeword)
    {
        if (codeword.ToLower() == "maapuvachitandaappu")
        {
            return this.GetFlagString();
        }

        return "Code word mismatch or missing";
    }
    
    private string GetFlagString()
    {
        UserLevel currentLevel = this.userInfo.challenge.currentLevel;
        string currentFlag = this.GetUserFlagBasedOnLevel(currentLevel);
        return currentFlag;
    }
    
    private string GetUserFlagBasedOnLevel(UserLevel currentLevel)
    {
        UserModel userData = new UserHelper().GetUserById(this.userInfo.userId, false);
        List<CTFStatus> userStatus = userData.challenge.challengeStatus;
        CTFStatus currentLevelObject = userStatus.Find(data => data.level == currentLevel);
        return currentLevelObject.flag;
    }
}