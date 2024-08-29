using System;
using System.Collections.Generic;

namespace linqweb.Models;

public partial class ItemSupplierView
{
    public int Id { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }
}
