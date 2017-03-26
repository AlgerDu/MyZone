using System;
using System.Collections.Generic;
using System.Linq;
using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Models.DTO
{
    public class BathOpsResultItem<T> : IBathOpsResultItem<T>
    {
        /// <summary>
        /// 返回码 0 代表成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// item 在批量操作中顺序
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 需要返回的数据
        /// </summary>
        public T Data { get; set; }
    }

    public class BathOpsResult<T> : IBathOpsResult<T>
        where T : class
    {
        Dictionary<int, IBathOpsResultItem<T>> _items = new Dictionary<int, IBathOpsResultItem<T>>();

        public int OpsCount { get; private set; }

        public int Code { get; }

        public string Message { get; set; }

        public IEnumerable<IBathOpsResultItem<T>> Items
        {
            get
            {
                return _items.Values.OrderBy(i => i.Index);
            }
        }

        public BathOpsResult(int opsCount)
        {
            OpsCount = opsCount;
        }

        /// <summary>
        /// 添加成功项
        /// </summary>
        /// <param name="item"></param>
        public void AddSuccessItem(int index, T data = null)
        {
            if (_items.ContainsKey(index))
            {
                throw new Exception("MyZone.Server.Models.DTO.BathOpsResult 添加重复的 item，编号：" + index);
            }

            var item = new BathOpsResultItem<T>();
            item.Success = true;
            item.Index = index;
            item.Message = null;
            item.Data = data;

            _items.Add(index, item);
        }

        /// <summary>
        /// 添加失败项
        /// </summary>
        /// <param name="item"></param>
        public void AddErrorItem(int index, string msg = null, T data = null)
        {
            if (_items.ContainsKey(index))
            {
                throw new Exception("MyZone.Server.Models.DTO.BathOpsResult 添加重复的 item，编号：" + index);
            }

            var item = new BathOpsResultItem<T>();
            item.Success = false;
            item.Index = index;
            item.Message = msg;
            item.Data = data;

            _items.Add(index, item);
        }
    }
}