using System;
using System.ComponentModel;

namespace DefineReminder.Models
{
    public class ReminderEvent : INotifyPropertyChanged
    {
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
                Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public DateTime Date
        {
            get => date;
            set
            {
                Date = value;
                OnPropertyChanged(nameof(Date));
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
