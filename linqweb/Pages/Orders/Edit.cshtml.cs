using linqweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace linqweb.Pages.Orders
{
    public class EditModel : PageModel
    {
        public MarketContext db;
        public Order order;
        public string[] io = { "in", "out" };
        public List<Item> items { get; set; }

        public EditModel(MarketContext mc)
        {
            db = mc;
        }
        public void OnGet(int Id)
        {
            order = db.Orders.FirstOrDefault(s => s.Id == Id);
            items = db.Items.ToList();

        }
        public async Task<IActionResult> OnPost(Order order, int Id)
        {
            if (order.Type == "in")
            {
                Item o = db.Items.FirstOrDefault(x => x.Id == order.ItemId);
                order.SupplierId = o.SupplierId;
            }
            var x = db.Orders.FirstOrDefault(s => s.Id == Id);
            x.ItemId = order.ItemId;
            x.Quantity = order.Quantity;
            x.SupplierId = order.SupplierId;
            x.Type = order.Type;

            db.SaveChanges();
            return RedirectToPage("/Orders/Index");
        }
    }
}
