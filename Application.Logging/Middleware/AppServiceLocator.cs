using System;

namespace Application.Logging.Middleware
{
    public static class AppServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
}
