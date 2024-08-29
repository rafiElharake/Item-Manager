using linqweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace linqweb.Pages.Items
{
    public class EditModel : PageModel
    { 
            public MarketContext db;
            public Item item;
            public EditModel(MarketContext mc)
            {
                db = mc;
            }
            public List<Supplier> suppliers;
            public void OnGet(int Id)
            {
                suppliers = db.Suppliers.ToList();
                item=db.Items.FirstOrDefault(item=>item.Id == Id);
            }
        public async Task<IActionResult> OnPost(Item item, int Id)
        {
            var db_item=db.Items.FirstOrDefault(item=>item.Id==Id);
            db_item.ItemName = item.ItemName;
            db_item.Price = item.Price;
            db_item.Quantity = item.Quantity;
            db_item.SupplierId = item.SupplierId;
            db.SaveChanges();
            return RedirectToPage("/Items/Index");
        }
    }
    }
