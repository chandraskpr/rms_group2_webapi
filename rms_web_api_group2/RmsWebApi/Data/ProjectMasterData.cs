﻿namespace RmsWebApi.Data
{
    public class ProjectMasterData
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
