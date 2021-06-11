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
                //.AsNoTracking()
                .Include(b => b.Posts)
                .SingleOrDefaultAsync(b => b.Id == id);
            return blog;
        }

        public async Task<Blog> RemoverPorId(int id)
        {
            var blog = await _contexto.Blogs.FindAsync(id);
            if (blog != null)
            {
                _contexto.Blogs.Remove(blog);
                await _contexto.SaveChangesAsync();
            }
            return blog;
        }

        public async Task AdicionarPost(int blogId, Post post)
        {
            var blog = await _contexto.Blogs.FindAsync(blogId);
            if (blog != null)
            {
                blog.Posts.Add(post);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}