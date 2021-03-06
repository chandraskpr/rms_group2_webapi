using Microsoft.EntityFrameworkCore;
using RmsWebApi.Data;
using RmsWebApi.Repository.Interfaces;
using RmsWebApi.RMS_DB;

namespace RmsWebApi.Repository
{
    public class ResumeRepository : BaseRepository<Resume>, IResumeRepository
    {
       
        public ResumeRepository(RMSContext context)
            : base(context)
        {

        }

        public List<ResumeDomain> GetAll()
        {
            var records = base.SelectAll().Select(x => new ResumeDomain()
            {
                ResumeId = x.ResumeId,
                ResumeTitle = x.ResumeTitle,
                ResumeStatus = x.ResumeStatus,
                UpdationDate = x.UpdationDate,
                CreationDate = x.CreationDate,

                SkillList = x.Skills.Select(s => new RMS.Domain.ResumeDomain.SkillsDomain()
                {
                    Category = s.Category,
                    SkillName = s.SkillName,

                }).ToList(),

                aboutMe = x.AboutMes.Select(b => new RMS.Domain.ResumeDomain.AboutMeDomain()
                {
                    KeyPoints = b.KeyPoints,
                    MainDescription = b.MainDescription,
                }).ToList(),
                
                achivements = x.Achievements.Select(c => new RMS.Domain.ResumeDomain.AchievementsDomain()
                {
                    AchievementName = c.AchievementName,
                }).ToList(),
                
                memberships = x.Memberships.Select(e => new RMS.Domain.ResumeDomain.MembershipsDomain()
                {
                    MembershipName = e.MembershipName,
                }).ToList(),

                myDetails = x.MyDetails.Select(f => new RMS.Domain.ResumeDomain.MyDetailsDomain()
                {
                    ProfilePicture = f.ProfilePicture,
                    TotalExp = (float)f.TotalExp,
                    UserName = f.Name,
                    Role = f.Role,
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
                
                educationDetails = x.EducationDetails.Select(d => new RMS.Domain.ResumeDomain.EducationDetailsDomain()
                {
                    EducationalDetailsId = d.EducationId,
                    CourseName = d.CourseName,
                    Stream=d.Specialization,
                    InstitutionName = d.InstituteName,
                    PassingYear = d.PassingYear,
                    Marks = (float)d.Marks,
                    University = d.University,
                }).ToList(),

                userResumes = x.UserResumes.Select(p =>new UserResumeDomain()
                {
                    UserId = p.UserId,
                    ResumeId = p.ResumeId,
                    UserResumeId = p.UserResumeId,
                }).ToList(),

                certifications = x.Certifications.Select(p => new CertificationDomain()
                {
                    CertificationId = p.CertificationId,
                    CertificationName = p.CertificationName,
                }).ToList(),

                trainings = x.training.Select(p => new TrainingDomain()
                {
                    TrainingId = p.TrainingId,
                    Trainingname=p.Trainingname
                }).ToList(),

                reviews = x.ReviewTables.Select(a => new ReviewTableDomain()
                {
                    ReviewId = a.ReviewId,
                    ReviewComment = a.ReviewComment,
                    ResumeId = a.ResumeId,
                    ReviewerId = a.ReviewerId,
                }).ToList()

            }).ToList();
            return records;
        }

        public List<ResumeDomain> GetNonDraftResume()
        {
            var result = base.SelectAll().Where(x => x.ResumeStatus != "Draft").Select(x => new ResumeDomain()
            {
                ResumeId = x.ResumeId,
                ResumeTitle = x.ResumeTitle,
                ResumeStatus = x.ResumeStatus,
                UpdationDate = x.UpdationDate,
                CreationDate = x.CreationDate,

                SkillList = x.Skills.Select(a => new RMS.Domain.ResumeDomain.SkillsDomain()
                {
                    Category = a.Category,
                    SkillName = a.SkillName,
                }
                ).ToList(),

                aboutMe = x.AboutMes.Select(b => new RMS.Domain.ResumeDomain.AboutMeDomain()
                {
                    KeyPoints = b.KeyPoints,
                    MainDescription = b.MainDescription,
                }
                ).ToList(),

                achivements = x.Achievements.Select(c => new RMS.Domain.ResumeDomain.AchievementsDomain()
                {
                    AchievementName = c.AchievementName,
                }
                ).ToList(),

                educationDetails = x.EducationDetails.Select(d => new RMS.Domain.ResumeDomain.EducationDetailsDomain()
                {
                    EducationalDetailsId = d.EducationId,
                    CourseName = d.CourseName,
                    Stream = d.Specialization,
                    InstitutionName = d.InstituteName,
                    PassingYear = d.PassingYear,
                    Marks = (float)d.Marks,
                    University = d.University,
                }
                ).ToList(),

                memberships = x.Memberships.Select(e => new RMS.Domain.ResumeDomain.MembershipsDomain()
                {
                    MembershipName = e.MembershipName,
                }
                ).ToList(),

                myDetails = x.MyDetails.Select(f => new RMS.Domain.ResumeDomain.MyDetailsDomain()
                {
                    ProfilePicture = f.ProfilePicture,
                    TotalExp = (float)f.TotalExp,
                    UserName = f.Name,
                    Role = f.Role,
                }
                ).ToList(),

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
                }
                ).ToList(),

                certifications = x.Certifications.Select(p => new CertificationDomain()
                {
                    CertificationId = p.CertificationId,
                    CertificationName = p.CertificationName,
                }).ToList(),

                trainings = x.training.Select(p => new TrainingDomain()
                {
                    TrainingId = p.TrainingId,
                    Trainingname = p.Trainingname
                }).ToList(),

                reviews = x.ReviewTables.Select(a => new ReviewTableDomain()
                {
                    ReviewId = a.ReviewId,
                    ReviewComment = a.ReviewComment,
                    ResumeId = a.ResumeId,
                    ReviewerId = a.ReviewerId,
                }).ToList(),

            }).ToList();



            return result;
        }

        public ResumeDomain Create(ResumeDomain resume)
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
                    SkillName = record.SkillName,
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

            foreach(var record in resume.myDetails)
            {
                res.MyDetails.Add(new MyDetail()
                {
                    ProfilePicture = record.ProfilePicture,
                    TotalExp = record.TotalExp,
                    Name = record.UserName,
                    Role =  record.Role,
                });
            }
            foreach (var record in resume.achivements)
            {
                res.Achievements.Add(new Achievement()
                {
                    AchievementName =   record.AchievementName,
                    
                });
            }
            foreach (var record in resume.memberships)
            {
                res.Memberships.Add(new Membership()
                {
                    MembershipName = record.MembershipName,
               
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

            foreach(var record in resume.educationDetails)
            {
                res.EducationDetails.Add(new EducationDetail()
                {
                    CourseName = record.CourseName,
                    InstituteName = record.InstitutionName,
                    Specialization = record.Stream,
                    PassingYear = record.PassingYear,
                    Marks = record.Marks,
                    University = record.University,
                });
            }

            foreach(var record in resume.userResumes)
            {
                res.UserResumes.Add(new UserResume()
                {
                    UserId = record.UserId,
                    ResumeId = record.ResumeId,
                    UserResumeId = record.UserResumeId,
                });
            }

            foreach (var record in resume.certifications)
            {
                res.Certifications.Add(new Certification()
                {
                    /*CertificationId = record.CertificationId,*/
                    CertificationName = record.CertificationName,
                });
            }

            foreach (var record in resume.trainings)
            {
                res.training.Add(new training()
                {
                    //TrainingId = record.TrainingId,
                    Trainingname = record.Trainingname
                });
            }

            foreach (var record in resume.reviews)
            {
                res.ReviewTables.Add(new ReviewTable()
                {
                    //ReviewId = record.ReviewId,
                    ReviewerId = record.ReviewerId,
                    ReviewComment = record.ReviewComment,
                    ResumeId = record.ResumeId
                });
            }

            var response = base.Create(res);
            if (response != null)
            {
                return new ResumeDomain()
                {
                    ResumeId = response.ResumeId,
                    ResumeStatus = response.ResumeStatus,
                };
            }
            return null;
        }


        public void Delete(int ResumeId)
        {
            //var res = base.SelectAll().FirstOrDefault(x => x.ResumeId == ResumeId);
            var res = this.entitySet
                .Include(x => x.MyDetails)
                .Include(x => x.Memberships)
                .Include(x => x.AboutMes)
                .Include(x => x.Achievements)
                .Include(x => x.EducationDetails)
                .Include(x => x.Skills)
                .Include(x => x.WorkExperiences)
                .Include(x => x.MyDetails)
                .Include(x =>x.UserResumes)
                .Include(x =>x.Certifications)
                .Include(x =>x.training)
                .Include(x => x.ReviewTables)
                .FirstOrDefault(x => x.ResumeId == ResumeId);

            if (res!= null)
                base.Delete(res);

        }

        public void Update(int ResumeId, ResumeDomain resume)
        {
            var res = base.SelectAll().FirstOrDefault(x => x.ResumeId == ResumeId);
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
                        SkillName = record.SkillName,
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
                        Name = record.UserName,
                        Role = record.Role,
                    });
                }
                foreach (var record in resume.achivements)
                {
                    res.Achievements.Add(new Achievement()
                    {
                        AchievementName = record.AchievementName,
                      
                    });
                }
                foreach (var record in resume.memberships)
                {
                    res.Memberships.Add(new Membership()
                    {
                        MembershipName = record.MembershipName,
                  
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
                        InstituteName = record.InstitutionName,
                        Specialization = record.Stream,
                        PassingYear = record.PassingYear,
                        Marks = record.Marks,
                        University = record.University,
                    });
                }

                foreach (var record in resume.userResumes)
                {
                    res.UserResumes.Add(new UserResume()
                    {
                        UserId = record.UserId,
                        ResumeId = record.ResumeId,
                        UserResumeId = record.UserResumeId,
                    });
                }

                foreach(var record in resume.certifications)
                {
                    res.Certifications.Add(new Certification()
                    {
                        /*CertificationId = record.CertificationId,*/
                        CertificationName = record.CertificationName,
                    });
                }

                foreach(var record in resume.trainings)
                {
                    res.training.Add(new training()
                    {
                        /*TrainingId = record.TrainingId,*/
                        Trainingname = record.Trainingname
                    });
                }

                foreach (var record in resume.reviews)
                {
                    res.ReviewTables.Add(new ReviewTable()
                    {
                        /*ReviewId = record.ReviewId,*/
                        ReviewerId = record.ReviewerId,
                        ReviewComment = record.ReviewComment,
                        ResumeId = record.ResumeId
                    });
                }
                base.Update(res);
                
            }

            

        }

        public List<ResumeDomain> GetResumeBySkills(List<string> skills)
        {
            var result = base.SelectAll().Where(z => z.Skills.Any(y => skills.Any(s => y.SkillName == s))).Select(x => new ResumeDomain()
            {
                ResumeId = x.ResumeId,
                ResumeTitle = x.ResumeTitle,
                ResumeStatus = x.ResumeStatus,
                UpdationDate = x.UpdationDate,
                CreationDate = x.CreationDate,

                SkillList = x.Skills.Select(s => new RMS.Domain.ResumeDomain.SkillsDomain()
                {
                    Category = s.Category,
                    SkillName = s.SkillName,

                }).ToList(),

                aboutMe = x.AboutMes.Select(b => new RMS.Domain.ResumeDomain.AboutMeDomain()
                {
                    KeyPoints = b.KeyPoints,
                    MainDescription = b.MainDescription,
                }).ToList(),

                achivements = x.Achievements.Select(c => new RMS.Domain.ResumeDomain.AchievementsDomain()
                {
                    AchievementName = c.AchievementName,
                }).ToList(),

                memberships = x.Memberships.Select(e => new RMS.Domain.ResumeDomain.MembershipsDomain()
                {
                    MembershipName = e.MembershipName,
                }).ToList(),

                myDetails = x.MyDetails.Select(f => new RMS.Domain.ResumeDomain.MyDetailsDomain()
                {
                    ProfilePicture = f.ProfilePicture,
                    TotalExp = (float)f.TotalExp,
                    UserName = f.Name,
                    Role = f.Role,
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

                educationDetails = x.EducationDetails.Select(d => new RMS.Domain.ResumeDomain.EducationDetailsDomain()
                {
                    EducationalDetailsId = d.EducationId,
                    CourseName = d.CourseName,
                    Stream = d.Specialization,
                    InstitutionName = d.InstituteName,
                    PassingYear = d.PassingYear,
                    Marks = (float)d.Marks,
                    University = d.University,
                }).ToList(),

                //userResumes = x.UserResumes.Select(p => new UserResumeDomain()
                //{
                // UserId = p.UserId,
                // ResumeId = p.ResumeId,
                // UserResumeId = p.UserResumeId,
                //}).ToList(),

                certifications = x.Certifications.Select(p => new CertificationDomain()
                {
                    CertificationId = p.CertificationId,
                    CertificationName = p.CertificationName,
                }).ToList(),

                trainings = x.training.Select(p => new TrainingDomain()
                {
                    TrainingId = p.TrainingId,
                    Trainingname = p.Trainingname
                }).ToList(),

                reviews = x.ReviewTables.Select(a => new ReviewTableDomain()
                {
                    ReviewId = a.ReviewId,
                    ReviewComment = a.ReviewComment,
                    ResumeId = a.ResumeId,
                    ReviewerId = a.ReviewerId,
                }).ToList()

            }).ToList();
            return result;
        }

        public List<ResumeDomain> GetResumeByProjects(List<string> projects)
        {
            var result = base.SelectAll().Where(t => t.WorkExperiences.Any(y => projects.Any(s => y.ProjectName == s))).Select(x => new ResumeDomain()
            {
                ResumeId = x.ResumeId,
                ResumeTitle = x.ResumeTitle,
                ResumeStatus = x.ResumeStatus,
                UpdationDate = x.UpdationDate,
                CreationDate = x.CreationDate,

                SkillList = x.Skills.Select(s => new RMS.Domain.ResumeDomain.SkillsDomain()
                {
                    Category = s.Category,
                    SkillName = s.SkillName,

                }).ToList(),

                aboutMe = x.AboutMes.Select(b => new RMS.Domain.ResumeDomain.AboutMeDomain()
                {
                    KeyPoints = b.KeyPoints,
                    MainDescription = b.MainDescription,
                }).ToList(),

                achivements = x.Achievements.Select(c => new RMS.Domain.ResumeDomain.AchievementsDomain()
                {
                    AchievementName = c.AchievementName,
                }).ToList(),

                memberships = x.Memberships.Select(e => new RMS.Domain.ResumeDomain.MembershipsDomain()
                {
                    MembershipName = e.MembershipName,
                }).ToList(),

                myDetails = x.MyDetails.Select(f => new RMS.Domain.ResumeDomain.MyDetailsDomain()
                {
                    ProfilePicture = f.ProfilePicture,
                    TotalExp = (float)f.TotalExp,
                    UserName = f.Name,
                    Role = f.Role,
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

                educationDetails = x.EducationDetails.Select(d => new RMS.Domain.ResumeDomain.EducationDetailsDomain()
                {
                    EducationalDetailsId = d.EducationId,
                    CourseName = d.CourseName,
                    Stream = d.Specialization,
                    InstitutionName = d.InstituteName,
                    PassingYear = d.PassingYear,
                    Marks = (float)d.Marks,
                    University = d.University,
                }).ToList(),

                //userResumes = x.UserResumes.Select(p => new UserResumeDomain()
                //{
                // UserId = p.UserId,
                // ResumeId = p.ResumeId,
                // UserResumeId = p.UserResumeId,
                //}).ToList(),

                certifications = x.Certifications.Select(p => new CertificationDomain()
                {
                    CertificationId = p.CertificationId,
                    CertificationName = p.CertificationName,
                }).ToList(),

                trainings = x.training.Select(p => new TrainingDomain()
                {
                    TrainingId = p.TrainingId,
                    Trainingname = p.Trainingname
                }).ToList(),

                reviews = x.ReviewTables.Select(a => new ReviewTableDomain()
                {
                    ReviewId = a.ReviewId,
                    ReviewComment = a.ReviewComment,
                    ResumeId = a.ResumeId,
                    ReviewerId = a.ReviewerId,
                }).ToList()

            }).ToList();
            return result;
        }

        public List<ResumeDomain> GetResumeByRoles(List<string> roles)
        {
            var result = base.SelectAll().Where(u => u.WorkExperiences.Any(y => roles.Any(s => y.ProjectRole == s))).Select(x => new ResumeDomain()
            {
                ResumeId = x.ResumeId,
                ResumeTitle = x.ResumeTitle,
                ResumeStatus = x.ResumeStatus,
                UpdationDate = x.UpdationDate,
                CreationDate = x.CreationDate,

                SkillList = x.Skills.Select(s => new RMS.Domain.ResumeDomain.SkillsDomain()
                {
                    Category = s.Category,
                    SkillName = s.SkillName,

                }).ToList(),

                aboutMe = x.AboutMes.Select(b => new RMS.Domain.ResumeDomain.AboutMeDomain()
                {
                    KeyPoints = b.KeyPoints,
                    MainDescription = b.MainDescription,
                }).ToList(),

                achivements = x.Achievements.Select(c => new RMS.Domain.ResumeDomain.AchievementsDomain()
                {
                    AchievementName = c.AchievementName,
                }).ToList(),

                memberships = x.Memberships.Select(e => new RMS.Domain.ResumeDomain.MembershipsDomain()
                {
                    MembershipName = e.MembershipName,
                }).ToList(),

                myDetails = x.MyDetails.Select(f => new RMS.Domain.ResumeDomain.MyDetailsDomain()
                {
                    ProfilePicture = f.ProfilePicture,
                    TotalExp = (float)f.TotalExp,
                    UserName = f.Name,
                    Role = f.Role,
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

                educationDetails = x.EducationDetails.Select(d => new RMS.Domain.ResumeDomain.EducationDetailsDomain()
                {
                    EducationalDetailsId = d.EducationId,
                    CourseName = d.CourseName,
                    Stream = d.Specialization,
                    InstitutionName = d.InstituteName,
                    PassingYear = d.PassingYear,
                    Marks = (float)d.Marks,
                    University = d.University,
                }).ToList(),

                //userResumes = x.UserResumes.Select(p => new UserResumeDomain()
                //{
                // UserId = p.UserId,
                // ResumeId = p.ResumeId,
                // UserResumeId = p.UserResumeId,
                //}).ToList(),

                certifications = x.Certifications.Select(p => new CertificationDomain()
                {
                    CertificationId = p.CertificationId,
                    CertificationName = p.CertificationName,
                }).ToList(),

                trainings = x.training.Select(p => new TrainingDomain()
                {
                    TrainingId = p.TrainingId,
                    Trainingname = p.Trainingname
                }).ToList(),

                reviews = x.ReviewTables.Select(a => new ReviewTableDomain()
                {
                    ReviewId = a.ReviewId,
                    ReviewComment = a.ReviewComment,
                    ResumeId = a.ResumeId,
                    ReviewerId = a.ReviewerId,
                }).ToList()

            }).ToList();
            return result;
        }
    }
}
