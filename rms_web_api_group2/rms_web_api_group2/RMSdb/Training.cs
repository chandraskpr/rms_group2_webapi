namespace rms_web_api_group2.RMSdb
{
    public class Training
    {
        public int? ResumeId { get; set; }
        public int TrainingId { get; set; }
        public string? Trainingname { get; set; }

        public virtual Resume? Resume { get; set; }
    }
}
