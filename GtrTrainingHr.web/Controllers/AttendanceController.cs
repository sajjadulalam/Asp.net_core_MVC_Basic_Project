using GtrTrainingHr.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GtrTrainingHr.web.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly GtrDbContext db;

        public AttendanceController(GtrDbContext db)
        {
            this.db=db;
        }



        // GET: AttendanceController
        public async Task<ActionResult> Index()
        {
            var companylist=  await db.attendances.Where(x => x.Id == Request.Cookies["CompanyID"]).ToListAsync();
            return View(companylist);
        }



        // GET: AttendanceController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var singlecompany = await db.attendances.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (singlecompany == null)
                return NotFound();
            return View(singlecompany);
        }



        // GET: AttendanceController/Create
        public async Task<ActionResult> CreateOrEdit( string id)
        {
            ViewBag.Desig = new SelectList(await db.designations.Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync(), "Id", "DesigName");
            ViewBag.Dept = new SelectList(await db.departments.Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync(), "Id", "DeptName");
            ViewBag.shift = new SelectList(await db.shifts.Where(x => x.CompanyId == Request.Cookies["CompanyID"]).ToListAsync(), "Id", "ShiftName");
            if (string.IsNullOrWhiteSpace(id))
            {
                return View(new Attendance()
                {
                    Id = string.Empty
                });
            }
            else
            {
                var singlecompany = await db.attendances.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (singlecompany == null)
                    return NotFound();
                return View(singlecompany);
            }
        }

        // POST: AttendanceController/Create
        [HttpPost]
        public async Task<ActionResult> CreateOrEdit(Attendance model)
        {
            ViewBag.EmpId = new SelectList(await db.employees
                 .Where(x => x.CompanyId == Request.Cookies["CompanyID"])
                 .ToListAsync(), "Id", "EmpName");
            var salary = await db.companies.Where(x => x.Id == Request.Cookies["CompanyID"]).SingleOrDefaultAsync();
            if (salary == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var employeeshift = await db.employees.Where(x => x.Id == model.EmpId).Select(x => x.ShiftId).SingleOrDefaultAsync();
            var shift = await db.shifts.Where(x => x.Id == employeeshift).SingleOrDefaultAsync();
            try
            {
                if (model.InTime.TimeOfDay > shift.ShiftLate.TimeOfDay)
                {
                    model.AttStatus = "L";
                }
                if (model.InTime.TimeOfDay <= shift.ShiftIn.TimeOfDay)
                {
                    model.AttStatus = "P";
                }
                if (model.dtDate.DayOfWeek == DayOfWeek.Friday)
                {
                    model.AttStatus = "W";
                }
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                    model.CompanyId = Request.Cookies["CompanyID"];

                    await db.attendances.AddAsync(model);
                }
                else
                {
                    var olddata = await db.attendances.Where(x => x.Id == model.Id).SingleOrDefaultAsync();
                    if (olddata == null)
                        return NotFound();
                    olddata.InTime = model.InTime;
                    olddata.OutTime = model.OutTime;
                    olddata.dtDate = model.dtDate;
                    olddata.AttStatus = model.AttStatus;
                    olddata.CompanyId = Request.Cookies["CompanyID"];
                    olddata.EmpId = model.EmpId;

                    //olddata.AttStatus = model.Gross * (salary.HRent / 100);




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

        // POST: AttendenceController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var olddata = await db.attendances.Where(x => x.Id == id).SingleOrDefaultAsync();
                if (olddata == null)
                    return NotFound();

                db.attendances.Remove(olddata);
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
