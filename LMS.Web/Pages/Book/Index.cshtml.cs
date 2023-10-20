using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using veripark.DataAccess.Models;
using veripark.Infrastructure;
using veripark.Infrastructure.Impl;
using veripark.ViewMode.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LMS.Web.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBookService _bookService;
        public IEnumerable<BooksEntity> booksentities { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
            
        }
        public IActionResult OnGet()
        {
            booksentities = getBooklist();
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
