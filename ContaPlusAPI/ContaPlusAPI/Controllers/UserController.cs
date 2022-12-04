using AutoMapper;
using ContaPlusAPI.Context;
using ContaPlusAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userList = await _context.Users.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(userList));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            var mappedUser =  _mapper.Map<UserDTO>(userObj);
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Email== userObj.Email && x.Password == userObj.Password);
           
            if(user == null)
            {
                return NotFound("User Not Found");
            }
            return Ok("Logged in succefully");
     
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] User userObj)
        {
            if(userObj==null)
            {
                return BadRequest();
            }

            if(userObj.Role==null)
            {
                userObj.Role = "user";
            }
            
            await _context.Users.AddAsync(userObj);
            await _context.SaveChangesAsync();
            return Ok("Registration succesfull");
        }

    }
}
