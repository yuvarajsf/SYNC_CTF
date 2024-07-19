using ctf.Helper;
using ctf.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ctf.Controller;

[Route("user/")]
public class UserController : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    [Route("get-user-info/{userid}")]
    public UserModel GetUserStatus(string userid)
    {
        var userId = Guid.Parse(userid);
        var userInfo = new UserHelper().GetUserById(userId);
        return userInfo;
    }

    [HttpPost]
    [Route("register-user")]
    public ActionResult<UserModel> UpdateUser([FromBody] RegisterUser userData)
    {
        var serializedData = JsonConvert.SerializeObject(userData);
        var userObject = JsonConvert.DeserializeObject<UserModel>(serializedData);
        var userInfo = new UserHelper().UpdateUser(userObject);

        return userInfo;
    }

    [HttpPost]
    [Route("update-hint")]
    public string UpdateUserHint([FromBody] HintModel hintData)
    {
        var response = new UserHelper().UpdateUserHintWithUseId(hintData);
        return response;
    }

    [HttpGet]
    [Route("get-comments/{userid}")]
    public List<CommentModel> GetAllComments(string userid)
    {
        userid = userid == "null" ? null : userid;
        var response = new UserHelper().GetAllCommentsFromDB(userid, true, true);
        return response;
    }
    
    [HttpPost]
    [Route("add-comment")]
    public List<CommentModel> AddComment([FromBody] CommentModel userComment)
    {
        var response = new UserHelper().UpdateUserComment(userComment);
        return response;
    }

    [HttpGet]
    [Route("validate-role/{role}")]
    public string ValidateUserRole(string role)
    {
        var response = new UserHelper().ValidateUserRole(role);
        return response;
    }
}