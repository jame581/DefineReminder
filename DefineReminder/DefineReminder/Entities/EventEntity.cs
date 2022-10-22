using SQLite;
using System;

namespace DefineReminder.Entities
{
    public class EventEntity
    {
        public EventEntity()
        {

        }

        public EventEntity(int id, string name, string description, DateTime date, int iconType)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            IconType = iconType;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int IconType { get; set; }
    }
}
