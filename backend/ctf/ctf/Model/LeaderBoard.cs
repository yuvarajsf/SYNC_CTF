namespace ctf.Model;

public class LeaderBoard
{
    public UserLevel level { get; set; }
    
    public List<UserData> userData { get; set; }
}

public class UserData
{
    public string userName { get; set; }
    
    public DateTime foundAt { get; set; }
    
    public string bgColor { get; set; }
}