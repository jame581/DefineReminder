using SQLite;
using System;

namespace DefineReminder.Entities
{
    public class EventEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
