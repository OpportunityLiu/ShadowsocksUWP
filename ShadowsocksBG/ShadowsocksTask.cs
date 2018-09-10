using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Networking.Vpn;

namespace ShadowsocksBG
{
    public sealed class ShadowsocksTask : IBackgroundTask
    {
        private BackgroundTaskDeferral _deferral; // Note: defined at class scope so we can mark it complete inside the OnCancel() callback if we choose to support cancellation

        private static VpnPlugInImpl vpnPlugInImpl = new VpnPlugInImpl();

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();
            VpnChannel.ProcessEventAsync(vpnPlugInImpl, taskInstance.TriggerDetails);
        }
    }
}
