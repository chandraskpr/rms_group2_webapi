﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RmsWebApi.Repository.Interfaces;
using System.Linq;
using RmsWebApi.Data;
using RmsWebApi.Repository;

namespace RmsWebApi.Controllers.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeRepository resumeRepository;

        public ResumeController(IResumeRepository resumeRepository)
        {
            this.resumeRepository = resumeRepository;
        }

        [HttpGet]
        public List<ResumeDomain> Get()
        {
            return this.resumeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ResumeDomain Get(int id)
        {
            return this.resumeRepository.GetAll().FirstOrDefault(x => x.ResumeId == id);
        }

        [HttpGet]
        [Route("GetNonDraftResume")]
        public List<ResumeDomain> GetNonDraftResume()
        {
            return this.resumeRepository.GetNonDraftResume();
        }

        [HttpPost]
        public ResumeDomain Post([FromBody] ResumeDomain value)
        {
            return this.resumeRepository.Create(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.resumeRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ResumeDomain value)
        {
            this.resumeRepository.Update(id, value);
        }

        [HttpPost]
        [Route("GetResumeBySkills")]
        public List<ResumeDomain> GetResumeBySkills([FromBody] List<string> skills)
        {
            return this.resumeRepository.GetResumeBySkills(skills);

        }

        [HttpPost]
        [Route("GetResumeByProjects")]
        public List<ResumeDomain> GetResumeByProjects([FromBody] List<string> projects)
        {
            return this.resumeRepository.GetResumeByProjects(projects);
        }

        [HttpPost]
        [Route("GetResumeByRoles")]
        public List<ResumeDomain> GetResumeByRoles([FromBody] List<string> roles)
        {
            return this.resumeRepository.GetResumeByRoles(roles);
        }
    }
}