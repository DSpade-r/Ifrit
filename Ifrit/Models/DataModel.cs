using Ifrit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
}