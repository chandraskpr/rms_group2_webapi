namespace RmsWebApi.Data
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
            
        public DateTime CreationDate { get; set; }

        public DateTime UpdationDate { get; set; }
    }
}
