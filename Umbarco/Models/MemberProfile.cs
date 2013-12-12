using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace Umbarco.Models
{
    public class MemberProfile : ProfileBase
    {

        public static MemberProfile GetUserProfile(string username)
        {
            return Create(username) as MemberProfile;
        }

        public static MemberProfile GetUserProfile()
        {
            return Create(Membership.GetUser().UserName) as MemberProfile;
        }

        [SettingsAllowAnonymous(false)]
        public string AuthGuid
        {
            get
            {
                var o = base.GetPropertyValue("auth_guid");
                if (o == DBNull.Value)
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                base.SetPropertyValue("auth_guid", value);
            }
        }

        [SettingsAllowAnonymous(false)]
        public string FirstName
        {
            get
            {
                var o = base.GetPropertyValue("first_name");
                if (o == DBNull.Value)
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                base.SetPropertyValue("first_name", value);
            }
        }

        [SettingsAllowAnonymous(false)]
        public string LastName
        {
            get
            {
                var o = base.GetPropertyValue("last_name");
                if (o == DBNull.Value)
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                base.SetPropertyValue("last_name", value);
            }
        }

        [SettingsAllowAnonymous(false)]
        public string MiddleName
        {
            get
            {
                var o = base.GetPropertyValue("middle_name");
                if (o == DBNull.Value)
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                base.SetPropertyValue("middle_name", value);
            }
        }
    }
}