namespace ctf.Model;

public class CtfModel
{
    public UserLevel currentLevel { get; set; }
    
    public List<CTFStatus> challengeStatus { get; set; } 
}

public class CTFStatus
{
    public UserLevel level { get; set; }
    
    public bool isCompleted { get; set; }
    
    public string flag { get; set; }
}