using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLib.Models
{
    /// <summary>
    /// 游戏数据实体
    /// </summary>
    public class t_gameData
    {
        public int id { get; set; }
        public string GameNumber { get; set; }
        public string GameJson { get; set; }
        public string GameResult { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
