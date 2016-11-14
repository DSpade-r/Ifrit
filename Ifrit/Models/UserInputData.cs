using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ifrit.Models
{
    public class UIResume
    {
        public int ResumeId { get; set; }
        [Required(ErrorMessage = "Необходимо указать название желаемой позиции")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Необходимо написать о себе(минимум пару предложений)")]
        [StringLength(100, MinimumLength = 6)]
        public string Body { get; set; }
        [Range(1, (double)decimal.MaxValue, ErrorMessage = "Значение должно быть между {1} и {2}.")]
        public decimal Salary { get; set; }        
        public ApplicationUser User { get; set; }
    }
    public class UIVacancy
    {
        public int VacancyId { get; set; }
        [Required(ErrorMessage = "Необходимо указать название вакансии")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Необходимо написать о вакансии(минимум пару предложений)")]
        [StringLength(100, MinimumLength = 6)]
        public string Body { get; set; }
        [Range(1, (double)decimal.MaxValue, ErrorMessage = "Значение должно быть между {1} и {2}.")]
        public decimal Salary { get; set; }        
        //public string User_id { get; set; }
        public ApplicationUser User { get; set; }
    }
    public class UIFindResume
    {
        public string Title { get; set; }
    }
    public class UIFindVacancy
    {
        public string Title { get; set; }
    }
    public class UIBusinessCard
    {
        public int BusinessCardId { get; set; }
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }
        public string Adress { get; set; }
        public string WebSite { get; set; }
        [Required]
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
    }
}