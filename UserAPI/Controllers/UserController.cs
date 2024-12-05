using Microsoft.AspNetCore.Mvc;
using AdminPartShop.Models;
using System.Text.RegularExpressions;
using System.Diagnostics.Tracing;
using System.Windows;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<User> UserID(int id)
        {
            var users = JsonUser.GetUsers();
            var user_id = users.FirstOrDefault(u => u.Id == id);
            return user_id == null ? NotFound("Пользователь не найден.") : Ok(user_id);
        }

        [HttpGet("UserAll")]
        public ActionResult<User> UserAll()
        {
            var user_all = JsonUser.GetUsers();
            if (user_all == null || user_all.Count == 0)
            {
                return NotFound("Пользователи не найдены.");
            }
            return Ok(user_all);
        }

        [HttpPost("Register")]
        public ActionResult<User> Register(User user)
        {
            List<User> users = JsonUser.GetUsers();
            var userCheck = users.FirstOrDefault(u => u.Email.ToLower() == user.Email.ToLower());

            if (userCheck != null)
            {
                return BadRequest("Пользователь с такой почтой уже существует!");
            }   

            int maxId = users.Count > 0 ? users.Max(u => u.Id) : 0;
            user.Id = maxId + 1;

            users.Add(user);
            JsonUser.SaveUsers(users);

            return Ok("Вы успешно зарегистрировались");
        }

        [HttpPost("Authorization")]
        public ActionResult<User> Authorization([FromBody] UserLoginModel loginModel)
        {
            var users = JsonUser.GetUsers();
            var user_check = users.FirstOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);

            return user_check == null ? NotFound("Пользователь не найден.") : Ok(user_check);
        }
    }
}
