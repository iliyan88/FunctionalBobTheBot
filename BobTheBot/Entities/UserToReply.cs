using RJ.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BobTheBot.Entities
{
    public class UserToReply : Entity<int>
    {
        protected UserToReply()
        {
        }

        protected UserToReply(int id) : base(id)
        {
        }

        public UserToReply(string conversationId, string userId, string userName)
        {
            ConversationId = conversationId;
            UserId = userId;
            UserName = userName;
        }

        public string ConversationId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public bool SendEmail { get; set; }
        public bool IsActive { get; set; }
    }
}
