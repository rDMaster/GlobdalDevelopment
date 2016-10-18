using GlobalDevelopment.Interfaces;
using GlobalDevelopment.Servers;
using System;
using Umbraco.Web.Mvc;
namespace GlobalDevelopment.Controllers
{
    public class ServicesSurfaceController : SurfaceController
    {
        public string StartServer(int port)
        {
            string result = "";
            try
            {
                ITcpServer Server = new TcpServer(false, port);
                Server.Start(500);
                foreach(var log in Server.Log)
                {
                    result = log.Message + " ";
                }
                return result;
            }
            catch(Exception er)
            {
                return result = er.Message;
            }
        }
    }
}