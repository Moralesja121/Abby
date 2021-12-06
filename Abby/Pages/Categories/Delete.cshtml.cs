using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    // [BindProperties] We can use this to auto-bind properties within this page/code-behind without have to type out [BindProperty for each one]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id); // Finds Id as a match
            // Category = _db.Category.FirstOrDefault(u => u.Id == id); // Finds first record that matches; ignores everything else, if nothing is found "First" throws an exception. "FirstOrDefault" returns NULL
            // Category = _db.Category.SingleOrDefault(u => u.Id == id); // Can use when you only expect one result to be returned. Will throw exceptions if more than one item is returned
            // Category = _db.Category.Where(u => u.Id == id).FirstOrDefault(); // Can return many records for enumeration or for finding the first result

        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot be an exact math to the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Remove(Category);
                await _db.SaveChangesAsync(); // This command is the actual saving of data to the database
                TempData["success"] = "Category removed successfully!";
                return RedirectToPage("Index");
            }
            
            return Page();
        }
    }
}
