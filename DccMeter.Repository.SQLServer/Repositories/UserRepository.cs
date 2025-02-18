using DccMeter.Repository.SQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DccMeter.Api.Domain.Models;
using DccMeter.Api.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DccMeter.Repository.SQLServer
{
    public class UserRepository : IUserRepository
    {
        private readonly DccMeterContext _context;

        public UserRepository(DccMeterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns list of users
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<UserList> GetUserListAsync([FromQuery]GetUserContext context)
        {
            
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            IQueryable<DccMeter.Repository.SQLServer.Models.User> query = _context.Users.AsQueryable();

            if (context.Idx != null)
            {
                query = query.Where(u => u.Idx == context.Idx);
            }

            if (context.Eid != null)
            {
                query = query.Where(u => u.Eid == context.Eid);
            }


            if (context.UserName.IsNotNullOrEmpty())
            {
                query = query.Where(u => u.UserName.ToLower().StartsWith(context.UserName.ToLower()));
            }

            if (context.UserEmail.IsNotNullOrEmpty())
            {
                query = query.Where(u => u.UserEmail.ToLower().StartsWith(context.UserEmail.ToLower()));
            }

            int totalCount = await query.CountAsync();

            if (context.SortBy == null)
            {
                context.SortBy = UserSortingOption.Idx;
            }

            query = query.ApplySorting(context.SortBy.Value.ToString(), context.SortDirection);

            int? pageSize = context.PageSize;
            int? pageNumber = context.PageNumber;

            query = query.ApplyPaging(ref pageSize, ref pageNumber);

            var result = await query.ToListAsync();

            var list = new UserList
            {
                Items = Mapper.Map<IEnumerable<Api.Domain.Models.User>>(result),
                TotalCount = totalCount
            };

            list.SetPagingInfo(totalCount, pageSize.HasValue ? pageSize.Value : 0, pageNumber.Value);

            return list;

        }

        /// <summary>
        /// Returns a single user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Api.Domain.Models.User> GetUserAsync(int id)
        {
            var item = await _context.Users.SingleOrDefaultAsync(u => u.Idx == id);

            return Mapper.Map<Api.Domain.Models.User>(item); 
        }

        /// <summary>
        /// UserExistsAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UserExistsAsync(int id)
        {
            var query = _context.Users.Where(u => u.Idx == id);

            var item = await query.FirstOrDefaultAsync();

            return item != null;
        }


        /// <summary>
        /// RegisterUserAsync
        /// </summary>
        /// <returns></returns>
        public async Task<Api.Domain.Models.User> RegisterUserAsync(RegisterUserCommand command)
        {
            var item = new Models.User()
            {
                Eid = command.Eid,
                UserName = command.UserName,
                UserEmail = command.UserEmail,
                UserTeamId = command.UserTeamId,
               

            };

            _context.Users.Add(item);

            if (await _context.SaveChangesAsync() > 0)
            {
                return await GetUserAsync(item.Idx);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ModifyUserAsync
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> ModifyUserAsync(int id, ModifyUserCommand command)
        {
            var query = _context.Users.Where(u => u.Idx == id);

            var item = await query.FirstOrDefaultAsync();

            if (item == null) 
                return false;

            item.Eid = command.Eid;
            item.UserName = command.UserName;
            item.UserEmail = command.UserEmail;
            item.UserTeamId = command.UserTeamId;

            if (!_context.ChangeTracker.HasChanges())
                return true;

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> RemoveUserAsync(int id)
        {
            var query = _context.Users.Where(u => u.Idx == id);

            var item = await query.FirstOrDefaultAsync();

            if (item == null) 
                return false;

            _context.Remove(item);

            return await _context.SaveChangesAsync() > 0;
        }

    }
}
