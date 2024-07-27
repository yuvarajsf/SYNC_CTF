using ctf.Helper;
using ctf.Model;
using Microsoft.AspNetCore.Mvc;

namespace ctf.Controller;

[Route("admin/")]
public class AdminController : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    [Route("check-permission/{userName}")]
    public bool CheckPermission(string userName)
    {
        return new AdminHelper().CheckPermission(userName);
    }

    [HttpGet]
    [Route("get-all-player-status")]
    public List<CurrentLevelInfo> GetAllUsersInfo()
    {
        return new AdminHelper().GetAllUserLevelInfo();
    }
}