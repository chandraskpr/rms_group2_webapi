using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class Membership
    {
        public int MembershipId { get; set; }
        public int? ResumeId { get; set; }
        public string? MembershipName { get; set; }
        public string? MembershipDesc { get; set; }

        public virtual Resume? Resume { get; set; }
    }
}
