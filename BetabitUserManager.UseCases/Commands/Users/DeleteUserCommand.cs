using BetabitUserManager.Domain;
using MediatR;

namespace BetabitUserManager.UseCases.Commands.Users;

public class DeleteUserCommand : IRequest<Response<User>>
{
    public int Id { get; private set; }

    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}