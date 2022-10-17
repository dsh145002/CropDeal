using CaseStudy.Dtos;
using CaseStudy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private DatabaseContext _databaseContext;
        public LoginController(DatabaseContext context)
        {
            _databaseContext = context;
        }
        
        

        //[HttpPost("register")]
        //[AllowAnonymous]
        //public async Task<ActionResult<User>> Register(CreateUserDto newUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new User();
        //        user.Name = newUser.Name;
        //        user.Email = newUser.Email;
        //        user.Phone = newUser.Phone;
        //        user.Status = newUser.Status;
        //        user.RoleId = (int)Enum.Parse(typeof(Role), newUser.Role);
        //        CreatePasswordHash(newUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
        //        user.PasswordSalt = passwordSalt;
        //        user.PasswordHash = passwordHash;


        //        //Address
        //        var address = new Address();
        //        address.Line = newUser.Line;
        //        address.City = newUser.City;
        //        address.State = newUser.State;

        //        user.Address = address;
                
        //        Account acc = new Account();
        //        //Account
        //        acc.AccountNumber = newUser.AccountNumber;
        //        acc.IFSCCode = newUser.IFSC;
        //        acc.BankName = newUser.BankName;
        //        user.Account = acc;

        //        _databaseContext.Users.Add(user);
        //        _databaseContext.SaveChanges();
        //        return Ok();
        //    }
        //    return BadRequest();
           
        //}
        [HttpPost]
        public ActionResult<string> Login(LoginDto loginData)
        {
            
            var user = _databaseContext.Users.Include("Role").SingleOrDefault(a => a.Email == loginData.username);
            if (user == null) return NotFound();
            else if(!VerifyPassword(loginData.password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }
            string token = GenerateToken(user);
            return token;
 
        }


        private string GenerateToken(User user)
        {
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim("email",user.Email),
                new Claim("role",user.Role.RoleName),
            };

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisisadummytokenkey"));
            var signCred = new SigningCredentials(symmetricKey,SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signCred);

            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private bool VerifyPassword(string password, byte[] passwordHash,byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return passHash.SequenceEqual(passwordHash);
            }
        }
    }
}
