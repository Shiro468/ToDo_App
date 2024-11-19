using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Interfaces;
using ToDoApp.Models;
namespace ToDoApp.Repository
{
    public class JobsRepository : IJobsRepository
    {
        private readonly ApplicationDbContext _context;

        public JobsRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        
        public bool Add(Jobs jobs)
        {
            _context.Add(jobs);
            return Save();
        }

        public bool Delete(Jobs jobs)
        {
            _context.Remove(jobs);
            return Save();
        }

        public async Task<IEnumerable<Jobs>> GetAll()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Jobs> GetByIdAsync(int id)
        {
            return await _context.Jobs.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Jobs jobs)
        {
            _context.Update(jobs);
            return Save();
        }
    }
}
