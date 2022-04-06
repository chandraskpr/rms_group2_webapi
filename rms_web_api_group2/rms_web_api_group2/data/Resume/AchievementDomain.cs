namespace RMS.Domain.ResumeDomain
{
    public class AchievementDomain
    {
        public int AchievementId { get; set; }
        public int? ResumeId { get; set; }
        public int AchievementYear { get; set; }
        public string AchievementName { get; set; } = null!;
        public string AchievementDesc { get; set; } = null!;

        
    }
}
