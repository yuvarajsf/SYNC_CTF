using ctf.Model;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ctf.Helper;

public class AdminHelper
{
    private UserHelper _userHelper;
    private List<UserModel> usersData;
    private List<HintModel> userHints;
    private List<CommentModel> userComments;
    public AdminHelper()
    {
        this._userHelper = new UserHelper();
        this.usersData = _userHelper.GetAllUser();
        this.userHints = _userHelper.GetUserHintsFromFile();
        this.userComments = _userHelper.GetAllCommentsFromDB();
    }

    public bool CheckPermission(string userName)
    {
        bool havePermission = false;
        if (!string.IsNullOrEmpty(userName))
        {
            string adminName = this.GetAdminName();
            if (!string.IsNullOrEmpty(adminName))
            {
                if (adminName == userName)
                {
                    havePermission = true;
                }
            }
        }
        return havePermission;
    }

    private string GetAdminName()
    {
        string admin = this.usersData.Find(data => data.team == "admin")?.userName;
        if (!string.IsNullOrEmpty(admin))
        {
            return admin;
        }

        return string.Empty;
    }
}