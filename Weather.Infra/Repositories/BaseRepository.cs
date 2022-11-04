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

        public virtual async Task<T> Get(int Id)
        {
            var obj = await context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == Id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        //public virtual async Task<T> Update(T Obj)
        //{
        //    context.Entry(Obj).State = EntityState.Modified;
        //    await context.SaveChangesAsync();

        //    return Obj;
        //}
    }
}
