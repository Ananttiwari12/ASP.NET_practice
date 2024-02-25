using ASP.NET_tut.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_tut.Data.Repository
{
    public class StudentRepository(CollegeDbContext dbContext) : IStudentRepository
    {
        private readonly CollegeDbContext _dbContext = dbContext;

        public async Task<int> CreateStudentAsync(Students student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return student.Id;
        }
        public async Task<bool> DeleteStudentByidAsync(Students student)
        {
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<Students>> GetallAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }
        public async Task<Students> GetByIdAsync(int id, bool asnotracking=false)
        {
            if(!asnotracking)
                return await _dbContext.Students.Where(student=>student.Id==id).FirstOrDefaultAsync();  
            return await _dbContext.Students.AsNoTracking().Where(student=>student.Id==id).FirstOrDefaultAsync();
        }
        public async Task<Students> GetByNameAsync(string name)
        {
            return await _dbContext.Students.Where(student=>student.Name.ToLower().Contains(name.ToLower())).FirstOrDefaultAsync();
        }
        public async Task<int> UpdateStudentAsync(Students student)
        {   
            _dbContext.Update(student);
            await _dbContext.SaveChangesAsync();
            return student.Id;
        }
    }
}