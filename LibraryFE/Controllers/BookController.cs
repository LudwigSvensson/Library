using Library.Models;
using Library.Models.DTO_s;
using LibraryFE.Models;
using LibraryFE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LibraryFE.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> BookIndex()
        {
            List<BookDTO> List = new List<BookDTO>();
            var response = await _bookService.GetAllBooks<ResponseDTO>();
            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<BookDTO>>(Convert.ToString(response.Result));
            }
            return View(List);
        }

        public IActionResult BookCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookCreate(BookCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.CreateBookAsync<ResponseDTO>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));  
                }
            }
            return View(model);
        }

        public async Task<IActionResult> BookDelete(int bookId)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(bookId);

            if (response != null && response.IsSuccess)
            {
                BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookDeleteConfirmed(BookDTO model)
        {
            var response = await _bookService.DeleteBookAsync<ResponseDTO>(model.BookId);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(BookIndex));               
            }
            return RedirectToAction(nameof(BookIndex));
        }

        public async Task<IActionResult> BookUpdate(int bookId)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(bookId);

            if (response != null && response.IsSuccess)
            {
                BookDTO model = JsonConvert.
                    DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookUpdate(BookDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync<ResponseDTO>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }
    }
}
