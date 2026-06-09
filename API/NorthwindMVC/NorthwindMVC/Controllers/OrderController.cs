using Newtonsoft.Json;
using NorthwindMVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NorthwindMVC.Controllers
{
    public class OrderController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();

            string data =
                await client.GetStringAsync(
                "http://localhost:5000/api/orders/employee5");

            List<Order> orders =
                JsonConvert.DeserializeObject<List<Order>>(data);

            return View(orders);
        }
    }
}