using ASP.NET_tut.Models;

namespace ASP.NET_tut.Data.Repository
{
    public interface IStudentRepository : ICollegeRepository<Students>
    {
        Task<List<Students>>GetFeeStatusOfStudents(int feeStatus);
    }
    
}