using System;
using System.Collections.Generic;
using Nh.Domain;
using Nh.Data;
using Entities = Nh.Data.Entities;
using AutoMapper;
using System.Linq;

namespace Nh.Services.Messages
{
    public class MessagesProvider : IMessagesProvider
    {
        private const string NullErrorMessage = "Message cannot be null.";

        private readonly IRepository<Entities.Message> _msgRepository;
        public MessagesProvider(IRepository<Entities.Message> msgRepository)
        {
            _msgRepository = msgRepository;
            if (!_msgRepository.GetAll().Any())
            {
                var msg = new Message { Id = 1, Text = "Hello World!", UpdatedOn = DateTime.Now };
                _msgRepository.Add(Mapper.Map<Entities.Message>(msg));
            }
        }
        public void Insert(Message entity)
        {
            _msgRepository.Add(Mapper.Map<Entities.Message>(entity));
        }

        public void Delete(Message entity)
        {
            var msg = FindMessage(entity);
            _msgRepository.Delete(msg);
        }

        public Message Get(long id)
        {
            var message = _msgRepository.Get(id);
            return Mapper.Map<Message>(message);
        }

        public IEnumerable<Message> GetAll()
        {
            var messages = _msgRepository.GetAll();
            return Mapper.Map<IEnumerable<Message>>(messages);
        }

        public void Update(Message entity)
        {
            var msg = FindMessage(entity);
            msg.Text = entity.Text;
            msg.UpdatedOn = entity.UpdatedOn;

            _msgRepository.Update(msg);

        }

        private Entities.Message FindMessage(Message entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), NullErrorMessage);
            }
            var msg = _msgRepository.Get(entity.Id);
            if (msg == null)
            {
                throw new KeyNotFoundException($"Cannot find a message with the requested ID {entity.Id}. Update aborted.");
            }

            return msg;
        }
    }
}
