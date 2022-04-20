using System;
using System.Collections.Generic;



namespace RmsWebApi.Data
{
    public class SkillsMasterData
    {
        public int SkillsId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillCategory { get; set; }
        public bool? IsDeleted { get; set; }
    }
}