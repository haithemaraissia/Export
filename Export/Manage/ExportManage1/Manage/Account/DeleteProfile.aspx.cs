using System;
using System.Web.Profile;
using System.Web.Security;

namespace Account
{
    public partial class Account_DeleteProfile : System.Web.UI.Page
    {

        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            ProfileManager.DeleteProfile(User.Identity.Name);
            Profile.Save();
            Membership.DeleteUser(User.Identity.Name);
            Response.Redirect("../Advertiser/Home.aspx");
        }

        protected void CancelButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("../Advertiser/Home.aspx");
        }
    }
}