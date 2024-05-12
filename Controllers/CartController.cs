using ECommerceProject.Data;
using ECommerceProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ECommerceProject.Controllers
{
    
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddToCart(int pid, decimal qty)
        {
            var extcart = HttpContext.Session.GetObject<Cart>("MyCart");
            if (extcart == null)
            {
                var prod = _context.Product.FirstOrDefault(x=> x.Id == pid);
                if (prod != null)
                {
                    ProductVM p = new ProductVM();
                    p.ProductId = pid;
                    p.ProductName = prod.ProductName;
                    p.UnitName = prod.Unit.UnitName;
                    p.SaleQuantity=qty;
                    p.UnitPrice = prod.SalePrice;
                    p.SubTotal = prod.SalePrice * qty;

                    Cart c = new Cart();
                    HttpContext.Session.SetObject<Cart>("MyCart", c);
                    return Json(new { flag = "1", msg = "Product is added in empty cart" });
                }
                else
                {
                    return Json(new { flag = "0", msg = "Product is invalid" });
                }
            }
            else
            {
                var prod1 = _context.Product.FirstOrDefault(x => x.Id == pid);
                if (prod1 != null)
                {
                    var prod2 = extcart.Products.FirstOrDefault(x => x.ProductId == pid);
                    if (prod2 == null)
                    {
                        ProductVM p = new ProductVM();
                        p.ProductId = pid;
                        p.ProductName = prod1.ProductName;
                        p.UnitName = prod1.Unit.UnitName;
                        p.SaleQuantity = qty;
                        p.UnitPrice = prod1.SalePrice;
                        p.SubTotal = prod1.SalePrice * qty;

                        Cart c = new Cart();
                        HttpContext.Session.SetObject<Cart>("MyCart", c);
                        return Json(new { flag = "1", msg = "Product is added in existing cart" });
                    }
                    else
                    {
                        prod2.SaleQuantity += 1;
                        HttpContext.Session.SetObject<Cart>("MyCart", extcart);
                        return Json(new { flag = "1", msg = "Product is upded in the existing cart" });
                    }
                }
                else
                {
                    return Json(new { flag = "0", msg = "Product is invalid" });
                }
            }
        }

        [HttpPost]
        public JsonResult RemoveItem(int pid)
        {
            var extcart = HttpContext.Session.GetObject<Cart>("MyCart");
            if (extcart != null)
            {
                var prod = extcart.Products.FirstOrDefault(x => x.ProductId == pid);
                if (prod != null)
                {
                    extcart.Products.Remove(prod);
                    HttpContext.Session.SetObject<Cart>("MyCart", extcart);
                    return Json(new { flag = "1", msg = "Product is removed successfully" });
                }
                else
                {
                    return Json(new { flag = "0", msg = "Product is invalid" });
                }
            }
            else
            {
                return Json(new { flag = "0", msg = "Product is invalid" });
            }
        }
        public IActionResult WishList()
        {
            return View();
        }
        public IActionResult ShoppingCart()
        {
            return View();
        }
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}
