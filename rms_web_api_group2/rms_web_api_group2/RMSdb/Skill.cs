using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class Skill
    {
        public int SkillId { get; set; }
        public int? ResumeId { get; set; }
        public string Category { get; set; } = null!;

        public virtual Resume? Resume { get; set; }
    }
}
