using Azure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WEB_API_1_Paskaita.Models
{
    public class Holiday
    {
        public string name { get; set; }
        public string description { get; set; }
        public Date date { get; set; }
        public List<string> type { get; set; }
    }
    public class Date
    {
        public string iso { get; set; }
        public Datetime datetime { get; set; }
    }

    public class Datetime
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
    }
    public class Meta
    {
        public int code { get; set; }
    }
    public class Country
    {
        public string country_name { get; set; }
        //public string iso-3166 { get; set; }
        public int total_holidays { get; set; }
        public int supported_languages { get; set; }
        public string uuid { get; set; }
        public string flag_unicode { get; set; }
    }
    public class Language
    {
        public string code { get; set; }
        public string name { get; set; }
        public string nativeName { get; set; }
    }
    public class Response
    {
        public List<Holiday> holidays { get; set; }
        public List<Country> countries { get; set; }
        public List<Language> languages { get; set; }
    }

    public class Root
    {
        public Meta meta { get; set; }
        public Response response { get; set; }
    }
}
