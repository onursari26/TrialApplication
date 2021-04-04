using System;

namespace Application.Utility.StaticMethods
{
    public static class AppServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
}
