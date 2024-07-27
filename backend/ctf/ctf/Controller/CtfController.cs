using ctf.Helper;
using Microsoft.AspNetCore.Mvc;

namespace ctf.Controller;

[Route("flag/")]
public class CtfController : Microsoft.AspNetCore.Mvc.Controller
{
   [HttpGet]
   [Route("validate-flag/{userId}/{flag}")]
   public bool ValidateFlag(string userId, string flag)
   {
      var status = new CtfHelper(Guid.Parse(userId)).ValidateUserFlag(flag);
      return status;
   }

   [HttpGet]
   [Route("validate-escape/{userId}")]
   public bool ValidateUserEscapeStatus(string userId)
   {
      var status = new CtfHelper(Guid.Parse(userId)).UpdateUserEscapeStatus();
      return status;
   }
}