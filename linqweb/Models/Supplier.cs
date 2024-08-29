using System;
using System.Collections.Generic;

namespace linqweb.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
