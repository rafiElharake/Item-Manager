using System;
using System.Collections.Generic;

namespace linqweb.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? SupplierId { get; set; }

    public string Type { get; set; } = null!;

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Supplier? Supplier { get; set; }
}
