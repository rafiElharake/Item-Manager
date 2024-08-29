using System;
using System.Collections.Generic;

namespace linqweb.Models;

public partial class GroupItemView
{
    public int Id { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Expr1 { get; set; } = null!;
}
