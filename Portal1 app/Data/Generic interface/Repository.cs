using Data.DbInitializer;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Generic_interface
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public async Task Create(T entity)
        {
            try
            {
                if (entity is T)
                {
                    using (var portalContext = new PortalContext())
                    {
                        await Task.Run(() =>
                        {
                            portalContext.Set<T>().Add(entity);
                            portalContext.SaveChanges();
                        });
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName}");
                        Console.WriteLine($"Error: {validationError.ErrorMessage}");
                    }
                }
            }
        }

        public async Task<T> GetByID(int Id)
        {
            T item = default;
            using (var portalContext = new PortalContext())
            {
                await Task.Run(() =>
                {
                    item = portalContext.Set<T>().FirstOrDefault(x => x.Id == Id);
                    
                });
                return item;
            }
        }

        public async Task<List<T>> GetAll(T entity)
        {
            using (var portalContext = new PortalContext())
            {
                return await portalContext.Set<T>().ToListAsync();
            }
        }

        public async Task Update(int Id, T entity)
        {
            using (var portalContext = new PortalContext())
            {
                var data = portalContext.Set<T>().FirstOrDefault(x => x.Id == Id);
                if (data != null)
                {
                    await Task.Run(() =>
                    {
                        portalContext.Set<T>().AddOrUpdate(entity, data);
                        portalContext.SaveChanges();
                    });
                }

                else
                {
                    Console.WriteLine("Id does not exist");
                }
            }
        }

        public async Task Delete(int Id)
        {
            using (var portalContext = new PortalContext())
            {
                var data = portalContext.Set<T>().FirstOrDefault(x => x.Id == Id);
                if (data != null)
                {
                    await Task.Run(() =>
                    {
                        portalContext.Set<T>().Remove(data);
                        portalContext.SaveChanges();
                    });    
                }
                else
                {
                    Console.WriteLine("Id does not exist");
                }
            }
        }
    }
}
