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
                var o = base.GetPropertyValue("pAuthGuid");
                if (o == DBNull.Value)
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                base.SetPropertyValue("pAuthGuid", value);
            }
        }

        [SettingsAllowAnonymous(false)]
        public string FirstName
        {
            get
            {
                var o = base.GetPropertyValue("pFirstName");
                if (o == DBNull.Value)
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                base.SetPropertyValue("pFirstName", value);
            }
        }

        [SettingsAllowAnonymous(false)]
        public string LastName
        {
            get
            {
                var o = base.GetPropertyValue("pLastName");
                if (o == DBNull.Value)
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                base.SetPropertyValue("pLastName", value);
            }
        }

        [SettingsAllowAnonymous(false)]
        public string MiddleName
        {
            get
            {
                var o = base.GetPropertyValue("pMiddleName");
                if (o == DBNull.Value)
                {
                    return string.Empty;
                }
                return (string)o;
            }
            set
            {
                base.SetPropertyValue("pMiddleName", value);
            }
        }
    }
}