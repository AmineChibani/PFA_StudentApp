namespace StudentApp.ViewModels.Statistics
{
    public class AnalyticsVM
    {
        public int TotalStudents { get; set; }
        public int TotalPublishers { get; set; }
        public int totalActiveAds { get; set; }
        public int TotalAbonneent { get; set; }
        public int TotalClicks { get; set; }
        public Dictionary<string, int> StudentsByQuartier { get; set; }
        public Dictionary<string, double> QuartierPercentages { get; set; }
        public Dictionary<int, int> lignesWithTotalSubscriptions { get; set; }  
        public Dictionary<int, int> ClicksByCampaign { get; set; }
        public Dictionary<string, int> ClicksByOS { get; set; }
    }
}
