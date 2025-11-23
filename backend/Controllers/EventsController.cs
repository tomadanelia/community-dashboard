using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<Event>> GetAllEvents()
        {
            List<Event> db = _eventService.GetAllEvents();
            return Ok(db);
        }
        [HttpGet("{id}")]
        public ActionResult<Event> GetEventById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
               
                Event? ev = _eventService.GetEventById(id);
            if (ev == null)
            {
                return NotFound(new {message= "event not found"});

            }
            return Ok(ev);

        }
        [HttpPost]
        public ActionResult<Event> AddEvent(Event ev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created= _eventService.AddEvent(ev);
            return CreatedAtAction(nameof(GetEventById), new { id = created.Id }, created);



        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            
                var deleteFlag=_eventService.DeleteEvent(id);
            if (deleteFlag)
            {
                return NoContent();
            }
            return NotFound(new { message = "event to delete not founf" });
                
        }
        [HttpPut("{id}")]
        public ActionResult<Event> ModifyEvent(int id,Event ev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                var modified= _eventService.ModifyEvent(id, ev);
            if (modified == null) return NotFound(new { message = "not found event to modify" });
            return CreatedAtAction(nameof(GetEventById), new { id = modified.Id }, modified);


        }
    }
}
