using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentApp.Services
{
    public class EmailEntity
    {
        public string FromEmailAddress { get; set; }
        public string ToEmailAddress { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
       public IFormFile Attachement { get; set; } 

    }
}
