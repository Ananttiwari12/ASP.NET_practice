using System.Linq.Expressions;
using ASP.NET_tut.Models;

namespace ASP.NET_tut.Data.Repository
{
    public interface ICollegeRepository<T>
    {
        Task<List<T>>GetallAsync();
        Task<T> GetAsync(Expression<Func<T,bool>>filter, bool asnotracking=false);
        Task<bool> DeleteStudentByidAsync(T dbRecord);
        Task<T> CreateStudentAsync(T dbRecord);
        Task<T> UpdateStudentAsync(T dbRecord);
    }
    
}