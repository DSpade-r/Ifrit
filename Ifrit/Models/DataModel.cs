using Ifrit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ifrit.Models
{
    public class CV
    {
        public int CVId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Salary { get; set; }
        public ApplicationUser User { get; set; }
    }
    public class Vacancy
    {
        public int VacancyId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Salary { get; set; }
        public ApplicationUser User { get; set; }
    }
}