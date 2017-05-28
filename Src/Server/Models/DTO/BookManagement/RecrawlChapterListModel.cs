using System;
using System.Collections.Generic;

namespace MyZone.Server.Models.DTO.BookManagement
{
    public class RecrawlChapterListItemModel
    {
        public long VolumeNo { get; set; }

        public long VolumeIndex { get; set; }
    }

    /// <summary>
    /// 重新抓取章节列表
    /// </summary>
    public class RecrawlChapterListModel
    {
        public Guid BookUid { get; set; }

        public List<RecrawlChapterListItemModel> Chapters { get; set; }
    }
}