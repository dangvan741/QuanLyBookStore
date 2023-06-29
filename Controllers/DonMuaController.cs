using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyBookStore.Data;
using QuanLyBookStore.Models;

namespace QuanLyBookStore.Controllers
{
    public class DonMuaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonMuaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DonMua
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DonMua.Include(d => d.Sach);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DonMua/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DonMua == null)
            {
                return NotFound();
            }

            var donMua = await _context.DonMua
                .Include(d => d.Sach)
                .FirstOrDefaultAsync(m => m.MaDM == id);
            if (donMua == null)
            {
                return NotFound();
            }

            return View(donMua);
        }

        // GET: DonMua/Create
        public IActionResult Create()
        {
            ViewData["TenSach"] = new SelectList(_context.Sach, "MaSach", "TenSach");
            return View();
        }

        // POST: DonMua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDM,TenKhach,TenSach,DateBuy")] DonMua donMua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donMua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenSach"] = new SelectList(_context.Sach, "MaSach", "TenSach", donMua.TenSach);
            return View(donMua);
        }

        // GET: DonMua/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DonMua == null)
            {
                return NotFound();
            }

            var donMua = await _context.DonMua.FindAsync(id);
            if (donMua == null)
            {
                return NotFound();
            }
            ViewData["TenSach"] = new SelectList(_context.Sach, "MaSach", "TenSach", donMua.TenSach);
            return View(donMua);
        }

        // POST: DonMua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDM,TenKhach,TenSach,DateBuy")] DonMua donMua)
        {
            if (id != donMua.MaDM)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donMua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonMuaExists(donMua.MaDM))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenSach"] = new SelectList(_context.Sach, "MaSach", "TenSach", donMua.TenSach);
            return View(donMua);
        }

        // GET: DonMua/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DonMua == null)
            {
                return NotFound();
            }

            var donMua = await _context.DonMua
                .Include(d => d.Sach)
                .FirstOrDefaultAsync(m => m.MaDM == id);
            if (donMua == null)
            {
                return NotFound();
            }

            return View(donMua);
        }

        // POST: DonMua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DonMua == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DonMua'  is null.");
            }
            var donMua = await _context.DonMua.FindAsync(id);
            if (donMua != null)
            {
                _context.DonMua.Remove(donMua);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonMuaExists(string id)
        {
          return (_context.DonMua?.Any(e => e.MaDM == id)).GetValueOrDefault();
        }
    }
}
