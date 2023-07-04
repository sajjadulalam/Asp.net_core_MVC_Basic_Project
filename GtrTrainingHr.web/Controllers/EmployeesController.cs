using GtrTrainingHr.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GtrTrainingHr.web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly GtrDbContext db;

        public EmployeesController(GtrDbContext db)
        {
            this.db = db;
        }
        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var companylist = await db.employees.Include(x => x.Company)
                .Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync();
            return View(companylist);
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var singlecompany = await db.employees.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (singlecompany == null)
                return NotFound();

            return View(singlecompany);
        }

        // GET: Employees/Create
        public async Task<ActionResult> CreateOrEdit(string id)
        {
            ViewBag.Desig = new SelectList(await db.designations.Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync(), "Id", "DesigName");
            ViewBag.Dept = new SelectList(await db.departments.Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync(), "Id", "DeptName");
            ViewBag.shift = new SelectList(await db.shifts.Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync(), "Id", "ShiftName");
            if (string.IsNullOrWhiteSpace(id))
            {
                return View(new Employee()
                {
                    Id = string.Empty
                });
            }
            else
            {
                var singlecompany = await db.employees.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (singlecompany == null)
                    return NotFound();
                return View(singlecompany);
            }


        }

        // POST: Employees/CreateOrEdit
        [HttpPost]

        public async Task<ActionResult> CreateOrEdit(Employee _context)
        {
            try
            {
                ViewBag.Desig = new SelectList(await db.designations.Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync(), "Id", "DesigName");
                ViewBag.Dept = new SelectList(await db.departments.Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync(), "Id", "DeptName");
                ViewBag.shift = new SelectList(await db.shifts.Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync(), "Id", "ShiftName");
                var salary = await db.companies.Where(x => x.Id == Request.Cookies["CompanyID"]).SingleOrDefaultAsync();
                if (salary == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (string.IsNullOrWhiteSpace(_context.Id))
                {
                    _context.Id = Guid.NewGuid().ToString();
                    _context.CompanyId = Request.Cookies["CompanyID"];
                    _context.Basic = _context.Gross * (salary.Basic / 100);
                    _context.HRent = _context.Gross * (salary.HRent / 100);
                    _context.Medical = _context.Gross * (salary.Medical / 100);
                    _context.Others = _context.Gross - (_context.Basic + _context.HRent + _context.Medical);
                    await db.employees.AddAsync(_context);
                }
                else
                {
                    var olddata = await db.employees.Where(x => x.Id == _context.Id).SingleOrDefaultAsync();
                    if (olddata == null)
                        return NotFound();
                    olddata.EmpName = _context.EmpName;
                    olddata.DeptId = _context.DeptId;
                    olddata.DesigId = _context.DesigId;
                    olddata.CompanyId = Request.Cookies["CompanyID"];
                    olddata.Gross = _context.Gross;
                    olddata.dtJoin = _context.dtJoin;
                    olddata.Basic = _context.Gross * (salary.Basic / 100);
                    olddata.HRent = _context.Gross * (salary.HRent / 100);
                    olddata.Medical = _context.Gross * (salary.Medical / 100);
                    olddata.Others = _context.Gross - (_context.Basic + _context.HRent + _context.Medical);
                    olddata.ShiftId = _context.ShiftId;
                }
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(_context);
            }
        }



        // POST: Employees/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var olddata = await db.employees.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (olddata == null)
                    return NotFound();

                db.employees.Remove(olddata);
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
