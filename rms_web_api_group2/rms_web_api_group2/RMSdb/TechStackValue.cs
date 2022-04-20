namespace rms_web_api_group2.RMSdb
{
    public partial class TechStackValue
    {
        public int ValueId { get; set; }
        public string? ValueName { get; set; }
        public int? TechStackId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual TechStackMaster? TechStack { get; set; }
    }
}
