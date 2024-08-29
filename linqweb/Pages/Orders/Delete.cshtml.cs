using linqweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace linqweb.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        public Order Order;
        public MarketContext db;
        public List<Item> items { get; set; }

        public DeleteModel(MarketContext mc)
        {
            db = mc;

        }
        public void OnGet(int Id)
        {
            Order = db.Orders.FirstOrDefault(s => s.Id == Id);
            items = db.Items.ToList();
        }
        public async Task<IActionResult> OnPost(int Id)
        {
            var o = db.Orders.FirstOrDefault(s => s.Id == Id);
            db.Orders.Remove(o);
            db.SaveChanges();
            return RedirectToPage("/Orders/Index");
        }
    }
}
