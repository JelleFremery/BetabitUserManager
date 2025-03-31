using BetabitUserManager.Domain;
using BetabitUserManager.UseCases.Repositories;
using MediatR;

namespace BetabitUserManager.UseCases.Queries.Users;

public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, IEnumerable<User>>
{
    private readonly IUserRepository _userRepository;

    public ListUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.ListAsync();
    }
}