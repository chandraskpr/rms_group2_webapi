using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Data;

public class UserNotificationsData
{
    [Key]
    public int NotificationId { get; set; }
    public int UserId { get; set; }
    public string NotificationDescription { get; set; } = null!;
    public byte[] CreationDate { get; set; } = null!;
    public string? NotificationState { get; set; }




}

