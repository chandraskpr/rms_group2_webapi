using RMS.Domain.ResumeDomain;

namespace RmsWebApi.Data
{
    public class ResumeData
    {
        public ResumeData()
        {
            SkillList = new List<SkillsData>();
            aboutMe = new List<AboutMeData>();
            educationDetails = new List<EducationDetailsData>();
            achivements = new List<AchievementsData>();
            memberships = new List<MembershipsData>();
            myDetails = new List<MyDetailsData>();
            workExperience = new List<WorkExperienceData>();
            userResumes = new List<UserResumeData>();
            certifications = new List<CertificationData>();
            trainings = new List<TrainingData>();
        }
        public int ResumeId { get; set; }
        public string ResumeTitle { get; set; }
        public string ResumeStatus { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdationDate { get; set; }

        public List<SkillsData> SkillList { get; set; }
        public List<AboutMeData> aboutMe { get; set; }
        //public List<EducationalBackgroundDomain> eduBackground { get; set; }
        public List<EducationDetailsData> educationDetails { get; set; }
        public List<AchievementsData> achivements { get; set; }
        public List<MembershipsData> memberships { get; set; }
        public List<MyDetailsData> myDetails { get; set; }
        public List<WorkExperienceData> workExperience { get; set; }
        public List<UserResumeData> userResumes { get; set; }

        public List<CertificationData> certifications { get; set; }

        public List<TrainingData> trainings { get; set; }
    }
}