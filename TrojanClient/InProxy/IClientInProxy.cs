﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TrojanClient.InProxy
{
    public interface IClientInProxy:IDisposable
    {




       Task<TcpClient>  BeginListenAsync();






    }
}
