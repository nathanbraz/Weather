using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;
using Weather.Infra.Context;
using Weather.Infra.Interfaces;

namespace Weather.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly WeatherContext context;

        public BaseRepository(WeatherContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> Create(T Obj)
        {
            context.Add(Obj);
            await context.SaveChangesAsync();

            return Obj;
        }
    }
}
