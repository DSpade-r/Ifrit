using Ifrit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ifrit.Models
{
    public class Resume
    {
        public int ResumeId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Body { get; set; }
        [Range(1, (double)decimal.MaxValue)]
        public decimal Salary { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
    }
    public class Vacancy
    {
        public int VacancyId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Body { get; set; }
        [Range(1, (double)decimal.MaxValue)]
        public decimal Salary { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
    }

    public class BusinessCard
    {
        public int BusinessCardId { get; set; }
        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }
        [Required]
        public string Adress { get; set; }
        public string WebSite { get; set; }
        [Required]
        public string Description { get; set; } 
        [Required]    
        public ApplicationUser User { get; set; }   
    }
}