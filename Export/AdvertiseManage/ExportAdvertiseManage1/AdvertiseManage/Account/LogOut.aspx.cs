using System;
using System.Web.Security;

namespace Account
{
    public partial class AccountLogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("../Advertiser/Profile/ViewProfile.aspx");
        }
    }
}