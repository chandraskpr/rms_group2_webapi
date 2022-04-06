using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Domain.ResumeDomain
{
    public class EducationalBackgroundData
    {
        [Key]

        public int EduBackgroundId { get; set; }

    }
}
