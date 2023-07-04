using GtrTrainingHr.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GtrTrainingHr.web.Controllers
{
    public class DesignationController : Controller
    {
        private readonly GtrDbContext db;

        public DesignationController(GtrDbContext db)
        {
            this.db = db;
        }
        // GET: Designation
        public async Task<ActionResult> Index()
        {
            var companylist = await db.designations.Include(x => x.Company).Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync();
            return View(companylist);
        }

        // GET: Designation/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var singlecompany = await db.designations.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (singlecompany == null)
                return NotFound();

            return View(singlecompany);
        }

        // GET: Designation/Create
        public async Task<ActionResult> CreateOrEdit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return View(new Designation()
                {
                    Id = string.Empty
                });
            }
            else
            {
                var singlecompany = await db.designations.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (singlecompany == null)
                    return NotFound();
                return View(singlecompany);
            }


        }

        // POST: Designation/CreateOrEdit
        [HttpPost]

        public async Task<ActionResult> CreateOrEdit(Designation model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                    model.CompanyId = Request.Cookies["CompanyID"];
                    await db.designations.AddAsync(model);
                }
                else
                {
                    var olddata = await db.designations.Where(x => x.Id == model.Id).SingleOrDefaultAsync();
                    if (olddata == null)
                        return NotFound();
                    olddata.CompanyId = Request.Cookies["CompanyID"];
                    olddata.DesigName = model.DesigName;
                }
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }
        }

        

        // POST: Designation/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var olddata = await db.designations.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (olddata == null)
                    return NotFound();

                db.designations.Remove(olddata);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }
        }
    }
}
