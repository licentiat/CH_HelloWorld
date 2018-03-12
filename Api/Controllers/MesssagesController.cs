using Microsoft.AspNetCore.Mvc;
using Nh.Domain;
using Nh.Services.Messages;
using System.Collections.Generic;

namespace Nh.Api.Controllers
{
    [Route("api/[controller]")]
    public class MesssagesController : Controller
    {
        private readonly IMessagesProvider _msgProvider;
        public MesssagesController(IMessagesProvider messagesProvider)
        {
            _msgProvider = messagesProvider;
        }


        // GET api/messages
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            var messages = _msgProvider.GetAll();
            return messages;
        }

        // GET api/messages/7
        [HttpGet("{id}", Name = "GetMessage")]
        public IActionResult GetById(int id)
        {
            var item = _msgProvider.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/messages
        [HttpPost]
        [ProducesResponseType(typeof(Message), 201)] // Created
        [ProducesResponseType(typeof(Message), 400)] // BadRequest
        public IActionResult Create([FromBody]Message item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _msgProvider.Insert(item);

            return CreatedAtRoute("GetMessage", new { id = item.Id }, item);
        }

        // PUT api/messages/7
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Message), 204)] // NoContent
        [ProducesResponseType(typeof(Message), 400)] // BadRequest
        [ProducesResponseType(typeof(Message), 404)] // NotFound
        public IActionResult Update(long id, [FromBody] Message item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var msg = _msgProvider.Get(id);
            if (msg == null)
            {
                return NotFound();
            }
            msg.Text = item.Text;
            msg.UpdatedOn = item.UpdatedOn;

            _msgProvider.Update(msg);
            return new NoContentResult();
        }

        // DELETE api/messages/7
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Message), 204)] // NoContent
        [ProducesResponseType(typeof(Message), 404)] // NotFound

        public IActionResult Delete(int id)
        {
            var msg = _msgProvider.Get(id);
            if (msg == null)
            {
                return NotFound();
            }

            _msgProvider.Delete(msg);
            return new NoContentResult();
        }
    }
}
