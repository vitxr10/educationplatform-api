using AutoMapper;
using EducationPlatform.Application.Common;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Repositories;
using MediatR;

namespace EducationPlatform.Application.Queries.UserQueries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ServiceResult<List<UserViewModel>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(request.StringQuery);

            var usersViewModel = _mapper.Map<List<UserViewModel>>(users);

            return ServiceResult<List<UserViewModel>>.Success(usersViewModel);
        }
    }
}
