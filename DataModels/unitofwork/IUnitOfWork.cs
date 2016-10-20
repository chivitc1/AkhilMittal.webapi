using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Repositories;

namespace DataModels.unitofwork
{
    public interface IUnitOfWork
    {
        GenericRepository<User> UserRepository { get; }
        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<Token> TokenRepository { get; }
        void Save();
    }
}
