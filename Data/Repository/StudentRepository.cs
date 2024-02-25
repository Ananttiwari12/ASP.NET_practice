using ASP.NET_tut.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_tut.Data.Repository
{
    public class StudentRepository(CollegeDbContext dbContext) : CollegeRepository<Students>(dbContext),IStudentRepository
    {
        private readonly CollegeDbContext _dbContext = dbContext;
        public Task<List<Students>> GetFeeStatusOfStudents(int feeStatus)
        {
            return null;// write methods
        }
    }
}