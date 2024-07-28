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

    [HttpGet]
    [Route("get-all-player-stage-wise-status")]
    public List<UsedHints> GetAllUserHints()
    {
        return new AdminHelper().GetAllUsersHintLevelWise();
    }

    [HttpGet]
    [Route("get-all-comments")]
    public List<UserCommentsModel> GetAllComments()
    {
        return new AdminHelper().GetAllComments();
    }

    [HttpGet]
    [Route("get-leaderboard")]
    public List<LeaderBoard> GetLeaderBoard()
    {
        return new AdminHelper().GetLeaderBoardInfo();
    }
}