using System.Collections.Generic;
using System.Linq;

namespace MyZone.Server.Models.DataBase
{
    /// <summary>
    /// 领域对象，不是领域根
    /// </summary>
    public partial class Host
    {
        List<PageParse> _parses = new List<PageParse>();

        public IEnumerable<PageParse> PageParses
        {
            get
            {
                return _parses;
            }
            set
            {
                _parses = value.ToList();
            }
        }

        /// <summary>
        /// 获取域名下某个类型的页面的解析代码
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public PageParse PageParse(PageType type)
        {
            return _parses.FirstOrDefault(p => p.PageType == (int)type);
        }
    }
}