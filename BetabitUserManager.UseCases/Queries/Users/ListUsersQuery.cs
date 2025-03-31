using BetabitUserManager.Domain;
using MediatR;

namespace BetabitUserManager.UseCases.Queries.Users;

public class ListUsersQuery : IRequest<IEnumerable<User>>
{
}