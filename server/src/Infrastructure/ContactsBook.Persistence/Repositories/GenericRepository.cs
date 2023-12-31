﻿using Microsoft.EntityFrameworkCore;
using ContactsBook.Domain;
using ContactsBook.Persistence.DatabaseContext;
using ContactsBook.Domain.Interfaces;

namespace ContactsBook.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        protected readonly ContactsBookDatabaseContext _context;

        protected DbSet<T> Set => _context.Set<T>();

        public GenericRepository(ContactsBookDatabaseContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _context.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
