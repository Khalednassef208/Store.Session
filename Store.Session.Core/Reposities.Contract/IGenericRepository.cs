﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Session.Core.Entities;

namespace Store.Session.Core.Reposities.Contract
{
    public interface IGenericRepository<TEntity, Tkey> where TEntity:BaseEntity<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Tkey id );
        Task AddAsync (TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
