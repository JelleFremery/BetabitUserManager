using BetabitUserManager.Domain;
using BetabitUserManager.UseCases.Repositories;
using MediatR;

namespace BetabitUserManager.UseCases.Commands.Users;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<User>>
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.FindByIdAsync(request.Id);

        if (user == null)
        {
            return new Response<User>("User not found");
        }

        _repository.Delete(user);
        await _unitOfWork.CompleteAsync();

        return new Response<User>(user);
    }
}