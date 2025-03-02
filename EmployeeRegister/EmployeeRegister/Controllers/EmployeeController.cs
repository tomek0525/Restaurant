using EmployeeRegister.Data;
using EmployeeRegister.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeRegister.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DB _context;

        public EmployeeController(DB context)
        {
            _context = context;
        }

        // list
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.Include(e => e.OrganizationalUnit).ToListAsync();
            return View(employees);
        }

        // create
        public IActionResult Create()
        {
            var organizationalUnits = _context.Organizations.ToList();
            var supervisors = _context.Employees.ToList();

            // Ha nincs szervezeti egység vagy dolgozó, ne dobjon hibát a nézet
            ViewBag.Organizations = organizationalUnits.Any()
                ? new SelectList(organizationalUnits, "Id", "Name")
                : new SelectList(new List<Organization>(), "Id", "Name");

            ViewBag.Supervisors = supervisors.Any()
                ? new SelectList(supervisors, "Id", "Name")
                : new SelectList(new List<Employee>(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid) //validálás, értékelési szempont volt
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Ha az adat érvénytelen, újra betöltjük a listákat
            var organizationalUnits = _context.Organizations.ToList();
            var supervisors = _context.Employees.ToList();

            ViewBag.Organizations = organizationalUnits.Any()
                ? new SelectList(organizationalUnits, "Id", "Name")
                : new SelectList(new List<Organization>(), "Id", "Name");

            ViewBag.Supervisors = supervisors.Any()
                ? new SelectList(supervisors, "Id", "Name")
                : new SelectList(new List<Employee>(), "Id", "Name");

            return View(employee);
        }

        // edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        //delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
