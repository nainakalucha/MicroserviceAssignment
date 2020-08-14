using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> Get()
        {
            var response =  "[{\"orderId\": 1,\"orderAmount\": 450,\"orderDate\": \"20-Apr-2020\"},{\"orderId\": 2,\"orderAmount\": 900,\"orderDate\": \"25-Apr-2020\"}]";
            var result = JsonConvert.DeserializeObject<object>(response);
            return result;
        }
    }
}