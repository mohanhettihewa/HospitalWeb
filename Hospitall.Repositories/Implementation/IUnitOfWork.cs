using Hospitall.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Repositories.Implementation
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository <T>() where T : class;

        void Save();

    }
}
