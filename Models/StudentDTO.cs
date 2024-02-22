using System.ComponentModel.DataAnnotations;
using ASP.NET_tut.Validators;

namespace ASP.NET_tut.Models
{
    public class StudentDTO
    {
        public int Id {get;set;}
        [Required]
        public string Name {get; set;}
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        public string Address {get;set;}

        [DateCheck]
        public DateTime AdmissionDate {get;set;}

    }
}