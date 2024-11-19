using ToDoApp.Models;
namespace ToDoApp.Interfaces
{
    public interface IJobsRepository
    {
        Task <IEnumerable<Jobs>> GetAll();

        Task<Jobs> GetByIdAsync(int id);

        bool Add(Jobs jobs);
        bool Update(Jobs jobs);
        bool Delete(Jobs jobs);
        bool Save();

    }
}
