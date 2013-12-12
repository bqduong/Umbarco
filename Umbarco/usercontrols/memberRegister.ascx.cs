using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Umbarco.Models;

namespace Umbarco.usercontrols
{
    public partial class memberRegister : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // is user is already logged on, redirect to home page (doesn't make sense to register when already logged in...)
            if (umbraco.library.IsLoggedOn())
                Response.Redirect("~/");
        }

        protected void cwMember_CreatedUser(object sender, EventArgs e)
        {
            CreateUserWizard cuw = (CreateUserWizard)sender;
            MembershipUser user = Membership.GetUser(cuw.UserName);
            if (user != null)
            {
                // create a new Guid
                string newUserGuid = System.Guid.NewGuid().ToString("N");
 
                // get the profile for this user
                MemberProfile mp = MemberProfile.GetUserProfile(cuw.UserName);
                mp.AuthGuid = newUserGuid;
                mp.FirstName = ((TextBox) cuw.CreateUserStep.ContentTemplateContainer.FindControl("FirstName")).Text;
                mp.MiddleName = ((TextBox)cuw.CreateUserStep.ContentTemplateContainer.FindControl("MiddleName")).Text;
                mp.LastName = ((TextBox)cuw.CreateUserStep.ContentTemplateContainer.FindControl("LastName")).Text;
                mp.Save();
 
                // add the user to the "SiteMembers" group
                Roles.AddUserToRole(cuw.UserName, "SiteMembers");
 
                // send email to user with link in the form
                // 
//http://domain.com/auth.aspx?a=
//{username}&b={guid}
 
                // for now, just show the link on screen...
                HyperLink hlAuth = (HyperLink)cuw.CompleteStep.ContentTemplateContainer.FindControl("hlAuth");
                if (hlAuth != null)
                {
                    hlAuth.NavigateUrl = "http://" + Request.ServerVariables["HTTP_HOST"] +
                                            Request.ApplicationPath.TrimEnd('/') + "/auth.aspx?a=" + user.UserName +
                                            "&b=" +
                                            newUserGuid;
 
                    hlAuth.Text = hlAuth.NavigateUrl;
                }
 
            }
 
        }
    }
}