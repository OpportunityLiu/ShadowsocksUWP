using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Networking.Vpn;

namespace ShadowsocksBG
{
    public sealed class VpnPlugInImpl : IVpnPlugIn
    {
        private readonly StreamWebSocket socket = new StreamWebSocket();

        public async void Connect(VpnChannel channel)
        {
            try
            {
                channel.LogDiagnosticMessage("Connect");
                var cfg = channel.GetConfig();
                var pw = new VpnCustomEditBox
                {
                    Label = "Password",
                    Compulsory = true,
                    NoEcho = true,
                };
                //var method = new VpnCustomPromptOptionSelector
                //{
                //    Compulsory = true,
                //    DisplayName = "Encrypt Method",
                //    Options = { "rc4-md5", "salsa20", "salsa20", "chacha20", "chacha20", "chacha20-ietf", "chacha20-ietf", "aes-256-cfb", "aes-256-cfb", "aes-192-cfb", "aes-192-cfb", "aes-128-cfb", "aes-128-cfb", "aes-256-ctr", "aes-256-ctr", "aes-192-ctr", "aes-192-ctr", "aes-128-ctr", "aes-128-ctr", "bf-cfb", "bf-cfb", "camellia-128-cfb", "camellia-128-cfb", "camellia-192-cfb", "camellia-192-cfb", "camellia-256-cfb", "camellia-256-cfb", "aes-128-gcm", "aes-128-gcm", "aes-192-gcm", "aes-192-gcm", "aes-256-gcm", "aes-256-gcm", "chacha20-ietf-poly1305" }
                //};
                channel.RequestCustomPrompt(new IVpnCustomPrompt[] { pw });
                channel.AddAndAssociateTransport(socket, null);
                channel.Start(null, null, new VpnInterfaceId(new byte[] { 12, 12, 12, 33 }), null, null, 1500, 1500, false, socket, null);

            }
            catch (Exception ex)
            {
                channel.LogDiagnosticMessage(ex.Message);
            }
        }

        public void Disconnect(VpnChannel channel)
        {
            channel.LogDiagnosticMessage("Disconnect");
            var cfg = channel.GetConfig();
        }

        public void GetKeepAlivePayload(VpnChannel channel, out VpnPacketBuffer keepAlivePacket)
        {
            channel.LogDiagnosticMessage("Disconnect");
            var cfg = channel.GetConfig();
            keepAlivePacket = null;
        }

        public void Encapsulate(VpnChannel channel, VpnPacketBufferList packets, VpnPacketBufferList encapulatedPackets)
        {
            channel.LogDiagnosticMessage("Encapsulate");
            var cfg = channel.GetConfig();
        }

        public void Decapsulate(VpnChannel channel, VpnPacketBuffer encapBuffer, VpnPacketBufferList decapsulatedPackets,
            VpnPacketBufferList controlPacketsToSend)
        {
            channel.LogDiagnosticMessage("Decapsulate");
            var cfg = channel.GetConfig();
        }
    }
}
