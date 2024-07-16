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
}