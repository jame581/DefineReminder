using DefineReminder.Entities;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DefineReminder.Data
{
    public class EventDatabase
    {
        readonly SQLiteAsyncConnection database;

        public EventDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<EventEntity>().Wait();
        }

        public Task<List<EventEntity>> GetEventsAsync()
        {
            //Get all events.
            return database.Table<EventEntity>().ToListAsync();
        }

        public Task<EventEntity> GetEventAsync(int id)
        {
            // Get a specific event.
            return database.Table<EventEntity>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveEventAsync(EventEntity eventEntity)
        {
            if (eventEntity.Id != 0)
            {
                // Update an existing event.
                return database.UpdateAsync(eventEntity);
            }
            else
            {
                // Save a new event.
                return database.InsertAsync(eventEntity);
            }
        }

        public Task<int> DeleteEventAsync(EventEntity eventEntity)
        {
            // Delete a event.
            return database.DeleteAsync(eventEntity);
        }
    }
}
