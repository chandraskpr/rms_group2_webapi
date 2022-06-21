﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Domain.ResumeDomain
{
    public class EducationDetailsDomain
    {   
        [Key]
        public int EducationalDetailsId { get; set; }

        public string CourseName { get; set; }

        public string Stream { get; set; }

        public string InstitutionName { get; set; }

        public int PassingYear { get; set; }

        [Display(Name ="Percentage/CGPA")]
        public float Marks { get; set; }

        [Display(Name ="University/Board")]
        public string University { get; set; }

        
        

    }
}
