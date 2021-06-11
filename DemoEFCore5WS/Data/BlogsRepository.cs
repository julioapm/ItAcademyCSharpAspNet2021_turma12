using DemoEFCore5WS.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCore5WS.Data
{
    public class BlogsRepository
    {
        private readonly BDContext _contexto;
        public BlogsRepository(BDContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Blog> BuscarPorId(int id)
        {
            var blog = await _contexto.Blogs
                .Include(b => b.Posts)
                .SingleOrDefaultAsync(b => b.Id == id);
            return blog;
        }
    }
}