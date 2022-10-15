using DefineReminder.Entities;
using DefineReminder.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DefineReminder.Services
{
    public class EventDataStore : IDataStore<ReminderEvent>
    {
        public async Task<bool> AddItemAsync(ReminderEvent item)
        {
            EventEntity entity = new EventEntity(item.Id, item.Text, item.EventDate);
            int result = await App.Database.SaveEventAsync(entity);

            return result > 0;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            EventEntity entity = new EventEntity { Id = id };
            int result = await App.Database.DeleteEventAsync(entity);

            return result > 0;
        }

        public async Task<ReminderEvent> GetItemAsync(int id)
        {
            EventEntity eventEntity = await App.Database.GetEventAsync(id);
            
            if (eventEntity == null)
            {
                return null;
            }
            
            return new ReminderEvent(eventEntity);
        }

        public async Task<IEnumerable<ReminderEvent>> GetItemsAsync(bool forceRefresh = false)
        {
            List<EventEntity> eventEntities = await App.Database.GetEventsAsync();
            List<ReminderEvent> reminderEvents = new List<ReminderEvent>();
            
            foreach (var eventEntity in eventEntities)
            {
                // Dates in DB are saved in UTC format
                eventEntity.Date = eventEntity.Date.ToLocalTime();
                reminderEvents.Add(new ReminderEvent(eventEntity));
            }

            return reminderEvents;
        }

        public async Task<bool> UpdateItemAsync(ReminderEvent item)
        {
            EventEntity entity = new EventEntity(item.Id, item.Text, item.EventDate);
            int result = await App.Database.SaveEventAsync(entity);

            return result > 0;
        }
    }
}
