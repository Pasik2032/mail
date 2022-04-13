using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Servise;

namespace WebApplication4.Controllers
{
    public class UserController : Controller
    {

        private Storage _storage;
        public UserController(Storage storage)
        {
            _storage = storage;
        }
        // GET

        [HttpPost("create-user")]
        public IActionResult CreateUser( [FromBody] CreateUserRequest req)
        {
            var selectedTeams = from t in _storage.users
                where t.Email == req.Email
                select t;
            if (selectedTeams.ToList().Count != 0)
                return BadRequest();

            var user = new UserInfo()
                {Id = _storage.users.Count + 1,
                    Email = req.Email,
                    UserName = req.UserName
                };
            _storage.users.Add(user);
            return Ok(user);
        }




        [HttpGet("get-user-by-email")]
        public IActionResult GetUserByEmail([FromQuery] string email)
        {
            var result = _storage.users.Where(x => x.Email == email).ToList();
            if (result.Count == 0)
            {
                return NotFound(new {Message = $"Пользователь с Email = {email} не найден"});
            }

            return Ok(result.First());
        }


        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            return Ok(_storage.users.OrderBy(x => x.Email).ToList());
        }

        [HttpGet("get-all-users-limit-offset")]
        public IActionResult GetAllUsersLimitOffset(int Limit, int Offset)
        {
            if (Limit < 0 || Offset < 0 || Offset + Limit - 1 > _storage.users.Count)
                return BadRequest();
            return Ok(_storage.users.OrderBy(x => x.Email).ToList().Skip(Offset).Take(Limit));
        }
    }
}