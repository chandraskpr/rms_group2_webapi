using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class Achievement
    {
        public int AchievementId { get; set; }
        public int? ResumeId { get; set; }
        public int AchievementYear { get; set; }
        public string AchievementName { get; set; } = null!;
        public string AchievementDesc { get; set; } = null!;

        public virtual Resume? Resume { get; set; }
    }
}
