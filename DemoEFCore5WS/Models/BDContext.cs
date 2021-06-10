using Microsoft.EntityFrameworkCore;

namespace DemoEFCore5WS.Models
{
    public class BDContext : DbContext
    {
        public BDContext(){}
        public BDContext(DbContextOptions<BDContext> options)
        : base(options)
        {
        }
    }
}