using BookStore.Domain.Domain;
using BookStore.Domain.DTO;
using BookStore.Service.Implementation;
using BookStore.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Security.Claims;

namespace BookStore.Web.Controllers
{
    public class BookPublisherController : Controller
    {
        private readonly IBookPublisherService _bookPublisherService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;

        public BookPublisherController(IBookPublisherService bookPublisherService, IShoppingCartService shoppingCartService, IBookService bookService, IPublisherService publisherService)
        {
            _bookPublisherService = bookPublisherService;
            _shoppingCartService = shoppingCartService;
            _bookService = bookService;
            _publisherService = publisherService;
        }





        // GET: Tickets
        public IActionResult Index()
        {
            return View(_bookPublisherService.GetAll());
        }

        // GET: Tickets/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tmp = _bookPublisherService.GetDetails(id);

            if (tmp == null)
            {
                return NotFound();
            }

            return View(tmp);
        }

        // GET: Tickets/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.BookId = new SelectList(_bookService.GetAll(), "Id", "Title");
            ViewBag.PublisherId = new SelectList(_publisherService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("Id,BookId,PublisherId,Price")] BookPublisher bookPublisher)
        {
            if (ModelState.IsValid)
            {
                _bookPublisherService.CreateNew(bookPublisher);
                return RedirectToAction(nameof(Index));
            }
            return View(bookPublisher);
        }

        // GET: Tickets/Edit/5
        [Authorize]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tmp = _bookPublisherService.GetDetails(id);
            if (tmp == null)
            {
                return NotFound();
            }
            var books = _bookService.GetAll();
            ViewBag.BookId = books.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Title
            }).ToList();
            var publishers = _publisherService.GetAll();
            ViewBag.PublisherId = publishers.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();
            return View(tmp);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Guid id, [Bind("Id,BookId,PublisherId,Price")] BookPublisher bookPublisher)
        {
            if (id != bookPublisher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookPublisherService.UpdateExisting(bookPublisher);
                return RedirectToAction(nameof(Index));
            }
            return View(bookPublisher);
        }

        // GET: Tickets/Delete/5
        [Authorize]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tmp = _bookPublisherService.GetDetails(id);
            if (tmp == null)
            {
                return NotFound();
            }

            return View(tmp);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _bookPublisherService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]

        public IActionResult AddProductToCart(Guid Id)
        {
            var result = _shoppingCartService.getProductInfo(Id);
            if (result != null)
            {
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddProductToCart(AddToCartDTO model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _shoppingCartService.AddProductToShoppingCart(userId, model);

            if (result != null)
            {
                return RedirectToAction("Index", "ShoppingCarts");
            }
            else { return View(model); }
        }


    }
}

