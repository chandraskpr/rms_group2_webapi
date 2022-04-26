using System.ComponentModel.DataAnnotations;
namespace RMS.Data.ResumeData
{
    public class MyDetailsData
    {
        public byte[] ProfilePicture { get; set; }
        public float TotalExp { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
