using System.Web;
using System.Web.Mvc;
using FluentSecurity;

namespace CastleWindsorFluentSecurity
{
    public class DenyAccessPolicyViolationHandler : IPolicyViolationHandler
    {
        public ActionResult Handle(PolicyViolationException exception)
        {
            return new HttpUnauthorizedResult(exception.Message);
        }
    }
}