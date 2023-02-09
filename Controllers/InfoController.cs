using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KubernetesServer.SharedExtensions
{

    public class ServerInfo  
    {
        public string Version { get; set; } = "1.0";
        public bool IsLive { get; set; } = false;
        public string Server { get; set; } = "localhost";
        public int Status { get; set; } = 1;
        public string Message { get; set; } = "Online";
        public string DatabaseServer { get; set; } = "localhost";
        public string DatabaseName { get; set; } = "DB";
        public string DatabaseStatus { get; set; } = "connected";
        public string ClientVersion { get; set; } = "0.0.1";
        public DateTime? FirstOnlineTime { get; set; } 
        public DateTime? LastOfflineTime { get; set; }
        public Dictionary<string, string> Attributes { get; set; }

    }


    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class InfoController : Controller
    {
        [HttpGet()]
        public  ServerInfo GetServerInfo()
        {
            ServerInfo info = new ServerInfo();
            info.Version = "1.0";
            //info.Attributes = new Dictionary<string, string>();
            //info.Attributes.Add("url", WebApiConfig.OfficeFileServerUrl);
            //info.Attributes.Add("version", OFServerInfo.Version);
            //info.Attributes.Add("server", OFServerInfo.Server);
            //info.Attributes.Add("databaseserver", OFServerInfo.DatabaseServer);
            //info.Attributes.Add("databasename", OFServerInfo.DatabaseName);

            return info;
        }

    }
}