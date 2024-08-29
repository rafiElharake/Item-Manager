using linqweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace linqweb.Pages.Suppliers
{
    public class CreateModel : PageModel
    {
        public MarketContext db;
        public Supplier supplier;
        public CreateModel(MarketContext mc)
        {
            db = mc;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
            return RedirectToPage("/Suppliers/Index");
        }
    }
}
