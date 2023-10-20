using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veripark.ViewMode.Entities;

namespace LMSWeb.Pages.Books
{
    public class CreateModel : PageModel
    {
       
        public void OnGet()
        {
        }
        public IActionResult OnPost() {

            return RedirectToPage("/Books/Index");
        }
        public IActionResult OnEdit(int id)
        {
            return RedirectToPage("/Books/Index");

        }
    }
}
