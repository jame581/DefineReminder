using DefineReminder.Entities;
using System;

namespace DefineReminder.Services
{
    public interface INotificationManager
    {
        event EventHandler NotificationReceived;
        void Initialize();
        void SendNotification(string title, string message, DateTime? notifyTime = null, IconType iconType = IconType.Default);
        void ReceiveNotification(string title, string message);
    }
}
