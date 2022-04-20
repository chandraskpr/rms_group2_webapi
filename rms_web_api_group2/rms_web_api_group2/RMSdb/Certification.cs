namespace rms_web_api_group2.RMSdb
{
    public class Certification
    {
        
            public int? resumeId { get; set; }
            public int certificationId { get; set; }
            public string? certificationName { get; set; }

            public virtual Resume? Resume { get; set; }
        }
    }


