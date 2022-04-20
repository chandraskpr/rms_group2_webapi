using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class RoleMaster
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
