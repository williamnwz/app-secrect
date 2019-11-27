using System;
using System.Collections.Generic;
using System.Text;

namespace AppSecrect.Domain.Entities
{
    public class Friend : Entity
    {
        protected Friend()
        {

        }
        public Friend(User me, User friend)
        {
            this.FriendId = friend.Id;
            this.FriendUser = friend;
            this.MeId = me.Id;
            this.Me = me;
        }

        public Guid MeId { get; protected set; }
        public User Me { get; protected set; }
        public Guid FriendId { get; protected set; }
        public User FriendUser { get; protected set; }
    }
}
