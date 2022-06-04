namespace rms_web_api_group2.RMSdb
{
   
        public partial class ReviewTable
        {
            public int ReviewId { get; set; }
            public int? ResumeId { get; set; }
            public string? ReviewComment { get; set; }
            public int? ReviewerId { get; set; }

            public virtual Resume? Resume { get; set; }
            public virtual UserInfo? Reviewer { get; set; }
        }
    
}
