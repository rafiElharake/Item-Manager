using linqweb.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;

namespace linqweb.Pages.Items
{
    public class DeleteModel : PageModel
    {
        public MarketContext db;
        public ItemSupplierView item;
        public List<Supplier> suppliers;
        public DeleteModel(MarketContext mc)
        {
            db=mc;
        }
        public void OnGet(int Id)
        {
            suppliers=db.Suppliers.ToList();
            item = db.ItemSupplierViews.FirstOrDefault(i => i.Id == Id); 
        }
        public async Task<IActionResult> OnPost(int Id)
        {
            var db_item = db.Items.FirstOrDefault(item => item.Id == Id);
            db.Items.Remove(db_item);
            db.SaveChanges();
            return RedirectToPage("/Items/Index");
        }
    }
}
