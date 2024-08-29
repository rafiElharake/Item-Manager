using System;
using System.Collections.Generic;

namespace linqweb.Models;

public partial class Item
{
    public int Id { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int SupplierId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Supplier Supplier { get; set; } = null!;
}
