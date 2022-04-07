namespace RmsWebApi.Data
{
    public class ResumeDomain
    {

        public ResumeDomain()
        {
            skillsList = new List<Skills>();
            aboutMeDomain = new List<AboutMeDomain>();
            achievements = new List<Achievements>();
            educationDetails = new List<EducationDetails>();
            memberships = new List<Memberships>();
            myDetails = new List<MyDetails>();
            workExperienceDomain = new List<WorkExperienceDomain>();
        }
        public int ResumeId { get; set; }
        public string ResumeTitle { get; set; }
        public string ResumeStatus { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdationDate { get; set; }

        public List<Skills> skillsList { get; set; }

        public List<AboutMeDomain> aboutMeDomain { get; set; }
        public List<Achievements> achievements { get; set; }
        public List<EducationDetails> educationDetails { get; set; }
        public List<Memberships> memberships { get; set; }
        public List<MyDetails> myDetails { get; set; }
        public List<WorkExperienceDomain> workExperienceDomain { get; set;}
    }
}
