namespace Amplifier
{
    public class Trend
    {
        public string customer { get; set; }
        public string reporting_period { get; set; } = "year";
        public int year { get; set; } = 0;
        public int quarter { get; set; } = 0;
        public int month { get; set; } = 0;
        public int number_of_active_months { get; set; } = 0;
        public string purchase_pattern_description { get; set; }
        public string alert { get; set; }
        public decimal sales_value { get; set; } = 0;
        public string trend { get; set; }
        public string trend_position_in_the_group { get; set; }
        public string action_strategy { get; set; }
    }
}