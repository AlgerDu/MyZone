using System;
using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Models.DTO
{
    public class DResult : IDResult
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public static IDResult<T2> Success<T2>(T2 data = null)
            where T2 : class
        {
            return new DResult<T2>()
            {
                Code = 0,
                Data = data
            };
        }

        public static IDResult<T2> Error<T2>(string msg = null, T2 data = null)
            where T2 : class
        {
            return new DResult<T2>()
            {
                Code = 1,
                Message = msg,
                Data = null
            };
        }

        public static IDResult Success()
        {
            return new DResult()
            {
                Code = 0,
                Message = null
            };
        }

        public static IDResult Error(string msg = null)
        {
            return new DResult()
            {
                Code = 1,
                Message = msg
            };
        }
    }

    public class DResult<T> : IDResult<T>
        where T : class
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}