using System;

namespace Application.Utility.Extensions
{
    public static class Exceptions
    {
        public static string GetInnerExceptionMessage(this Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;

            return ex.Message + " r\nInnerException:" + GetInnerExceptionMessage(ex.InnerException);
        }
    }
}
