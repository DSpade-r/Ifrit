using Ifrit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ifrit.Models
{
    public class Resume
    {
        public int ResumeId { get; set; }
        [Required(ErrorMessage = "Необходимо указать название желаемой позиции")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Необходимо написать о себе(минимум пару предложений)")]
        [StringLength(100, MinimumLength = 6)]
        public string Body { get; set; }
        [Range(1, (double)decimal.MaxValue, ErrorMessage = "Значение должно быть между {1} и {2}.")]
        public decimal Salary { get; set; }
        [Required]
        //public string User_id { get; set; }
        public ApplicationUser User { get; set; }
    }
    public class Vacancy
    {
        public int VacancyId { get; set; }
        [Required(ErrorMessage = "Необходимо указать название вакансии")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Необходимо написать о вакансии(минимум пару предложений)")]
        [StringLength(100, MinimumLength = 6)]
        public string Body { get; set; }
        [Range(1, (double)decimal.MaxValue, ErrorMessage = "Значение должно быть между {1} и {2}.")]
        public decimal Salary { get; set; }
        [Required]
        //public string User_id { get; set; }
        public ApplicationUser User { get; set; }
    }
}