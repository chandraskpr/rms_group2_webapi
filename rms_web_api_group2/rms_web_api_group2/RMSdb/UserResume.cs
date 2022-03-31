using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class UserResume
    {
        public int UserResumeId { get; set; }
        public int? UserId { get; set; }
        public int ResumeId { get; set; }

        public virtual Resume Resume { get; set; } = null!;
        public virtual UserInfo? User { get; set; }
    }
}
