﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrojanClient.Model
{
    public class MySetting
    {
        public List<Trojan> Trojan { get; set;}

        public int HttpProxyPort { get; set; }
        public int PacServerPort { get; set; }

    }

    public class Trojan 
    {
        public string Remark { get; set; }
        public string Host { get; set; }

        public short Port { get; set; }

        public string Pass { get; set; }
        
        public bool ValidServerCert { get; set; }



    }
}
