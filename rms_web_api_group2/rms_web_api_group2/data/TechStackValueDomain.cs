namespace rms_web_api_group2.data
{
    public class TechStackValueDomain
    {
        public int ValueId { get; set; }
        public string? ValueName { get; set; }

        public int? TechStackId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
