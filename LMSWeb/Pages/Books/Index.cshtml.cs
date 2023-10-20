using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veripark.Infrastructure;
using veripark.ViewMode.Entities;

namespace LMSWeb.Pages.Books
{
    public class IndexModel : PageModel
    {
        public IEnumerable<BooksEntity> booksentities { get; set; }
        private readonly IBookService _bookService;

        public IndexModel(IBookService bookService)
        {
            _bookService = bookService;

        }

        public IActionResult OnGet()
        {
            booksentities = new List<BooksEntity>();
            booksentities = getBooklist();
            return Page();

        }
        public IActionResult OnPost()
        {

            return Page();
        }
        private IEnumerable<BooksEntity> getBooklist()
        {
            var reuslt = _bookService.GetAll().ToList();
            if (reuslt.Any())
                return reuslt;
            else
                return new List<BooksEntity>();
        }
    }
}
