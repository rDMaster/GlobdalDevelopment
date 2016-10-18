using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace GlobalDevelopment.Helpers
{
    public static class NetworkHelper
    {
        public static int Port { get; set; }
        public static ManualResetEvent connectDone = new ManualResetEvent(false);
        public static ManualResetEvent sendDone = new ManualResetEvent(false);
        public static ManualResetEvent receiveDone = new ManualResetEvent(false);
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private static IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
        private static IPAddress[] Ipv4Addresses = Array.FindAll(Dns.GetHostEntry(String.Empty).AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);
        private static IPAddress[] Ipv6Addresses = Array.FindAll(Dns.GetHostEntry(String.Empty).AddressList, a => a.AddressFamily == AddressFamily.InterNetworkV6);
        public static IPAddress GetMyIpv6IPaddress()
        {
            return Ipv6Addresses[0];
        }
        public static IPAddress GetMyIpv4IPaddress()
        {
            return Ipv4Addresses[0];
        }
        public static IPEndPoint GetLocalEndPoint(int port)
        {
            return new IPEndPoint(GetMyIpv6IPaddress(), port);
        }
        public static Socket CreateDefaultIpv4TcpSocket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public static Socket CreateDefaultIpv6TcpSocket()
        {
            return new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
        }
        public static Socket CreateDefaultIpv4UdpSocket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        public static Socket CreateDefaultIpv6UdpSocket()
        {
            return new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
        }
        public static IPEndPoint CreateIpv4EndPoint(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            if (ep.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ep = new IPEndPoint(ep.Address.MapToIPv4(), ep.Port);
            }
            return ep;
        }
        public static IPEndPoint CreateIpv6EndPoint(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            if (ep.AddressFamily == AddressFamily.InterNetwork)
            {
                ep = new IPEndPoint(ep.Address.MapToIPv6(), ep.Port);
            }
            return ep;
        }
        public static IPEndPoint CreateIpv4EndPoint(IPAddress ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(ip, port);
            if (ep.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ep = new IPEndPoint(ep.Address.MapToIPv4(), ep.Port);
            }
            return ep;
        }
        public static IPEndPoint CreateIpv6EndPoint(IPAddress ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(ip, port);
            if (ep.AddressFamily == AddressFamily.InterNetwork)
            {
                ep = new IPEndPoint(ep.Address.MapToIPv6(), ep.Port);
            }
            return ep;
        }
        public static bool IsIpv6Available()
        {
            return Socket.OSSupportsIPv6;
        }
        public static IPEndPoint ConvertEndPointToIpv6(IPEndPoint ep)
        {
            if (ep.AddressFamily == AddressFamily.InterNetwork)
            {
                ep = new IPEndPoint(ep.Address.MapToIPv6(), ep.Port);
            }
            return ep;
        }
        public static IPEndPoint ConvertEndPointToIpv4(IPEndPoint ep)
        {
            if (ep.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ep = new IPEndPoint(ep.Address.MapToIPv4(), ep.Port);
            }
            return ep;
        }
        public static bool IsTpcPortAvailable(int port)
        {
            bool IsAvailable = true;
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
            {
                if (tcpi.LocalEndPoint.Port == port)
                {
                    IsAvailable = false;
                }
            }
            return IsAvailable;
        }
        public static bool IsIpv6Address(string ip)
        {
            bool isIpv6 = false;
            IPAddress Ip;
            if (IPAddress.TryParse(ip, out Ip))
            {
                if (Ip.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    return true;
                }
            }
            return isIpv6;
        }
        public static bool IsIpv4Address(string ip)
        {
            bool isIpv6 = false;
            IPAddress Ip;
            if (IPAddress.TryParse(ip, out Ip))
            {
                if (Ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return true;
                }
            }
            return isIpv6;
        }
    }
}
