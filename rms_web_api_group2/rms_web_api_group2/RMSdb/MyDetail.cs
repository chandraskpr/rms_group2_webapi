﻿using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class MyDetail
    {
        public int UserdetailsId { get; set; }
        public int? ResumeId { get; set; }
        public string? ProfilePicture { get; set; }
        public double? TotalExp { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }

        public virtual Resume? Resume { get; set; }
    }
}
