namespace RMS.Domain.ResumeDomain
{
    public class AboutMeDomain
    {
        public int AboutMeId { get; set; }
        public int? ResumeId { get; set; }
        public string MainDescription { get; set; } = null!;
        public string? KeyPoints { get; set; }
    }
}
