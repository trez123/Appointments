using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Appointments.Models;

namespace Appointments.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly DoctorsDbContext _context;

        public DoctorsController(DoctorsDbContext context)
        {
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
              return _context.DoctorsAppointments != null ? 
                          View(await _context.DoctorsAppointments.ToListAsync()) :
                          Problem("Entity set 'DoctorsDbContext.DoctorsAppointments'  is null.");
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorsAppointments == null)
            {
                return NotFound();
            }

            var doctorsAppointment = await _context.DoctorsAppointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorsAppointment == null)
            {
                return NotFound();
            }

            return View(doctorsAppointment);
        }

        // GET: Doctors/Create
        public IActionResult Upsert(int id = 0)
        {
            if (id == 0)
                return View(new DoctorsAppointment());
            else
                return View(_context.DoctorsAppointments.Find(id));
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert([Bind("Id,FirstName,LastName,DOB,EmailAddress,PhoneNumber")] DoctorsAppointment doctorsAppointment)
        {
            if (ModelState.IsValid)
            {
                if (doctorsAppointment.Id == 0)
                {
                    doctorsAppointment.DOB = DateTime.Now;
                    _context.Add(doctorsAppointment);
                }
                else
                    _context.Update(doctorsAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorsAppointment);
        }

      

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorsAppointments == null)
            {
                return NotFound();
            }

            var doctorsAppointment = await _context.DoctorsAppointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorsAppointment == null)
            {
                return NotFound();
            }

            return View(doctorsAppointment);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorsAppointments == null)
            {
                return Problem("Entity set 'DoctorsDbContext.DoctorsAppointments'  is null.");
            }
            var doctorsAppointment = await _context.DoctorsAppointments.FindAsync(id);
            if (doctorsAppointment != null)
            {
                _context.DoctorsAppointments.Remove(doctorsAppointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorsAppointmentExists(int id)
        {
          return (_context.DoctorsAppointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
