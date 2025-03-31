using BetabitUserManager.Domain;
using MediatR;

namespace BetabitUserManager.UseCases.Queries.Users;

public class GetUserQuery : IRequest<User>
{
    public int UserId { get; private set; }

    public GetUserQuery(int userId)
    {
        UserId = userId;
    }
}