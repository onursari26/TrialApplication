using AutoMapper;
using MediatR;
using Application.Core.Interfaces;
using Application.Data.Entities.Concrete;
using Application.Dto.Concrete;
using Application.Dto.Response;
using Application.Service.AuthService.Commands.Command;
using Application.Utility.Hashing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Service.AuthService.Commands.Handler
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ResponseInfo<UserDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserLoginCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ResponseInfo<UserDto>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            ResponseInfo<UserDto> result = new ResponseInfo<UserDto>();

            var user = await _uow.Repository<User>().FindAsync(x => x.Username == request.Username);

            if (user == null)
            {
                result.ErrorMessage = request.Username + " kullanıcı adı bulunamadı.";
                return result;
            }

            if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                result.ErrorMessage = "Hatalı şifre.";
                return result;
            }

            result.Response = _mapper.Map<UserDto>(user);

            return result;
        }

    }
}
