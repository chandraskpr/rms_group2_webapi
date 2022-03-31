using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class UserNotification
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string NotificationDescription { get; set; } = null!;
        public byte[] CreationDate { get; set; } = null!;
        public string? NotificationState { get; set; }

        public virtual UserInfo User { get; set; } = null!;
    }
}
