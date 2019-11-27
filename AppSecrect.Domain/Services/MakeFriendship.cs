namespace AppSecrect.Domain.Services
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Exceptions;
    using AppSecrect.Domain.Repositories;
    using AppSecrect.Domain.Services.Interfaces;
    using System;
    using System.Threading.Tasks;

    public class MakeFriendship : IMakeFriendship
    {
        private readonly IFriendRepostory friendRepostory;
        private readonly IUserRepository userRepository;

        public MakeFriendship(
            IFriendRepostory friendRepostory,
            IUserRepository userRepository)
        {
            this.friendRepostory = friendRepostory;
            this.userRepository = userRepository;
        }

        public async Task NewFriend(Guid me, Guid friend)
        {
            if (me == Guid.Empty || friend == Guid.Empty)
                throw new DomainException("invalid user or friend");

            User meFound = await this.userRepository.GetUserByIdWithFriends(me);

            if (meFound == null)
                throw new DomainException("invalid user or friend");

            User friendFound = await this.userRepository.GetUserByIdWithFriends(friend);

            if (friendFound == null)
                throw new DomainException("invalid user or friend");

            meFound.MakeFriend(friendFound);


        }
    }
}
