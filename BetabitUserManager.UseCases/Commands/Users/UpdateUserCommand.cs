using BetabitUserManager.Domain;
using MediatR;

namespace BetabitUserManager.UseCases.Commands.Users;

public class UpdateUserCommand : IRequest<Response<User>>
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public byte Age { get; private set; }

    public UpdateUserCommand(int id, string name, byte age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

}