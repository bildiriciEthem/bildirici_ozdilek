namespace bildirici_ozdilek.Models
{
    public class DateRangeResponseModel
    {
        public List<MonthModel> Months { get; set; }
        public List<DateRangeModel> DateRanges { get; set; }
        public List<TransactionModel> Transactions { get; set; }
    }
}
