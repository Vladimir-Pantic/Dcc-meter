using DccMeter.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DccMeter.Api.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserList> GetUserListAsync(GetUserContext context);

        Task<User> GetUserAsync(int id);

        Task<bool> UserExistsAsync(int id);

        Task<Api.Domain.Models.User> RegisterUserAsync(RegisterUserCommand command);

        Task<bool> ModifyUserAsync(int id, ModifyUserCommand command);

        Task<bool> RemoveUserAsync(int id);
    }
}
 