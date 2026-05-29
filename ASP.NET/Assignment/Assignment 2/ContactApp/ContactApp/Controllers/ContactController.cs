using System.Threading.Tasks;
using System.Web.Mvc;
using ContactApp.Models;
using ContactApp.Repositories;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        private IContactRepository repo = new ContactRepository();

        public async Task<ActionResult> Index()
        {
            var data = await repo.GetAllAsync();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await repo.CreateAsync(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}