using System;
using System.ComponentModel.DataAnnotations;
namespace P11.Shared
{
    public class Info
    {
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Adress {get;set;}
        [Required,Range(1,100,ErrorMessage="It should be in range 1,100")]
        // public DateTime Date {get;set;}
        public int Number {get;set;}
    }
}