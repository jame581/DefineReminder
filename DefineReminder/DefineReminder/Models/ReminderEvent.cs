using DefineReminder.Entities;
using System;
using System.ComponentModel;

namespace DefineReminder.Models
{
    public class ReminderEvent : INotifyPropertyChanged
    {
        public ReminderEvent()
        {

        }

        public ReminderEvent(EventEntity eventEntity)
        {
            Id = eventEntity.Id;
            Name = eventEntity.Name;
            Description = eventEntity.Description;
            EventDate = eventEntity.Date;
        }

        int id;
        string name;
        string description;
        DateTime eventDate;
        TimeSpan eventTime;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public DateTime EventDate
        {
            get => eventDate;
            set
            {
                eventDate = value;
                OnPropertyChanged(nameof(EventDate));
            }
        }

        public TimeSpan EventTime
        {
            get => eventTime;
            set
            {
                eventTime = value;
                OnPropertyChanged(nameof(EventTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
