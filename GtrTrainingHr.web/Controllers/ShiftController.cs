using GtrTrainingHr.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GtrTrainingHr.web.Controllers
{
    public class ShiftController : Controller
    {
        private readonly GtrDbContext db;

        public ShiftController(GtrDbContext db)
        {
            this.db = db;
        }
        // GET: ShiftController
        public async Task<ActionResult> Index()
        {
            var companylist = await db.shifts.Include(x => x.Company).Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync();
            return View(companylist);
        }

        // GET: ShiftController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var singlecompany = await db.shifts.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (singlecompany == null)
                return NotFound();

            return View(singlecompany);
        }

        // GET: ShiftController/Create
        public async Task<ActionResult> CreateOrEdit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return View(new Shift()
                {
                    Id = string.Empty
                });
            }
            else
            {
                var singlecompany = await db.shifts.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (singlecompany == null)
                    return NotFound();
                return View(singlecompany);
            }


        }

        // POST: ShiftController/Create
        [HttpPost]
        public async Task<ActionResult> CreateOrEdit(Shift model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                    model.CompanyId = Request.Cookies["CompanyID"];
                    await db.shifts.AddAsync(model);
                }
                else
                {
                    var olddata = await db.shifts.Where(x => x.Id == model.Id).SingleOrDefaultAsync();
                    if (olddata == null)
                        return NotFound();
                    olddata.CompanyId = Request.Cookies["CompanyID"];
                    olddata.ShiftName = model.ShiftName;
                    olddata.ShiftIn = model.ShiftIn;
                    olddata.ShiftOut = model.ShiftOut;
                    olddata.ShiftLate = model.ShiftLate;
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
        // POST: ShiftController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var olddata = await db.shifts.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (olddata == null)
                    return NotFound();

                db.shifts.Remove(olddata);
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
