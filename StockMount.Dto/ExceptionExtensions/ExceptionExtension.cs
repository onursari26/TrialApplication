using System;

namespace Application.Dto.ExceptionExtensions
{
    public static class ExceptionExtension
    {
        public static string InnerExceptionMessage(this Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;

            return ex.Message + " r\nInnerException:" + InnerExceptionMessage(ex.InnerException);
        }
    }
}
