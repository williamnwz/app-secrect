namespace AppSecrect.DataAccess.Repositories
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Repositories;
    public class FriendRepostory : Repository<Friend>, IFriendRepostory
    {
        public FriendRepostory(AppSecrectContext context) : base(context)
        {
        }
    }
}
