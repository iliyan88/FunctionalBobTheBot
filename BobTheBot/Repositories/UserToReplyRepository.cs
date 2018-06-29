using BobTheBot.Entities;
using Microsoft.EntityFrameworkCore;
using RJ.Repository.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BobTheBot.Repositories
{
    public class UserToReplyRepository : SqlServerRepository<UserToReply>, IUserToReplyRepository
    {
        private readonly AppDbContext dbContext;

        public UserToReplyRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IReadOnlyList<UserToReply>> GetActiveUser()
        {
            return await dbContext.UserToReplies.Where(x => x.IsActive).ToListAsync();
        }
    }
}
