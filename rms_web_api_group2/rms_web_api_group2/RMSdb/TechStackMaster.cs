using System;
using System.Collections.Generic;
namespace rms_web_api_group2.RMSdb
{
    public partial class TechStackMaster
    {
        public TechStackMaster()
        {
            TechStackValues = new HashSet<TechStackValue>();
        }

        public int TechStackId { get; set; }
        public string? Category { get; set; }

        public virtual ICollection<TechStackValue> TechStackValues { get; set; }
    }
}