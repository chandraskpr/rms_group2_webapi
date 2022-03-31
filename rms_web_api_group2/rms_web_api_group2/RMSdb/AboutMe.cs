using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class AboutMe
    {
        public int AboutMeId { get; set; }
        public int? ResumeId { get; set; }
        public string MainDescription { get; set; } = null!;
        public string? KeyPoints { get; set; }

        public virtual Resume? Resume { get; set; }
    }
}
