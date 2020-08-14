using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<User> Get()
        {           
            var response =  "{\"name\": \"John\",  \"age\": \"23\",\"email\": \"john.abc@google.com\"}";
            var user = JsonConvert.DeserializeObject<User>(response);
            return user;
        }
    }
}