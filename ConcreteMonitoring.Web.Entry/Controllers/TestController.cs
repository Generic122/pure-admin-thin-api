using Furion.DataEncryption;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcreteMonitoring.Web.Entry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            return Ok(new
            {

            });


        }

        // POST api/<TestController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var accessToken = JWTEncryption.Encrypt(
                new Dictionary<string, object>()
                {
                    { "UserId", 123456 }, // 存储Id
                    { "Account", user.UserName }, // 存储用户名
                }
            );
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken, 43200);

            var result = new Result();
            result.Success = true;
            result.Data.UserName = user.UserName;
            result.Data.Roles = "";
            result.Data.AccessToken = accessToken;
            result.Data.RefreshToken = refreshToken;

            return Ok(result);
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }

    public class User
    {
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
    }

    public class Result
    {
        public Result()
        {
            Data = new Data();
        }

        public bool Success { get; set; }
        public Data? Data { get; set; }
    }

    public class Data
    {
        public string? UserName { get; set; }
        public string? Roles { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
