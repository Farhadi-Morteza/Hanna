using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Server.Controllers
{
    public class AuthController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration) : base(unitOfWork)
        {
            _configuration = configuration;
        }
       
        private readonly IConfiguration _configuration;

        [HttpPost("Register")]
        public async Task<ActionResult<ViewModels.UserViewModel>> Register(ViewModels.UserViewModel entity)
        {
            if (entity == null)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }

            try
            {
                CreatePasswordHash(entity.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var newEntity =
                    new Models.User
                    {
                        Username = entity.Username,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        CompanyId = entity.Company.Id,
                        Admin = entity.Admin,
                        FullName = entity.FullName,
                    };

                await UnitOfWork.UserRepository.InsertAsync(newEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: newEntity);
            }
            catch (Exception)
            {

                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPost(template:"Login")]
        public async Task<ActionResult<string>> Login(ViewModels.UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user =
                await UnitOfWork.UserRepository.GetUserByUserName(request.Username);           

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            //if (user.Username.ToLower() != request.Username.ToLower())
            //{
            //    return BadRequest("User not found.");
            //}

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }



            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            System.Security.Claims.Claim claim;

            List<Claim> claims = new List<Claim>
            {
                //new Claim(type: JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                //new Claim(type: JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(type: ClaimTypes.Name,value: user.Username),
                new Claim(type: ClaimTypes.NameIdentifier, value: user.Id.ToString()),
                new Claim(type: ClaimTypes.Role, value: user.Admin == true? "Admin" : "User"),
                new Claim(type: ClaimTypes.NameIdentifier, value: user.Username),
                new Claim(nameof(user.CompanyId), value: user.CompanyId.ToString()),
                new Claim("UserId", value: user.Id.ToString()),

                 

                //if (user.Roles != null)
                //{
                //foreach (var role in user.Roles)
                //{
                //    claim =
                //        new System.Security.Claims.Claim(type: ClaimTypes.Role,value: role.ToString());

                //    claims.Add(item: claim);

                //}

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
