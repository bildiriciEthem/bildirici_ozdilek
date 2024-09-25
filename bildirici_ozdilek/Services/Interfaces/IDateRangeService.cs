using bildirici_ozdilek.Models;

namespace bildirici_ozdilek.Services.Interfaces
{
    public interface IDateRangeService
    {
        DateRangeResponseModel CalculateDateRange(DateRangeRequestModel request);
    }
}
