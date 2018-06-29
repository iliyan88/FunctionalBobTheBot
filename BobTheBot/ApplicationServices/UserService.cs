using BobTheBot.Entities;
using BobTheBot.Kernel;
using BobTheBot.RequestAndResponse;
using RJ.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BobTheBot.ApplicationServices
{
    public class UserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<UserToReply>> GetAsync()
        {
            var users = await unitOfWork.UserToReplyRepository.GetAsync();
            return users;
        }

        public async Task<Result> UpdateAsync(int entityId, UserUpdateRequest request)
        {
            var user = await unitOfWork.UserToReplyRepository.GetByIDAsync(entityId);
            if (user == null)
            {
                return Result.Fail(ErrorType.NotFound, nameof(UserToReply), entityId);
            }

            user.Email = request.Email;
            user.SendEmail = request.SendEmail;
            user.IsActive = request.IsActive;
            await unitOfWork.SaveChangesAsync();
            return Result.Ok();
        }

        public async Task<Result> DeleteAsync(int entityId)
        {
            var user = await unitOfWork.UserToReplyRepository.GetByIDAsync(entityId);
            if (user == null)
            {
                return Result.Fail(ErrorType.NotFound, nameof(UserToReply), entityId);
            }
            unitOfWork.UserToReplyRepository.Delete(user);
            await unitOfWork.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
