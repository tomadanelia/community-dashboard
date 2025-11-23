using Backend.Models;
namespace Backend.Services
{
    public class EventService
    {
        private List<Event> db = new List<Event>
{
    new Event { Id = 1, Name = "Welcome Party", Description = "Nonalcoholic", Date = DateTime.Now },
    new Event { Id = 2, Name = "Halloween Party", Description = "notgood", Date = DateTime.Now.AddDays(1) },
    new Event { Id = 3, Name = "graduation", Description = "notinvited", Date = DateTime.Now.AddDays(2) }
};

        public List<Event> GetAllEvents()=>db;
        
        public Event? GetEventById(int id)
        {
            var ev= db.Find(e => e.Id == id);
            
            return ev;
        }
        public Event AddEvent(Event newevent)
        {
            int newId = db.Count > 0 ? db.Max(e => e.Id) + 1 : 1;
            newevent.Id = newId;
            db.Add(newevent);
            return newevent;
        }
        public bool DeleteEvent(int id)
        {
            var ev = db.Find(e => e.Id == id);
            if (ev != null)
            {
                db.Remove(ev);
                return true;
            }
            else
            {
                return false;
            }

        }
        public Event? ModifyEvent(int id,Event newevent)
        {
            var oldeventindex = db.FindIndex(e => e.Id == id);
            if (oldeventindex == -1)
            {
                return null;
            }
            newevent.Id = id;
            db[oldeventindex] = newevent;
            return newevent;

        }




    }

}