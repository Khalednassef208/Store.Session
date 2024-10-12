using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Session.Core.Entities;
using Store.Session.Core.Reposities.Contract;
using Store.Session.Repository.Data.Context;

namespace Store.Session.Repository.Reposities
{
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {

        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async void Delete(TEntity entity)
        {
             _context.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(TEntity) == typeof(Product))
            {
              return (IEnumerable<TEntity>)      await _context.Products.Include(p => p.Brand).Include(p=> p.Type).ToListAsync();
            }
            return await _context.Set<TEntity>().ToListAsync();

        }

        public async Task<TEntity> GetAsync(Tkey id )
        {

            if (typeof(TEntity) == typeof(Product))
            {
                return await _context.Products.Include(p => p.Brand).Include(p => p.Type).FirstOrDefaultAsync(p => p.Id==id as int? ) as TEntity  ;
            }
            return  await _context.Set<TEntity>().FindAsync( id);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
