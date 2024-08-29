using linqweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace linqweb.Pages.Suppliers
{
    public class EditModel : PageModel
    {  
        public MarketContext db;
        public Supplier supplier;
        public EditModel(MarketContext mc)
        {
            db = mc;
        }
         public void OnGet(int Id)
        { 
            supplier = db.Suppliers.FirstOrDefault(s => s.Id == Id);
        }
        public async Task<IActionResult> OnPost(Supplier supplier, int Id)
        {
            var x = db.Suppliers.FirstOrDefault(s => s.Id == Id);
            x.Name = supplier.Name;
            x.Email = supplier.Email; 
            db.SaveChanges();
            return RedirectToPage("/Suppliers/Index");
        }
    }
}
