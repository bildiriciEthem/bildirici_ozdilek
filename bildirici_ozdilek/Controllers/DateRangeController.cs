using bildirici_ozdilek.Models;
using bildirici_ozdilek.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace bildirici_ozdilek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateRangeController : ControllerBase
    {
        private readonly IDateRangeService _dateRangeService;

        public DateRangeController(IDateRangeService dateRangeService)
        {
            _dateRangeService = dateRangeService;
        }

        [HttpPost("calculate")]
        public IActionResult CalculateDateRange([FromQuery] DateRangeRequestModel request)
        {
            var result = _dateRangeService.CalculateDateRange(request);
            return Ok(result);
        }
    }
}
