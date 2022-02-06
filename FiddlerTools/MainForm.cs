using Fiddler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiddlerTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.Load += MainForm_Load;
            this.FormClosed += MainForm_FormClosed;
        }

        private void MainForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Shutdown:
            FiddlerApplication.Shutdown();
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            InstallCert();

            // Attach to events of interest:
            FiddlerApplication.Log.OnLogString += Log_OnLogString;
            FiddlerApplication.OnWebSocketMessage += FiddlerApplication_OnWebSocketMessage;
            FiddlerApplication.AfterSessionComplete += session =>
            {
                SetLogs("[Session]" + session.ToString());
            };
            // Build startup settings:
            var settings = new FiddlerCoreStartupSettingsBuilder().RegisterAsSystemProxy().Build();
            // Start:
            FiddlerApplication.Startup(settings);
        }

        private void FiddlerApplication_OnWebSocketMessage(object? sender, WebSocketMessageEventArgs e)
        {

        }

        /// <summary>
        /// 安装证书
        /// </summary>
        public void InstallCert()
        {
            //生成证书
            CertMaker.createRootCert();
            //返回根证书，Fiddler使用该根证书生成用于HTTPS拦截的每个站点的证书。
            X509Certificate2 oRootCert = CertMaker.GetRootCertificate();

            X509Store certStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadWrite);
            try
            {
                certStore.Add(oRootCert);
            }
            finally
            {
                certStore.Close();
            }

            //这个证书还要赋值给变量oDefaultClientCertificate（The default certificate used for client authentication）
            FiddlerApplication.oDefaultClientCertificate = oRootCert;
            //在解密HTTPS通信时，控制服务器证书错误是否被忽略。
            CONFIG.IgnoreServerCertErrors = false;
        }

        private void Log_OnLogString(object? sender, LogEventArgs e)
        {
            SetLogs("[LogString]" + e.LogString);
        }

        private void SetLogs(string msg)
        {
            msg = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]{msg}";
            txtShowLogs.Text = txtShowLogs.Text.Insert(0, msg);
        }
    }
}
