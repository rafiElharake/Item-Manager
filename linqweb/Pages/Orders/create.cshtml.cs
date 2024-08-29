using linqweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace linqweb.Pages.Orders
{
    public class createModel : PageModel
    {
        private readonly MarketContext _context;
        public List<Item> items { get; set; }
        public string[] io = { "in", "out" };
        public createModel(MarketContext context)
        {
            _context = context;
        }
        public Order order { get; set; }
        public void OnGet()
        {
            items = _context.Items.ToList();
        }
        public async Task<IActionResult> OnPostAsync(Order order)
        {
            if (order.Type == "in")
            {
                Item o = _context.Items.FirstOrDefault(x => x.Id == order.ItemId);
                order.SupplierId = o.SupplierId;
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}