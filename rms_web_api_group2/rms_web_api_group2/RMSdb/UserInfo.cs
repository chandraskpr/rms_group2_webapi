﻿using System;
using System.Collections.Generic;

namespace rms_web_api_group2.RMSdb
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            ReviewTables = new HashSet<ReviewTable>();
            UserNotifications = new HashSet<UserNotification>();
            UserResumes = new HashSet<UserResume>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

        public virtual ICollection<UserNotification> UserNotifications { get; set; }
        public virtual ICollection<UserResume> UserResumes { get; set; }
        public virtual ICollection<ReviewTable> ReviewTables { get; set; }
    }
}
