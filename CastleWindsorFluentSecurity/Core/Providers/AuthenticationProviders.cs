using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CastleWindsorFluentSecurity
{
    public interface IAuthenticationProvider
    {
        void SignIn(string userName, bool makePersistent = false);
        void SignOut();
    }

    public class FormsAuthenticationProvider : IAuthenticationProvider
    {
        public void SignIn(string userName, bool makePersistent = false)
        {
            FormsAuthentication.SetAuthCookie(userName, makePersistent);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}