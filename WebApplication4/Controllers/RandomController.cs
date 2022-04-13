using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Servise;

namespace WebApplication4.Controllers
{
    public class RandomController : Controller
    {
        private Storage _storage;
        public RandomController(Storage storage)
        {
            _storage = storage;

        }
        // GET
        [HttpPost("create-users-random")]
        public IActionResult CreateUsersRandom()
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(100); i++)
            {
                UserInfo user = new UserInfo()
                {
                    Id = _storage.users.Count + 1,
                    Email = UserInfo.RandomString(random.Next(1,30)),
                    UserName = UserInfo.RandomString(random.Next(1,30))
                };
                _storage.users.Add(user);
            }
            for (int i = 0; i < random.Next(100); i++)
            {
                MessageInfo message = new MessageInfo()
                {Id = _storage.messageInfos.Count + 1,
                    SenderId= _storage.users[random.Next(_storage.users.Count)].Email,
                    ReceiverId = _storage.users[random.Next(_storage.users.Count)].Email,
                    Messege = UserInfo.RandomString(random.Next(1,100)),
                    Timestamp = DateTime.Now
                };
                _storage.messageInfos.Add(message);

            }
            return Ok();

        }
    }
}