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

        public List<ResumeData> GetAll()
        {
            var records = base.SelectAll().Select(x => new ResumeData()
            {
                ResumeId = x.ResumeId,
                ResumeTitle = x.ResumeTitle,
                ResumeStatus = x.ResumeStatus,
                UpdationDate = x.UpdationDate,
                CreationDate = x.CreationDate,

                SkillList = x.Skills.Select(a => new RMS.Domain.ResumeDomain.SkillsData()
                {
                    Category = a.Category,
                }
                ).ToList(),

                aboutMe = x.AboutMes.Select(b => new RMS.Domain.ResumeDomain.AboutMeData()
                {
                    KeyPoints = b.KeyPoints,
                    MainDescription = b.MainDescription,
                }
                ).ToList(),

                achivements = x.Achievements.Select(c => new RMS.Domain.ResumeDomain.AchievementsData()
                {
                    AchievementName = c.AchievementName,
                    AchievementYear = c.AchievementYear,
                    AchievementDescription = c.AchievementDesc,
                }
                ).ToList(),

                educationDetails = x.EducationDetails.Select(d => new RMS.Domain.ResumeDomain.EducationDetailsData()
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

                memberships = x.Memberships.Select(e => new RMS.Domain.ResumeDomain.MembershipsData()
                {
                    MembershipName = e.MembershipName,
                    MembershipDescription = e.MembershipDesc,
                }
                ).ToList(),

                myDetails = x.MyDetails.Select(f => new RMS.Domain.ResumeDomain.MyDetailsData()
                {
                    ProfilePicture = f.ProfilePicture,
                    TotalExp = (float)f.TotalExp,
                    UserName = f.UserName,
                    Role = f.Role,
                }
                ).ToList(),

                workExperience = x.WorkExperiences.Select(g => new RMS.Domain.ResumeDomain.WorkExperienceData()
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

            }).ToList();
            return records;
        }

        public ResumeData Create(ResumeData resume)
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
                }
                );
            };
            foreach (var record in resume.aboutMe)
            {
                res.AboutMes.Add(new AboutMe()
                {
                    MainDescription = record.MainDescription,
                    KeyPoints = record.KeyPoints,
                }
                );
            }

            foreach (var records in resume.myDetails)
            {
                res.MyDetails.Add(new MyDetail()
                {
                    ProfilePicture = records.ProfilePicture,
                    TotalExp = records.TotalExp,
                    UserName = records.UserName,
                    Role = records.Role,
                }
                );
            }

            foreach (var records in resume.achivements)
            {
                res.Achievements.Add(new Achievement()
                {
                    AchievementName = records.AchievementName,
                    AchievementYear = records.AchievementYear,
                    AchievementDesc = records.AchievementDescription,
                }
                );
            }

            foreach (var records in resume.memberships)
            {
                res.Memberships.Add(new Membership()
                {
                    MembershipName = records.MembershipName,
                    MembershipDesc = records.MembershipDescription,
                }
                );
            }

            foreach (var records in resume.workExperience)
            {
                res.WorkExperiences.Add(new WorkExperience()
                {
                    ClientDescription = records.ClientDescription,
                    Country = records.Country,
                    ProjectName = records.ProjectName,
                    ProjectResponsibilities = records.ProjectResponsibilities,
                    ProjectRole = records.ProjectRole,
                    BusinessSolution = records.BusinessSolution,
                    StartDate = records.StartDate,
                    EndDate = records.EndDate,
                    TechnologyStack = records.TechnologyStack,
                }
                );
            }

            foreach (var records in resume.educationDetails)
            {
                res.EducationDetails.Add(new EducationDetail()
                {
                    CourseName = records.CourseName,
                    InstituteName = records.InstitutionName,
                    Specialization = records.Stream,
                    PassingYear = records.PassingYear,
                    Marks = records.Marks,
                    University = records.University,
                }
                );
            }

            var response = base.Create(res);
            if (response != null)
            {
                return new ResumeData()
                {
                    ResumeId = response.ResumeId,
                    ResumeStatus = response.ResumeStatus,
                };
            }
            return null;

        }


        public void Delete(int ResumeId)
        {

            var res = this.entitySet
                .Include(x => x.MyDetails)
                .Include(x => x.Memberships)
                .Include(x => x.AboutMes)
                .Include(x => x.Achievements)
                .Include(x => x.EducationDetails)
                .Include(x => x.UserResumes)
                .Include(x => x.Skills)
                .Include(x => x.WorkExperiences)
                .FirstOrDefault(x => x.ResumeId == ResumeId);

            //var res = base.SelectAll().FirstOrDefault(x => x.ResumeId == ResumeId);

            //context.AboutMes.RemoveRange(res.AboutMes);
            //context.Memberships.RemoveRange(res.Memberships);
            //context.MyDetails.RemoveRange(res.MyDetails);
            //context.Achievements.RemoveRange(res.Achievements);
            //context.EducationDetails.RemoveRange(res.EducationDetails);
            //context.Skills.RemoveRange(res.Skills);
            //context.WorkExperiences.RemoveRange(res.WorkExperiences);

            if (res != null)
            {
                base.Delete(res);
            }

        }

        public void Update(int ResumeId, ResumeData resume)
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
                    }
                    );
                }

                foreach (var record in resume.aboutMe)
                {
                    res.AboutMes.Add(new AboutMe()
                    {
                        MainDescription = record.MainDescription,
                        KeyPoints = record.KeyPoints,
                    }
                    );
                }

                foreach (var records in resume.myDetails)
                {
                    res.MyDetails.Add(new MyDetail()
                    {
                        ProfilePicture = records.ProfilePicture,
                        TotalExp = records.TotalExp,
                    }
                    );
                }

                foreach (var records in resume.achivements)
                {
                    res.Achievements.Add(new Achievement()
                    {
                        AchievementName = records.AchievementName,
                        AchievementYear = records.AchievementYear,
                        AchievementDesc = records.AchievementDescription,
                    }
                    );
                }

                foreach (var records in resume.memberships)
                {
                    res.Memberships.Add(new Membership()
                    {
                        MembershipName = records.MembershipName,
                        MembershipDesc = records.MembershipDescription,
                    }
                    );
                }

                foreach (var records in resume.workExperience)
                {
                    res.WorkExperiences.Add(new WorkExperience()
                    {
                        ClientDescription = records.ClientDescription,
                        Country = records.Country,
                        ProjectName = records.ProjectName,
                        ProjectResponsibilities = records.ProjectResponsibilities,
                        ProjectRole = records.ProjectRole,
                        BusinessSolution = records.BusinessSolution,
                        StartDate = records.StartDate,
                        EndDate = records.EndDate,
                        TechnologyStack = records.TechnologyStack,
                    }
                    );
                }

                foreach (var records in resume.educationDetails)
                {
                    res.EducationDetails.Add(new EducationDetail()
                    {
                        CourseName = records.CourseName,
                        InstituteName = records.InstitutionName,
                        Specialization = records.Stream,
                        PassingYear = records.PassingYear,
                        Marks = records.Marks,
                        University = records.University,
                    }
                    );
                }

                base.Update(res);

            }

        }
    }
}