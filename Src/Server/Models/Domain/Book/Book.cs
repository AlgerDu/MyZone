using System;
using System.Collections.Generic;
using System.Linq;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Infrastructure.Results;

namespace MyZone.Server.Models.DataBase
{
    /// <summary>
    /// 书籍领域模型
    /// </summary>
    public partial class Book : IAggregateRoot<Guid>
    {
        public Guid Key
        {
            get
            {
                return Uid;
            }
        }

        /// <summary>
        /// 小说的官方网站
        /// </summary>
        public Url OfficialSite { get; set; }

        /// <summary>
        /// 爬去书籍用非官方网站（第三方）
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Url> UnofficialWites { get; set; }

        /// <summary>
        /// 添加章节
        /// </summary>
        /// <param name="newVolume"></param>
        /// <returns></returns>
        public IResult AddVolume(Volume newVolume)
        {
            if (Volume.FirstOrDefault(v => v.No == newVolume.No) != null)
            {
                return Result.Error("卷信息已经存在");
            }
            else
            {
                Volume.Add(newVolume);
                return Result.Success();
            }
        }

        /// <summary>
        /// 添加新的章节信息
        /// </summary>
        /// <param name="newChapter"></param>
        /// <returns></returns>
        public IResult AddChapter(Chapter newChapter)
        {
            if (Chapter.FirstOrDefault(c => c.VolumeNo == newChapter.VolumeNo && c.VolumeIndex == newChapter.VolumeIndex) != null)
            {
                return Result.Error("相同编号的章节信息已经存在");
            }
            else
            {
                newChapter.NeedCrawl = true;

                Chapter.Add(newChapter);
                return Result.Success();
            }
        }

        /// <summary>
        /// 获取书籍的某个章节
        /// </summary>
        /// <param name="volumeNo"></param>
        /// <param name="volumeIndex"></param>
        /// <returns></returns>
        public Chapter GetChapter(int volumeNo, int volumeIndex)
        {
            return Chapter.FirstOrDefault(c => c.VolumeNo == volumeNo && c.VolumeIndex == volumeIndex);
        }
    }
}