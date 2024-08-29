namespace linqweb.Models
{
    public class OrderView
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string SupplierName { get; set; }
        public string Type { get; set; }
    }
}