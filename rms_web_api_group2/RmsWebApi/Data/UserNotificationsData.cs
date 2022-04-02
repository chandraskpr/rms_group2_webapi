﻿namespace RmsWebApi.Data
{
    public class UserNotificationsData
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string NotificationDescription { get; set; } = null!;
        public byte[] CreationDate { get; set; } = null!;
        public string? NotificationState { get; set; }
    }
}