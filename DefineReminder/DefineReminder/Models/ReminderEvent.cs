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
            IconType = (IconType)eventEntity.IconType;
        }

        int id;
        string name;
        string description;
        DateTime eventDate;
        TimeSpan eventTime;
        IconType iconType = IconType.Default;

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

        public string EventImageUrl
        {
            get
            {
                switch (IconType)
                {
                    case IconType.Sport:
                        return "sport_event.png";
                    case IconType.Party:
                        return "party_event.png";
                    case IconType.Meeting:
                        return "meeting_event.png";
                    case IconType.Default:
                    default:
                        return "default_event.png";
                }
            }
        }

        public IconType IconType
        {
            get => iconType;
            set
            {
                iconType = value;
                OnPropertyChanged(nameof(IconType));
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
