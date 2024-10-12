using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Session.Core.Entities;
using Store.Session.Core.Reposities.Contract;
using Store.Session.Repository.Data.Context;

namespace Store.Session.Repository.Reposities
{
    public class UnitOfWork : IUnitOfWork
    {

        private Hashtable _repository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _repository = new Hashtable();
        }
        public async Task<int> CompleteAsync()
        {
            return await  _context.SaveChangesAsync();

        }

        public  IGenericRepository<TEntity, Tkey> Repository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {

        var type =     typeof(TEntity).Name;
            if (!_repository.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity, Tkey>(_context);
                _repository.Add(type, repository);
            }

         return _repository[type]  as IGenericRepository<TEntity, Tkey>;
        }
    }
}
