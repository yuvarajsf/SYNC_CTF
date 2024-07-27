namespace ctf.Model;

public class CurrentLevelInfo
{
    public string userName { get; set; }
    
    public string team { get; set; }
    
    public UserLevel currentLevel { get; set; }
    
    public bool isFlagFound { get; set; }
    
    public bool isEscaped { get; set; }
}