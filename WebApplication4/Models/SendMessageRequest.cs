using System;

namespace WebApplication4.Models
{
    public class SendMessageRequest
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Messege { get; set; }
        public string Subject{ get; set; }

    }
}