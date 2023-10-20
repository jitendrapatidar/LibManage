using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using veripark.DataAccess.Models;
using veripark.Infrastructure;
using veripark.ViewMode.Entities;

namespace LMS.Web.Pages.Book
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IBookService _bookService;

        public CreateModel(ILogger<CreateModel> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;

        }
        public void OnGet()
        {
            var model = new BooksEntity();
        }
        public IActionResult OnPost()
        {

            return RedirectToPage("/Books/Index");
        }


    }
}

////public void OnCreate()
////{
////    var model = new BooksEntity();


////}
////public void OnCreate(BooksEntity model)
////{

////}
//public IActionResult OnGet() 
//{
//    var model = new BooksEntity();
//    return Page();
//}


//public IActionResult OnPost(BooksEntity model)
//{
//    return RedirectToAction("Index");
//}
////public async Task<IActionResult> OnPostAsync()
//{
//    //if (!ModelState.IsValid)
//    //{
//    //    return Page();
//    //}

//    //if (Customer != null) _context.Customer.Add(Customer);
//    //await _context.SaveChangesAsync();

//    //return RedirectToPage("./Index");
//    return Page();
//}
//  public async Task<IActionResult> OnPostDeleteAsync(int id)


