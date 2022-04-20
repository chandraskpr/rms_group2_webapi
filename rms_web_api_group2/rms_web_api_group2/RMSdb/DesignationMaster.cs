using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class DesignationMaster
    {
        public int DesignationId { get; set; }
        public string? DesignationName { get; set; }
        public string? DesignationDescription { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
