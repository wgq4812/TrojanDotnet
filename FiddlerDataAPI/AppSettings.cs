namespace FiddlerDataAPI
{
    public class AppSettings
    {
        public string AccessKey { get; set; }

        public string SecretKey { get; set; }

        public string Bucket { get; set; }

        public string Domain { get; set; }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string SqlConn { get; set; }
    }
}
