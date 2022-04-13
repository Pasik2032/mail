using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Servise;

namespace WebApplication4.Controllers
{
    public class MessageController : Controller
    {

        private Storage _storage;
        public MessageController(Storage storage)
        {
            _storage = storage;

        }

        // GET
        [HttpPost("send-message")]
        public IActionResult SendMessage( [FromBody] SendMessageRequest req)
        {
            var message = new MessageInfo()
            {Id = _storage.messageInfos.Count + 1,
                SenderId= req.SenderId,
                ReceiverId = req.ReceiverId,
                Messege = req.Messege,
                Timestamp = DateTime.Now,
                Subject =  req.Subject

            };
            _storage.messageInfos.Add(message);
            return Ok(message);
        }

        [HttpGet("get-messages")]
        public IActionResult GetMessagesBySenderAndReceiver([FromQuery]string senderId, [FromQuery]string receiverId)
        {
            var result = _storage.messageInfos.Where(x => x.ReceiverId == receiverId && x.SenderId == senderId).ToList();

            return Ok(result);
        }

        [HttpGet("get-messages-sender")]
        public IActionResult GetMessagesBySender([FromQuery]string senderId)
        {
            var result = _storage.messageInfos.Where(x =>  x.SenderId == senderId).ToList();

            return Ok(result);
        }

        [HttpGet("get-messages-received")]
        public IActionResult GetMessagesByReceiver( [FromQuery]string receiverId)
        {
            var result = _storage.messageInfos.Where(x => x.ReceiverId == receiverId ).ToList();

            return Ok(result);
        }

    }
}