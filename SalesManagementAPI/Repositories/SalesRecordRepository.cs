using Microsoft.EntityFrameworkCore;

public class SalesRecordRepository : ISalesRecordRepository
{
 private readonly SalesDbContext _context;

 public SalesRecordRepository(SalesDbContext context)
 {
  _context = context;
 }

 public async Task<IEnumerable<SalesRecord>> GetAllAsync(int? repId, string? search, DateTime? startDate, DateTime? endDate)
 {
  // return await _context.SalesRecords.Include(s => s.Representative)
  // .ToListAsync();
  var query = _context.SalesRecords
                      .Include(s => s.Representative)
                      .AsQueryable();

  if (repId.HasValue)
   query = query.Where(s => s.RepresentativeId == repId.Value);

  if (!string.IsNullOrWhiteSpace(search))
   query = query.Where(s =>
      (s.ProductDetails ?? string.Empty).Contains(search) ||
       (s.CustomerInfo ?? string.Empty).Contains(search));

  if (startDate.HasValue)
   query = query.Where(s => s.Date >= startDate.Value);

  if (endDate.HasValue)
   query = query.Where(s => s.Date <= endDate.Value);

  var records = await query.ToListAsync();

  return records;

 }

 public async Task<IEnumerable<SalesRepresentative>> GetAllSalesRepresentativesAsync()
 {
  return await _context.SalesRepresentatives.ToListAsync(); 
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
