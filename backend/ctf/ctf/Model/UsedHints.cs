namespace ctf.Model;

public class UsedHints
{
    public string userName { get; set; }
    
    public List<UserLogData> data { get; set; }
}

public class UserLogData
{
    public UserLevel level { get; set; }

    public List<string> hint { get; set; }
}