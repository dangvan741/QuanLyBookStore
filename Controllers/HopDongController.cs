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
    public class HopDongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HopDongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HopDong
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HopDong.Include(h => h.NhanVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HopDong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HopDong == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong
                .Include(h => h.NhanVien)
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // GET: HopDong/Create
        public IActionResult Create()
        {
            ViewData["TenNV"] = new SelectList(_context.NhanVien, "MaNV", "TenNV");
            return View();
        }

        // POST: HopDong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHD,TenNV,DateStart,DateEnd,Luong")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hopDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenNV"] = new SelectList(_context.NhanVien, "MaNV", "TenNV", hopDong.TenNV);
            return View(hopDong);
        }

        // GET: HopDong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HopDong == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong.FindAsync(id);
            if (hopDong == null)
            {
                return NotFound();
            }
            ViewData["TenNV"] = new SelectList(_context.NhanVien, "MaNV", "TenNV", hopDong.TenNV);
            return View(hopDong);
        }

        // POST: HopDong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHD,TenNV,DateStart,DateEnd,Luong")] HopDong hopDong)
        {
            if (id != hopDong.MaHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopDongExists(hopDong.MaHD))
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
            ViewData["TenNV"] = new SelectList(_context.NhanVien, "MaNV", "TenNV", hopDong.TenNV);
            return View(hopDong);
        }

        // GET: HopDong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HopDong == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong
                .Include(h => h.NhanVien)
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // POST: HopDong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HopDong == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HopDong'  is null.");
            }
            var hopDong = await _context.HopDong.FindAsync(id);
            if (hopDong != null)
            {
                _context.HopDong.Remove(hopDong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopDongExists(string id)
        {
          return (_context.HopDong?.Any(e => e.MaHD == id)).GetValueOrDefault();
        }
    }
}
