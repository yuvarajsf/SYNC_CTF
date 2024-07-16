using ctf.Helper;
using Microsoft.AspNetCore.Mvc;

namespace ctf.Controller;

public class lvlController : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    [Route("/lvl1/flag")]
    public string GetLvl1Flag(string userId, string codeword)
    {
        string userFlag = new lvlHelper(userId).Getl1UserFlag(codeword);
        return userFlag;
    }
}