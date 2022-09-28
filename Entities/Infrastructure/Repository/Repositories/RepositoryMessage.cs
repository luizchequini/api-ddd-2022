using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryMessage : RepositoryGenerics<Message>, IMessage
    {

        private readonly DbContextOptions<ContextBase> _ContextOptions;
        public RepositoryMessage()
        {
            _ContextOptions = new DbContextOptions<ContextBase>();
        }
    }
}
