using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;

namespace Weather.Infra.Interfaces
{
    public interface IBaseRepository<T> where T: Base
    {
        Task<T> Create(T Obj);
        //Task<T> Update(T Obj);
        Task<T> Get(int Id);
    }
}
