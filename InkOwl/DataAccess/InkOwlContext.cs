using Microsoft.EntityFrameworkCore;

namespace InkOwl.DataAccess
{
    public class InkOwlContext : DbContext
    {


        public InkOwlContext(DbContextOptions<InkOwlContext> options) : base(options)
        {

        }
    }
}
