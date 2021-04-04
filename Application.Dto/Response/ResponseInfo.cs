using Application.Dto.Enums;
using Application.Utility.Extensions;
using System;
using System.Collections;
using System.Text.Json.Serialization;

namespace Application.Dto.Response
{
    public class ResponseInfo<T>
    {
        public bool IsSuccessfull { get; set; } = true;

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
                    this.IsSuccessfull = false;
                    this.errorMessage = value;
                }
            }
        }
        public T Data { get; set; }

        private int count;
        public int Count
        {
            get
            {
                this.count = this.IsSuccessfull && this.Data != null ? 1 : 0;

                ICollection col = this.Data as ICollection;
                if (col != null)
                    this.count = col.Count;

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
                    this.IsSuccessfull = false;
                    this.exception = value;
                    this.ErrorMessage = value.GetInnerExceptionMessage();
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
