using RMS.Domain.ResumeDomain;
namespace rms_web_api_group2.data.Resume
{
    public class ResumeDomain
    {
        public ResumeDomain()
        {
            SkillList = new List<UserSkillDomain>();
            aboutMe = new List<AboutMeDomain>();
            //eduBackground = new List<EducationalBackgroundDomain>();
            educationDetails = new List<EducationalDetailsDomain>();
            achivements = new List<AchievementDomain>();
            memberships = new List<MembershipDomain>();
            myDetails = new List<MyDetailDomain>();
            workExperience = new List<WorkExperienceDomain>();
            userResumes = new List<UserResumeDomain>();
            certifications = new List<CertificationDomain>();
            trainings = new List<TrainingDomain>();
            reviews = new List<ReviewTableDomain>();
        }
        public int ResumeId { get; set; }
        public string ResumeTitle { get; set; } 
        public string ResumeStatus { get; set; } 
        public DateTime CreationDate { get; set; }
        public DateTime UpdationDate { get; set; }
        public List<UserSkillDomain> SkillList { get; set; }
        public List<AboutMeDomain> aboutMe { get; set; }

        public List<EducationalDetailsDomain> educationDetails { get; set; }
        public List<AchievementDomain> achivements { get; set; }
        public List<MembershipDomain> memberships { get; set; }
        public List<MyDetailDomain> myDetails { get; set; }
        public List<WorkExperienceDomain> workExperience { get; set; }
        public List<UserResumeDomain> userResumes { get; set; }
        public List<CertificationDomain> certifications { get; set; }
        public List<TrainingDomain> trainings { get; set; }
        public List<ReviewTableDomain> reviews { get; set; }
    }
}
