public interface ISalesRecordRepository
{
    Task<IEnumerable<SalesRecord>> GetAllAsync(int? repId, string? search, DateTime? startDate, DateTime? endDate);
    Task<IEnumerable<SalesRepresentative>> GetAllSalesRepresentativesAsync();
    Task<SalesRecord> GetByIdAsync(int id);
    Task AddAsync(SalesRecord salesRecord);
    Task UpdateAsync(SalesRecord salesRecord);
    Task DeleteAsync(int id);
}
