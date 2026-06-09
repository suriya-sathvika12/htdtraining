using CountryAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CountryAPI.Controllers
{
    public class CountryController : ApiController
    {
        CountryContext db = new CountryContext();

        // GET ALL
        public IHttpActionResult Get()
        {
            return Ok(db.Countries.ToList());
        }

        // GET BY ID
        public IHttpActionResult Get(int id)
        {
            var country = db.Countries.Find(id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }

        // INSERT
        public IHttpActionResult Post(Country c)
        {
            db.Countries.Add(c);
            db.SaveChanges();

            return Ok("Inserted Successfully");
        }

        // UPDATE
        public IHttpActionResult Put(int id, Country c)
        {
            var country = db.Countries.Find(id);

            if (country == null)
                return NotFound();

            country.CountryName = c.CountryName;
            country.Capital = c.Capital;

            db.SaveChanges();

            return Ok("Updated Successfully");
        }

        // DELETE
        public IHttpActionResult Delete(int id)
        {
            var country = db.Countries.Find(id);

            if (country == null)
                return NotFound();

            db.Countries.Remove(country);

            db.SaveChanges();

            return Ok("Deleted Successfully");
        }
    }
}