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
            Text = eventEntity.Text;
            EventDate = eventEntity.Date;
        }

        int id;
        string text;
        DateTime date;

        public int Id
        { 
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public DateTime EventDate
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(EventDate));
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
