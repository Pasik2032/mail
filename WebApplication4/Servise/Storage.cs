using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication4.Models;

namespace WebApplication4.Servise
{
    public class Storage
    {
        public List<UserInfo> users = new List<UserInfo>();
        public List<MessageInfo> messageInfos = new List<MessageInfo>();


    }
}