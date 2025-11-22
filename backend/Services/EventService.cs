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

        public List<Event> GetAllEvents()
        {
            return this.db;
        }
        public Event GetEventById(int id)
        {
            var ev= db.Find(e => e.Id == id);
            if (ev!=null){
            return ev;

        }
            throw new Exception("Event not found");
        }
        public void AddEvent(Event newevent)
        {
            if (db.Find(e => e.Id == newevent.Id) != null)
            {
                throw new Exception("Event with the same ID already exists");
            }
            db.Add(newevent);
        }
        public void DeleteEvent(int id)
        {
            var ev = db.Find(e => e.Id == id);
            if (ev != null)
            {
                db.Remove(ev);
            }
            else
            {
                throw new Exception ("Event was never there dumbass");
            }

        }
        public void ModifyEvent(int id,Event newevent)
        {
            var oldeventindex = db.FindIndex(e => e.Id == id);
            if (oldeventindex == -1)
            {
                throw new Exception("no such event in db");
            }
            db[oldeventindex] = newevent;
        }



    }

}