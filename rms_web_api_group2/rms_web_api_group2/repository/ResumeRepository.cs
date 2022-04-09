using rms_web_api_group2.data.Resume;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;
using rms_web_api_group2.data;

namespace rms_web_api_group2.repository
{
    public class ResumeRepository : BaseRepository<Resume>, IResumeRepository
    {
        
       
        public ResumeRepository(RMSContext context) :base(context)
        {
            
        }

        public new List<ResumeDomain> SelectAll()
        {
            var records = base.SelectAll().Select(x => new ResumeDomain()
            {
                ResumeId = x.ResumeId,
                ResumeTitle = x.ResumeTitle,
                ResumeStatus = x.ResumeStatus,
                UpdationDate = x.UpdationDate,
                CreationDate = x.CreationDate,
            

            SkillList = x.Skills.Select(s => new RMS.Domain.ResumeDomain.UserSkillDomain()
            {
                Category = s.Category,

            }).ToList(),

                aboutMe = x.AboutMes.Select(b => new RMS.Domain.ResumeDomain.AboutMeDomain()
                {
                    KeyPoints = b.KeyPoints,
                    MainDescription = b.MainDescription,
                }).ToList(),

                achivements =x.Achievements.Select(c => new RMS.Domain.ResumeDomain.AchievementDomain()
                {
                    AchievementName = c.AchievementName,
                    AchievementYear = c.AchievementYear,
                    AchievementDesc = c.AchievementDesc,
                }).ToList(),

                memberships = x.Memberships.Select(e => new RMS.Domain.ResumeDomain.MembershipDomain()
                {
                    MembershipName = e.MembershipName,
                    MembershipDesc = e.MembershipDesc,
                }).ToList(),

                myDetails = x.MyDetails.Select(f => new RMS.Domain.ResumeDomain.MyDetailDomain()
                {
                    ProfilePicture = f.ProfilePicture,
                    TotalExp = (float)f.TotalExp,
                }).ToList(),

                workExperience = x.WorkExperiences.Select(g => new RMS.Domain.ResumeDomain.WorkExperienceDomain()
                {
                    ClientDescription = g.ClientDescription,
                    Country = g.Country,
                    ProjectName = g.ProjectName,
                    ProjectRole = g.ProjectRole,
                    ProjectResponsibilities = g.ProjectResponsibilities,
                    StartDate = g.StartDate,
                    EndDate = g.EndDate,
                    BusinessSolution = g.BusinessSolution,
                    TechnologyStack = g.TechnologyStack,
                }).ToList(),

                educationDetails = x.EducationDetails.Select(d => new RMS.Domain.ResumeDomain.EducationalDetailsDomain()
                {
                    EducationId = d.EducationId,
                    CourseName = d.CourseName,
                    Specialization = d.Specialization,
                    InstituteName = d.InstituteName,
                    PassingYear = d.PassingYear,
                    Marks = (float)d.Marks,
                    University = d.University,
                }).ToList(),

            }).ToList();
            return records;
        }
           
        public void Insert(ResumeDomain resume)
        {
            var res = new Resume()
            {
                ResumeTitle = resume.ResumeTitle,
                ResumeStatus = resume.ResumeStatus,
                UpdationDate = resume.UpdationDate,
                CreationDate = resume.CreationDate,

            };
            foreach (var record in resume.SkillList)
            {
                res.Skills.Add(new Skill()
                {
                    Category = record.Category,
                });
            }

            foreach (var record in resume.aboutMe)
            {
                res.AboutMes.Add(new AboutMe()
                {
                    MainDescription = record.MainDescription,
                    KeyPoints = record.KeyPoints,
                });
            }

            foreach (var record in resume.myDetails)
            {
                res.MyDetails.Add(new MyDetail()
                {
                    ProfilePicture = record.ProfilePicture,
                    TotalExp = record.TotalExp,
                });
            }
            foreach (var record in resume.achivements)
            {
                res.Achievements.Add(new Achievement()
                {
                    AchievementName = record.AchievementName,
                    AchievementYear = record.AchievementYear,
                    AchievementDesc = record.AchievementDesc,
                });
            }
            foreach (var record in resume.memberships)
            {
                res.Memberships.Add(new Membership()
                {
                    MembershipName = record.MembershipName,
                    MembershipDesc = record.MembershipDesc,
                });
            }
            foreach (var record in resume.workExperience)
            {
                res.WorkExperiences.Add(new WorkExperience()
                {
                    ClientDescription = record.ClientDescription,
                    Country = record.Country,
                    ProjectName = record.ProjectName,
                    ProjectResponsibilities = record.ProjectResponsibilities,
                    ProjectRole = record.ProjectRole,
                    BusinessSolution = record.BusinessSolution,
                    StartDate = record.StartDate,
                    EndDate = record.EndDate,
                    TechnologyStack = record.TechnologyStack,
                });
            }

            foreach (var record in resume.educationDetails)
            {
                res.EducationDetails.Add(new EducationDetail()
                {
                    CourseName = record.CourseName,
                    InstituteName = record.InstituteName,
                    Specialization = record.Specialization,
                    PassingYear = record.PassingYear,
                    Marks = record.Marks,
                    University = record.University,
                });
            }
            base.Insert(res);
        }
          
        public void Delete(int ResumeId)
        {
            var res = base.SelectAll().Find(e=>e.ResumeId==ResumeId);
            if (res != null)
            {
                base.Delete(res);
            }
            
        }
        public void Update(int ResumeId, ResumeDomain resume)
        {
            var res = base.SelectAll().Find(e=>e.ResumeId == ResumeId);
            if (res != null)
            {
                res.ResumeTitle = resume.ResumeTitle;
                res.ResumeStatus = resume.ResumeStatus;
                res.UpdationDate = resume.UpdationDate;
                res.CreationDate = resume.CreationDate;
                foreach (var record in resume.SkillList)
                {
                    res.Skills.Add(new Skill()
                    {
                        Category = record.Category,
                    });
                }

                foreach (var record in resume.aboutMe)
                {
                    res.AboutMes.Add(new AboutMe()
                    {
                        MainDescription = record.MainDescription,
                        KeyPoints = record.KeyPoints,
                    });
                }

                foreach (var record in resume.myDetails)
                {
                    res.MyDetails.Add(new MyDetail()
                    {
                        ProfilePicture = record.ProfilePicture,
                        TotalExp = record.TotalExp,
                    });
                }
                foreach (var record in resume.achivements)
                {
                    res.Achievements.Add(new Achievement()
                    {
                        AchievementName = record.AchievementName,
                        AchievementYear = record.AchievementYear,
                        AchievementDesc = record.AchievementDesc,
                    });
                }
                foreach (var record in resume.memberships)
                {
                    res.Memberships.Add(new Membership()
                    {
                        MembershipName = record.MembershipName,
                        MembershipDesc = record.MembershipDesc,
                    });
                }
                foreach (var record in resume.workExperience)
                {
                    res.WorkExperiences.Add(new WorkExperience()
                    {
                        ClientDescription = record.ClientDescription,
                        Country = record.Country,
                        ProjectName = record.ProjectName,
                        ProjectResponsibilities = record.ProjectResponsibilities,
                        ProjectRole = record.ProjectRole,
                        BusinessSolution = record.BusinessSolution,
                        StartDate = record.StartDate,
                        EndDate = record.EndDate,
                        TechnologyStack = record.TechnologyStack,
                    });
                }

                foreach (var record in resume.educationDetails)
                {
                    res.EducationDetails.Add(new EducationDetail()
                    {
                        CourseName = record.CourseName,
                        InstituteName = record.InstituteName,
                        Specialization = record.Specialization,
                        PassingYear = record.PassingYear,
                        Marks = record.Marks,
                        University = record.University,
                    });
                }

                base.Update(res);

            }

        }
    }
}
