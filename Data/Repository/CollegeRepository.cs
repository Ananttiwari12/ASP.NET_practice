using System.Linq.Expressions;
using ASP.NET_tut.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_tut.Data.Repository
{
    public class CollegeRepository<T>(CollegeDbContext dbContext):ICollegeRepository<T> where T : class
    {
        private readonly CollegeDbContext _dbContext = dbContext;
        private DbSet<T> _dbSet= dbContext.Set<T>();

        public async Task<T> CreateStudentAsync(T dbRecord)
        {
            _dbSet.Add(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }
        public async Task<bool> DeleteStudentByidAsync(T dbRecord)
        {
            _dbSet.Remove(dbRecord);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<T>> GetallAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T,bool>>filter, bool asnotracking=false)
        {
            if(!asnotracking)
                return await _dbSet.Where(filter).FirstOrDefaultAsync();  
            return await _dbSet.AsNoTracking().Where(filter).FirstOrDefaultAsync();
        }
        public async Task<T> GetByNameAsync(Expression<Func<T,bool>>filter)
        {
            return await _dbSet.Where(filter).FirstOrDefaultAsync();
        }
        public async Task<T> UpdateStudentAsync(T dbRecord)
        {   
            _dbContext.Update(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }
    }
}