using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GG
{
    class NetworkHandler
    {
        /// <summary> 
        /// 获取本地IP地址 
        /// </summary> 
        /// <returns>本地IP地址</returns> 
        public static string GetLocalIP()
        {
            string hostName = Dns.GetHostName();
            string localIP = "";
            IPHostEntry iPHostEntry = Dns.GetHostEntry(hostName);
            for (int i = 0; i < iPHostEntry.AddressList.Length; i++)
            {
                if (iPHostEntry.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = iPHostEntry.AddressList[i].ToString();
                }
            }

            return localIP;
        }

        /// <summary>
        /// 绑定端点
        /// </summary>
        /// <param name="IP">待绑定IP</param>
        /// <param name="port">待绑定端口号</param>
        /// <returns></returns>
        public static IPEndPoint BindEndPoint(string IP, int port)
        {
            //获取本地IP地址
            IPAddress IPAddress = IPAddress.Parse(IP);
            //将IP地址和端口号绑定到网络节点endpoint上 
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress, port);

            return ipEndPoint;
        }
    }
}
