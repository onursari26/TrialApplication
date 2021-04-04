using Microsoft.AspNetCore.Http;
using System.Threading;

namespace Application.Utility.StaticMethods
{
    public static class CurrentUser
    {
        public static string GetCurrentUserName()
        {
            IHttpContextAccessor httpContext = (IHttpContextAccessor)AppServiceLocator.Instance.GetService(typeof(IHttpContextAccessor));

            string currentUsername = "Anonymous";

            if (httpContext.HttpContext?.User?.Identity?.IsAuthenticated == true)
            {
                currentUsername = httpContext.HttpContext.User.Identity.Name;
            }
            else
            {
                var threadPincipal = Thread.CurrentPrincipal;
                if (threadPincipal != null && threadPincipal.Identity?.IsAuthenticated == true)
                {
                    currentUsername = threadPincipal.Identity.Name;
                }
            }

            return currentUsername;
        }
    }
}
