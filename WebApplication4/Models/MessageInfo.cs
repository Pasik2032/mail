using System;

namespace WebApplication4.Models
{
    public class MessageInfo
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Messege { get; set; }
        public string Subject { get; set; }
        public DateTime Timestamp { get; set; }

    }
}