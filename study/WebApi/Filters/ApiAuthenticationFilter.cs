using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Filters
{
    public class ApiAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }

    }
}