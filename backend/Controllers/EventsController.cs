using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Backend.Services;
namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;
        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public List<Event> GetAllEvents()
        {
            List<Event> db = _eventService.GetAllEvents();
            return db;
        }
        [HttpGet("{id}")]
        public ActionResult<Event> GetEventById(int id)
        {
            try
            {
                Event ev = _eventService.GetEventById(id);
                return Ok(ev);

            }
            catch (Exception ex) {
                return NotFound(ex.Message);

            }

        }
        [HttpPost]
        public ActionResult<Event> AddEvent(Event ev)
        {
            return _eventService.AddEvent(ev);


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            try
            {
                _eventService.DeleteEvent(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Event> ModifyEvent(int id,Event ev)
        {
            try
            {
                return _eventService.ModifyEvent(id, ev);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);

            }

        }
    }
}
