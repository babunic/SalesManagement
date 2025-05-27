using Microsoft.EntityFrameworkCore;

public class SalesRecordRepository : ISalesRecordRepository
{
    private readonly SalesDbContext _context;

    public SalesRecordRepository(SalesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SalesRecord>> GetAllAsync()
    {
        return await _context.SalesRecords.ToListAsync();
    }

    public async Task<SalesRecord> GetByIdAsync(int id)
    {
        return await _context.SalesRecords.FindAsync(id);
    }

    public async Task AddAsync(SalesRecord salesRecord)
    {
        await _context.SalesRecords.AddAsync(salesRecord);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SalesRecord salesRecord)
    {
        _context.SalesRecords.Update(salesRecord);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var salesRecord = await _context.SalesRecords.FindAsync(id);
        if (salesRecord != null)
        {
            _context.SalesRecords.Remove(salesRecord);
            await _context.SaveChangesAsync();
        }
    }
}
