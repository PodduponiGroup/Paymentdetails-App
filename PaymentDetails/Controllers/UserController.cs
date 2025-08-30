using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaymentDetails.DTO;
using PaymentDetails.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PaymentDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
       
        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var v =await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return Ok(v);
        }
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await _dbContext.User.ToListAsync());
        //}
        //[HttpPost("getUser")]
        //public async Task<IActionResult> GetUser([FromBody] UserDto userDto)
        //{
        //    var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Email == userDto.Email && x.PasswordHash == userDto.Password);
        //    return Ok(user);
        //}
        
       
    }
}
