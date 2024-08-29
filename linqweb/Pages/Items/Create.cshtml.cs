using linqweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace linqweb.Pages.Items
{
    public class CreateModel : PageModel
    {
        public MarketContext db;
        public Item item;
        public CreateModel(MarketContext mc)
        {
            db = mc;
        }
        public List<Supplier> suppliers;
        public void OnGet()
        {
            suppliers=db.Suppliers.ToList();
        }
        public async Task<IActionResult> OnPost(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToPage("/Items/Index");
        }
    }
}
