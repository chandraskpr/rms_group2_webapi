namespace RmsWebApi.Data
{
    public class RoleMasterData
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
