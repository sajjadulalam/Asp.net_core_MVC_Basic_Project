using GtrTrainingHr.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GtrTrainingHr.web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly GtrDbContext _contex;

        public CompanyController(GtrDbContext context)
        {
            _contex = context;
        }
        // GET: CompanyController
        public async Task<ActionResult> Index()
        {
            var model = await _contex.companies.ToListAsync();
            return View(model);
        }

        // GET: CompanyController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var singlecompany = await _contex.companies.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (singlecompany == null)
                return NotFound();

            return View(singlecompany);
        }

        // GET: CompanyController/Create
        public async Task<ActionResult> CreateOrEdit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return View(new Company()
                {
                    Id = string.Empty
                });
            }
            else
            {
                var singlecompany = await _contex.companies.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (singlecompany == null)
                    return NotFound();
                return View(singlecompany);
            }


        }

        // POST: CompanyController/Create
        [HttpPost]
        public async Task<ActionResult> CreateOrEdit(Company model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                    await _contex.companies.AddAsync(model);
                }
                else
                {
                    var olddata = await _contex.companies.Where(x => x.Id == model.Id).SingleOrDefaultAsync();
                    if (olddata == null)
                        return NotFound();
                    olddata.IsInactive = model.IsInactive;
                    olddata.ComName = model.ComName;
                    olddata.Basic = model.Basic;
                    olddata.HRent = model.HRent;
                    olddata.Medical = model.Medical;


                }
                await _contex.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }

        }
        // POST: CompanyController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var olddata = await _contex.companies.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (olddata == null)
                    return NotFound();

                _contex.companies.Remove(olddata);
                await _contex.SaveChangesAsync();
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
