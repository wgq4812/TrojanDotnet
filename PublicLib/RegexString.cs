using System;

namespace PublicLib
{
    /// <summary>
    /// 正则表达式合集
    /// </summary>
    public class RegexString
    {
        /// <summary>
        /// 游戏开始的表达式 开头标记  EN
        /// </summary>
        public const string StartPattern = "EN{1}";
        /// <summary>
        /// 游戏编号表达式
        /// </summary>
        public const string GameNumberPattern = @"\d{6}\S\d{6}";
        /// <summary>
        /// 取json字符串表达式
        /// </summary>
        public const string GetJsonStringPattern = @"\{[\S\s]+\}";
        /// <summary>
        /// 获取开奖结果 25,2,9  开奖结果是 9 但是这个是谁赢 区分不出来 ，需要后期数据分析
        /// </summary>
        public const string GetOpenResultPattern = @"[0-9]{2},[0-9]{1},[0-9]{1}";
    }
}
