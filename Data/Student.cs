using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_tut.Models
{
    public class Students
    {   
        public int Id {get;set;}
        public string Name {get; set;}
        public string Email {get;set;}
        public string Address {get;set;}
        public DateTime DOB {get;set;}
    }
    
}