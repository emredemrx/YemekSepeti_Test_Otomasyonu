using System.Data.Entity;
using Y_SepetiTest.Entities;

namespace Y_SepetiTest
{
    public class DataContext : DbContext
    {
        public DbSet<TestLog> testLog { get; set; }
    }
}
