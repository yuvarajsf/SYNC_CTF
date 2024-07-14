namespace ctf.Model;

public class UserModel
{
    public string userName { get; set; }
    
    public Guid userId { get; set; }
    
    public string team { get; set; }

    public CtfModel challenge { get; set; }

}

public enum UserLevel
{
    Level1 = 1,
    Level2 = 2,
    Level3 = 3,
    Level4 = 4,
    Level5 = 5
}

public class RegisterUser
{
    public string userName { get; set; }
    
    public string team { get; set; }
}