using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Common
{
    public class ServiceResult
    {
        public ServiceResult(bool isSuccess = true, string message = "", ErrorTypeEnum errorTypeEnum = ErrorTypeEnum.None)
        {
            IsSuccess = isSuccess;
            Message = message;
            ErrorTypeEnum = errorTypeEnum;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ErrorTypeEnum ErrorTypeEnum { get; set; }

        public static ServiceResult Success()
            => new();

        public static ServiceResult Error(string message, ErrorTypeEnum errorTypeEnum)
            => new(false, message, errorTypeEnum);
    }

    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult(T? data, bool isSuccess = true, string message = "", ErrorTypeEnum errorTypeEnum = ErrorTypeEnum.None)
            : base(isSuccess, message, errorTypeEnum)
        {
            Data = data;
        }

        public T? Data { get; set; }

        public static ServiceResult<T> Success(T data)
            => new(data);

        public static new ServiceResult<T> Error(string message, ErrorTypeEnum errorTypeEnum)
            => new(default, false, message, errorTypeEnum);
    }

    public enum ErrorTypeEnum
    {
        None = 0,
        NotFound = 1,
        Failure = 2
    }
}
