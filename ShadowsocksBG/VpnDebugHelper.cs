using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Vpn;

namespace ShadowsocksBG
{
    internal static class VpnDebugHelper
    {
        public sealed class VpnChannelConfigurationDebugView
        {
            public string CustomField { get; }
            public object ServerHostNameList { get; }
            public string ServerServiceName { get; }
            public object ServerUris { get; }

            public VpnChannelConfigurationDebugView(VpnChannelConfiguration configuration)
            {
                CustomField = configuration.CustomField;
                ServerHostNameList = configuration.ServerHostNameList.ToArray();
                ServerServiceName = configuration.ServerServiceName;
                try
                {
                    ServerUris = configuration.ServerUris.ToArray();
                }
                catch (Exception ex)
                {
                    ServerUris = ex;
                }
            }
        }

        public static VpnChannelConfigurationDebugView GetConfig(this VpnChannel channel)
        {
            return new VpnChannelConfigurationDebugView(channel.Configuration);
        }
    }
}
