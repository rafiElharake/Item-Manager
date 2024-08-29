using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using linqweb.Models;
using Microsoft.EntityFrameworkCore;

namespace linqweb.Items
{
    public class IndexModel : PageModel
    {
        private readonly MarketContext db;
        public IndexModel(MarketContext mc)
        {
            db= mc;

        }
        public List<ItemSupplierView> Items = new();
        public string SearchName { get; set; }
        public string Price { get; set; }
        public int Total { get; set; }
        public string Quantity { get; set; }
        public string SelectedOption { get; set; }
        public void OnGet()
        {
           Items=db.ItemSupplierViews.ToList();

        }
        public async Task<IActionResult> OnPostAsync(string SearchName, string Price, string Quantity)
        {
            IQueryable<ItemSupplierView> query = db.ItemSupplierViews; 
            if (!string.IsNullOrEmpty(SearchName))
            {
                query = query.Where(x => x.ItemName.Contains(SearchName));
            } 
            if (decimal.TryParse(Price, out decimal parsedPrice))
            {
                query = query.Where(x => x.Price == parsedPrice);
            }
            if (int.TryParse(Quantity, out int parsedQuantity))
            {
                query = query.Where(x => x.Quantity < parsedQuantity);
            }
            Items = await query.OrderBy(i => i.Id).ToListAsync();
            SelectedOption = Request.Form["selectedOption"];

            if (SelectedOption=="Increasing")
            Items = Items.OrderBy(I => I.Price).ToList();
            else if (SelectedOption == "Decreasing")
            {
                Items = Items.OrderByDescending(I => I.Price).ToList();
            }
            return Page();
        }
    }
}
