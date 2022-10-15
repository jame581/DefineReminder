using SQLite;
using System;

namespace DefineReminder.Entities
{
    public class EventEntity
    {
        public EventEntity()
        {

        }

        public EventEntity(int id, string text, DateTime date)
        {
            Id = id;
            Text = text;
            Date = date;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
