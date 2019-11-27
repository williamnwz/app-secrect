namespace AppSecrect.Domain.Services.Interfaces
{
    using System;
    using System.Threading.Tasks;
    public interface IMakeFriendship
    {
        Task NewFriend(Guid me, Guid friend);
    }
}
