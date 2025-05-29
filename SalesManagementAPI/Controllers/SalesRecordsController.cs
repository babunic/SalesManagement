using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SalesRecordsController : ControllerBase
{
    private readonly SalesRecordService _service;

    public SalesRecordsController(SalesRecordService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SalesRecord>>> GetSalesRecords([FromQuery] int? repId, [FromQuery] string? search, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        try
        {
            var salesRecords = await _service.GetAllSalesRecordsAsync(repId, search, startDate, endDate);
            return Ok(salesRecords);
        }
        catch (Exception ex)
        {
            // Log error (with Serilog or ILogger if you have it)
            return StatusCode(500, $"An error occurred while fetching sales records: {ex.Message}");
        }
    }

    [HttpGet("representatives")]
    public async Task<ActionResult<IEnumerable<SalesRepresentative>>> GetRepresentatives()
    {
        try
        {
            var reps = await _service.GetAllSalesRepresentativesAsync();
            return Ok(reps);
        }
        catch (Exception ex)
        {
            // Log error (with Serilog or ILogger if you have it)
            return StatusCode(500, $"Error fetching representatives: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SalesRecord>> GetSalesRecord(int id)
    {
        var salesRecord = await _service.GetSalesRecordByIdAsync(id);
        if (salesRecord == null)
        {
            return NotFound();
        }
        return Ok(salesRecord);
    }

    [HttpPost]
    public async Task<ActionResult> AddSalesRecord(SalesRecord salesRecord)
    {
        await _service.AddSalesRecordAsync(salesRecord);
        return CreatedAtAction(nameof(GetSalesRecord), new { id = salesRecord.Id }, salesRecord);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSalesRecord(int id, SalesRecord salesRecord)
    {
        if (id != salesRecord.Id)
        {
            return BadRequest();
        }
        await _service.UpdateSalesRecordAsync(salesRecord);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSalesRecord(int id)
    {
        await _service.DeleteSalesRecordAsync(id);
        return NoContent();
    }
}
