﻿using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class ProjectMaster
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
