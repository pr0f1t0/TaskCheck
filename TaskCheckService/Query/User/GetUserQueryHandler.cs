using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskCheckService.Query.Dto;
using TaskCheckStorage.Repository;
using Entity = TaskCheckStorage.Entities;

namespace TaskCheckService.Query.User
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, Entity.User>
    {
        private readonly IUserRepository userRepository;
        private readonly UserDto userDto;

        public GetUserQueryHandler(IUserRepository userRepository, UserDto userDto)
        {
            this.userRepository = userRepository;
            this.userDto = userDto;
        }

        public Entity.User Handle(GetUserQuery query)
        {
            return userRepository.LoginUser(userDto.Username, userDto.Password);
        }
    }
}
