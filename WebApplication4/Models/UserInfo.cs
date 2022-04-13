using System;
using System.Linq;

namespace WebApplication4.Models
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Id  { get; set; }
        public static string RandomString(int length)
        {
                    Random random = new Random();
                    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    return new string(Enumerable.Repeat(chars, length)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}