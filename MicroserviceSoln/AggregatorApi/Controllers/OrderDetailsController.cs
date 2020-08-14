using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AggregatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var result = "";
            result += "\"userDetails\":"  + getUserDetails();
            result += "\"orders\":" + getOrderDetails();
            return result;
        }
        private string getUserDetails()
        {
            var a = Environment.GetEnvironmentVariable("User_URL");
            if (a == null || a == String.Empty)
            {
                a = "https://localhost:44312";
            }
            var respone = GetAsyncMethodCall(a + "/api/user");
            if (respone.Result.IsSuccessStatusCode)
            {
                var result = respone.Result.Content.ReadAsStringAsync().Result;
                return result;
            }
            return "";
        }
        private string getOrderDetails()
        {
            var a = Environment.GetEnvironmentVariable("Orders_URL");
            if (a == null || a== String.Empty)
            {
                a = "https://localhost:44313";
            }
            var respone = GetAsyncMethodCall(a + "/api/orders");
            if (respone.Result.IsSuccessStatusCode)
            {
                var result = respone.Result.Content.ReadAsStringAsync().Result;
                return result;
            }
            return "";
        }
        private async static Task<HttpResponseMessage> GetAsyncMethodCall(string _apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                var a =  await client.GetAsync(_apiUrl);
                return a;
            }
        }
    }
}