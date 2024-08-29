using linqweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace linqweb.Pages.Suppliers
{
    public class DeleteModel : PageModel
    {
        public MarketContext db;
        public Supplier supplier; 
        public DeleteModel(MarketContext mc)
        {
            db = mc;
        }
        public void OnGet(int Id)
        { 
            supplier = db.Suppliers.FirstOrDefault(i => i.Id == Id);
        }
        public async Task<IActionResult> OnPost(int Id)
        {
            var supplier = db.Suppliers.FirstOrDefault(s => s.Id == Id);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
            return RedirectToPage("/Suppliers/Index");
        }
    }
}
