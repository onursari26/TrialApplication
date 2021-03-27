using Application.Dto.Enums;
using Application.Dto.ExceptionExtensions;
using Application.Dto.Extensions;
using System;
using System.Collections;

namespace Application.Dto.Response
{
    public class ResponseInfo<T>
    {
        public bool Result { get; set; } = true;
        public string Message
        {
            get
            {
                if ((int)errorCode == 0)
                    return null;

                return errorCode.GetDisplayAttribute().Name;
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.Result = false;
                    this.errorMessage = value;
                    this.errorCode = Enums.ErrorCode.Error;
                }
            }
        }

        private ErrorCode errorCode;
        public string ErrorCode
        {
            get
            {
                if ((int)errorCode == 0)
                    return null;

                return ((int)errorCode).ToString();
            }
            set
            {
                this.ErrorCode = value;
            }
        }
        public T Response { get; set; }

        private int count;
        public int Count
        {
            get
            {
                this.count = this.Result && this.Response != null ? 1 : 0;

                ICollection col = this.Response as ICollection;
                if (col != null)
                    this.count = col.Count;

                if (this.count == 0)
                    this.errorCode = Enums.ErrorCode.Warning;

                return count;
            }
            set
            {
                this.count = value;
            }
        }



        private Exception exception;
        public Exception Exception
        {
            get
            {
                return exception;
            }
            set
            {
                if (value != null)
                {
                    this.Result = false;
                    this.exception = value;
                    this.ErrorMessage = value.InnerExceptionMessage();
                    this.errorCode = Enums.ErrorCode.Error;
                }
            }
        }

        private int totalCount;
        public int TotalCount
        {
            get
            {
                if (totalCount == 0)
                    totalCount = count;

                return totalCount;
            }
            set
            {
                this.totalCount = value;
            }
        }

    }
}
