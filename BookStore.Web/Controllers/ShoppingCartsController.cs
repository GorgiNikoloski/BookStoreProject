using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;
using System.Data;

using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using BookStore.Service.Interface;
using Microsoft.AspNetCore.Identity;
using GemBox.Document;
using System.IO;


namespace EShop.Web.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartsController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
            ViewBag.TotalPrice = _shoppingCartService.TotalPrice(userId);

            return View(_shoppingCartService.getShoppingCartDetails(userId??"")); 
        }

        // GET: ShoppingCarts/Details/5
     
        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> DeleteProductFromShoppingCart(Guid? productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var result = _shoppingCartService.deleteFromShoppingCart(userId, productId);

            return RedirectToAction("Index", "ShoppingCarts");
        }

        public async Task<IActionResult> Order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var result = _shoppingCartService.orderProducts(userId??"");

            return RedirectToAction("Index", "ShoppingCarts");
        }

        public async Task<IActionResult> Export()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var pdfBytes = _shoppingCartService.ExportShoppingCart(userId??"");

            return File(pdfBytes, new PdfSaveOptions().ContentType, "ShoppingCart.pdf");

 
        }


    }
}
