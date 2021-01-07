using Microsoft.EntityFrameworkCore;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Data.Context;
using SkillsCore.Shared.Models;
using System;

namespace SkillsCore.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly SkillsContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(SkillsContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
            _context.SaveChanges();
        }

        public T Find(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T obj)
        {
            _dbSet.Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _dbSet.Update(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
