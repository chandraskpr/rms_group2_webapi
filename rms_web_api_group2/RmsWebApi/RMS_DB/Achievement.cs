using System;
using System.Collections.Generic;

namespace RmsWebApi.RMS_DB
{
    public partial class Achievement
    {
        public int AchievementId { get; set; }
        public int? ResumeId { get; set; }
        public string AchievementName { get; set; } = null!;

        public virtual Resume? Resume { get; set; }
    }
}
