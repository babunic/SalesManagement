public class SalesRepresentative
{
    public int Id { get; set; }
    public string ? Name { get; set; }
    public string ? ContactDetails { get; set; }
    public string ? Address { get; set; }
    public string ? Position { get; set; }
    public DateTime DateOfJoining { get; set; }
    public ICollection<SalesRecord> ? SalesRecords { get; set; }
}
