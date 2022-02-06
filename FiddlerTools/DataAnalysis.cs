using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiddlerTools
{
    public partial class DataAnalysis : Form
    {
        public DataAnalysis()
        {
            InitializeComponent();
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            var selectValue = txtSelectValue.Text;
            switch (selectValue)
            {
                case "十六进制":
                    var oldData = txtOldData.Text.Trim().Replace("-", "");

                    txtNewData.Text = UnHex(oldData);
                    break;
                case "二进制":
                    var newDataArray = new List<byte>();

                    var oldDataArray = txtOldData.Text.Trim().Split(',').ToList();

                    oldDataArray.ForEach(x =>
                    {
                        if (Convert.ToChar(int.Parse(x)) > 32 && Convert.ToChar(int.Parse(x)) < 127)
                        {
                            newDataArray.Add(Convert.ToByte(x));
                        }
                    });

                    var result = Convert.ToHexString(newDataArray.ToArray());

                    txtNewData.Text = Encoding.UTF8.GetString(newDataArray.ToArray());

                    break;
                case "解析数据":
                    var oldDataText = txtOldData.Text.Trim();

                    var regRule = new Regex("");

                    break;
            }
        }

        ///<summary>
        /// 从16进制转换成汉字
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="charset">编码,如"utf-8","gb2312"</param>
        /// <returns></returns>
        public string UnHex(string hex, string charset = "ascii")
        {
            if (hex == null)
                throw new ArgumentNullException("hex");
            hex = hex.Replace(",", "");
            hex = hex.Replace("\n", "");
            hex = hex.Replace("\\", "");
            hex = hex.Replace(" ", "");
            hex = hex.Replace("0x", "");

            if (hex.Length % 2 != 0)
            {
                hex += "20";//空格
            }
            // 需要将 hex 转换成 byte 数组。
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message.
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            return chs.GetString(bytes);
        }
    }
}
