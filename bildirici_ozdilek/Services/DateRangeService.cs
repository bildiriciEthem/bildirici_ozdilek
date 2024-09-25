using bildirici_ozdilek.Models;
using bildirici_ozdilek.Services.Interfaces;

namespace bildirici_ozdilek.Services
{
    public class DateRangeService : IDateRangeService
    {
        public DateRangeResponseModel CalculateDateRange(DateRangeRequestModel request)
        {
            return new DateRangeResponseModel();
        }
    }
}
