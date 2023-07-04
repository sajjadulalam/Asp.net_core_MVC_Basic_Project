using GtrTrainingHr.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GtrTrainingHr.web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly GtrDbContext db;

        public DepartmentController(GtrDbContext db)
        {
            this.db = db;
        }
        // GET: Department
        public async Task<ActionResult> Index()
        {
            //var companylist = await db.departments.Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync();
            var companylist = await db.departments.Include(x => x.Company).Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync();
            return View(companylist);
        }

        // GET: Department/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var singlecompany = await db.departments.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (singlecompany == null)
                return NotFound();

            return View(singlecompany);
        }

        // GET: Department/Create
        public async Task<ActionResult> CreateOrEdit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return View(new Department()
                {
                    Id = string.Empty
                });
            }
            else
            {
                var singlecompany = await db.departments.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (singlecompany == null)
                    return NotFound();
                return View(singlecompany);
            }


        }

        // POST: Department/CreateOrEdit
        [HttpPost]

        public async Task<ActionResult> CreateOrEdit(Department model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                    model.CompanyId = Request.Cookies["CompanyID"];
                    await db.departments.AddAsync(model);
                }
                else
                {
                    var olddata = await db.departments.Where(x => x.Id == model.Id).SingleOrDefaultAsync();
                    if (olddata == null)
                        return NotFound();
                    olddata.CompanyId = Request.Cookies["CompanyID"];
                    olddata.DeptName = model.DeptName;
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

        

        // POST: Department/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var olddata = await db.departments.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (olddata == null)
                    return NotFound();

                db.departments.Remove(olddata);
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
