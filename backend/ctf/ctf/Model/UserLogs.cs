namespace ctf.Model;

public class UserLogs
{
    public string userName { get; set; }
    
    public string userId { get; set; }
    
    public List<UserHintsAndLvl> userLogData { get; set; }
}

public class UserHintsAndLvl
{
    public UserLevel level { get; set; }
    
    public string codeWord { get; set; }
}