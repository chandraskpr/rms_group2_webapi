﻿using RMS.Data.ResumeData;

using RmsWebApi.Data;
using RmsWebApi.RMS_DB;

namespace RmsWebApi.Repository.Interfaces
{
    public interface IResumeRepository : IBaseRepository<Resume>
    {
        public List<ResumeData> GetAll();

        public ResumeData Create(ResumeData resume);

        public void Delete(int ResumeId);

        public void Update(int ResumeId, ResumeData resume);
        public List<ResumeData> GetNonDraftResume();
        public List<ResumeData> GetResumeBySkills(int skillIds);


    }
}
