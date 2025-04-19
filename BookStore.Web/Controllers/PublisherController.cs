using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Repository;
using BookStore.Domain.Domain;
using BookStore.Repository.Interface;
using BookStore.Service.Interface;

namespace WebApplication1.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        private readonly IBookService _bookService;

        public PublisherController(IPublisherService publisherService, IBookService bookService)
        {
            _publisherService = publisherService;
            _bookService = bookService;
        }

        // GET: Publishers
        public IActionResult Index()
        {
            var publishers = _publisherService.GetAll();
            return View(publishers);
        }

        // GET: Publishers/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _publisherService.GetDetails(id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
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
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Country,Address,Id")] Publisher publisher)
        {

            publisher.Id = Guid.NewGuid();
            publisher.BookPublishers = new List<BookPublisher>();
            _publisherService.CreateNew(publisher);
            return RedirectToAction(nameof(Index));

        }

        // GET: Publishers/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _publisherService.GetDetails(id);

            if (publisher == null)
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

            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Country,Address,Id")] Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return NotFound();
            }


            try
            {
                _publisherService.UpdateExisting(publisher);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(publisher.Id))
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

        // GET: Publishers/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _publisherService.GetDetails(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var publisher = _publisherService.GetDetails(id);
            if (publisher != null)
            {
                _publisherService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(Guid id)
        {
            return _publisherService.GetDetails(id) != null;
        }
    }
}