using bildirici_ozdilek.Models;
using bildirici_ozdilek.Services.Interfaces;

namespace bildirici_ozdilek.Services
{
    public class DateRangeService : IDateRangeService
    {
        public DateRangeResponseModel CalculateDateRange(DateRangeRequestModel request)
        {
            DateTime current;
            DateTime endMonth;

            var response = new DateRangeResponseModel
            {
                Months = new List<MonthModel>(),
                DateRanges = new List<DateRangeModel>(),
                Transactions = new List<TransactionModel>()
            };

            if (request.Start.Day == 1 && (request.Start.TimeOfDay == TimeSpan.Zero))
            {
                current = new DateTime(request.Start.Year, request.Start.Month, request.Start.Day);
                endMonth = new DateTime(request.End.Year, request.End.Month, 1);
            }

            else
            {
                current = new DateTime(request.Start.Year, request.Start.Month, 1).AddMonths(1);
                endMonth = new DateTime(request.End.Year, request.End.Month, 1);

            }


            while (current < endMonth)
            {
                response.Months.Add(new MonthModel
                {
                    Year = current.Year,
                    Month = current.Month
                });
                current = current.AddMonths(1);
            }

            if (response.Months.Count > 0)
            {
                DateTime startDateRange = request.Start;
                DateTime endDateRange = request.End;
                current = current.AddMonths(-1);
                if (startDateRange.TimeOfDay != TimeSpan.Zero)
                {
                    startDateRange = startDateRange.Date.AddDays(1);
                    endDateRange = new DateTime(current.Year, current.Month, 1);
                }




                if (startDateRange <= endDateRange)
                {
                    response.DateRanges.Add(new DateRangeModel
                    {
                        StartDate = startDateRange.ToString("yyyy-MM-dd"),
                        EndDate = endDateRange.ToString("yyyy-MM-dd")
                    });
                }
                current = current.AddMonths(1);
                startDateRange = new DateTime(current.Year, current.Month, 1);
                endDateRange = new DateTime(request.End.Year, request.End.Month, request.End.Day);

                response.DateRanges.Add(new DateRangeModel
                {
                    StartDate = startDateRange.ToString("yyyy-MM-dd"),
                    EndDate = endDateRange.ToString("yyyy-MM-dd")
                });
            }

            else if (request.End.Day > request.Start.Day)
            {
                DateTime startDateRange = new DateTime(request.Start.Year, request.Start.Month, request.Start.Day).AddDays(1);
                DateTime endDateRange = new DateTime(request.End.Year, request.End.Month, request.End.Day);

                response.DateRanges.Add(new DateRangeModel
                {
                    StartDate = startDateRange.ToString("yyyy-MM-dd"),
                    EndDate = endDateRange.ToString("yyyy-MM-dd")
                });
            }

            if (request.Start.Date == request.End.Date)
            {
                response.Transactions.Add(new TransactionModel
                {
                    StartDate = request.Start,
                    EndDate = request.End
                });
            }
            else
            {
                if (request.Start.TimeOfDay != TimeSpan.Zero)
                {
                    response.Transactions.Add(new TransactionModel
                    {
                        StartDate = request.Start,
                        EndDate = request.Start.Date.AddDays(1)
                    });
                }

                if (request.End.TimeOfDay != TimeSpan.Zero)
                {
                    response.Transactions.Add(new TransactionModel
                    {
                        StartDate = request.End.Date,
                        EndDate = request.End
                    });
                }
            }

            return response;
        }
    }
}
