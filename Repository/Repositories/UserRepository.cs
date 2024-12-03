using Domain.Entities.Models;
using Domain.Interfaces;
namespace Repository.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
}
