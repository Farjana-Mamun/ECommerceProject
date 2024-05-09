using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceProject.Data;
using ECommerceProject.Models;

namespace ECommerceProject.Controllers
{
    public class SaleDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SaleDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SaleDetail.Include(s => s.Product).Include(s => s.SalesOrder).Include(s => s.Unit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SaleDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await _context.SaleDetail
                .Include(s => s.Product)
                .Include(s => s.SalesOrder)
                .Include(s => s.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleDetail == null)
            {
                return NotFound();
            }

            return View(saleDetail);
        }

        // GET: SaleDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode");
            ViewData["SalesOrderId"] = new SelectList(_context.Set<SalesOrder>(), "Id", "InvoiceNumber");
            ViewData["UnitId"] = new SelectList(_context.Set<Unit>(), "Id", "UnitName");
            return View();
        }

        // POST: SaleDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalesOrderId,ProductId,UnitId,UnitPrice,SaleQuantity")] SaleDetail saleDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode", saleDetail.ProductId);
            ViewData["SalesOrderId"] = new SelectList(_context.Set<SalesOrder>(), "Id", "InvoiceNumber", saleDetail.SalesOrderId);
            ViewData["UnitId"] = new SelectList(_context.Set<Unit>(), "Id", "UnitName", saleDetail.UnitId);
            return View(saleDetail);
        }

        // GET: SaleDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await _context.SaleDetail.FindAsync(id);
            if (saleDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode", saleDetail.ProductId);
            ViewData["SalesOrderId"] = new SelectList(_context.Set<SalesOrder>(), "Id", "InvoiceNumber", saleDetail.SalesOrderId);
            ViewData["UnitId"] = new SelectList(_context.Set<Unit>(), "Id", "UnitName", saleDetail.UnitId);
            return View(saleDetail);
        }

        // POST: SaleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalesOrderId,ProductId,UnitId,UnitPrice,SaleQuantity")] SaleDetail saleDetail)
        {
            if (id != saleDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleDetailExists(saleDetail.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductCode", saleDetail.ProductId);
            ViewData["SalesOrderId"] = new SelectList(_context.Set<SalesOrder>(), "Id", "InvoiceNumber", saleDetail.SalesOrderId);
            ViewData["UnitId"] = new SelectList(_context.Set<Unit>(), "Id", "UnitName", saleDetail.UnitId);
            return View(saleDetail);
        }

        // GET: SaleDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await _context.SaleDetail
                .Include(s => s.Product)
                .Include(s => s.SalesOrder)
                .Include(s => s.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleDetail == null)
            {
                return NotFound();
            }

            return View(saleDetail);
        }

        // POST: SaleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleDetail = await _context.SaleDetail.FindAsync(id);
            if (saleDetail != null)
            {
                _context.SaleDetail.Remove(saleDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleDetailExists(int id)
        {
            return _context.SaleDetail.Any(e => e.Id == id);
        }
    }
}
