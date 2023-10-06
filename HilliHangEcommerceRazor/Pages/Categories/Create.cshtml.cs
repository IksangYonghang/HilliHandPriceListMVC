using BulkyEcommerceRazor.Data;
using BulkyEcommerceRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyEcommerceRazor.Pages.Categories
{
	[BindProperties]
	public class CreateModel : PageModel
    {
		private readonly ApplicationDbContext _context;      
        public Category Category { get; set; }
		public CreateModel(ApplicationDbContext context)
        {
			_context = context;
		}
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _context.Categories.Add(Category);
            _context.SaveChanges();
            TempData["success"] = "Category created scccuessfully";
            return RedirectToPage("Index");
        }
    }
}
