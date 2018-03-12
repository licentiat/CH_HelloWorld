using Nh.Domain;
using System.Collections.Generic;

namespace Nh.Services.Messages
{
    public interface IMessagesProvider
    {
        void Insert(Message entity);
        IEnumerable<Message> GetAll();
        Message Get(long id);
        void Delete(Message entity);
        void Update(Message entity);
    }
}
