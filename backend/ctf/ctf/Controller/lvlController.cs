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

    [HttpGet]
    [Route("/lvl2/flag")]
    public string GetLvl2Falg(string userId, string codeword)
    {
        string userFlag = new lvlHelper(userId).Getl2UserFlag(codeword);
        return userFlag;
    }

    [HttpGet]
    [Route("/lvl3/flag")]
    public string GetLvl3Flag(string userId, string codeword)
    {
        string userFlag = new lvlHelper(userId).Getl3UserFlag(codeword);
        return userFlag;
    }

    [HttpGet]
    [Route(("/lvl4/flag"))]
    public string GetLvl4Flag(string userId, string codeword)
    {
        string userFlag = new lvlHelper(userId).Getl4UserFlag(codeword);
        return userFlag;
    }
}