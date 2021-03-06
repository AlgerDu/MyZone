using System;
using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Infrastructure.Results
{
    public class Result : IResult
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public static IResult<T> Success<T>(T data = null)
            where T : class
        {
            return new Result<T>()
            {
                Code = 0,
                Data = data
            };
        }

        public static IResult<T> Error<T>(string msg = null, T data = null)
            where T : class
        {
            return new Result<T>()
            {
                Code = 1,
                Message = msg,
                Data = null
            };
        }

        public static IResult Success()
        {
            return new Result()
            {
                Code = 0,
                Message = null
            };
        }

        public static IResult Error(string msg = null)
        {
            return new Result()
            {
                Code = 1,
                Message = msg
            };
        }
    }

    public class Result<T> : IResult<T>
        where T : class
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}