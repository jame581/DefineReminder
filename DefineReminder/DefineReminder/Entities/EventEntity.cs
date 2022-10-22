using SQLite;
using System;

namespace DefineReminder.Entities
{
    public class EventEntity
    {
        public EventEntity()
        {

        }

        public EventEntity(int id, string name, string description, DateTime date)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
