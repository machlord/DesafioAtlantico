using System.Threading.Tasks;

namespace api.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }
    }
}