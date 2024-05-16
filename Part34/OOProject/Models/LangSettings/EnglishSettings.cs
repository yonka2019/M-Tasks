namespace OOProject.Models.Languages
{
    public class EnglishSettings : ILangSettings
    {
        public string[] ONES { get; set; } = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        public string[] TENS { get; set; } = { null, "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        public string[] PREFIXES { get; set; } = { "Hundred", "Thousand", "Million", "Billion" };
    }
}
