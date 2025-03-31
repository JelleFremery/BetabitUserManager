using BetabitUserManager.Domain;
using MediatR;

namespace BetabitUserManager.UseCases.Commands.Users;

public class CreateUserCommand : IRequest<User>
{
    public string Name { get; private set; }
    public byte Age { get; private set; }

    public CreateUserCommand(string name, byte age)
    {
        Age = age;
        Name = name;
    }
}