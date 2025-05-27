public class SalesRecord
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string ProductDetails { get; set; }
    public string CustomerInfo { get; set; }
    public int RepresentativeId { get; set; }
    public SalesRepresentative Representative { get; set; }
}
