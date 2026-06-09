using System.Web.Http;

namespace NorthwindAPI.Controllers
{
    public class CustomersController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        [Route("api/customers/{country}")]
        public IHttpActionResult GetCustomer(string country)
        {
            var result = db.GetCustomersByCountry(country);

            return Ok(result);
        }
    }
}