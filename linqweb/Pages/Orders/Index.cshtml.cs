using linqweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace linqweb.Pages.Orders
{
    public class IndexModel : PageModel
    {
        MarketContext db = new();
        public List<OrderView> orderlist = new List<OrderView>();
        public int Search { get; set; } 
        public IndexModel(MarketContext mc)
        {
            db = mc;
        }
        public void OnGet()
        {
            var orders = db.Orders.ToList();
            var items = db.Items.ToList();
            var suppliers = db.Suppliers.ToList();
            orderlist = (from o in orders
                               join i in items on o.ItemId equals i.Id
                         join s in suppliers on o.SupplierId equals s.Id into supplierGroup
                         from s in supplierGroup.DefaultIfEmpty()
                         select new OrderView
                               {
                                   Id=o.Id,
                                   ItemName = i.ItemName,
                                   Quantity = o.Quantity,
                                   SupplierName = s != null ? s.Name : "client", 
                                   Type=o.Type
                               }).ToList();
        }
        public async Task<IActionResult> OnPostAsync(string Search)
        {
            IQueryable<Order> query = db.Orders;
            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(x => x.Item.ItemName.Contains(Search));
            }
            var x = await query.ToListAsync();
            foreach(var q in x)
            {
                OrderView view = new OrderView();
                view.Id = q.Id;
                view.ItemName = db.Items.FirstOrDefault(x => x.Id == q.ItemId).ItemName;
                view.Quantity = q.Quantity;
                view.SupplierName = q.Supplier != null ? db.Suppliers.FirstOrDefault(x => x.Id == q.SupplierId).Name : "client";
                view.Type = q.Type;
                orderlist.Add(view);
            }
            return Page();
        }
    }
}
