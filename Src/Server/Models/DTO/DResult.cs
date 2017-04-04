using System;
using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Models.DTO
{
    public class Result : IResult
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public static IResult<T2> Success<T2>(T2 data = null)
            where T2 : class
        {
            return new Result<T2>()
            {
                Code = 0,
                Data = data
            };
        }

        public static IResult<T2> Error<T2>(string msg = null, T2 data = null)
            where T2 : class
        {
            return new Result<T2>()
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