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
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.Brand).Include(p => p.Configuration).Include(p => p.ProductModel).Include(p => p.SubCategories);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Configuration)
                .Include(p => p.ProductModel)
                .Include(p => p.SubCategories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "BrandName");
            ViewData["ConfigurationId"] = new SelectList(_context.Configuration, "Id", "ConfigurationName");
            ViewData["ProductModelId"] = new SelectList(_context.Set<ProductModel>(), "Id", "ModelName");
            ViewData["SubCategoryId"] = new SelectList(_context.Set<SubCategory>(), "Id", "SubCatategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubCategoryId,BrandId,ProductModelId,ConfigurationId,ProductCode,IsActive,SalePrice,Weight,WarnPoint,ProductWarranty,CreateDate,VAT,UpdateDate,ShortDescription,LongDescription,ProductName,DiscountInPercent,DiscountAmount")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "BrandName", product.BrandId);
            ViewData["ConfigurationId"] = new SelectList(_context.Configuration, "Id", "ConfigurationName", product.ConfigurationId);
            ViewData["ProductModelId"] = new SelectList(_context.Set<ProductModel>(), "Id", "ModelName", product.ProductModelId);
            ViewData["SubCategoryId"] = new SelectList(_context.Set<SubCategory>(), "Id", "SubCatategoryName", product.SubCategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "BrandName", product.BrandId);
            ViewData["ConfigurationId"] = new SelectList(_context.Configuration, "Id", "ConfigurationName", product.ConfigurationId);
            ViewData["ProductModelId"] = new SelectList(_context.Set<ProductModel>(), "Id", "ModelName", product.ProductModelId);
            ViewData["SubCategoryId"] = new SelectList(_context.Set<SubCategory>(), "Id", "SubCatategoryName", product.SubCategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubCategoryId,BrandId,ProductModelId,ConfigurationId,ProductCode,IsActive,SalePrice,Weight,WarnPoint,ProductWarranty,CreateDate,VAT,UpdateDate,ShortDescription,LongDescription,ProductName,DiscountInPercent,DiscountAmount")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "BrandName", product.BrandId);
            ViewData["ConfigurationId"] = new SelectList(_context.Configuration, "Id", "ConfigurationName", product.ConfigurationId);
            ViewData["ProductModelId"] = new SelectList(_context.Set<ProductModel>(), "Id", "ModelName", product.ProductModelId);
            ViewData["SubCategoryId"] = new SelectList(_context.Set<SubCategory>(), "Id", "SubCatategoryName", product.SubCategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Configuration)
                .Include(p => p.ProductModel)
                .Include(p => p.SubCategories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
