﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GG
{
    public partial class Chatroom : Form
    {
        public static string localUser; //本地用户
        public string remoteUser; //远程用户
        protected int serverPort = 1; //服务器开启的端口号，暂定为1
        protected int clientPort = 2; //客户端开启的端口号，client暂定为2,client1暂定为3
        private static string serverIP = "10.66.93.241"; //服务器IP地址
        private static string localIP; //本地IP地址
        private static IPEndPoint remoteEndPoint; //服务器IP端点
        private static IPEndPoint localEndPoint; //本地客户端IP端点

        Socket socketWatch = null; //负责监听服务器的套接字，此时客户端为接收方
        Thread threadWatch = null; //负责监听服务器的线程，此时客户端为接收方
        Socket socConnection = null; //创建一个负责和服务器通信的套接字 
        Socket socketSender = null;  //负责发送消息的套接字

        public Chatroom(string user, string friend)
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;

            localUser = user;
            remoteUser = friend;
            updateContent();

            localIP = NetworkHandler.GetLocalIP(); //获取本地IP
            remoteEndPoint = NetworkHandler.BindEndPoint(serverIP, serverPort); //获取服务器端点
            localEndPoint = NetworkHandler.BindEndPoint(localIP, clientPort); //获取本地端点

            EstablishSenderService(serverIP);
            EstablishReceiverService(localIP);
        }

        public void updateContent()
        {
            DataTable messageTable = DatabaseHandler.SelectMsg(localUser, remoteUser).Copy();
            foreach (DataRow row in messageTable.Rows)
            {
                textBox3.Text += row[0].ToString() + ": " + row[3].ToString() + "\r\n" + row[2] + "\r\n";
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            SendMsg(localUser, "text", textBox4.Text, remoteUser, CommonHandler.GetCurrentTime().ToString());
        }

        /// <summary>
        /// 与服务器建立连接，准备发送消息
        /// </summary>
        /// <param name="serverAddress">服务器地址</param>
        private void EstablishSenderService(string serverIP)
        {
            //负责发送消息的套接字，包含3个参数(IP4寻址协议,流式连接,TCP协议)
            socketSender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //连接到服务器
                socketSender.Connect(remoteEndPoint);
            }
            catch (SocketException e)
            {
                label4.Text = "Cannot connect!";
            }
        }

        /// <summary>
        /// 打开主机端口，准备接收服务器传来的消息
        /// </summary>
        /// <param name="clientIP">本地客户端IP地址</param>
        public void EstablishReceiverService(string clientIP)
        {
            //用于监听服务器信息的套接字，包含3个参数(IP4寻址协议,流式连接,TCP协议)
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //监听绑定的网络节点
            socketWatch.Bind(localEndPoint);
            //将套接字的监听队列长度限制为20
            socketWatch.Listen(20);
            //创建一个监听线程 
            threadWatch = new Thread(WatchConnecting);
            //将窗体线程设置为与后台同步
            threadWatch.IsBackground = true;
            //启动线程
            threadWatch.Start();
        }

        private void WatchConnecting()
        {
            while (true)  //持续不断监听服务器发来的请求
            {
                socConnection = socketWatch.Accept();
                //创建一个通信线程 
                ParameterizedThreadStart pts = new ParameterizedThreadStart(RecMsg);
                Thread thr = new Thread(pts);
                thr.IsBackground = true;
                //启动线程
                thr.Start(socConnection);
            }
        }

        private void RecMsg(object socketReceiverPara)
        {
            Socket socketListener = socketReceiverPara as Socket;
            while (true)
            {
                //创建一个内存缓冲区 其大小为1024*1024字节  即1M
                byte[] arrRecMsg = new byte[1024 * 1024];
                //将接收到的信息存入到内存缓冲区,并返回其字节数组的长度
                int length = socketListener.Receive(arrRecMsg);
                //将机器接受到的字节数组转换为人可以读懂的字符串
                string strRecMsg = Encoding.UTF8.GetString(arrRecMsg, 0, length);
                Dictionary<string, string> messageSet = new Dictionary<string, string>(CommonHandler.ResolveMessage(strRecMsg));
                textBox3.Text += messageSet["sender"] + ": " + messageSet["time"] + "\r\n" + messageSet["value"] + "\r\n";
            }
        }

        /// <summary>
        /// 发送字符串信息到服务器的方法
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="content_type">发送内容类型</param>
        /// <param name="value">发送内容</param>
        /// <param name="target">接收者</param>
        private void SendMsg(string sender, string content_type, string value, string target, string time)
        {
            string sendMsg = CommonHandler.CreateXmlString(sender, content_type, value, time, target);
            //将输入的内容字符串转换为机器可以识别的字节数组
            byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);
            //调用发送信息套接字发送字节数组
            socketSender.Send(arrSendMsg);
            textBox3.Text += sender + ": " + time + "\r\n" + value + "\r\n";
        }

        private void Chatroom_FormClosed(object sender, FormClosedEventArgs e)
        {
            socketSender.Disconnect(false);
            Application.Exit();
        }
    }
}
