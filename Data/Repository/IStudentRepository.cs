using ASP.NET_tut.Models;

namespace ASP.NET_tut.Data.Repository
{
    public interface IStudentRepository
    {
        Task<List<Students>>GetallAsync();
        Task<Students> GetByIdAsync(int id, bool asnotracking=false);
        Task<Students> GetByNameAsync(string name);
        Task<bool> DeleteStudentByidAsync(Students student);
        Task<int> CreateStudentAsync(Students student);
        Task<int> UpdateStudentAsync(Students student);
    }
    
}