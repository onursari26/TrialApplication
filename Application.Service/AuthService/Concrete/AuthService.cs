using Application.Core.Interfaces;
using Application.Data.Entities.Concrete;
using Application.Dto.Concrete;
using Application.Dto.Response;
using Application.Security.ApiCode.Interfaces;
using Application.Service.AuthService.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Service.AuthService.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _uow;
        private readonly IApiCodeHelper _apiCodeHelper;
        public AuthService(IUnitOfWork uow, IApiCodeHelper apiCodeHelper)
        {
            _uow = uow;
            _apiCodeHelper = apiCodeHelper;
        }

        public async Task<ResponseInfo<UserDto>> CreateApiCode(ResponseInfo<UserDto> user)
        {
            var session = await _uow.Repository<ApiSession>().FindAsync(x => x.PackageEndDate >= DateTime.UtcNow && x.UserId == user.Data.UserId);
            if (session == null)
                session = await AddApiSession(user.Data.UserId);

            user.Data.ApiCode = session.ApiCode;
            user.Data.PackageEndDate = session.PackageEndDate;

            return user;
        }


        private async Task<ApiSession> AddApiSession(int userId)
        {
            var session = await _uow.Repository<ApiSession>().AddAsync(new ApiSession
            {
                UserId = userId,
                ApiCode = Guid.NewGuid().ToString(),
                PackageEndDate = DateTime.Now.AddMinutes(_apiCodeHelper.GetApiCodeOptions().AccessTokenExpiration)
            });

            await _uow.SaveChangesAsync();

            return session;
        }
    }
}
