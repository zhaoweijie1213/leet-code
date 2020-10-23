using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeetCode.Data.Models
{
    //[Table("clubseason_drawboxreceive")]
    public partial class ClubseasonDrawboxreceive
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 区域Id
        /// </summary>
        public int Areaid { get; set; }
        /// <summary>
        /// 游戏Id
        /// </summary>
        public int Gameid { get; set; }
        /// <summary>
        /// 俱乐部Id
        /// </summary>
        public int Clubid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Gameno { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 领奖时间
        /// </summary>
        public DateTime opentime { get; set; }
        /// <summary>
        /// 牌局结束时间
        /// </summary>
        public DateTime endtime { get; set; }
        /// <summary>
        /// 是否领取
        /// </summary>
        public int Isreceive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Receivebox { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Goldbox { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Silverbox { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Copperbox { get; set; }
    }
}
