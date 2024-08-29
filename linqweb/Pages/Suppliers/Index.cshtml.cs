using linqweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace linqweb.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly MarketContext db;
        public IndexModel(MarketContext mc)
        {
            db = mc;

        }
        public List<Supplier> suppliers = new();
        public string SearchName { get; set; }
        public int Total { get; set; }
        public void OnGet()
        {
            suppliers = db.Suppliers.ToList();
        }
        public async Task<IActionResult> OnPostAsync(string SearchName)
        {
            if (SearchName == null)
                suppliers = db.Suppliers.OrderBy(I => I.Id).ToList();
            else
                suppliers = db.Suppliers.Where(x => x.Name.Contains(SearchName)).ToList();
            return Page();
        }
 
    }
}
