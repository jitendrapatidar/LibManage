using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMSWeb.Pages.Books
{
    public class EditModel : PageModel
    {
        public IActionResult OnGet(int? id)
        {
            return RedirectToPage("/Books/Index");
        }
    }
}
