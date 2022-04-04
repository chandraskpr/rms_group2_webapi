﻿using RmsWebApi.Data;
using RmsWebApi.RMS_DB;



namespace RmsWebApi.Repository.Interfaces
{
    public interface IResumeRepository : IBaseRepository<Resume>
    {
        public List<ResumeDomain> GetAll();



        public void Create(ResumeDomain resume);



        public void Delete(int ResumeId);



        public void Update(int ResumeId, ResumeDomain resume);
    }
}