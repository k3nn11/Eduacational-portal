﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Generic_interface
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> GetByID(int id);
        Task Create(T entity);
        Task Update(int Id, T entity);
        Task Delete(int Id);

    }
}
